using System.ComponentModel.Design;
using LearningDotNetCoreMVC.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearningDotNetCoreMVC.Models.ViewModels;

public class ProductVM
{
    public Product? Product { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> Categories { get; set; }
}