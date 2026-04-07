using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearningDotNetCoreMVC.Models.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [DisplayName("Name of the book")]
    public string Name { get; set; }
    
    [DisplayName("About the book")]
    public string Description { get; set; }
    
    [Required]
    [DisplayName("Name of the Author")]
    public string Author { get; set; }

    [Required]
    [DisplayName("ISBN of the book")]
    public string ISBN { get; set; }
    
    [Required]
    [DisplayName("Price of the book")]
    public double Price { get; set; }
    
    [DisplayName("Price for books > 50")]
    public double PriceForFifty { get; set; }
    
    [DisplayName("Price For Books > 100")]
    public double PriceForHundred { get; set; }
}