using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtrer.Filters
{
    /// <summary>
    /// remqarque il y'a deux filter attributes namespace
    /// l'un dans blablalba.Mvc
    /// l'autre blablabla.Http.Filters
    /// on prend le le Mvc(biensur) !!!!
    /// </summary>
    public class MyAuhtorizationAttribute : FilterAttribute,
        IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //lancer une session
            var session = filterContext.HttpContext.Session;

            var isLoggedIn = Convert.ToBoolean(session["loggedIn"]);

            if (!isLoggedIn)
            {

                var action = filterContext.ActionDescriptor;

                if (!action.IsDefined(typeof(AllowAnonymousAttribute), true))
                {

                    filterContext.Result = new HttpUnauthorizedResult();
                }

            }

        }
    }
}