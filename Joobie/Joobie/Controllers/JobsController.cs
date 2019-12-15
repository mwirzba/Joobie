using Joobie.Models.JobModels;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Repositories;
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

        public async Task<IActionResult> ListAsync()
        {
            var jobs = await _unitOfWork.Jobs.GetJobsWithAllPropertiesAsync();
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

        public async void DeleteAsync(long id)
        {
            //TODO

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
                if (job.CompanyId != 0)
                    jobInDb.CompanyId = job.CompanyId;
            }
            else
            {
                //job id cannot be empty but we dont wat to get all companies
                //must create company repository
                if (job.CompanyId == 0)
                    job.CompanyId = 1;
                await _unitOfWork.Jobs.AddAsync(job);
            }
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("list");
        }

       
    }
}
