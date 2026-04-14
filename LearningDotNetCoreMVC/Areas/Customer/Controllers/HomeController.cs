using System.Diagnostics;
using LearningDotNetCoreMVC.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using LearningDotNetCoreMVC.Models;
using LearningDotNetCoreMVC.Models.Models;
using ErrorViewModel = LearningDotNetCoreMVC.Models.Models.ErrorViewModel;

namespace LearningDotNetCoreMVC.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Product> products = _unitOfWork.Product.GetAll().ToList();
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Details(int? id)
    {
        if (id != null)
        {
            var product = _unitOfWork.Product.Get(x=>x.Id == id, "Category").ToList().FirstOrDefault();
            if (product != null)
            {
                return View(product);
            }
        }

        return NotFound();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}
