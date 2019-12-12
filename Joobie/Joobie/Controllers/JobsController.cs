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
            var jobs = await _unitOfWork.Jobs.GetAllAsync();
            return View("List", jobs);
        }
    }
}
