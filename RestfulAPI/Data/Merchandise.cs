using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulAPI.Data
{
    // Định Nghĩa Entity -> Tiếp đến Định nghĩa DB Context
    [Table("Merchandise")]
    public class Merchandise
    {
        [Key]
        public Guid code { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }   
        public string description { get; set; }
        [Range(0, double.MaxValue)]
        public double price { get; set; }
        public byte discount { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
