using ClosedXML.Excel;
using Information_System_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Ajax.Utilities;
using Microsoft.Office.Interop.Word;

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
                var currentRowCount = 1;

                if (list is List<BookedTicket>)
                {
                    worksheet.Cell(currentRowCount, 1).Value = "Код записи";
                    worksheet.Cell(currentRowCount, 2).Value = "Количество";
                    worksheet.Cell(currentRowCount, 3).Value = "Стоимость";
                    worksheet.Cell(currentRowCount, 4).Value = "Оплачен ?";
                    worksheet.Cell(currentRowCount, 5).Value = "Код мероприятия";
                    worksheet.Cell(currentRowCount, 6).Value = "Логин туриста";
                }
                if (list is List<Building>)
                {
                    worksheet.Cell(currentRowCount, 1).Value = "Код здания";
                    worksheet.Cell(currentRowCount, 2).Value = "Количество номеров";
                }
                if (list is List<Equipment>)
                {
                    worksheet.Cell(currentRowCount, 1).Value = "Код оборудования";
                    worksheet.Cell(currentRowCount, 2).Value = "Название";
                    worksheet.Cell(currentRowCount, 3).Value = "Количество";
                    worksheet.Cell(currentRowCount, 4).Value = "Код профессии";
                }
                if (list is List<Event>)
                {
                    worksheet.Cell(currentRowCount, 1).Value = "Код записи";
                    worksheet.Cell(currentRowCount, 2).Value = "Название";
                    worksheet.Cell(currentRowCount, 3).Value = "Цена";
                    worksheet.Cell(currentRowCount, 4).Value = "Описание";
                    worksheet.Cell(currentRowCount, 5).Value = "Дата проведения";
                    worksheet.Cell(currentRowCount, 6).Value = "Количество билетов";
                    worksheet.Cell(currentRowCount, 6).Value = "Код рабочего места";
                }
                if (list is List<Order>)
                {

                    worksheet.Cell(currentRowCount, 1).Value = "Код записи";
                    worksheet.Cell(currentRowCount, 2).Value = "Количество";
                    worksheet.Cell(currentRowCount, 3).Value = "Стоимость";
                    worksheet.Cell(currentRowCount, 4).Value = "Дата заказа";
                    worksheet.Cell(currentRowCount, 5).Value = "Оплачен ?";
                    worksheet.Cell(currentRowCount, 6).Value = "Логин туриста";
                    worksheet.Cell(currentRowCount, 6).Value = "Код товара";
                }
                if (list is List<Product>)
                {
                    worksheet.Cell(currentRowCount, 1).Value = "Код записи";
                    worksheet.Cell(currentRowCount, 2).Value = "Название";
                    worksheet.Cell(currentRowCount, 3).Value = "Цена";
                    worksheet.Cell(currentRowCount, 4).Value = "Описание";
                    worksheet.Cell(currentRowCount, 5).Value = "Вид";
                    worksheet.Cell(currentRowCount, 6).Value = "Количество";
                }
                if (list is List<Profession>)
                {
                    worksheet.Cell(currentRowCount, 1).Value = "Код профессии";
                    worksheet.Cell(currentRowCount, 2).Value = "Название";
                    worksheet.Cell(currentRowCount, 3).Value = "Уровень прав в системе";
                }
                if (list is List<Room>)
                {
                    worksheet.Cell(currentRowCount, 1).Value = "Код номера";
                    worksheet.Cell(currentRowCount, 2).Value = "Цена";
                    worksheet.Cell(currentRowCount, 3).Value = "Количество кроватей";
                    worksheet.Cell(currentRowCount, 4).Value = "Количество комнат";
                    worksheet.Cell(currentRowCount, 5).Value = "Свободен ?";
                    worksheet.Cell(currentRowCount, 6).Value = "Код здания";
                }
                if (list is List<Tourist>)
                {
                    worksheet.Cell(currentRowCount, 1).Value = "Логин";
                    worksheet.Cell(currentRowCount, 2).Value = "Пароль";
                    worksheet.Cell(currentRowCount, 3).Value = "Эл почта";
                    worksheet.Cell(currentRowCount, 4).Value = "Имя";
                    worksheet.Cell(currentRowCount, 5).Value = "Фамилия";
                    worksheet.Cell(currentRowCount, 6).Value = "Отчество";
                    worksheet.Cell(currentRowCount, 7).Value = "Дата рождения";
                    worksheet.Cell(currentRowCount, 8).Value = "Дата приезда";
                    worksheet.Cell(currentRowCount, 9).Value = "Дата отъезда";
                    worksheet.Cell(currentRowCount, 10).Value = "Страна";
                    worksheet.Cell(currentRowCount, 11).Value = "Номер комнаты";
                }
                if (list is List<Worker>)
                {
                    worksheet.Cell(currentRowCount, 1).Value = "Логин";
                    worksheet.Cell(currentRowCount, 2).Value = "Пароль";
                    worksheet.Cell(currentRowCount, 3).Value = "Имя";
                    worksheet.Cell(currentRowCount, 4).Value = "Фамилия";
                    worksheet.Cell(currentRowCount, 5).Value = "Отчество";
                    worksheet.Cell(currentRowCount, 6).Value = "Дата рождения";
                    worksheet.Cell(currentRowCount, 7).Value = "Эл почта";
                    worksheet.Cell(currentRowCount, 8).Value = "Рабочие дни";
                    worksheet.Cell(currentRowCount, 9).Value = "Код профессии";
                    worksheet.Cell(currentRowCount, 10).Value = "Код рабочего места";
                }
                if (list is List<WorkPlace>)
                {
                    worksheet.Cell(currentRowCount, 1).Value = "Код записи";
                    worksheet.Cell(currentRowCount, 2).Value = "Код места";
                    worksheet.Cell(currentRowCount, 3).Value = "Код здания";
                }
                foreach (var item in list)
                {
                    currentRowCount++;
                    if (list is List<BookedTicket>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as BookedTicket).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as BookedTicket).Quantity;
                        worksheet.Cell(currentRowCount, 3).Value = (item as BookedTicket).Cost;
                        worksheet.Cell(currentRowCount, 4).Value = (item as BookedTicket).IsPaid.ToString();
                        worksheet.Cell(currentRowCount, 5).Value = (item as BookedTicket).EventId;
                        worksheet.Cell(currentRowCount, 6).Value = (item as BookedTicket).TouristId;
                    }
                    if (list is List<Building>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as Building).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as Building).RoomCount;
                    }
                    if (list is List<Equipment>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as Equipment).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as Equipment).Name;
                        worksheet.Cell(currentRowCount, 3).Value = (item as Equipment).Quantity;
                        worksheet.Cell(currentRowCount, 4).Value = (item as Equipment).ProfessionId;
                    }
                    if (list is List<Event>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as Event).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as Event).Name;
                        worksheet.Cell(currentRowCount, 3).Value = (item as Event).Price;
                        worksheet.Cell(currentRowCount, 4).Value = (item as Event).Description;
                        worksheet.Cell(currentRowCount, 5).Value = (item as Event).Date;
                        worksheet.Cell(currentRowCount, 6).Value = (item as Event).Quantity;
                        worksheet.Cell(currentRowCount, 7).Value = (item as Event).WorkPlaceId;
                    }
                    if (list is List<Order>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as Order).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as Order).Quantity;
                        worksheet.Cell(currentRowCount, 3).Value = (item as Order).Cost;
                        worksheet.Cell(currentRowCount, 4).Value = (item as Order).DateOrder;
                        worksheet.Cell(currentRowCount, 5).Value = (item as Order).IsDone.ToString();
                        worksheet.Cell(currentRowCount, 6).Value = (item as Order).TouristId;
                        worksheet.Cell(currentRowCount, 7).Value = (item as Order).ProductId;
                    }
                    if (list is List<Product>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as Product).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as Product).Name;
                        worksheet.Cell(currentRowCount, 3).Value = (item as Product).Price;
                        worksheet.Cell(currentRowCount, 4).Value = (item as Product).Description;
                        worksheet.Cell(currentRowCount, 5).Value = (item as Product).Type;
                        worksheet.Cell(currentRowCount, 6).Value = (item as Product).Quantity;
                    }
                    if (list is List<Profession>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as Profession).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as Profession).Name;
                        worksheet.Cell(currentRowCount, 3).Value = (item as Profession).Power;
                    }
                    if (list is List<Room>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as Room).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as Room).Price;
                        worksheet.Cell(currentRowCount, 3).Value = (item as Room).Beds;
                        worksheet.Cell(currentRowCount, 4).Value = (item as Room).SingleRooms;
                        worksheet.Cell(currentRowCount, 5).Value = (item as Room).IsAvailable.ToString();
                        worksheet.Cell(currentRowCount, 6).Value = (item as Room).BuildingId;
                    }
                    if (list is List<Tourist>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as Tourist).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as Tourist).Password;
                        worksheet.Cell(currentRowCount, 3).Value = (item as Tourist).Email;
                        worksheet.Cell(currentRowCount, 4).Value = (item as Tourist).Name;
                        worksheet.Cell(currentRowCount, 5).Value = (item as Tourist).Surname;
                        worksheet.Cell(currentRowCount, 6).Value = (item as Tourist).Thirdname;
                        worksheet.Cell(currentRowCount, 7).Value = (item as Tourist).DateOfBirth;
                        worksheet.Cell(currentRowCount, 8).Value = (item as Tourist).DateOfComing;
                        worksheet.Cell(currentRowCount, 9).Value = (item as Tourist).DateOfLeaving;
                        worksheet.Cell(currentRowCount, 10).Value = (item as Tourist).Country;
                        worksheet.Cell(currentRowCount, 11).Value = (item as Tourist).RoomId;

                    }
                    if (list is List<Worker>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as Worker).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as Worker).Password;
                        worksheet.Cell(currentRowCount, 3).Value = (item as Worker).Name;
                        worksheet.Cell(currentRowCount, 4).Value = (item as Worker).Surname;
                        worksheet.Cell(currentRowCount, 5).Value = (item as Worker).Thirdname;
                        worksheet.Cell(currentRowCount, 6).Value = (item as Worker).DateOfBirth;
                        worksheet.Cell(currentRowCount, 7).Value = (item as Worker).Email;
                        worksheet.Cell(currentRowCount, 8).Value = (item as Worker).WorkDays;
                        worksheet.Cell(currentRowCount, 9).Value = (item as Worker).ProfessionId;
                        worksheet.Cell(currentRowCount, 10).Value = (item as Worker).WorkPlaceId;
                    }
                    if (list is List<WorkPlace>)
                    {
                        worksheet.Cell(currentRowCount, 1).Value = (item as WorkPlace).Id;
                        worksheet.Cell(currentRowCount, 2).Value = (item as WorkPlace).PlaceId;
                        worksheet.Cell(currentRowCount, 3).Value = (item as WorkPlace).BuildingId;
                    }
                }

                for (int i = 1; i <= currentRowCount; i++)
                {
                    for (int j = 1; j <= worksheet.ColumnsUsed().Count(); j++)
                    {
                        if (i == 1)
                        {
                            worksheet.Cell(i, j).Style.Font.Bold = true;
                        }
                        worksheet.Cell(i, j).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    }
                }

                worksheet.Cell(currentRowCount, worksheet.Columns().Count() + 2).Value = "Всего записей";
                worksheet.Cell(currentRowCount, worksheet.Columns().Count() + 1).Style.Font.Bold = true;
                worksheet.Cell(currentRowCount, worksheet.Columns().Count() + 2).Value = currentRowCount - 1;

                worksheet.Columns().AdjustToContents();
                worksheet.Rows().AdjustToContents();

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

        //[HttpPost]
        //[Authorize]
        //public ActionResult ExportWord(Answer answer)
        //{
        //    dynamic list = null;
        //    string json = answer.JsonFile;

        //    if (answer.Type[0] == "Information_System_MVC.Models.BookedTickets")
        //    {
        //        list = JsonConvert.DeserializeObject<List<BookedTicket>>(json);
        //    }
        //    if (answer.Type[0] == "Information_System_MVC.Models.Building")
        //    {
        //        list = JsonConvert.DeserializeObject<List<Building>>(json);
        //    }
        //    if (answer.Type[0] == "Information_System_MVC.Models.Equipment")
        //    {
        //        list = JsonConvert.DeserializeObject<List<Equipment>>(json);
        //    }
        //    if (answer.Type[0] == "Information_System_MVC.Models.Event")
        //    {
        //        list = JsonConvert.DeserializeObject<List<Event>>(json);
        //    }
        //    if (answer.Type[0] == "Information_System_MVC.Models.Order")
        //    {
        //        list = JsonConvert.DeserializeObject<List<Order>>(json);
        //    }
        //    if (answer.Type[0] == "Information_System_MVC.Models.Product")
        //    {
        //        list = JsonConvert.DeserializeObject<List<Product>>(json);
        //    }
        //    if (answer.Type[0] == "Information_System_MVC.Models.Profession")
        //    {
        //        list = JsonConvert.DeserializeObject<List<Profession>>(json);
        //    }
        //    if (answer.Type[0] == "Information_System_MVC.Models.Room")
        //    {
        //        list = JsonConvert.DeserializeObject<List<Room>>(json);
        //    }
        //    if (answer.Type[0] == "Information_System_MVC.Models.Tourist")
        //    {
        //        list = JsonConvert.DeserializeObject<List<Tourist>>(json);
        //    }
        //    if (answer.Type[0] == "Information_System_MVC.Models.Worker")
        //    {
        //        list = JsonConvert.DeserializeObject<List<Worker>>(json);
        //    }
        //    if (answer.Type[0] == "Information_System_MVC.Models.WorkPlace")
        //    {
        //        list = JsonConvert.DeserializeObject<List<WorkPlace>>(json);
        //    }

        //    try
        //    {
        //        var app = new Application();
        //        app.Visible = true;

        //        var wb = app.Workbooks.Add();
        //        var ws = (Worksheet)wb.Worksheets[1];

        //        for (int i = 1; i < dgwSearchResults.Columns.Count + 1; i++)
        //        {
        //            ws.Cells[1, i].Value = dgwSearchResults.Columns[i - 1].HeaderText;
        //            ws.Cells[1, i].EntireColumn.ColumnWidth = dgwSearchResults.Columns[i - 1].Width / 5;
        //            ws.Cells[1, i].HorizontalAlignment = XlHAlign.xlHAlignCenter;
        //        }

        //        for (int i = 0; i < dgwSearchResults.Rows.Count; i++)
        //        {
        //            for (int j = 0; j < dgwSearchResults.Columns.Count; j++)
        //            {
        //                ws.Cells[i + 2, j + 1].Value = dgwSearchResults.Rows[i].Cells[j].Value.ToString();
        //                ws.Cells[i + 2, j + 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }

        //    return View();
        //}

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