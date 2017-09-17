using DataAccess;
using Service;
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
        // HRDbContext db = new HRDbContext();
        private Repository<Employee> EmpRep;
        private UnitOfWork unitOfWork;

        public EmployeeController()
        {
            unitOfWork = new UnitOfWork();
            EmpRep = unitOfWork.Repository<Employee>();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var item = EmpRep.GetAll();
            return View(item);
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
    }
    public class Country
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}