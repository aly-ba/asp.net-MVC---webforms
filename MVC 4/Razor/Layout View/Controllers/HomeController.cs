using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson07.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Title = "Hello Index Page!";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "Hello About Page!";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Me";
            return View();
        }

    }
}
