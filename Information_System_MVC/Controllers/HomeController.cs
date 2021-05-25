using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Information_System_MVC.Controllers
{
    public class HomeController : Controller
    {
        ISContext db = new ISContext();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult PersonalData()
        {
            object obj = System.Web.HttpContext.Current.Session["CurrentUser"];

            return View(obj);
        }
    }
}
