using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Information_System_MVC.Models
{
    public class User
    {
        public int Login { get; set; }
        public string Password { get; set; }
        public string Captcha { get; set; }
    }
}