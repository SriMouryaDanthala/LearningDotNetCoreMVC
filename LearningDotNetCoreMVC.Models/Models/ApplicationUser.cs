using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LearningDotNetCoreMVC.Models.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string UserName { get; set; }
    
    public string? StreetAddress { get; set; }
    public string? PostalCode { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
}