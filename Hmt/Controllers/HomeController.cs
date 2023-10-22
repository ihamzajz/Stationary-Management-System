using Hmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;









namespace Hmt.Controllers
{
    public class HomeController : Controller
    {
        HmtDbEntities db = new HmtDbEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }






        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin al)
        {
            if (ModelState.IsValid == true)
            {
                var credentials = db.Admins.Where(x => x.admin_username == al.admin_username && x.admin_password == al.admin_password).FirstOrDefault();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Incorrent Credentials";
                    return View();
                }
                else
                {
                    Session["userId"] = al.admin_id;
                    Session["username"] = al.admin_username.ToString();
                    return RedirectToAction("Requests", "Admin");
                }
            }
            return View();
        }







        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(Employee ul)
        {
            if (ModelState.IsValid == true)
            {
                var credentials = db.Employees.Where(x => x.emp_username == ul.emp_username && x.emp_password == ul.emp_password).FirstOrDefault();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Incorrent Credentials";
                    return View();
                }
                else
                {
                    Session["userId"] = credentials.emp_id;
                    Session["username"] = ul.emp_username.ToString();
                    return RedirectToAction("stationeries", "User");
                }
            }
            return View();
        }



        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }
    }
}