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

        // GET: BookedTickets
        public ActionResult Index()
        {
            IEnumerable<BookedTicket> bookedTickets = db.BookedTickets;

            ViewBag.BookedTickets = bookedTickets;

            return View();
        }

        // GET: BookedTickets/Details/5
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

        // GET: BookedTickets/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookedTickets/Create
        [HttpPost]
        public ActionResult Create(BookedTicket ticket)
        {
            try
            {
                db.BookedTickets.Add(ticket);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookedTickets/Edit/5
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

        // GET: BookedTickets/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BookedTicket ticket = db.BookedTickets.Find(id);

            if (ticket == null)
            {
                return HttpNotFound();
            }

            return View(ticket);
        }

        // POST: BookedTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                BookedTicket ticket = db.BookedTickets.Find(id);
                if (ticket == null)
                {
                    return HttpNotFound();
                }

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
