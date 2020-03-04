using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mitchell_International.Models;

namespace Mitchell_International.Controllers
{
    public class HomeController : Controller
    {
        private ProjectEntities db = new ProjectEntities();
        
        //GetCars
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CarbyId(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            // ProjectEntities pr = 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}