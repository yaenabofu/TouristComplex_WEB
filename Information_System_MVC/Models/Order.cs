using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Models
{
    public class Order
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Стоимость")]
        public double Cost { get; set; }
        [Required]
        [Display(Name = "Дата заказа")]
        public DateTime DateOrder { get; set; }
        [Required]
        [Display(Name = "Оплачен?")]
        public bool IsDone { get; set; }

        //Связь с туристом
        public Tourist Tourist { get; set; }
        [Display(Name = "Код туриста")]
        [Required]
        public int? TouristId { get; set; }
        //Связь с товаром
        public Product Product { get; set; }
        [Display(Name = "Код товара")]
        [Required]
        public int? ProductId { get; set; }
    }
}