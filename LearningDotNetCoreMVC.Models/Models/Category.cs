using System.ComponentModel.DataAnnotations;

namespace LearningDotNetCoreMVC.Models.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(32)]
        [MinLength(3)]
        public string Name { get; set; }

        [Range(1,100)]
        public int DisplayOrder { get; set; }
    }
}
