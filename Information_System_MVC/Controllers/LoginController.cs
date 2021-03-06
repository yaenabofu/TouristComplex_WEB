using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Information_System_MVC.Controllers
{
    public class LoginController : Controller
    {
        ISContext db = new ISContext();

        public ActionResult Captcha()
        {
            string code = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
            Session["code"] = code;
            CaptchaImage captcha = new CaptchaImage(code, 110, 50);

            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            captcha.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            captcha.Dispose();
            return null;
        }

        public ActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enter(User user)
        {
            if (user.Captcha != (string)Session["code"])
            {
                ModelState.AddModelError("Captcha", "Текст с картинки введен неверно");
            }
            if (ModelState.IsValid)
            {
                Object obj = null;

                if (IsTourist(user))
                {
                    obj = db.Tourists.Find(user.Login);
                }

                if (IsWorker(user))
                {
                    obj = db.Workers.Find(user.Login);
                    Profession prof = db.Professions.Find((obj as Worker).ProfessionId);

                    ConnectedWorker conWorker = new ConnectedWorker
                    {
                        Id = (obj as Worker).Id,
                        DateOfBirth = (obj as Worker).DateOfBirth,
                        Email = (obj as Worker).Email,
                        Name = (obj as Worker).Name,
                        Password = (obj as Worker).Password,
                        ProfessionId = (obj as Worker).ProfessionId,
                        Surname = (obj as Worker).Surname,
                        Thirdname = (obj as Worker).Thirdname,
                        WorkDays = (obj as Worker).WorkDays,
                        WorkPlaceId = (obj as Worker).WorkPlaceId,
                        Power = prof.Power
                    };

                    obj = conWorker;
                }

                if (obj != null)
                {
                    System.Web.HttpContext.Current.Session["CurrentUser"] = obj;

                    FormsAuthentication.SetAuthCookie(user.Password, true);

                    return Redirect("/Home/Index/");
                }
            }

            return Redirect("/Login/Error/");
        }

        public ActionResult Error()
        {
            return View();
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
