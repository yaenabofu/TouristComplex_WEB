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

        [Authorize]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
                || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    IEnumerable<Room> rooms = db.Rooms;

                    ViewBag.Rooms = rooms;

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
        public ActionResult Details(int? id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
               || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
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
                else
                    return Redirect("/Home/Index");
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
        public ActionResult Create(Room room)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
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
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
              || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
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
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Room room)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
              || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
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
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
              || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    Room room = db.Rooms.Find(id);

                    if (room == null)
                    {
                        return HttpNotFound();
                    }

                    return View(room);
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
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
              || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
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
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }
    }
}
