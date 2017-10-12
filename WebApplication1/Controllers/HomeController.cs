using AutoMapper;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using WebApplication1.Models;
using WebApplication1.ViewModel;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork;
        private Repository<Roles> RolRep;
        private Repository<Features> FeaRep;
        List<ExcelClient> ClientsList = new List<ExcelClient>
            {
               //  new ExcelClient ( "Adam",  "Bielecki",  DateTime.ParseExact("22/05/1986"),       "adamb@example.com" ),
                 new ExcelClient (  "George", "Smith",  DateTime.Parse("10/10/1990"),  "george@example.com" )
            };

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
            return View();
        }
        public ActionResult AccessConfigJson()
        {
            HrContext db = new HrContext();
            FeatureRoles Fr = new FeatureRoles();
            var RolesModel = db.role.ToList();// RolRep.GetAll();
            Fr.Role = Mapper.Map<IEnumerable<RolesVM>>(RolesModel);
            var FeatModel = db.feature.ToList();//FeaRep.GetAll();
            Fr.Feature = Mapper.Map<IEnumerable<FeaturesVM>>(FeatModel);
            return Json(Fr, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddFeature(int[] Feature)
        {
            var FRcon = new FeatureAccessConfig();
            //FRcon.Feature_Id = Feature;
            //FRcon.Role_Id = Role;
            FRcon.IsCheck = true;
            unitOfWork.Save();
            return Json("Inserted");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View(ClientsList);
        }
        public void ExportClientsListToCSV()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("\"First Name\",\"Last Name\",\"DOB\",\"Email\"");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Exported_Users.csv");
            Response.ContentType = "text/csv";

            foreach (var line in ClientsList)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                                           line.FirstName,
                                           line.LastName,
                                           line.Dob,
                                           line.Email));
            }
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}