using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.WebHost;
using Mitchell_International.Models;
using System.Web.Script.Serialization;

namespace Mitchell_International.Controllers
{
    public class CarsController : Controller
    {
        private ProjectEntities db = new ProjectEntities();

        // GET: Cars
         
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        [HttpGet]
        //Get Cars using model,make or year
        //Not implemented completely
        public ActionResult Adv_search()
        {
            //var result = db.Cars.ToList();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //return View(js.Serialize(result)); 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //This is still work in progress
        public ActionResult Adv_search(int y, string mod, string mk)
        {
            return RedirectToAction("Select_Any", new {year = y, model = mod, make = mk });
        }


        //Work in Progress
        [HttpGet]
        public ActionResult Select_Any()
        {
            return View();
        }
        //Work in Progress
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Select_Any(int? year, string model, string make)
        {
            var car = db.Select_byanything(year, model, make);
            if (car != null)
            {
                return RedirectToAction("search_result", car);
            }
            return RedirectToAction("Cars_Error");
        }

        //GET : For searching using Id
        [HttpGet]
        public ActionResult Select()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Select(int? id)
        {
            if(id == null)
            {
                return View();
            }
            return RedirectToAction("Details", new { id = id });
        }

        // GET: Cars/Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return RedirectToAction("Cars_Error");
            }
            return View(car);
        }

        // GET: Cars/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // For Creating new Car objects and entering data in them
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Make,Model")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        //Error Page shown when Id is not present in the database
        [HttpGet]
        public ActionResult Cars_Error()
        {
            return View();
        }

        // GET: Cars/Edit
        //For Editing the details of Car
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit
        // Editing Car Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Make,Model")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete
        // For Deleting Cars
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
