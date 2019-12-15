using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Joobie.Models.JobModels;
using Microsoft.AspNetCore.Mvc;


namespace Joobie.Controllers
{ public class CategoriesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
         public async Task<IActionResult> ListAsync()
         {
             var categories = await _unitOfWork.Categories.GetCategoriesAsync();
             return View("List", categories);
         }
        
         public async Task<IActionResult> EditAsync(long id)
         {
             var categoryInDb = await _unitOfWork.Categories.GetCategoryAsync(id);
             var categoryFormInfo = new CategoryFormViewModel
             {
                 Category = categoryInDb
             };
        
             return View("CategoryForm", categoryFormInfo);
         }
        
         public async Task<IActionResult> DeleteAsync(long id)
         {
             var categoryInDb = await _unitOfWork.Categories.GetCategoryAsync(id);
             var categoryFormInfo = new CategoryFormViewModel
             {
                 Category = categoryInDb
             };
        
             return View("DeleteCategoryForm", categoryFormInfo);
         }
        
         [HttpPost, ActionName("DeleteAsync")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmedAsync(Category category)
         {
             var categoryInDb = await _unitOfWork.Categories.GetCategoryAsync(category.Id);
            _unitOfWork.Categories.Remove(categoryInDb);
             await _unitOfWork.CompleteAsync();
             return RedirectToAction("List");
         }
        
         public async Task<IActionResult> CreateAsync()
         {
             var categoryFormInfo = new CategoryFormViewModel
             {
                 Category = new Category()
             };
             return View("CategoryForm", categoryFormInfo);
         }
        
         public async Task<IActionResult> SaveAsync(Category category)
         {
             var categoryInDb = await _unitOfWork.Categories.GetCategoryAsync(category.Id);
             if (categoryInDb != null)
             {
                 categoryInDb.Name = category.Name;
             }
             else
             {
                 await _unitOfWork.Categories.AddAsync(category);
             }
             await _unitOfWork.CompleteAsync();
             return RedirectToAction("List");
         }

    }
}
