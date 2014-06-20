using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlleurFactorise.Controllers.Home
{
    public class Index : ActionController
    {

        public ActionResult Get(string id)
        {
            return View(model: id);
        }

        public ActionResult Post(Person person)
        {
            var fullName = string.Format("{0} {1}", person.FirstName, person.LastName);

            return RedirectToAction("Index", new object { id = fullName });
        }
    }
}