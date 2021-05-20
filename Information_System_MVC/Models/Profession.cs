using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Models
{
    public class Profession
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Права в системе")]
        public int Power { get; set; }

        //Связь с рабочими
        public ICollection<Worker> Workers { get; set; }
        //Связь с инструментами
        public ICollection<Equipment> Equipments { get; set; }
        public Profession()
        {
            Workers = new List<Worker>();
            Equipments = new List<Equipment>();
        }
    }
}