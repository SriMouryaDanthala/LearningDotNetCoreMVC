using LearningDotNetCoreMVC.DataAccess.Repository.IRepository;
using LearningDotNetCoreMVC.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningDotNetCoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork _unit)
        {
            _unitOfWork = _unit;
        }
        public IActionResult Index()
        {
            List<Product> productsList = _unitOfWork.Product.GetAll().ToList();
            return View(productsList);
        }

        public IActionResult Create()
            
        {
            return View();
        }

        public IActionResult Edit(int Id)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == Id).FirstOrDefault();
            if (product != null)
            {
                return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["Success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }
        
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["Success"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                _unitOfWork.Product.Delete(product);
                _unitOfWork.Save();
                TempData["Success"] = "Product Deleted Successfully";
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
