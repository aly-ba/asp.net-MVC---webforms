using MESSADIIS.Data;
using MESSADIIS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MESSADIIS.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;
        private IMessadiisRepository _repo;

        public HomeController(IMailService mail, IMessadiisRepository repo) 
        {
            _mail = mail;
            _repo = repo;

        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var questions = _repo.GetQuestions()
                                 .OrderByDescending(q => q.Creation)
                                 .Take(25)
                                 .ToList();
            return View(questions);                                 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var questions = _repo.GetQuestionsInclusReponses()
                                 .OrderByDescending(q => q.Creation)
                                 .Take(25)
                                 .ToList();
            return View(questions);
        }
    }
}
