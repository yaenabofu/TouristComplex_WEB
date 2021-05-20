using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Information_System_MVC.Models
{
    public class ISContext : DbContext
    {
        public DbSet<Profession> Professions { get; set; }
        public DbSet<BookedTicket> BookedTickets { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
    }
}