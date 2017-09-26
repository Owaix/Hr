using AutoMapper;
using DataAccess;
using DataAccess.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork;
        private Repository<DataAccess.Models.Roles> RolRep;
        private Repository<DataAccess.Models.Features> FeaRep;

        public HomeController()
        {
            unitOfWork = new UnitOfWork(new HRDbContext());
            RolRep = unitOfWork.Repository<DataAccess.Models.Roles>();
            FeaRep = unitOfWork.Repository<DataAccess.Models.Features>();

        }
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String Name, String Mail, String Address)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult AccessConfig()
        {
            FeatureRoles Fr = new FeatureRoles();
            var RolesModel = RolRep.GetAll();
            Fr.Role = Mapper.Map<IEnumerable<WebApplication1.ViewModel.Roles>>(RolesModel);
            var FeatModel = FeaRep.GetAll();
            Fr.Feature = Mapper.Map<IEnumerable<WebApplication1.ViewModel.Features>>(FeatModel);
            return View(Fr);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}