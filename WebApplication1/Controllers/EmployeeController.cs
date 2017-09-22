﻿using DataAccess;
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
        private UnitOfWork unitOfWork;
        private Repository<Employee> EmpRep;

        public EmployeeController()
        {
            unitOfWork = new UnitOfWork(new HRDbContext());
            EmpRep = unitOfWork.Repository<Employee>();
        }

        public ActionResult Index(int? page)
        {
            var item = EmpRep.GetAll();
            var items = Mapper.Map<List<EmployeeVM>>(item);
            return View(items.ToPagedList(page ?? 1, 5));
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
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Junk/"), fileName);
                file.SaveAs(path);
            }
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
            return Json(new Country { Name = "Pakistan" });
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