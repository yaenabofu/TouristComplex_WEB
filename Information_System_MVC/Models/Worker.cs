using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Models
{
    public class Worker
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Display(Name = "Пароль")]
        [Required]
        public string Password { get; set; }
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
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Рабочие дни")]
        public string WorkDays { get; set; }

        //Связь с профессией 
        [Display(Name = "Код профессии")]
        [Required]
        public int? ProfessionId { get; set; }
        public Profession Profession { get; set; }
        //Связь с рабочим местом
        [Display(Name = "Код рабочего места")]
        [Required]
        public int? WorkPlaceId { get; set; }
        public WorkPlace WorkPlace { get; set; }
    }
}