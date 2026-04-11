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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork _unit, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = _unit;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Upsert(ProductVM productVm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(webRootPath, @"images/product/");

                    if (!string.IsNullOrEmpty(productVm.Product.ImageUrl))
                    {
                        // delete the old pic and create a new one.
                        string oldImagePath = Path.Combine(webRootPath, productVm.Product.ImageUrl.Trim('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVm.Product.ImageUrl = @"/images/product/" + fileName;
                }
                else
                {
                    productVm.Product.ImageUrl = productVm.Product.ImageUrl.Equals(string.Empty) ? string.Empty : productVm.Product.ImageUrl;
                }
                if (productVm.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVm.Product);
                    TempData["Success"] = "Product Created Successfully";
                }
                else
                {
                    _unitOfWork.Product.Update(productVm.Product);
                    TempData["Success"] = "Product Updated Successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            
            productVm.Categories = _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(productVm);
            
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
