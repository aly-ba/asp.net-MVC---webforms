using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filtrer.Filters;

namespace Filtrer.Controllers
{
    
    public class HomeController : Controller
    {
         [AllowAnonymous]
        public ActionResult Index()
        {
         
            return View();
        }

         [AllowAnonymous]
        public ActionResult Login()
        {
            Session["loggedIn"] = true;

            return Redirect("Index");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("Index");
        }

        [MyAuhtorization]
        public string Protected()
        {
            return "This is protected";
        }

        public string Exception()
        {

            throw new Exception("This is a test exception");

        }
    }
}
