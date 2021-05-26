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
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 0)
                {
                    return Redirect("/Home/Index");
                }
            }

            IEnumerable<Order> orders = db.Orders;

            ViewBag.Orders = orders;

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

            Order order = db.Orders.Find(id);

            if (order != null)
            {
                return View(order);
            }

            return HttpNotFound();
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

            Order order = db.Orders.Find(id);

            if (order != null)
            {
                return View(order);
            }

            return HttpNotFound();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 0)
                {
                    return Redirect("/Home/Index");
                }
            }
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

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist)
            {
                Order ticket = db.Orders.Find(id);

                if (ticket == null)
                {
                    return HttpNotFound();
                }

                return View(ticket);
            }
            else
                return Redirect("/Home/Index");

        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist)
            {
                try
                {
                    Order order = db.Orders.Find(id);
                    if (order == null)
                    {
                        return HttpNotFound();
                    }

                    Product product = db.Products.Find(order.ProductId);
                    product.Quantity += order.Quantity;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();

                    db.Orders.Remove(order);
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
