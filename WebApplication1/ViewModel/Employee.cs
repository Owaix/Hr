using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplication1.ViewModel
{
    public class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public SelectList Country { get; set; }
        public SelectList Gender { get; set; }
        public int Page { get; set; }
    }
}