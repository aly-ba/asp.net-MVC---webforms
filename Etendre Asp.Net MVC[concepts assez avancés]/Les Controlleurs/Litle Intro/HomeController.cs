using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CONT.Controllers
{
    public class HomeController : Controller //IController
    {

        //IController
        //route engigne call this method thats right
        public void Execute(System.Web.Routing.RequestContext requestContext)
        {
            //get information about the route lol 
            var routeData = requestContext.RouteData;
            requestContext.HttpContext.Response.Write("Hello, basic controller");
            //get information about the route
            requestContext.HttpContext.Response.Write(routeData.Values["action"]);

        }
        //Fin I Controller

        [NonAction]
        public ActionResult Index()
        {
            return View();
        }
    }
}
