using AutoMapper;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.ViewModel;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork;
        private Repository<Roles> RolRep;
        private Repository<Features> FeaRep;

        public HomeController()
        {
            unitOfWork = new UnitOfWork(new HrContext());
            RolRep = unitOfWork.Repository<Roles>();
            FeaRep = unitOfWork.Repository<Features>();

        }
        [Authorize]
        public ActionResult Index()
        {
            //UserManager.AddToRole(user.Id, model.Role);
            //var b = UserManager.FindById(User.Identity.GetUserId()).Role;
            //var role = UserManager.GetRoles(user.Id);

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
            HrContext db = new HrContext();
            FeatureRoles Fr = new FeatureRoles();
            var RolesModel = db.role.ToList();// RolRep.GetAll();
            Fr.Role = Mapper.Map<IEnumerable<RolesVM>>(RolesModel);
            var FeatModel = db.feature.ToList();//FeaRep.GetAll();
            Fr.Feature = Mapper.Map<IEnumerable<FeaturesVM>>(FeatModel);
            return View(Fr);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}