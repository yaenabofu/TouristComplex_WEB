using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class EventController : Controller
    {
        ISContext db = new ISContext();
        public ActionResult Index()
        {
            IEnumerable<Event> events = db.Events;

            ViewBag.Events = events;

            return View();
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Event event1 = db.Events.Find(id);

            if (event1 != null)
            {
                return View(event1);
            }

            return HttpNotFound();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event event1)
        {
            try
            {
                db.Events.Add(event1);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Event event1 = db.Events.Find(id);

            if (event1 != null)
            {
                return View(event1);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Event event1)
        {
            try
            {
                db.Entry(event1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Event event1 = db.Events.Find(id);

            if (event1 == null)
            {
                return HttpNotFound();
            }

            return View(event1);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            try
            {
                Event event1 = db.Events.Find(id);
                if (event1 == null)
                {
                    return HttpNotFound();
                }

                db.Events.Remove(event1);
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
