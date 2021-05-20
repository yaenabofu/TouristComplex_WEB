using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class WorkerController : Controller
    {
        ISContext db = new ISContext();

        public ActionResult Index()
        {
            IEnumerable<Worker> workers = db.Workers;

            ViewBag.Workers = workers;

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Worker worker = db.Workers.Find(id);

            if (worker != null)
            {
                return View(worker);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Worker worker)
        {
            try
            {
                db.Workers.Add(worker);
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

            Worker worker = db.Workers.Find(id);

            if (worker != null)
            {
                return View(worker);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Worker worker)
        {
            try
            {
                db.Entry(worker).State = System.Data.Entity.EntityState.Modified;
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
            Worker worker = db.Workers.Find(id);

            if (worker == null)
            {
                return HttpNotFound();
            }

            return View(worker);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Worker worker = db.Workers.Find(id);
                if (worker == null)
                {
                    return HttpNotFound();
                }

                db.Workers.Remove(worker);
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
