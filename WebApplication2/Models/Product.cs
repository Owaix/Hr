using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}