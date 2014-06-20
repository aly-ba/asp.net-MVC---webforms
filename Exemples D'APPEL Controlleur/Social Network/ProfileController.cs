using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace RibbitMvc.Controllers
{
    public class ProfileController : Controller
    {
        //
        //GET: /Profile/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            throw new NotImplementedException();
        }
    }
}
