using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
    }
}