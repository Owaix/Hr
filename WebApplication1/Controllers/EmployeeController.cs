using DataAccess;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DataAccess.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // HRDbContext db = new HRDbContext();
        private Repository<EmployeeVM> EmpRep;
        private UnitOfWork unitOfWork;
        HRDbContext db = new HRDbContext();


        public EmployeeController()
        {
            unitOfWork = new UnitOfWork();
            //    EmpRep = unitOfWork.Repository<EmployeeVM>();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var ModelEmpployee = db.employee.ToList();
            var Items = Mapper.Map<List<EmployeeVM>>(ModelEmpployee);
            return View(Items);
        }

        public ActionResult New()
        {
            EmployeeVM emp = new EmployeeVM();
            List<Country> list = new List<Country>();
            list.Add(new Country { Id = 1, Name = "Pakistan" });
            list.Add(new Country { Id = 2, Name = "India" });
            list.Add(new Country { Id = 3, Name = "China" });
            list.Add(new Country { Id = 4, Name = "USA" });
            //    emp.Country = new SelectList(list, "Id", "Name");

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