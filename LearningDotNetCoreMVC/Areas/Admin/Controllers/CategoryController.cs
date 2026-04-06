using LearningDotNetCoreMVC.DataAccess.Data;
using LearningDotNetCoreMVC.DataAccess.Repository.IRepository;
using LearningDotNetCoreMVC.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningDotNetCoreMVC.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _UnitOfWork;
        public CategoryController(IUnitOfWork _UnitOfWork)
        {
            this._UnitOfWork = _UnitOfWork;
        }
        public IActionResult Index()
        {
           List<Category> AllCategories = _UnitOfWork.Category.GetAll().ToList();

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
                Category? category = _UnitOfWork.Category.Get(x => x.ID == id).FirstOrDefault();
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
                Category? category = _UnitOfWork.Category.Get(x=>x.ID ==id).FirstOrDefault();
                if(category != null)
                {
                    _UnitOfWork.Category.Delete(category);
                    _UnitOfWork.Save();
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
                _UnitOfWork.Category.Update(category);
                _UnitOfWork.Save();
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
                _UnitOfWork.Category.Add(category);
                _UnitOfWork.Save();
                TempData["Success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
