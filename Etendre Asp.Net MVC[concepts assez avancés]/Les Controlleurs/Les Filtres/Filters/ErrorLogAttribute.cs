using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtrer.Filters
{
    public class ErrorLogAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {

            var path = filterContext.RequestContext.HttpContext.Server.MapPath("~/App_Data/errorlog.txt");
             
            using(var writer = new System.IO.StreamWriter(path, true) )
            {
                var exception = filterContext.Exception;

                writer.WriteLine(DateTime.Now + "\t" + exception.Message);
            }

            base.OnException(filterContext);
        }
    }
}