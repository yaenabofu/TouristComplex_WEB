using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Models
{
    public class BookedTicket
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
        [Display(Name = "Логин туриста")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Оплачен?")]
        public bool IsPaid { get; set; }

        //Связи
        [Required]
        [Display(Name = "Код мероприятия")]
        public int? EventId { get; set; }
        public Event Event { get; set; }
        [Display(Name = "Код туриста")]
        [Required]
        public int? TouristId { get; set; }
        public Tourist Tourist { get; set; }
    }
}