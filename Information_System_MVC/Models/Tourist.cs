using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Models
{
    public class Tourist
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Эл. почта")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string Thirdname { get; set; }
        [Required]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Дата приезда")]
        public DateTime DateOfComing { get; set; }
        [Required]
        [Display(Name = "Дата отъезда")]
        public DateTime DateOfLeaving { get; set; }
        [Required]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        //Связь с комнатой
        public Room Room { get; set; }
        [Display(Name = "Код номера")]
        public int? RoomId { get; set; }
        //Связь с забронированными билетами
        public ICollection<BookedTicket> BookedTickets { get; set; }
        public Tourist()
        {
            BookedTickets = new List<BookedTicket>();
        }
    }
}