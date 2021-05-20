using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class RoomController : Controller
    {
        ISContext db = new ISContext();

        public ActionResult Index()
        {
            IEnumerable<Room> rooms = db.Rooms;

            ViewBag.Rooms = rooms;

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Room room = db.Rooms.Find(id);

            if (room != null)
            {
                return View(room);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            try
            {
                db.Rooms.Add(room);
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

            Room room = db.Rooms.Find(id);

            if (room != null)
            {
                return View(room);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            try
            {
                db.Entry(room).State = EntityState.Modified;
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
            Room room = db.Rooms.Find(id);

            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Room room = db.Rooms.Find(id);
                if (room == null)
                {
                    return HttpNotFound();
                }

                db.Rooms.Remove(room);
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
