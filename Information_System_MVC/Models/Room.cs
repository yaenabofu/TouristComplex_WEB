using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Models
{
    public class Room
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Количество кроватей")]
        public int Beds { get; set; }
        [Required]
        [Display(Name = "Количество комнат")]
        public int SingleRooms { get; set; }
        [Required]
        [Display(Name = "Свободен?")]
        public bool IsAvailable { get; set; }

        //Связь со зданием
        [Display(Name = "Код здания")]
        [Required]
        public int? BuildingId { get; set; }
        public Building Building { get; set; }

        //Связь с туристами
        public ICollection<Tourist> Tourists { get; set; }
        //Связь с заказами
        public ICollection<Order> Orders { get; set; }
        public Room()
        {
            Orders = new List<Order>();
            Tourists = new List<Tourist>();
        }
    }
}