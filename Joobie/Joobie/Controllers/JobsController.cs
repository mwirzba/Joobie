using Joobie.Models.JobModels;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joobie.Controllers
{
    public class JobsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ListAsync(string searchString,string citySearchString,int[] categories)
        {
            var listOfProperties = await _unitOfWork.Jobs.GetListsOfPropertiesAsync();
            ViewData["Categories"] = listOfProperties.Categories;
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentCityFilter"] = citySearchString;
            IEnumerable<Job> jobs = await GetSortedAndFilteredJobList(searchString, citySearchString,new List<int>(categories));
            return View("List", jobs);
        }

        public async Task<IActionResult> EditAsync(long id)
        {
            var jobInDb = await _unitOfWork.Jobs.GetJobWithAllPropertiesAsync(id);
            var listOfProperties = await _unitOfWork.Jobs.GetListsOfPropertiesAsync();
            var jobFormInfo = new JobFormViewModel
            {
                Job = jobInDb,
                Categories = listOfProperties.Categories,
                WorkingHours = listOfProperties.WorkingHours,
                TypesOfContract = listOfProperties.TypesOfContract
            };

            return View("JobForm", jobFormInfo);
        }

        public async Task<IActionResult> DeleteAsync(long id)
        {
            var jobInDb = await _unitOfWork.Jobs.GetJobWithAllPropertiesAsync(id);
            var listOfProperties = await _unitOfWork.Jobs.GetListsOfPropertiesAsync();

            var jobFormInfo = new JobFormViewModel
            {
                Job = jobInDb,
                Categories = listOfProperties.Categories,
                WorkingHours = listOfProperties.WorkingHours,
                TypesOfContract = listOfProperties.TypesOfContract
            };
            return View("DeleteJobForm", jobFormInfo);
        }

        [HttpPost, ActionName("DeleteAsync")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(Job job)
        {
            var jobInDb = await _unitOfWork.Jobs.GetJobWithAllPropertiesAsync(job.Id);
            _unitOfWork.Jobs.Remove(jobInDb);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("list");
        }

        public async Task<IActionResult> CreateAsync()
        {
            var listOfProperties = await _unitOfWork.Jobs.GetListsOfPropertiesAsync();
            var jobFormInfo = new JobFormViewModel
            {
                Job = new Job(),
                Categories = listOfProperties.Categories,
                WorkingHours = listOfProperties.WorkingHours,
                TypesOfContract = listOfProperties.TypesOfContract
            };
            return View("JobForm", jobFormInfo);
        }

        public async Task<IActionResult> SaveAsync(Job job)
        {
            var jobInDb = await _unitOfWork.Jobs.GetJobWithAllPropertiesAsync(job.Id);
            if (jobInDb != null)
            {
                jobInDb.Name = job.Name;
                jobInDb.Localization = job.Localization;
                jobInDb.Salary = job.Salary;
                jobInDb.Description = job.Description;
                jobInDb.AddedDate = job.AddedDate;
                jobInDb.ExpirationDate = job.ExpirationDate;
                if (job.CategoryId != 0)
                    jobInDb.CategoryId = job.CategoryId;
                if (job.TypeOfContractId != 0)
                    jobInDb.TypeOfContractId = job.TypeOfContractId;
                if (job.WorkingHoursId != 0)
                    jobInDb.WorkingHoursId = job.WorkingHoursId;
                 await GetOrCreateIfNullCompanyJob(job);
                jobInDb.CompanyId = job.CompanyId;
            }
            else
            {              
                await GetOrCreateIfNullCompanyJob(job);
                await _unitOfWork.Jobs.AddAsync(job);
            }
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("list");
        }

        private async Task GetOrCreateIfNullCompanyJob(Job job)
        {
            var findJobResult = await _unitOfWork.Companies.SingleOrDefaultAsync(c => c.Name == job.Company.Name);
            if (findJobResult == null)
            {
                await _unitOfWork.Companies.AddAsync(job.Company);
                await _unitOfWork.CompleteAsync();
                findJobResult = await _unitOfWork.Companies.SingleOrDefaultAsync(c => c.Name == job.Company.Name);
            }
            job.CompanyId = findJobResult.Id; 
        }


        //has to be changed  - too many options and posible situations???
        private async Task<IEnumerable<Job>> GetSortedAndFilteredJobList(string jobNameSearchString, string citySearchString,List<int> categories)
        {
            IEnumerable<Job> jobs = null;
            System.Linq.Expressions.Expression<Func<Job, bool>> predicate = null;
            if (!string.IsNullOrEmpty(jobNameSearchString) && !string.IsNullOrEmpty(citySearchString) && categories.Count > 0)
            {
                predicate = j => j.Name.Contains(jobNameSearchString) 
                    && j.Localization.Contains(citySearchString) 
                    && categories.Contains(j.CategoryId);
            }
            else if (!string.IsNullOrEmpty(jobNameSearchString) && !string.IsNullOrEmpty(citySearchString))
            {
                 predicate = j => j.Name.Contains(jobNameSearchString)
                        && j.Localization.Contains(citySearchString);
            }
            else if (!string.IsNullOrEmpty(jobNameSearchString) && categories.Count > 0)
            {
                predicate = j => j.Name.Contains(jobNameSearchString)
                       && categories.Contains(j.CategoryId);
            }
            else if (!string.IsNullOrEmpty(jobNameSearchString))
            {
                predicate = j => j.Name.Contains(jobNameSearchString);
            }
            else if (!string.IsNullOrEmpty(citySearchString))
            {
                predicate = j => j.Localization.Contains(citySearchString);
            }
            else if (categories.Count > 0)
            {
                predicate = j => categories.Contains(j.CategoryId);
            }
            else
            {
                predicate = j => !string.IsNullOrEmpty(j.Name);
            }
            jobs = await _unitOfWork.Jobs.GetJobsWithAllPropertiesByFilterAsync(predicate);
            return jobs;
        }

    }
}
