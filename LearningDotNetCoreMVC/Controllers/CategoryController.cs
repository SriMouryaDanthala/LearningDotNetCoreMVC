using LearningDotNetCoreMVC.DataAccess.Data;
using LearningDotNetCoreMVC.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningDotNetCoreMVC.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           List<Category> AllCategories = _db.Categories.ToList();

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
                Category category = _db.Categories.Find(id);
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
                Category? category = _db.Categories.Find(id);
                if(category != null)
                {
                    _db.Categories.Remove(category);
                    _db.SaveChanges();
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
                _db.Categories.Update(category);
                _db.SaveChanges();
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
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["Success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
