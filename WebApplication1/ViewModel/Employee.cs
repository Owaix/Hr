using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.ViewModel
{
    public class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public SelectList Country { get; set; }
    }
}