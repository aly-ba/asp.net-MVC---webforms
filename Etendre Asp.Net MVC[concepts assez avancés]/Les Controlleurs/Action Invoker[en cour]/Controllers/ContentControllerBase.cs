using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAI.Controllers
{
    public class ContentControllerBase : Controller
    {
        //
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
             
            base.Initialize(requestContext);

            var acceptTypes = requestContext.HttpContext.Request.AcceptTypes ?? new string []{ };
                
            var acceptType  = acceptTypes.FirstOrDefault();

            ActionInvoKer = new ContenxtActionInvoker();

        }

    }
}
