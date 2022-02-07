using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Models
{
    public class Category
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
