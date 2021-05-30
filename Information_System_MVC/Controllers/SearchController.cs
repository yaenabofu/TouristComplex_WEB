using ClosedXML.Excel;
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

                }
                if (list is List<Building>)
                {

                }
                if (list is List<Equipment>)
                {

                }
                if (list is List<Event>)
                {

                }
                if (list is List<Order>)
                {

                }
                if (list is List<Product>)
                {

                }
                if (list is List<Profession>)
                {

                }
                if (list is List<Room>)
                {

                }
                if (list is List<Tourist>)
                {

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

                }
                foreach (var item in list)
                {
                    currentRow++;
                    if (list is List<BookedTicket>)
                    {

                    }
                    if (list is List<Building>)
                    {

                    }
                    if (list is List<Equipment>)
                    {

                    }
                    if (list is List<Event>)
                    {

                    }
                    if (list is List<Order>)
                    {

                    }
                    if (list is List<Product>)
                    {

                    }
                    if (list is List<Profession>)
                    {

                    }
                    if (list is List<Room>)
                    {

                    }
                    if (list is List<Tourist>)
                    {

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