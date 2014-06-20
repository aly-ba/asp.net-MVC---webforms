using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

            var model = new Person( firstName, lastName);



            //model metadatga validation

            bindingContext.ModelMetadata.Model = model;

            var validator = ModelValidator.GetModelValidator(bindingContext.ModelMetadata,
                controllerContext);

            var results = validator.Validate(model);





            //model binding validation
            //var results = from prop in TypeDescriptor.GetProperties(model).
            //              Cast<PropertyDescriptor>()
            //              from attribute in prop.Attributes.OfType<ValidationAttribute>()
            //              where !attribute.IsValid(prop.GetValue(model))
            //              select new {property = prop.Name, ErrorMessage=
            //                  attribute.FormatErrorMessage(string.Empty) 


            //foreach(var  result in results) {
            //       bindingContext.ModelState.AddModelError(result.ErrorMessage, result.ErrorMessage);
            //}
            foreach (var result in results)
            {
                bindingContext.ModelState.AddModelError(result.MemberName, result.Message);
            }
            
            return model;
          }
      }
}