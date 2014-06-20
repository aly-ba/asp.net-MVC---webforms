using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlleurFactorise.Controllers.Home;

namespace ControlleurFactorise
{
    public class ActionControllerFactory : DefaultControllerFactory
    {
        protected readonly Dictionary<string,Type> TypeCahe =
            new Dictionary<string,Type>(StringComparer.InvariantCultureIgnoreCase);

        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var action = requestContext.RouteData.Values["action"];

            var typeName =string.Format("{0}.{1}",controllerName, action);

            var controller = GetControllerFromAppDomain(typeName);


            return controller;

      
        }

        protected virtual IController GetControllerFromAppDomain(string typeName)
        {

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var types in assemblies.Select(assm => assm.GetTypes()))
            { 
                 foreach(var type in types.Where(type => typeof(ActionController).IsAssignableFrom(type)
                 {
                     var ns = type.UnderlyingSystemType.FullName;

                     if(ns.EndsWith(typeName, true, CultureInfo.InvariantCulture)) {
                         
                       if (TypeCahe.ContainsKey(typeName)) {
                            
                           return (IController)Activator.CreateInstance(TypeCahe[typeName]);
                       }

                         return (IController)Activator.CreateInstance(type);

                     }

                 }
            }
            return null;
        }
    }
}