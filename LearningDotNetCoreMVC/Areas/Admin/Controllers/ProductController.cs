using LearningDotNetCoreMVC.DataAccess.Repository.IRepository;
using LearningDotNetCoreMVC.Models.Models;
using LearningDotNetCoreMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        
        /// <summary>
        /// Upsert here stands for the combo of update and insert combo,
        /// the idea here is to have a single page for the insert and update functionality.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a View based on insert/update.</returns>
        public IActionResult Upsert(int? id)
        {
            ProductVM productVm = new ProductVM()
            {
                Product = id is 0 or null ? new Product() : _unitOfWork.Product.Get(u=>u.Id == id).FirstOrDefault<Product>(),
                Categories = _unitOfWork.Category.GetAll().Select( u=> new SelectListItem()
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }
                )
            };
            return View(productVm);
        }
        
        [HttpPost]
        public IActionResult Upsert(ProductVM productVm)
        {
            if (ModelState.IsValid)
            {
                if (productVm.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVm.Product);
                    _unitOfWork.Save();
                    TempData["Success"] = "Product Created Successfully";
                }
                else
                {
                    _unitOfWork.Product.Update(productVm.Product);
                    _unitOfWork.Save();
                    TempData["Success"] = "Product Updated Successfully";
                }

                return RedirectToAction("Index");
            }
            else
            {
                productVm.Categories = _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVm);
            }
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
