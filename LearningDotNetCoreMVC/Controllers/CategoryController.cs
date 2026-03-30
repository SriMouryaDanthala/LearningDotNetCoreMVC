using LearningDotNetCoreMVC.DataAccess.Data;
using LearningDotNetCoreMVC.DataAccess.Repository.IRepository;
using LearningDotNetCoreMVC.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningDotNetCoreMVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository dbRepository)
        {
            _categoryRepository = dbRepository;
        }
        public IActionResult Index()
        {
           List<Category> AllCategories = _categoryRepository.GetAll().ToList();

            return View(AllCategories);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                Category? category = _categoryRepository.Get(x => x.ID == id).FirstOrDefault();
                if (category != null)
                {
                    return View(category);
                }
            }
            return NotFound();
        }

        public IActionResult Delete(int? id)
        {
            if(id != null && id != 0)
            {
                Category? category = _categoryRepository.Get(x=>x.ID ==id).FirstOrDefault();
                if(category != null)
                {
                    _categoryRepository.Delete(category);
                    _categoryRepository.Save();
                    TempData["Success"] = "Category Deleted successfully";
                    return RedirectToAction("Index");
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category != null)
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                TempData["Success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                _categoryRepository.Save();
                TempData["Success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
