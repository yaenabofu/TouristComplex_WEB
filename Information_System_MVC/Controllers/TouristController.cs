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

        [Authorize]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
              || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    IEnumerable<Tourist> tourist = db.Tourists;

                    ViewBag.Tourists = tourist;

                    return View();
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
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

                    Tourist tourist = db.Tourists.Find(id);

                    if (tourist != null)
                    {
                        return View(tourist);
                    }

                    return HttpNotFound();
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
              || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    List<Room> rooms = db.Rooms.ToList();
                    ViewBag.PassingValue = rooms;

                    return View();
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Tourist tourist)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
                 || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    db.Tourists.Add(tourist);
                    db.SaveChanges();

                    Room room = db.Rooms.Find(tourist.RoomId);
                    room.IsAvailable = false;
                    db.Entry(room).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
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

                    List<Room> rooms = db.Rooms.ToList();
                    ViewBag.PassingValue = rooms;

                    Tourist tourist = db.Tourists.Find(id);

                    if (tourist != null)
                    {
                        return View(tourist);
                    }

                    return HttpNotFound();
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Tourist newTourist)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
              || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {

                    List<Tourist> getTourist = db.Tourists.AsNoTracking().Where(x => x.Id == newTourist.Id).Select(c => c).ToList();
                    Tourist old = getTourist.FirstOrDefault();

                    if (old.Id != newTourist.RoomId)
                    {
                        List<Tourist> livingInCurrentRoom = db.Tourists.AsNoTracking().Where(c => c.RoomId == old.RoomId).Select(c => c).ToList();

                        if (livingInCurrentRoom.Count - 1 == 0)
                        {
                            Room room = db.Rooms.Find(old.RoomId);
                            room.IsAvailable = true;
                            db.Entry(room).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    db.Entry(newTourist).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
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
                    Tourist tourist = db.Tourists.Find(id);

                    if (tourist == null)
                    {
                        return HttpNotFound();
                    }

                    return View(tourist);
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
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
                        Tourist tourist = db.Tourists.Find(id);

                        List<Tourist> livingInCurrentRoom = db.Tourists.AsNoTracking().Where(c => c.RoomId == tourist.RoomId).Select(c => c).ToList();

                        if (livingInCurrentRoom.Count - 1 == 0)
                        {
                            Room room = db.Rooms.Find(tourist.RoomId);
                            room.IsAvailable = true;
                            db.Entry(room).State = EntityState.Modified;
                            db.SaveChanges();
                        }

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
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }
    }
}
