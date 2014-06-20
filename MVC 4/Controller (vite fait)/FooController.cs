using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson04.Controllers
{
    public class FooController : Controller
    {
        //
        // GET: /Foo/

        //# type of actionresult:fileResult ,string, JsonResult, ActionreSult etc...
        public string Index()
        {
            return "This is Index";
        }
        //public int Index()
        //{
        //    return 10;
        //}

        public string Bar()
        {
            return " this is bar";
        }

        // the routing engine is not case sensitive again
        // the routing engine is not case sensitive again  but can understand the concept of overloading
        //id but id is optional in our routing table
       

        public string Baz(string id)
        {
            return "this is Baz" +id;
        }


    }
}
