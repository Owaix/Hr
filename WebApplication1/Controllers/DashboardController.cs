﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DashboardController : Controller
    {
        // GET Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Indexer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Indexr()
        {
            return View();
        }
    }
}