using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Binder.Models
{
    public class PersonModelBinder :IModelBinder 
    {
        //y'en 3 faire gaff Web.ModelBinding// Http.ModelBinding, Web.MVC
        public object BindModel(ControllerContext controllerContext,
              ModelBindingContext bindingContext)
        {
            //use binding Context tout retrieve the date of our fom hihi
            var provider = bindingContext.ValueProvider;

            var firstName = provider.GetValue<string>("firstName");
            var lastName = provider.GetValue<string>("lastName");

            return new Person(firstName, lastName);
        }
    }
}