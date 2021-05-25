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
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
                || (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist) ||
                (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
            {

                IEnumerable<BookedTicket> bookedTickets = db.BookedTickets;

                ViewBag.BookedTickets = bookedTickets;

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
                  || (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist) ||
                  (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
            {
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
            else
                return Redirect("/Home/Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
                  || (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist) ||
                  (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
            {
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
            else
                return Redirect("/Home/Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(BookedTicket ticket)
        {
            if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2
                 || (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist) ||
                 (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
            {
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
            else
                return Redirect("/Home/Index");
        }
    }
}
