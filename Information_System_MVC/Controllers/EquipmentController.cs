using Information_System_MVC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class EquipmentController : Controller
    {
        ISContext db = new ISContext();

        [Authorize]
        public ActionResult Index()
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
                || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 0)
            {
                IEnumerable<Equipment> equipments = db.Equipments;

                ViewBag.Equipments = equipments;

                return View();
            }
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
                   || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 0)
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
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                return View();
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Equipment equipment)
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
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
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
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
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Equipment equipment)
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
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
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
            {
                Equipment equipment = db.Equipments.Find(id);

                if (equipment == null)
                {
                    return HttpNotFound();
                }

                return View(equipment);
            }
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
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
            else
                return Redirect("/Home/Index");
        }
    }
}
