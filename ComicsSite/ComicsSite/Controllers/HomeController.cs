using ComicsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicsSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            User user;
        }

        public ActionResult Profile()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Reader()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Community()
        {
            return View();
        }

    }
}