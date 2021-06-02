using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Information_System_MVC.Models
{
    public class DbInitializer : CreateDatabaseIfNotExists<ISContext>
    {
        public static void CallSeed()
        {
            DbInitializer db = new DbInitializer();
            db.Seed(new ISContext());
        }
        protected override void Seed(ISContext db)
        {
            db.Professions.Add(new Profession { Name = "Администратор БД", Power = 2 });
            db.Professions.Add(new Profession { Name = "CTO", Power = 2 });
            db.Professions.Add(new Profession { Name = "Бухгалтер", Power = 1 });
            db.Professions.Add(new Profession { Name = "Менеджер", Power = 1 });
            db.Professions.Add(new Profession { Name = "Плотник", Power = 0 });
            db.Professions.Add(new Profession { Name = "Садовник", Power = 0 });
            db.Professions.Add(new Profession { Name = "Аниматор", Power = 0 });
            db.Professions.Add(new Profession { Name = "Повар", Power = 0 });
            db.Professions.Add(new Profession { Name = "Клининг", Power = 0 });
            db.Professions.Add(new Profession { Name = "Бармен", Power = 0 });
            db.Professions.Add(new Profession { Name = "Охранник", Power = 0 });

            db.Products.Add(new Product
            {
                Name = "Пицца пепперони",
                Price = 450,
                Quantity = 500,
                Type = "Еда",
                Description =
                "Пикантная пепперони, увеличенная порция моцареллы, томаты, томатный соус"
            });
            db.Products.Add(new Product
            {
                Name = "Пицца Маргарита",
                Price = 450,
                Quantity = 700,
                Type = "Еда",
                Description =
              "Увеличенная порция моцареллы, томаты, итальянские травы, томатный соус"
            });
            db.Products.Add(new Product
            {
                Name = "Борщ",
                Price = 350,
                Quantity = 800,
                Type = "Еда",
                Description =
             "Свекла, которая придает борщу насыщенный яркий цвет, крепкий мясной бульон из хорошей говядины, свежие овощи"
            });
            db.Products.Add(new Product
            {
                Name = "Яблочный сок",
                Price = 150,
                Quantity = 1500,
                Type = "Напитки",
                Description =
            "Сахар, пектины, крахмалы, энзимы, витамины А, Е, С, Н, группы В, а также минеральные вещества "
            });
            db.Products.Add(new Product
            {
                Name = "Минеравльная вода",
                Price = 100,
                Quantity = 3000,
                Type = "Напитки",
                Description = "Без газ."
            });

            db.Buildings.Add(new Building { RoomCount = 100 });
            db.Buildings.Add(new Building { RoomCount = 150 });
            db.Buildings.Add(new Building { RoomCount = 50 });
            db.Buildings.Add(new Building { RoomCount = 90 });
            db.Buildings.Add(new Building { RoomCount = 200 });

            db.WorkPlaces.Add(new WorkPlace { BuildingId = 1, PlaceId = "1 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 1, PlaceId = "2 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 1, PlaceId = "3 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 1, PlaceId = "4 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 2, PlaceId = "2 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 2, PlaceId = "3 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 2, PlaceId = "4 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 3, PlaceId = "1 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 3, PlaceId = "2 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 3, PlaceId = "3 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 4, PlaceId = "1 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 4, PlaceId = "2 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 5, PlaceId = "1 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 5, PlaceId = "2 этаж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 1, PlaceId = "Кухня" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 1, PlaceId = "Пляж" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 2, PlaceId = "Столовая" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 3, PlaceId = "Столовая" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 4, PlaceId = "Столовая" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 1, PlaceId = "Столовая" });
            db.WorkPlaces.Add(new WorkPlace { BuildingId = 5, PlaceId = "Столовая" });

            db.Workers.Add(new Worker
            {
                Name = "Петр",
                Surname = "Ильич",
                Thirdname = "Дмитриевич",
                Email = "petrIlyich@gmail.com",
                DateOfBirth = DateTime.Parse("12.07.1979"),
                Password = "adm123",
                ProfessionId = 1,
                WorkDays = "ПН,ВТ,СР,ЧТ,ПТ",
                WorkPlaceId = 1
            }); 
            db.Workers.Add(new Worker
            {
                Name = "Никита",
                Surname = "Валирьянов",
                Thirdname = "Эдуардович",
                Email = "nikitaValiryanov@gmail.com",
                DateOfBirth = DateTime.Parse("23.01.1980"),
                Password = "cto123",
                ProfessionId = 2,
                WorkDays = "ПН,ВТ,СР,ЧТ,ПТ",
                WorkPlaceId = 2
            }); 
            db.Workers.Add(new Worker
            {
                Name = "Александр",
                Surname = "Палиам",
                Thirdname = "Александрович",
                Email = "paleyamAlex@gmail.com",
                DateOfBirth = DateTime.Parse("01.01.1991"),
                Password = "adm123",
                ProfessionId = 4,
                WorkDays = "ПН,ВТ,СР,ЧТ,ПТ",
                WorkPlaceId = 3
            });
            db.Workers.Add(new Worker
            {
                Name = "Тимур",
                Surname = "Бабижнов",
                Thirdname = "Владимирович",
                Email = "babizhnovTimur@gmail.com",
                DateOfBirth = DateTime.Parse("02.09.1995"),
                Password = "man123",
                ProfessionId = 4,
                WorkDays = "ПН,ВТ,СР,ЧТ,ПТ",
                WorkPlaceId = 3
            });
            db.Workers.Add(new Worker
            {
                Name = "Владимир",
                Surname = "Пауцов",
                Thirdname = "Александрович",
                Email = "paucovVladimir@gmail.com",
                DateOfBirth = DateTime.Parse("03.10.1983"),
                Password = "work923",
                ProfessionId = 5,
                WorkDays = "ПН,ВТ,СР,ЧТ",
                WorkPlaceId = 5
            });
            db.Workers.Add(new Worker
            {
                Name = "Владимир",
                Surname = "Никтотько",
                Thirdname = "Тимурович",
                Email = "nikotkoVlad@gmail.com",
                DateOfBirth = DateTime.Parse("01.11.1987"),
                Password = "work451",
                ProfessionId = 5,
                WorkDays = "ПН,ВТ,ЧТ,ВС",
                WorkPlaceId = 6
            });
            db.Workers.Add(new Worker
            {
                Name = "Глад",
                Surname = "Вольфрамович",
                Thirdname = "Тигученкович",
                Email = "gladvalakas@gmail.com",
                DateOfBirth = DateTime.Parse("08.12.1992"),
                Password = "work991",
                ProfessionId = 5,
                WorkDays = "ВТ,ЧТ,ПТ",
                WorkPlaceId = 7
            });

            db.Rooms.Add(new Room { IsAvailable = true, Beds = 4, BuildingId = 1, Price = 1000, SingleRooms = 2 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 4, BuildingId = 1, Price = 1000, SingleRooms = 2 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 4, BuildingId = 1, Price = 1000, SingleRooms = 2 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 4, BuildingId = 1, Price = 1000, SingleRooms = 2 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 2, BuildingId = 2, Price = 1000, SingleRooms = 1 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 2, BuildingId = 2, Price = 750, SingleRooms = 1 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 2, BuildingId = 3, Price = 750, SingleRooms = 1 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 2, BuildingId = 3, Price = 750, SingleRooms = 1 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 2, BuildingId = 3, Price = 750, SingleRooms = 1 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 4, BuildingId = 4, Price = 750, SingleRooms = 3 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 4, BuildingId = 4, Price = 750, SingleRooms = 3 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 4, BuildingId = 5, Price = 5000, SingleRooms = 3 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 4, BuildingId = 5, Price = 5000, SingleRooms = 3 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 4, BuildingId = 5, Price = 5000, SingleRooms = 2 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 4, BuildingId = 5, Price = 5000, SingleRooms = 2 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 3, BuildingId = 1, Price = 7600, SingleRooms = 2 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 6, BuildingId = 2, Price = 8900, SingleRooms = 3 });
            db.Rooms.Add(new Room { IsAvailable = true, Beds = 5, BuildingId = 3, Price = 15000, SingleRooms = 4 });
            //[5-11]

            db.Tourists.Add(new Tourist
            {
                Name = "Петр",
                Surname = "Ильич",
                Thirdname = "Дмитриевич",
                Email = "petrIlyich@gmail.com",
                DateOfBirth = DateTime.Parse("12.07.1979"),
                Password = "tour1",
                Country = "Россия",
                DateOfComing = DateTime.Parse("02.08.2021"),
                DateOfLeaving = DateTime.Parse("15.08.2021"),
                RoomId = 1
            });
            db.Tourists.Add(new Tourist
            {
                Name = "Василий",
                Surname = "Кузимяка",
                Thirdname = "Дмитриевич",
                Email = "vasK@gmail.com",
                DateOfBirth = DateTime.Parse("12.07.1979"),
                Password = "tour2",
                Country = "Россия",
                DateOfComing = DateTime.Parse("02.08.2021"),
                DateOfLeaving = DateTime.Parse("15.08.2021"),
                RoomId = 2
            });
            db.Tourists.Add(new Tourist
            {
                Name = "Жанна",
                Surname = "Кузимяка",
                Thirdname = "Владимировна",
                Email = "janK@gmail.com",
                DateOfBirth = DateTime.Parse("12.07.1979"),
                Password = "tour3",
                Country = "Россия",
                DateOfComing = DateTime.Parse("02.08.2021"),
                DateOfLeaving = DateTime.Parse("15.08.2021"),
                RoomId = 2
            });
            db.Tourists.Add(new Tourist
            {
                Name = "Гамаз",
                Surname = "Тагирович",
                Thirdname = "Тагазиров",
                Email = "gamazTag@gmail.com",
                DateOfBirth = DateTime.Parse("12.07.1979"),
                Password = "tour4",
                Country = "Россия",
                DateOfComing = DateTime.Parse("02.08.2021"),
                DateOfLeaving = DateTime.Parse("15.08.2021"),
                RoomId = 3
            });
            db.Tourists.Add(new Tourist
            {
                Name = "Петр",
                Surname = "Терентьев",
                Thirdname = "ППА",
                Email = "petrTer@gmail.com",
                DateOfBirth = DateTime.Parse("12.07.1979"),
                Password = "tour5",
                Country = "Россия",
                DateOfComing = DateTime.Parse("02.08.2021"),
                DateOfLeaving = DateTime.Parse("15.08.2021"),
                RoomId = 5
            });
            db.Tourists.Add(new Tourist
            {
                Name = "Хоссе",
                Surname = "Артега",
                Thirdname = "Жак",
                Email = "hoesseArt@gmail.com",
                DateOfBirth = DateTime.Parse("12.07.1979"),
                Password = "tour5",
                Country = "Аргентина",
                DateOfComing = DateTime.Parse("02.08.2021"),
                DateOfLeaving = DateTime.Parse("15.08.2021"),
                RoomId = 6
            });

            //db.Events.Add(new Event
            //{
            //    Name = "Дискотека",
            //    Date = DateTime.Parse("24.06.2021"),
            //    Price = 200,
            //    Quantity = 350,
            //    WorkPlaceId = 1,
            //    Description = "Приходите будет весело"
            //});
            //db.Events.Add(new Event
            //{
            //    Name = "Караоке",
            //    Date = DateTime.Parse("23.06.2021"),
            //    Price = 200,
            //    Quantity = 450,
            //    WorkPlaceId = 1,
            //    Description = "Приходите будет весело"
            //});
            //db.Events.Add(new Event
            //{
            //    Name = "Танцы",
            //    Date = DateTime.Parse("22.06.2021"),
            //    Price = 200,
            //    Quantity = 550,
            //    WorkPlaceId = 1,
            //    Description = "Приходите будет весело"
            //});

            base.Seed(db);
        }
    }
}