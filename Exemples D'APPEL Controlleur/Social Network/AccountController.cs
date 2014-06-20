using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace RibbitMvc.Controllers
{
    public class AccountController : RibbitControllerBase
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Security.Logout();

            throw new NotImplementedException();
        }
    }
}
