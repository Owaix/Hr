using DataAccess;
using Service;
using System;
using System.Collections.Generic;
using DataAccess.Models;
using PagedList.Mvc;
using PagedList;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using WebApplication1.ViewModel;
using System.IO;
using System.Linq;
using Common;

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

        public ActionResult Index(int? page)
        {
            var item = EmpRep.GetAll();
            return View(item);
        }
        [HttpPost]
        public ActionResult SearchList(String Dept)
        {
            var item = EmpRep.FindById(x => x.Department == Dept).ToList();
            var items = Mapper.Map<IEnumerable<EmployeeVM>>(item);
            return View(items);
        }
        public ActionResult New()
        {
            Employee emp = new Employee();
            List<Country> list = new List<Country>();
            list.Add(new Country { Id = 1, Name = "Pakistan" });
            list.Add(new Country { Id = 2, Name = "India" });
            list.Add(new Country { Id = 3, Name = "China" });
            list.Add(new Country { Id = 4, Name = "USA" });
            // emp.Country = new SelectList(list, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult New(String[] Ins, String[] Deg, String[] Year)
        {
            for (int i = 0; i < Ins.Length; i++)
            {
                var institute = Ins[i];
                var degree = Deg[i];
                var year = Year[i];
                Logging.ExecuteSafely<EmployeeVM>(() =>
                {
                    var emp = new Employee();
                    emp.Name = "Owais";
                    emp.Age = 100;
                    return null;
                });
            }
            List<Country> countrylist = new List<Country>();
            countrylist.Add(new Country { Id = 1, Name = "Owais" });
            countrylist.Add(new Country { Id = 2, Name = "ALi" });
            countrylist.Add(new Country { Id = 3, Name = "Ahmed" });
            countrylist.Add(new Country { Id = 4, Name = "John" });
            countrylist.Add(new Country { Id = 5, Name = "Smith" });
            return Json(countrylist);
        }

        public EmployeeVM AddEmp(EmployeeVM EmpVm)
        {
            return ServiceHelper.ExecuteSafely<EmployeeVM>(() =>
            {
                var Employee = new Employee();
                Employee.Department = EmpVm.Department;
                Employee.Name = EmpVm.Name;
                Employee.Salary = EmpVm.Salary;
                unitOfWork.Repository<Employee>().Add(Employee);
                unitOfWork.Save();
                return EmpVm;
            });
        }
    }
    public class Country
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}