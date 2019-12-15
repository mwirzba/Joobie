using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Joobie.Models.JobModels;
using Microsoft.AspNetCore.Mvc;


namespace Joobie.Controllers
{ public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
         public async Task<IActionResult> ListAsync()
         {
             var categories = await _unitOfWork.Categories.GetAllAsync();
             return View("List", categories);
         }
        
         public async Task<IActionResult> EditAsync(long id)
         {
             var categoryInDb = await _unitOfWork.Categories.SingleOrDefaultAsync(c=>c.Id==id);      
             return View("CategoryForm", categoryInDb);
         }
        
         public async Task<IActionResult> DeleteAsync(long id)
         {
             var categoryInDb = await _unitOfWork.Categories.SingleOrDefaultAsync(c => c.Id == id);        
             return View("DeleteCategoryForm", categoryInDb);
         }
        
         [HttpPost, ActionName("DeleteAsync")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmedAsync(Category category)
         {
             var categoryInDb = await _unitOfWork.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);
            _unitOfWork.Categories.Remove(categoryInDb);
             await _unitOfWork.CompleteAsync();
             return RedirectToAction("List");
         }
        
         public async Task<IActionResult> CreateAsync()
         {
            return View("CategoryForm", new Category());
         }

        public async Task<IActionResult> SaveAsync(Category category)
        {
            var jobInDb = await _unitOfWork.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);
            if (jobInDb != null)
            {
                jobInDb.Name = category.Name;
            }
            else
            {
                await _unitOfWork.Categories.AddAsync(category);
            }
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("list");
        }

    }
}
