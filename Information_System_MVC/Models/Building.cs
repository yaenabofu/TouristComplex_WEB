using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Models
{
    public class Building
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Кол-во комнат")]
        public int RoomCount { get; set; }
        //Связь с рабочими местами
        public ICollection<WorkPlace> WorkPlaces { get; set; }
        //Связь с комнатами
        public ICollection<Room> Rooms { get; set; }
        public Building()
        {
            Rooms = new List<Room>();
            WorkPlaces = new List<WorkPlace>();
        }
    }
}