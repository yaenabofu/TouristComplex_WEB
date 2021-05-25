using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class OrderController : Controller
    {
        ISContext db = new ISContext();

        [Authorize]
        public ActionResult Index()
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
                (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist) ||
               (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
            {
                IEnumerable<Order> orders = db.Orders;

                ViewBag.Orders = orders;

                return View();
            }
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Details(int? id)
        {

            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
                (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist) ||
               (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
            {

                if (id == null)
                {
                    return HttpNotFound();
                }

                Order order = db.Orders.Find(id);

                if (order != null)
                {
                    return View(order);
                }

                return HttpNotFound();
            }
            else
                return Redirect("/Home/Index");
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Order order)
        //{
        //    try
        //    {
        //        db.Orders.Add(order);
        //        db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
                (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist) ||
               (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
            {

                if (id == null)
                {
                    return HttpNotFound();
                }

                Order order = db.Orders.Find(id);

                if (order != null)
                {
                    return View(order);
                }

                return HttpNotFound();
            }
            else
                return Redirect("/Home/Index");
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Order order)
        {

            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
                (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist) ||
               (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
            {
                try
                {
                    db.Entry(order).State = EntityState.Modified;
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

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    Order ticket = db.Orders.Find(id);

        //    if (ticket == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(ticket);
        //}

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        Order order = db.Orders.Find(id);
        //        if (order == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        db.Orders.Remove(order);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
