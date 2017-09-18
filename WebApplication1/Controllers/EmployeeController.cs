using DataAccess;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // HRDbContext db = new HRDbContext();
        private Repository<EmployeeVM> EmpRep;
        List<EmployeeVM> emp;
        private UnitOfWork unitOfWork;

        public EmployeeController()
        {
            unitOfWork = new UnitOfWork();
            EmpRep = unitOfWork.Repository<EmployeeVM>();

            emp = new List<EmployeeVM>();
            emp.Add(new EmployeeVM { Id = 1, Name = "Owais", Department = "HR", Salary = 4334 });
            emp.Add(new EmployeeVM { Id = 2, Name = "dasdd", Department = "HR", Salary = 4334 });
            emp.Add(new EmployeeVM { Id = 3, Name = "szdsa", Department = "HR", Salary = 4334 });
            emp.Add(new EmployeeVM { Id = 4, Name = "weweq", Department = "HR", Salary = 4334 });
            emp.Add(new EmployeeVM { Id = 5, Name = "dxzvd", Department = "HR", Salary = 4334 });
            emp.Add(new EmployeeVM { Id = 6, Name = "ererr", Department = "HR", Salary = 4334 });
            emp.Add(new EmployeeVM { Id = 7, Name = "rewtg", Department = "HR", Salary = 4334 });
        }

        public ActionResult Index()
        {
            // var item = EmpRep.GetAll();
            var item = Mapper.Map<List<EmployeeVM>>(emp);
            return View(item);
        }

        public ActionResult New()
        {
            EmployeeVM emp = new EmployeeVM();
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
            for (int i = 0; i < Ins.Length; i++)
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