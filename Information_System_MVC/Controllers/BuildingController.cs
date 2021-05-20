using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class BuildingController : Controller
    {
        ISContext db = new ISContext();

        public ActionResult Index()
        {
            IEnumerable<Building> buildings = db.Buildings;

            ViewBag.Buildings = buildings;

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Building building = db.Buildings.Find(id);

            if (building != null)
            {
                return View(building);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Building building)
        {
            try
            {
                db.Buildings.Add(building);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Building building = db.Buildings.Find(id);

            if (building != null)
            {
                return View(building);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(int id, Building building)
        {
            try
            {
                db.Entry(building).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Building building = db.Buildings.Find(id);

            if (building == null)
            {
                return HttpNotFound();
            }

            return View(building);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Building building = db.Buildings.Find(id);
                if (building == null)
                {
                    return HttpNotFound();
                }

                db.Buildings.Remove(building);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
