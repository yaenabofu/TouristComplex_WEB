using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class TouristController : Controller
    {
        ISContext db = new ISContext();

        public ActionResult Index()
        {
            IEnumerable<Tourist> tourist = db.Tourists;

            ViewBag.Tourists = tourist;

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Tourist tourist = db.Tourists.Find(id);

            if (tourist != null)
            {
                return View(tourist);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tourist tourist)
        {
            try
            {
                db.Tourists.Add(tourist);
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

            Tourist tourist = db.Tourists.Find(id);

            if (tourist != null)
            {
                return View(tourist);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Tourist tourist)
        {
            try
            {
                db.Entry(tourist).State = EntityState.Modified;
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
            Tourist tourist = db.Tourists.Find(id);

            if (tourist == null)
            {
                return HttpNotFound();
            }

            return View(tourist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Tourist tourist = db.Tourists.Find(id);
                if (tourist == null)
                {
                    return HttpNotFound();
                }

                db.Tourists.Remove(tourist);
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
