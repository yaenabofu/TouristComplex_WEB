using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class BookedTicketsController : Controller
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

            IEnumerable<BookedTicket> bookedTickets = db.BookedTickets;

            ViewBag.BookedTickets = bookedTickets;

            return View();
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

            BookedTicket ticket = db.BookedTickets.Find(id);

            if (ticket != null)
            {
                return View(ticket);
            }

            return HttpNotFound();
        }
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

            BookedTicket ticket = db.BookedTickets.Find(id);

            if (ticket != null)
            {
                return View(ticket);
            }

            return HttpNotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(BookedTicket ticket)
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
                db.Entry(ticket).State = EntityState.Modified;
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
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 0 ||
                    (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    return Redirect("/Home/Index");
                }
            }

            BookedTicket ticket = db.BookedTickets.Find(id);

            if (ticket == null)
            {
                return HttpNotFound();
            }

            return View(ticket);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 0 ||
                    (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    return Redirect("/Home/Index");
                }
            }

            try
            {
                BookedTicket ticket = db.BookedTickets.Find(id);

                if (ticket == null)
                {
                    return HttpNotFound();
                }

                Event event1 = db.Events.Find(ticket.EventId);
                event1.Quantity += ticket.Quantity;
                db.Entry(event1).State = EntityState.Modified;
                db.SaveChanges();

                db.BookedTickets.Remove(ticket);
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
