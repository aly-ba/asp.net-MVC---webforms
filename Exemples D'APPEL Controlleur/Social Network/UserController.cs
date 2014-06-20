using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RibbitMvc.Controllers
{
    public class UserController : Controller

    {
    //
    //GET : /User/
    public ActionResult Index(string username)
    {
        throw new NotImplementedException("list for" + username);
    }

    //GET : /User/
    public ActionResult Followers(string username)
    {
        throw new NotImplementedException("list for" + username);
    }


    //GET : /User/
    public ActionResult Following(string username)
    {
        throw new NotImplementedException("list for" + username);
    }


    }
}