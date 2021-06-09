using Information_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Information_System_MVC.Controllers
{
    public class ProductController : Controller
    {
        ISContext db = new ISContext();

        [Authorize]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 0)
                {
                    return HttpNotFound();
                }
            }
            IEnumerable<Product> products = db.Products;

            ViewBag.Products = products;

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 0)
                {
                    return HttpNotFound();
                }
            }

            if (id == null)
            {
                return HttpNotFound();
            }

            Product product = db.Products.Find(id);

            if (product != null)
            {
                return View(product);
            }

            return HttpNotFound();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
              (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                    return View();
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
              (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    try
                    {
                        db.Products.Add(product);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
              (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    if (id == null)
                    {
                        return HttpNotFound();
                    }

                    Product product = db.Products.Find(id);

                    if (product == null)
                    {
                        return HttpNotFound();
                    }

                    return View(product);
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
             (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    try
                    {
                        db.Entry(product).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
             (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    Product product = db.Products.Find(id);

                    if (product == null)
                    {
                        return HttpNotFound();
                    }

                    return View(product);
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is ConnectedWorker)
            {
                if ((System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 2 ||
             (System.Web.HttpContext.Current.Session["CurrentUser"] as ConnectedWorker).Power == 1)
                {
                    try
                    {
                        Product product = db.Products.Find(id);
                        if (product == null)
                        {
                            return HttpNotFound();
                        }

                        db.Products.Remove(product);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
                else
                    return HttpNotFound();
            }
            else
                return HttpNotFound();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Order(int id)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist)
            {
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }

                return View(product);
            }
            else
                return HttpNotFound();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Order(int id, int count)
        {
            if (System.Web.HttpContext.Current.Session["CurrentUser"] is Tourist)
            {
                try
                {
                    Product product = db.Products.Find(id);
                    if (product == null)
                    {
                        return HttpNotFound();
                    }
                    if (product.Quantity >= count)
                    {
                        product.Quantity -= count;

                        db.Entry(product).State = EntityState.Modified;
                        db.SaveChanges();

                        Order order = new Order
                        {
                            Cost = count * product.Price,
                            Quantity = count,
                            TouristId = (System.Web.HttpContext.Current.Session["CurrentUser"] as Tourist).Id,
                            DateOrder = DateTime.Now,
                            IsDone = false,
                            ProductId = id
                        };

                        db.Orders.Add(order);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    return View();
                }
            }
            else
                return HttpNotFound();
        }
    }
}
