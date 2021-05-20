using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class TouristController : Controller
    {
        // GET: Tourist
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tourist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tourist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tourist/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tourist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tourist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tourist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tourist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
