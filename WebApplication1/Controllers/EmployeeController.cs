using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            Employee emp = new Employee();
            List<Country> list = new List<Country>();
            list.Add(new Country { Id = 1, Name = "Pakistan" });
            list.Add(new Country { Id = 2, Name = "India" });
            list.Add(new Country { Id = 3, Name = "China" });
            list.Add(new Country { Id = 4, Name = "USA" });
            emp.Country = new SelectList(list, "Id", "Name");

            return View(emp);
        }
        [HttpPost]
        public ActionResult New(String[] Ins, String[] Deg, String[] Year)
        {
            for(int i=0;i<Ins.Length;i++)
            {
                var institute = Ins[i];
                var degree = Deg[i];
                var year = Year[i];
                //Save

            }
            
            return View();
        }
    }
    public class Country
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}