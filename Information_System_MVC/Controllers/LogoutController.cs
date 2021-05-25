using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Information_System_MVC.Controllers
{
    public class LogoutController : Controller
    {
        ISContext db = new ISContext();
        
        [Authorize]
        [HttpGet]
        public ActionResult Index(int id)
        {
            Worker worker = db.Workers.Find(id);

            return View(worker);
        }

        [Authorize]
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Login/Enter");
        }
    }
}
