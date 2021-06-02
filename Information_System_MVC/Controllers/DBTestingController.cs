using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Information_System_MVC.Controllers
{
    public class DBTestingController : Controller
    {
        // GET: DBTesting
        [Authorize]
        public ActionResult Seed()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2)
                {
                    DbInitializer.CallSeed();
                    FormsAuthentication.SignOut();
                    return Redirect("/Login/Enter");
                }
                else
                    return HttpNotFound();
            }
            return HttpNotFound();
        }
    }
}