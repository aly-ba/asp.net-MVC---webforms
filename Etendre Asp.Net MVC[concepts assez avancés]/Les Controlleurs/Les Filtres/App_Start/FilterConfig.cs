﻿using System.Web;
using System.Web.Mvc;
using Filtrer.Filters;

namespace Filtrer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ErrorLogAttribute());
        }
    }
}