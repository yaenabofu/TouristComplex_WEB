﻿using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class EventController : Controller
    {
        ISContext db = new ISContext();

        [Authorize]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 0)
                {
                    return Redirect("/Home/Index");
                }
            }

            IEnumerable<Event> events = db.Events;

            ViewBag.Events = events;

            return View();
        }


        [Authorize]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 0)
                {
                    return Redirect("/Home/Index");
                }
            }
            if (id == null)
            {
                return HttpNotFound();
            }

            Event event1 = db.Events.Find(id);

            if (event1 != null)
            {
                return View(event1);
            }

            return HttpNotFound();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
                 (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                    return View();
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }

        [HttpPost]
        public ActionResult Create(Event event1)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
                (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    try
                    {
                        db.Events.Add(event1);
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
        public ActionResult Edit(int? id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
                (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    if (id == null)
                    {
                        return HttpNotFound();
                    }

                    Event event1 = db.Events.Find(id);

                    if (event1 != null)
                    {
                        return View(event1);
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
        public ActionResult Edit(Event event1)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
                (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {

                    try
                    {
                        db.Entry(event1).State = EntityState.Modified;
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
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
                (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {

                    Event event1 = db.Events.Find(id);

                    if (event1 == null)
                    {
                        return HttpNotFound();
                    }

                    return View(event1);
                }
                else
                    return Redirect("/Home/Index");
            }
            else
                return Redirect("/Home/Index");
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
               (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {

                    try
                    {
                        Event event1 = db.Events.Find(id);
                        if (event1 == null)
                        {
                            return HttpNotFound();
                        }

                        db.Events.Remove(event1);
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
