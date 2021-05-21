using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class HomeController : Controller
    {
        ISContext db = new ISContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            IEnumerable<Profession> professions = db.Professions;

            ViewBag.Professions = professions;

            return View();
        }
    }
}
