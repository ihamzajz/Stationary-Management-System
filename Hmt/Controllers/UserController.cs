using Hmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hmtt.Controllers

{
    public class UserController : Controller
    {
        HmtDbEntities db = new HmtDbEntities();

        public static List<Cart> list = new List<Cart>();


        // GET: User
        public ActionResult UserIndex()
        {
            return View();
        }


        public ActionResult stationeries() //products
        {
            return View(db.Stationaries.ToList());
        }


        public ActionResult Details(int id)
        {
            var pr = db.Stationaries.Where(x => x.pro_id == id).FirstOrDefault();
            return View(pr);
        }
        [HttpPost]
        public ActionResult Details(int id, int qty)
        {
            var pr = db.Stationaries.Where(x => x.pro_id == id).FirstOrDefault();
            if (list.Count > 0)
            {
                bool flag = false;
                int count = 0;
                foreach (var item in list)
                {
                    if (item.pro_id == pr.pro_id)
                    {
                        flag = true;
                        break;
                    }
                    count++;
                }
                if (flag)
                {
                    list[count].pro_stock += qty;
                    list[count].pro_price += qty * pr.pro_price;
                }
                else
                {
                    list.Add(new Cart { pro_id = pr.pro_id, pro_name = pr.pro_name, pro_price = pr.pro_price * qty, pro_stock = qty, pro_image = pr.pro_image });
                }

            }
            else
            {
                list.Add(new Cart { pro_id = pr.pro_id, pro_name = pr.pro_name, pro_price = pr.pro_price * qty, pro_stock = qty, pro_image = pr.pro_image });

            }
            return RedirectToAction("checkout");
        }

        public ActionResult checkout()
        {
            int price = 0;
            foreach (var item in list)
            {
                price += Convert.ToInt32(item.pro_price);
            }
            ViewBag.total = price;
            return View(list);
        }
        public ActionResult OrderNow()
        {
            List<Request> order = new List<Request>();
            foreach (var item in list)
            {
                order.Add(new Request
                {
                    req_status = "Pending",
                    req_amount = item.pro_price,
                    req_date = DateTime.Now,
                    emp_id = Convert.ToInt32(Session["userId"]),
                    pro_id = item.pro_id

                });
            }
            foreach (var item in order)
            {
                db.Requests.Add(item);
                db.SaveChanges();
                list.Clear();
                ViewBag.Message = "Your order have been confirmed, will be delivered in 1-3 days";
                ViewBag.link = "Continue Shopping";
            }
            return RedirectToAction("checkout");
        }


    }
}
