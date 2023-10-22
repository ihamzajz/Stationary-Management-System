//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Hmt.Models;
//using System.Data.Entity.Validation;
//using System.Data.Entity.Infrastructure;



using Hmt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;





namespace Hmt.Controllers
{

    public class AdminController : Controller
    {
        HmtDbEntities db = new HmtDbEntities();

        // GET: Admin
        public ActionResult AdminIndex()
        {
            if (Session["username"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }



        //Users CRUD Start



        public ActionResult UsersInfo() //list of users
        {
            return View(db.Employees.ToList());
        }


        public ActionResult UserAdd() //Users add
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserAdd(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();

        }


        public ActionResult UserEdit(int id) //Users Edit
        {
            Employee emp = db.Employees.Where(a => a.emp_id == id).FirstOrDefault();
            return View(emp);
        }
        [HttpPost]
        public ActionResult UserEdit(int id, Employee emp)
        {
            Employee oldEmp = db.Employees.Where(a => a.emp_id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                oldEmp.emp_fname = emp.emp_fname;
                oldEmp.emp_lname = emp.emp_lname;
                oldEmp.emp_username = emp.emp_username;
                oldEmp.emp_password = emp.emp_password;
                oldEmp.emp_designation = emp.emp_designation;
                oldEmp.emp_email = emp.emp_email;
                oldEmp.emp_country = emp.emp_country;
                oldEmp.emp_gender = emp.emp_gender;
                oldEmp.emp_qualification = emp.emp_qualification;

                db.SaveChanges();
            }
            return View("UsersInfo", db.Employees.ToList());
        }


        public ActionResult UserDelete(int id) //Users Delete
        {
            Employee emp = db.Employees.Where(a => a.emp_id == id).FirstOrDefault();
            db.Employees.Remove(emp);
            db.SaveChanges();
            return View("UsersInfo", db.Employees.ToList());
        }


        //Users CRUD End




        //Admin CRUD Start

        public ActionResult AdminInfo() //list of admins
        {
            return View(db.Admins.ToList());
        }


        public ActionResult AdminAdd() //Admin add
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin ad)
        {
            db.Admins.Add(ad);
            db.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }


        public ActionResult AdminEdit(int id) //Users Edit
        {
            Admin ad = db.Admins.Where(a => a.admin_id == id).FirstOrDefault();
            return View(ad);
        }
        [HttpPost]
        public ActionResult AdminEdit(int id, Admin ad)
        {
            Admin oldAd = db.Admins.Where(a => a.admin_id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                oldAd.admin_fname = ad.admin_fname;
                oldAd.admin_lname = ad.admin_lname;
                oldAd.admin_email = ad.admin_email;
                oldAd.admin_username = ad.admin_username;
                oldAd.admin_password = ad.admin_password;
                db.SaveChanges();
            }
            return View("AdminInfo", db.Admins.ToList());
        }


        public ActionResult AdminDelete(int id) //Admin Delete
        {
            Admin ad = db.Admins.Where(a => a.admin_id == id).FirstOrDefault();
            db.Admins.Remove(ad);
            db.SaveChanges();
            return View("AdminInfo", db.Admins.ToList());
        }
        //Admin CRUD End















        //Request CRUD Start

        public ActionResult Requests() //List of Requests
        {
            return View(db.Requests.ToList());
        }

        public ActionResult RequestEdit(int id) //Request Edit
        {
            Request req = db.Requests.Where(a => a.req_id == id).FirstOrDefault();
            return View(req);
        }
        [HttpPost]
        public ActionResult RequestEdit(int id, Request req)
        {
            Request oldreq = db.Requests.Where(a => a.req_id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                //oldreq.req_id = req.req_id;
                oldreq.req_amount = req.req_amount;
                oldreq.req_date = req.req_date;
                oldreq.req_status = req.req_status;
                db.SaveChanges();
            }
            return View("Requests", db.Requests.ToList());
        }
        public ActionResult RequestDelete(int id) //Request Delete
        {
            Request req = db.Requests.Where(a => a.req_id == id).FirstOrDefault();
            db.Requests.Remove(req);
            db.SaveChanges();
            return View("Requests", db.Requests.ToList());
        }
        //Request CRUD End





        //Category CRUD Start
        public ActionResult CategoryList() //list of Category
        {
            return View(db.Categories.ToList());
        }

        public ActionResult CategoryAdd() //Category add
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category cat)
        {
            db.Categories.Add(cat);
            db.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }

        public ActionResult CategoryEdit(int id) //Category Edit
        {
            Category cat = db.Categories.Where(a => a.cat_id == id).FirstOrDefault();
            return View(cat);
        }
        [HttpPost]
        public ActionResult CategoryEdit(int id, Category cat)
        {
            Category oldCat = db.Categories.Where(a => a.cat_id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                //oldCat.cat_id = cat.cat_id;
                oldCat.cat_name = cat.cat_name;

                db.SaveChanges();
            }
            return View("CategoryList", db.Categories.ToList());
        }


        public ActionResult CategoryDelete(int id) //Category Delete
        {
            Category cat = db.Categories.Where(a => a.cat_id == id).FirstOrDefault();
            db.Categories.Remove(cat);
            db.SaveChanges();
            return View("CategoryList", db.Categories.ToList());
        }
        //Category CRUD End









        //products crud starts


        public ActionResult ProductList() //list of Product
        {
            return View(db.Stationaries.ToList());
        }
        public ActionResult Productadd() //Product add
        {
            return View();
        }
        [HttpPost]
        public ActionResult Productadd(Stationary s)
        {
            db.Stationaries.Add(s);
            db.SaveChanges();
            ViewBag.productadd = "data insert successfully";
            return View();

        }

        public ActionResult ProductEdit(int id) //Product edit
        {
            Stationary emp = db.Stationaries.Where(a => a.pro_id == id).FirstOrDefault();
            return View(emp);
        }
        [HttpPost]
        public ActionResult ProductEdit(int id, Stationary s)
        {
            Stationary olds = db.Stationaries.Where(a => a.pro_id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                olds.pro_name = s.pro_name;
                olds.pro_description = s.pro_description;
                olds.pro_price = s.pro_price;
                olds.pro_image = s.pro_image;
                olds.pro_stock = s.pro_stock;


                db.SaveChanges();
            }
            return View("Productlist", db.Stationaries.ToList());
        }


        public ActionResult ProductDelete(int id) //Product Delete
        {
            Stationary st = db.Stationaries.Where(a => a.pro_id == id).FirstOrDefault();
            db.Stationaries.Remove(st);
            db.SaveChanges();
            return View("ProductList", db.Stationaries.ToList());
        }



        //products crud starts

    }
}