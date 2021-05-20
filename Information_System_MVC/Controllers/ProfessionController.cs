using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class ProfessionController : Controller
    {
        ISContext db = new ISContext();

        public ActionResult Index()
        {
            IEnumerable<Profession> professions = db.Professions;

            ViewBag.Professions = professions;

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Profession profession = db.Professions.Find(id);

            if (profession != null)
            {
                return View(profession);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Profession profession)
        {
            try
            {
                db.Professions.Add(profession);
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

            Profession profession = db.Professions.Find(id);

            if (profession != null)
            {
                return View(profession);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Profession profession)
        {
            try
            {
                db.Entry(profession).State = EntityState.Modified;
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
            Profession profession = db.Professions.Find(id);

            if (profession == null)
            {
                return HttpNotFound();
            }

            return View(profession);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Profession profession = db.Professions.Find(id);
                if (profession == null)
                {
                    return HttpNotFound();
                }

                db.Professions.Remove(profession);
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
