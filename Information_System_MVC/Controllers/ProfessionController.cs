using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class ProfessionController : Controller
    {
        // GET: Profession
        public ActionResult Index()
        {
            return View();
        }

        // GET: Profession/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profession/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profession/Create
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

        // GET: Profession/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profession/Edit/5
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

        // GET: Profession/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profession/Delete/5
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
