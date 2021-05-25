using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Information_System_MVC.Models
{
    public class ConnectedWorker
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Thirdname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string WorkDays { get; set; }
        public int? ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public int? WorkPlaceId { get; set; }
        public int Power { get; set; }
    }
}