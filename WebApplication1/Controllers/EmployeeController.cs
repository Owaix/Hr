using Service;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Web.Mvc;
using WebApplication1.ViewModel;
using System.Linq;
using Common;
using DataAccess.Models;
using DataAccess;
using PagedList;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // HRDbContext db = new HRDbContext();
        private Repository<Employee> EmpRep;
        private UnitOfWork unitOfWork;

        public EmployeeController()
        {
            unitOfWork = new UnitOfWork(new HrContext());
            EmpRep = unitOfWork.Repository<Employee>();
        }

        public ActionResult Index(int? page)
        {
            var item = EmpRep.FindById(x => x.IsActive == false).ToList();
            var items = Mapper.Map<IEnumerable<EmployeeVM>>(item);
            return View(items.ToPagedList(page ?? 1, 10));
        }
        [HttpPost]
        public ActionResult SearchList(String name)
        {
            var item = EmpRep.FindById(x => x.Name == name).ToList();
            var items = Mapper.Map<IEnumerable<EmployeeVM>>(item);
            return View("Index", items.ToPagedList(1, 10));
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

        public ActionResult Delete(int id)
        {
            var EMpId = EmpRep.GetById(id);
            EMpId.IsActive = false;
            unitOfWork.Save();
            return View("Index");
        }
        public ActionResult ActionMethod(Country country)
        {
            return View();
        }


        public EmployeeVM AddEmp(EmployeeVM EmpVm)
        {
            return ServiceHelper.ExecuteSafely<EmployeeVM>(() =>
            {
                //var Employee = new Employee();
                //Employee.Department = EmpVm.Department;
                //Employee.Name = EmpVm.Name;
                //Employee.Salary = EmpVm.Salary;
                //unitOfWork.Repository<Employee>().Add(Employee);
                unitOfWork.Save();
                return EmpVm;
            });
        }
        public ActionResult Edit(int id)
        {
            var Emp = EmpRep.FindById(x => x.Id == id).FirstOrDefault();
            var items = Mapper.Map<EmployeeVM>(Emp);
            return PartialView("_Edit", items);
        }
    }
    public class Country
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}