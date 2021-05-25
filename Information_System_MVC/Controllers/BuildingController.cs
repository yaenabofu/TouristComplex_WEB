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

        [Authorize]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                IEnumerable<Building> buildings = db.Buildings;

                ViewBag.Buildings = buildings;

                return View();
            }
            else
                return Redirect("/Home/Index");

        }
        [Authorize]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
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
            else
                return Redirect("/Home/Index");
        }


        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                    return View();
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,RoomCount")] Building building)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {
                    if (ModelState.IsValid)
                    {
                        db.Buildings.Add(building);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View();
                }
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
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
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Building building)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
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
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {

                    Building building = db.Buildings.Find(id);

                    if (building == null)
                    {
                        return HttpNotFound();
                    }

                    return View(building);
                }
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
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
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }
    }
}
