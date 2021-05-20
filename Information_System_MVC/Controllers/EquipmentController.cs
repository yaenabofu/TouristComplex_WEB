using Information_System_MVC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class EquipmentController : Controller
    {
        ISContext db = new ISContext();
        public ActionResult Index()
        {
            IEnumerable<Equipment> equipments = db.Equipments;

            ViewBag.Equipments = equipments;

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Equipment equipment = db.Equipments.Find(id);

            if (equipment != null)
            {
                return View(equipment);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Equipment equipment)
        {
            try
            {
                db.Equipments.Add(equipment);
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

            BookedTicket ticket = db.BookedTickets.Find(id);

            if (ticket != null)
            {
                return View(ticket);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Equipment equipment)
        {
            try
            {
                db.Entry(equipment).State = EntityState.Modified;
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
            Equipment equipment = db.Equipments.Find(id);

            if (equipment == null)
            {
                return HttpNotFound();
            }

            return View(equipment);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Equipment equipment = db.Equipments.Find(id);
                if (equipment == null)
                {
                    return HttpNotFound();
                }

                db.Equipments.Remove(equipment);
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
