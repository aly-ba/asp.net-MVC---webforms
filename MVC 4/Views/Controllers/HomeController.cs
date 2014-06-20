using Lesson05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson05.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //ViewData is a Dictionnary

            ViewData["Title"] ="My Fisrt View";
            //ViewBag est beaucoup dynamique 
            //que view ViewData se comporte comme un objet

            ViewBag.Message = "This sis my first Message";

            //afficher ce contenu dans un autre view
            //on peut utiliser plusieur vues pour un simpel méthode 
            // d'un autre controlleur
            return View();

        }

        public ActionResult Greeting()
        {
            var model = new GreetingModel {
                Title ="My Secod View",
                Message="This is my second Message"
            };

            return View(model);

        }

    }
}
 