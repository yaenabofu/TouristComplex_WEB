using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Models
{
    public class Equipment
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        //Связь с профессией
        [Display(Name = "Код профессии")]
        public int? ProfessionId { get; set; }

        public Profession Profession { get; set; }
    }
}