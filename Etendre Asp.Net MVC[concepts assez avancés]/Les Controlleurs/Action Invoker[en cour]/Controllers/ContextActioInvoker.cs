using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace CAI.Controllers
{
    public class ContextActioInvoker : ControllerActionInvoker
    {
        private readonly string _acceptedType;

        private readonly Dictionary<string, Func<object, ActionResult>> _converters;

        public ContextActioInvoker(string accepType)
        {
            _acceptedType = accepType;
            _converters = new Dictionary<string, Func<object, ActionResult>>();


            _converters.Add("application/json", ConverToJson);
            _converters.Add("Text/xml", ConverToXml);
        }

        public override ActionResult CreateActionResult(ControllerContext controllerContext,
            ActionDescriptor actionDescriptor, object actionReturnValue)
        {

            if (actionReturnValue == null) 
            {
                return new EmptyResult();
            }

            var result = actionReturnValue as ActionResult;

            if (result != null && !_converters.ContainsKey(_acceptedType))
                {
                    return result;
                }

            var model = result == null ? actionReturnValue : controllerContext.Controller.ViewData.Model;

            return _converters.ContainsKeys(_acceptedType ? _converters[_acceptedType](model)

                :ConvertToView(ControllerContext, model);

            return base.CreateActionResult(controllerContext, actionDescriptor,
                actionReturnValue);

        }

        protected virtual ActionResult ConverToJson(object model)
        {
            return new JsonResult
            {
                Data = model,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        protected virtual ActionResult ConverToXml(object model)
        {
            var serializer = new XmlSerializer(model.GetType());

            using (var writer = new System.IO.StringWriter())
            {
                serializer.Serialize(writer, model);
                return new ContentResult {
                    Content = writer.ToString(),
                    ContentType ="text/xml"
                };
            }
        }

        protected virtual ActionResult ConvertToView(ControllerContext controllerContext, object model) 
        {
            controllerContext.Controller.ViewData.Model = model;

            return new ViewResult
            {
                TempData = controllerContext.Controller.TempData,
                ViewData = controllerContext.Controller.ViewData
            };
        }
    }
}