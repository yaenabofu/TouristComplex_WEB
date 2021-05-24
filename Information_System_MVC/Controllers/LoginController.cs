using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Information_System_MVC.Controllers
{
    public class LoginController : Controller
    {
        ISContext db = new ISContext();
        public ActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enter(User user)
        {
            Object obj = null;

            if (IsTourist(user))
            {
                obj = db.Tourists.Find(user.Login);
            }

            if (IsWorker(user))
            {
                obj = db.Workers.Find(user.Login);
            }

            if (obj != null)
            {
                System.Web.HttpContext.Current.Session["CurrentUser"] = obj;

                FormsAuthentication.SetAuthCookie(user.Password, true);

                return Redirect("/Home/Index/");
            }

            return View("Не удалось войти в систему");
        }
        private bool IsTourist(User user)
        {
            Tourist temp = db.Tourists.Find(user.Login);

            if (temp != null && temp.Password == user.Password)
                return true;

            return false;
        }
        private bool IsWorker(User user)
        {
            Worker temp = db.Workers.Find(user.Login);

            if (temp != null && temp.Password == user.Password)
                return true;

            return false;
        }
    }
}
