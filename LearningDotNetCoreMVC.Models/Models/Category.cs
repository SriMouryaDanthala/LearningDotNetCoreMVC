using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearningDotNetCoreMVC.Models.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(32)]
        [MinLength(3)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }
    }
}
