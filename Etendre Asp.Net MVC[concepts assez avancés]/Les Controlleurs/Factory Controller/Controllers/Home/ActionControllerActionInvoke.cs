using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ControlleurFactorise.Controllers.Home
{
    class ActionControllerActionInvoke : ControllerActionInvoker
    {

        protected override ActionDescriptor FindAction(ControllerContext controllerContext, 
            ControllerDescriptor controllerDescriptor, string actionName)
        {

            var method = controllerContext.HttpContext.Request.HttpMethod;

            return controllerDescriptor.FindAction(controllerContext, method); 
        }
    }
}
