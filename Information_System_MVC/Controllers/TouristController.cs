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

                    Tourist tourist = db.Tourists.Find(id);

                    if (tourist != null)
                    {
                        return View(tourist);
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
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
              || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    return View();
                }
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
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

                    Tourist tourist = db.Tourists.Find(id);

                    if (tourist != null)
                    {
                        return View(tourist);
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
        public ActionResult Edit(Tourist tourist)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
              || (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
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
                    Tourist tourist = db.Tourists.Find(id);

                    if (tourist == null)
                    {
                        return HttpNotFound();
                    }

                    return View(tourist);
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
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }
    }
}
