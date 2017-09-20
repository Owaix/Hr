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
            var item = EmpRep.GetAll().ToPagedList(page ?? 1, 3);
            var items = Mapper.Map<IPagedList<EmployeeVM>>(item);
            return View(items);
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