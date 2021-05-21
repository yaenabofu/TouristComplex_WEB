using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class WorkPlaceController : Controller
    {
        ISContext db = new ISContext();

        public ActionResult Index()
        {
            IEnumerable<WorkPlace> workPlaces = db.WorkPlaces;

            ViewBag.WorkPlaces = workPlaces;

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WorkPlace workPlace = db.WorkPlaces.Find(id);

            if (workPlace != null)
            {
                return View(workPlace);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,PlaceId,BuildingId")] WorkPlace workPlace)
        {
            try
            {
                db.WorkPlaces.Add(workPlace);
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

            WorkPlace workPlace = db.WorkPlaces.Find(id);

            if (workPlace != null)
            {
                return View(workPlace);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(WorkPlace workPlace)
        {
            try
            {
                db.Entry(workPlace).State = EntityState.Modified;
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
            WorkPlace workPlace = db.WorkPlaces.Find(id);

            if (workPlace == null)
            {
                return HttpNotFound();
            }

            return View(workPlace);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                WorkPlace workPlace = db.WorkPlaces.Find(id);
                if (workPlace == null)
                {
                    return HttpNotFound();
                }

                db.WorkPlaces.Remove(workPlace);
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
