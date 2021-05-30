using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Information_System_MVC.Models
{
    public class Answer
    {
        public string RequestString { get; set; }
        public dynamic SearchResultObjects { get; set; }
        public dynamic Type { get; set; }
        public string JsonFile { get; set; }
    }
}