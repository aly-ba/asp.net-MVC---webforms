using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlleurFactorise.Controllers.Home
{
    public class ActionController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new ActionControllerActionInvoke();
        }
    }
}