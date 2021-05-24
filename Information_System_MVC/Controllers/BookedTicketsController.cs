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
            IEnumerable<BookedTicket> bookedTickets = db.BookedTickets;

            ViewBag.BookedTickets = bookedTickets;

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Details(int? id)
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
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
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

        [Authorize]
        // POST: BookedTickets/Edit/5
        [HttpPost]
        public ActionResult Edit(BookedTicket ticket)
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
    }
}
