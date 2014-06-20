using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace contavance.Controllers
{
    public class HomeController : Controller 
    {

        //[NonAction]
        //JSON
        //FILE
        public ActionResult Index()
        {
            return View();
        }

        // you can pass here any layout lol haha
        public PartialViewResult Partial()
        {
              return PartialView("Index");
        }

        //return text //pratic de ls algos pour la presse
        public ContentResult Text()
        {
            return Content(" this is content.");
        }

        //JSON Result , serialize all object we pass to it
        public JsonResult Jason()
        {
            return Json(new {id =1, firstName="Eyebe", middleName="yespapi",
                lastName="BoyDakar"});
        }

        //fileResult other wie
        public FileContentResult FileResult()
        {
            // code ici
        }

        public FilePathResult PathResult()
        {
            //code ici
        }

        public FileStreamResult FileStreal()
        {
            //code ici
        }

        //get content from a pdf dans cette example
        public FileResult GetFileContents2()
        {
            //chemin du fichier
            var path = Server.MapPath(@"~/content/pdf/bus.pdf");

            //lit le contenu du fichier
            var contents = System.IO.File.ReadAllBytes(path);

            //content disposition en mode telechargement du fichier

            var header = new System.Net.Mime.ContentDisposition() {
                FileName = "bus.pdf",
                Inline =false
            };
             //fin contet dispositon
           

            Response.AddHeader("Content-Disposition", header.ToString());

            return File(contents, "application/pdf");
        }


        //get content from a pdf dans cette example
        public FileResult GetFilePath()
        {
            //chemin du fichier
            var path = Server.MapPath(@"~/content/pdf/bus.pdf");


            return File(path, "application/pdf");
        }


        //get content from a pdf dans cette example
        public FileResult GetFileStream()
        {
            //chemin du fichier
            var path = Server.MapPath(@"~/content/pdf/bus.pdf");

            //lit le contenu du fichier
            var contents = System.IO.File.ReadAllBytes(path);

            var ms = new MemoryStream(contents);


            return File(ms, "application/pdf");
        }

        //get content from a pdf dans cette example
        public FileResult GetFileContents()
        {
            //chemin du fichier
            var path = Server.MapPath(@"~/content/pdf/bus.pdf");

            //lit le contenu du fichier
            var contents = System.IO.File.ReadAllBytes(path);

            //set the cotent disposition for us with bus.pdf like 3th args
            return File(contents, "application/pdf", "bus.pdf");
        }

        public RedirectResult RedirectTo()
        {
            return RedirectPermanent("https://github.com/aly-ba/");
            return Redirect("https://github.com/aly-ba/");
            
        }

        public RedirectToRouteResult Goto()
        {
            return RedirectToAction("Index");
            return RedirectToActionPermanent("Index");
            return RedirectToRoute("Index");
            return RedirectToRoutePermanent("Index");

        }

        public HttpStatusCodeResult ReturnCode()
        {
            return new HttpStatusCodeResult(500);
        }

        public HttpNotFoundResult Return404()
        {
            return HttpNotFound();
        }

        public HttpUnauthorizedResult Unauthorizd() 
        {
            return new HttpUnauthorizedResult();

        }

    }
}
 