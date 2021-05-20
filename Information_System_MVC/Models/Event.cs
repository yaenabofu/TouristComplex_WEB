using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Models
{
    public class Event
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Дата проведения")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        //Связь с рабочим местом
        [Display(Name = "Код рабочего места")]
        public int? WorkPlaceId { get; set; }
        public WorkPlace WorkPlace { get; set; }
        //Связь с забронированными билетами
        public ICollection<BookedTicket> BookedTickets { get; set; }
        public Event()
        {
            BookedTickets = new List<BookedTicket>();
        }
    }
}