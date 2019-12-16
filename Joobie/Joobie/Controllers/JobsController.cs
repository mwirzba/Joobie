using Joobie.Models.JobModels;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Repositories;
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

        public async Task<IActionResult> ListAsync(string searchString,string citySearchString,int[] categories,int[] typesOfContracts, int[] workingHours)
        {
            var listOfProperties = await _unitOfWork.Jobs.GetListsOfPropertiesAsync();
            ViewData["Categories"] = listOfProperties.Categories;
            ViewData["TypesOfContracts"] = listOfProperties.TypesOfContract;
            ViewData["WorkingHours"] = listOfProperties.WorkingHours; 
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentCityFilter"] = citySearchString;
            IEnumerable<Job> jobs = await GetSortedAndFilteredJobListAsync(searchString, citySearchString,new List<int>(categories), new List<int>(typesOfContracts), new List<int>(workingHours));
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
                 await GetOrCreateIfNullCompanyJobAsync(job);
                jobInDb.CompanyId = job.CompanyId;
            }
            else
            {              
                await GetOrCreateIfNullCompanyJobAsync(job);
                await _unitOfWork.Jobs.AddAsync(job);
            }
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("list");
        }

        private async Task GetOrCreateIfNullCompanyJobAsync(Job job)
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

        private async Task<IEnumerable<Job>> GetSortedAndFilteredJobListAsync(string jobNameSearchString, string citySearchString,List<int> categories,List<int> typesOfContracts, List<int> workingHours)
        {
            var predicate = PredicateBuilder.New<Job>();
            predicate.DefaultExpression = j => true; 
            if (!string.IsNullOrEmpty(jobNameSearchString))
            {
                 predicate = predicate.And(j => j.Name.Contains(jobNameSearchString));
            }
            if (!string.IsNullOrEmpty(citySearchString))
            {
                 predicate = predicate.And(j => j.Localization.Contains(citySearchString));
            }
            if (categories.Count>0)
            {
                 predicate = predicate.And(j => categories.Contains(j.CategoryId));
            }
            if (typesOfContracts.Count > 0)
            {
                predicate = predicate.And(j => typesOfContracts.Contains(j.TypeOfContractId));
            }
            if (workingHours.Count > 0)
            {
                predicate = predicate.And(j => workingHours.Contains(j.WorkingHoursId));
            }
            var jobs = await _unitOfWork.Jobs.GetJobsWithAllPropertiesByFilterAsync(predicate);
            return jobs;
        }
    }
}
