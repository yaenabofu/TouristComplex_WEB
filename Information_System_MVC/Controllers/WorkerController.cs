using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class WorkerController : Controller
    {
        ISContext db = new ISContext();

        [Authorize]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {
                    IEnumerable<Worker> workers = db.Workers;

                    ViewBag.Workers = workers;

                    List<Profession> professions = db.Professions.ToList();

                    List<int> workPlaces = db.WorkPlaces.Select(x => x.Id).ToList();
                    workPlaces.Sort();
                    List<dynamic> list = new List<dynamic>();
                    list.Add(professions);
                    list.Add(workPlaces);

                    ViewBag.PassingValue = list;

                    return View();
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {
                    if (id == null)
                    {
                        return HttpNotFound();
                    }

                    Worker worker = db.Workers.Find(id);

                    if (worker != null)
                    {
                        return View(worker);
                    }

                    return HttpNotFound();
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {
                    List<Profession> professions = db.Professions.ToList();

                    List<int> workPlaces = db.WorkPlaces.Select(x => x.Id).ToList();
                    workPlaces.Sort();
                    List<dynamic> list = new List<dynamic>();
                    list.Add(professions);
                    list.Add(workPlaces);

                    ViewBag.PassingValue = list;

                    return View();
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Worker worker)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {
                    try
                    {
                        db.Workers.Add(worker);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {
                    if (id == null)
                    {
                        return HttpNotFound();
                    }

                    Worker worker = db.Workers.Find(id);

                    if (worker != null)
                    {
                        List<Profession> professions = db.Professions.ToList();

                        List<int> workPlaces = db.WorkPlaces.Select(x => x.Id).ToList();
                        workPlaces.Sort();
                        List<dynamic> list = new List<dynamic>();
                        list.Add(professions);
                        list.Add(workPlaces);

                        ViewBag.PassingValue = list;

                        return View(worker);
                    }

                    return HttpNotFound();
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return HttpNotFound();
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Worker worker)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {
                    try
                    {
                        db.Entry(worker).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {
                    Worker worker = db.Workers.Find(id);

                    if (worker == null)
                    {
                        return HttpNotFound();
                    }

                    List<Profession> professions = db.Professions.ToList();

                    List<int> workPlaces = db.WorkPlaces.Select(x => x.Id).ToList();
                    workPlaces.Sort();
                    List<dynamic> list = new List<dynamic>();
                    list.Add(professions);
                    list.Add(workPlaces);

                    ViewBag.PassingValue = list;

                    return View(worker);
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {
                    try
                    {
                        Worker worker = db.Workers.Find(id);
                        if (worker == null)
                        {
                            return HttpNotFound();
                        }

                        db.Workers.Remove(worker);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }
    }
}
