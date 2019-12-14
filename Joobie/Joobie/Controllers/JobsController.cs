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
            ViewBag.info = await _unitOfWork.Jobs.GetListsOfPropertiesAsync();

            return View("JobForm",jobInDb);
        }
    }
}
