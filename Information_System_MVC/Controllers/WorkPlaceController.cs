using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class WorkPlaceController : Controller
    {
        // GET: WorkPlace
        public ActionResult Index()
        {
            return View();
        }

        // GET: WorkPlace/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkPlace/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkPlace/Create
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

        // GET: WorkPlace/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkPlace/Edit/5
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

        // GET: WorkPlace/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkPlace/Delete/5
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
