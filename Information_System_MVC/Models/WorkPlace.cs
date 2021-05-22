using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Models
{
    public class WorkPlace
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Код места в здании")]
        public string PlaceId { get; set; }

        //Связь со зданием
        [Display(Name = "Код здания")]
        [Required]
        public int? BuildingId { get; set; }
        public Building Building { get; set; }

        //Связь с рабочими
        public ICollection<Worker> Workers { get; set; }
        //Связь с мероприятиями
        public ICollection<Event> Events { get; set; }
        public WorkPlace()
        {
            Workers = new List<Worker>();
            Events = new List<Event>();
        }
    }
}