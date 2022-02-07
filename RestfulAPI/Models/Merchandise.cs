using System;
using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Models
{
    public class MerchandiseVM
    {
        public string name { get; set; }
        public double price { get; set; }
    }
    public class Merchandise
    {
        public string name { get; set; }
        public double price { get; set; }
        [Key]
        public Guid code { get; set; }

    }
}
