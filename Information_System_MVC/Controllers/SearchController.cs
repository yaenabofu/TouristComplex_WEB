﻿using ClosedXML.Excel;
using Information_System_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Information_System_MVC.Controllers
{
    public class SearchController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Export(Answer answer)
        {
            dynamic list = null;
            string json = answer.JsonFile;

            if (answer.Type[0] == "Information_System_MVC.Models.BookedTickets")
            {
                list = JsonConvert.DeserializeObject<List<BookedTicket>>(json);
            }
            if (answer.Type[0] == "Information_System_MVC.Models.Building")
            {
                list = JsonConvert.DeserializeObject<List<Building>>(json);
            }
            if (answer.Type[0] == "Information_System_MVC.Models.Equipment")
            {
                list = JsonConvert.DeserializeObject<List<Equipment>>(json);
            }
            if (answer.Type[0] == "Information_System_MVC.Models.Event")
            {
                list = JsonConvert.DeserializeObject<List<Event>>(json);
            }
            if (answer.Type[0] == "Information_System_MVC.Models.Order")
            {
                list = JsonConvert.DeserializeObject<List<Order>>(json);
            }
            if (answer.Type[0] == "Information_System_MVC.Models.Product")
            {
                list = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            if (answer.Type[0] == "Information_System_MVC.Models.Profession")
            {
                list = JsonConvert.DeserializeObject<List<Profession>>(json);
            }
            if (answer.Type[0] == "Information_System_MVC.Models.Room")
            {
                list = JsonConvert.DeserializeObject<List<Room>>(json);
            }
            if (answer.Type[0] == "Information_System_MVC.Models.Tourist")
            {
                list = JsonConvert.DeserializeObject<List<Tourist>>(json);
            }
            if (answer.Type[0] == "Information_System_MVC.Models.Worker")
            {
                list = JsonConvert.DeserializeObject<List<Worker>>(json);
            }
            if (answer.Type[0] == "Information_System_MVC.Models.WorkPlace")
            {
                list = JsonConvert.DeserializeObject<List<WorkPlace>>(json);
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Отчет");
                var currentRow = 1;

                if (list is List<BookedTicket>)
                {
                    worksheet.Cell(currentRow, 1).Value = "Код записи";
                    worksheet.Cell(currentRow, 2).Value = "Количество";
                    worksheet.Cell(currentRow, 3).Value = "Стоимость";
                    worksheet.Cell(currentRow, 4).Value = "Оплачен ?";
                    worksheet.Cell(currentRow, 5).Value = "Код мероприятия";
                    worksheet.Cell(currentRow, 6).Value = "Логин туриста";
                }
                if (list is List<Building>)
                {
                    worksheet.Cell(currentRow, 1).Value = "Код здания";
                    worksheet.Cell(currentRow, 2).Value = "Количество номеров";
                }
                if (list is List<Equipment>)
                {
                    worksheet.Cell(currentRow, 1).Value = "Код оборудования";
                    worksheet.Cell(currentRow, 2).Value = "Название";
                    worksheet.Cell(currentRow, 3).Value = "Количество";
                    worksheet.Cell(currentRow, 4).Value = "Код профессии";
                }
                if (list is List<Event>)
                {
                    worksheet.Cell(currentRow, 1).Value = "Код записи";
                    worksheet.Cell(currentRow, 2).Value = "Название";
                    worksheet.Cell(currentRow, 3).Value = "Цена";
                    worksheet.Cell(currentRow, 4).Value = "Описание";
                    worksheet.Cell(currentRow, 5).Value = "Дата проведения";
                    worksheet.Cell(currentRow, 6).Value = "Количество билетов";
                    worksheet.Cell(currentRow, 6).Value = "Код рабочего места";
                }
                if (list is List<Order>)
                {

                    worksheet.Cell(currentRow, 1).Value = "Код записи";
                    worksheet.Cell(currentRow, 2).Value = "Количество";
                    worksheet.Cell(currentRow, 3).Value = "Стоимость";
                    worksheet.Cell(currentRow, 4).Value = "Дата заказа";
                    worksheet.Cell(currentRow, 5).Value = "Оплачен ?";
                    worksheet.Cell(currentRow, 6).Value = "Логин туриста";
                    worksheet.Cell(currentRow, 6).Value = "Код товара";
                }
                if (list is List<Product>)
                {
                    worksheet.Cell(currentRow, 1).Value = "Код записи";
                    worksheet.Cell(currentRow, 2).Value = "Название";
                    worksheet.Cell(currentRow, 3).Value = "Цена";
                    worksheet.Cell(currentRow, 4).Value = "Описание";
                    worksheet.Cell(currentRow, 5).Value = "Вид";
                    worksheet.Cell(currentRow, 6).Value = "Количество";
                }
                if (list is List<Profession>)
                {
                    worksheet.Cell(currentRow, 1).Value = "Код профессии";
                    worksheet.Cell(currentRow, 2).Value = "Название";
                    worksheet.Cell(currentRow, 3).Value = "Уровень прав в системе";
                }
                if (list is List<Room>)
                {
                    worksheet.Cell(currentRow, 1).Value = "Код номера";
                    worksheet.Cell(currentRow, 2).Value = "Цена";
                    worksheet.Cell(currentRow, 3).Value = "Количество кроватей";
                    worksheet.Cell(currentRow, 4).Value = "Количество комнат";
                    worksheet.Cell(currentRow, 5).Value = "Свободен ?";
                    worksheet.Cell(currentRow, 6).Value = "Код здания";
                }
                if (list is List<Tourist>)
                {
                    worksheet.Cell(currentRow, 1).Value = "Логин";
                    worksheet.Cell(currentRow, 2).Value = "Пароль";
                    worksheet.Cell(currentRow, 3).Value = "Эл почта";
                    worksheet.Cell(currentRow, 4).Value = "Имя";
                    worksheet.Cell(currentRow, 5).Value = "Фамилия";
                    worksheet.Cell(currentRow, 6).Value = "Отчество";
                    worksheet.Cell(currentRow, 7).Value = "Дата рождения";
                    worksheet.Cell(currentRow, 8).Value = "Дата приезда";
                    worksheet.Cell(currentRow, 9).Value = "Дата отъезда";
                    worksheet.Cell(currentRow, 10).Value = "Страна";
                    worksheet.Cell(currentRow, 11).Value = "Номер комнаты";
                }
                if (list is List<Worker>)
                {
                    worksheet.Cell(currentRow, 1).Value = "Логин";
                    worksheet.Cell(currentRow, 2).Value = "Пароль";
                    worksheet.Cell(currentRow, 3).Value = "Имя";
                    worksheet.Cell(currentRow, 4).Value = "Фамилия";
                    worksheet.Cell(currentRow, 5).Value = "Отчество";
                    worksheet.Cell(currentRow, 6).Value = "Дата рождения";
                    worksheet.Cell(currentRow, 7).Value = "Эл почта";
                    worksheet.Cell(currentRow, 8).Value = "Рабочие дни";
                    worksheet.Cell(currentRow, 9).Value = "Код профессии";
                    worksheet.Cell(currentRow, 10).Value = "Код рабочего места";
                }
                if (list is List<WorkPlace>)
                {
                    worksheet.Cell(currentRow, 1).Value = "Код записи";
                    worksheet.Cell(currentRow, 2).Value = "Код места";
                    worksheet.Cell(currentRow, 3).Value = "Код здания";
                }
                foreach (var item in list)
                {
                    currentRow++;
                    if (list is List<BookedTicket>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as BookedTicket).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as BookedTicket).Quantity;
                        worksheet.Cell(currentRow, 3).Value = (item as BookedTicket).Cost;
                        worksheet.Cell(currentRow, 4).Value = (item as BookedTicket).IsPaid.ToString();
                        worksheet.Cell(currentRow, 5).Value = (item as BookedTicket).EventId;
                        worksheet.Cell(currentRow, 6).Value = (item as BookedTicket).TouristId;
                    }
                    if (list is List<Building>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as Building).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as Building).RoomCount;
                    }
                    if (list is List<Equipment>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as Equipment).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as Equipment).Name;
                        worksheet.Cell(currentRow, 3).Value = (item as Equipment).Quantity;
                        worksheet.Cell(currentRow, 4).Value = (item as Equipment).ProfessionId;
                    }
                    if (list is List<Event>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as Event).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as Event).Name;
                        worksheet.Cell(currentRow, 3).Value = (item as Event).Price;
                        worksheet.Cell(currentRow, 4).Value = (item as Event).Description;
                        worksheet.Cell(currentRow, 5).Value = (item as Event).Date;
                        worksheet.Cell(currentRow, 6).Value = (item as Event).Quantity;
                        worksheet.Cell(currentRow, 7).Value = (item as Event).WorkPlaceId;
                    }
                    if (list is List<Order>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as Order).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as Order).Quantity;
                        worksheet.Cell(currentRow, 3).Value = (item as Order).Cost;
                        worksheet.Cell(currentRow, 4).Value = (item as Order).DateOrder;
                        worksheet.Cell(currentRow, 5).Value = (item as Order).IsDone.ToString();
                        worksheet.Cell(currentRow, 6).Value = (item as Order).TouristId;
                        worksheet.Cell(currentRow, 7).Value = (item as Order).ProductId;
                    }
                    if (list is List<Product>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as Product).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as Product).Name;
                        worksheet.Cell(currentRow, 3).Value = (item as Product).Price;
                        worksheet.Cell(currentRow, 4).Value = (item as Product).Description;
                        worksheet.Cell(currentRow, 5).Value = (item as Product).Type;
                        worksheet.Cell(currentRow, 6).Value = (item as Product).Quantity;
                    }
                    if (list is List<Profession>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as Profession).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as Profession).Name;
                        worksheet.Cell(currentRow, 3).Value = (item as Profession).Power;
                    }
                    if (list is List<Room>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as Room).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as Room).Price;
                        worksheet.Cell(currentRow, 3).Value = (item as Room).Beds;
                        worksheet.Cell(currentRow, 4).Value = (item as Room).SingleRooms;
                        worksheet.Cell(currentRow, 5).Value = (item as Room).IsAvailable.ToString();
                        worksheet.Cell(currentRow, 6).Value = (item as Room).BuildingId;
                    }
                    if (list is List<Tourist>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as Tourist).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as Tourist).Password;
                        worksheet.Cell(currentRow, 3).Value = (item as Tourist).Email;
                        worksheet.Cell(currentRow, 4).Value = (item as Tourist).Name;
                        worksheet.Cell(currentRow, 5).Value = (item as Tourist).Surname;
                        worksheet.Cell(currentRow, 6).Value = (item as Tourist).Thirdname;
                        worksheet.Cell(currentRow, 7).Value = (item as Tourist).DateOfBirth;
                        worksheet.Cell(currentRow, 8).Value = (item as Tourist).DateOfComing;
                        worksheet.Cell(currentRow, 9).Value = (item as Tourist).DateOfLeaving;
                        worksheet.Cell(currentRow, 10).Value = (item as Tourist).Country;
                        worksheet.Cell(currentRow, 11).Value = (item as Tourist).RoomId;

                    }
                    if (list is List<Worker>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as Worker).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as Worker).Password;
                        worksheet.Cell(currentRow, 3).Value = (item as Worker).Name;
                        worksheet.Cell(currentRow, 4).Value = (item as Worker).Surname;
                        worksheet.Cell(currentRow, 5).Value = (item as Worker).Thirdname;
                        worksheet.Cell(currentRow, 6).Value = (item as Worker).DateOfBirth;
                        worksheet.Cell(currentRow, 7).Value = (item as Worker).Email;
                        worksheet.Cell(currentRow, 8).Value = (item as Worker).WorkDays;
                        worksheet.Cell(currentRow, 9).Value = (item as Worker).ProfessionId;
                        worksheet.Cell(currentRow, 10).Value = (item as Worker).WorkPlaceId;
                    }
                    if (list is List<WorkPlace>)
                    {
                        worksheet.Cell(currentRow, 1).Value = (item as WorkPlace).Id;
                        worksheet.Cell(currentRow, 2).Value = (item as WorkPlace).PlaceId;
                        worksheet.Cell(currentRow, 3).Value = (item as WorkPlace).BuildingId;
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"отчет за {DateTime.Now.ToShortDateString()}.xls");
                }
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Find(Request request)
        {
            try
            {
                dynamic res = null;
                dynamic obj = null;
                using (ISContext db = new ISContext())
                {
                    if (request.Obj == "Workers")
                    {
                        res = db.Database.SqlQuery<Worker>(request.RequestString).ToList();
                        obj = new Worker();
                    }
                    if (request.Obj == "BookedTickets")
                    {
                        res = db.Database.SqlQuery<BookedTicket>(request.RequestString).ToList();
                        obj = new BookedTicket();
                    }
                    if (request.Obj == "Buildings")
                    {
                        res = db.Database.SqlQuery<Building>(request.RequestString).ToList();
                        obj = new Building();
                    }
                    if (request.Obj == "Equipments")
                    {
                        res = db.Database.SqlQuery<Equipment>(request.RequestString).ToList();
                        obj = new Equipment();
                    }
                    if (request.Obj == "Events")
                    {
                        res = db.Database.SqlQuery<Event>(request.RequestString).ToList();
                        obj = new Event();
                    }
                    if (request.Obj == "Orders")
                    {
                        res = db.Database.SqlQuery<Order>(request.RequestString).ToList();
                        obj = new Order();
                    }
                    if (request.Obj == "Products")
                    {
                        res = db.Database.SqlQuery<Product>(request.RequestString).ToList();
                        obj = new Product();
                    }
                    if (request.Obj == "Professions")
                    {
                        res = db.Database.SqlQuery<Profession>(request.RequestString).ToList();
                        obj = new Profession();
                    }
                    if (request.Obj == "Rooms")
                    {
                        res = db.Database.SqlQuery<Room>(request.RequestString).ToList();
                        obj = new Room();
                    }
                    if (request.Obj == "Tourists")
                    {
                        res = db.Database.SqlQuery<Tourist>(request.RequestString).ToList();
                        obj = new Tourist();
                    }
                    if (request.Obj == "WorkPlaces")
                    {
                        res = db.Database.SqlQuery<WorkPlace>(request.RequestString).ToList();
                        obj = new WorkPlace();
                    }

                }

                Answer answer = new Answer
                {
                    RequestString = request.RequestString,
                    SearchResultObjects = res,
                    Type = obj,
                    JsonFile = JsonConvert.SerializeObject(res)
                };

                return View(answer);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
    }
}