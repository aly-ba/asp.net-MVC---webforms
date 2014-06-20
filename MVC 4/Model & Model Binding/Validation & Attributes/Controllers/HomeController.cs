using Lesson10.Data;
using Lesson10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson10.Controllers
{
    public class HomeController : Controller
    {
        private BlogPostRepository _blogPosts = new BlogPostRepository();

        public ActionResult Index()
        {
            var posts = _blogPosts.GetRecentPosts();
            return View(posts);
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
                return new HttpNotFoundResult();

            var post = _blogPosts.GetById(id.Value);

            if (post == null)
                return new HttpNotFoundResult();

            return View(post);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Insert(BlogPost post)
        {
            post.Created = DateTime.Now;

            _blogPosts.Insert(post);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpNotFoundResult();

            var post = _blogPosts.GetById(id.Value);

            if (post == null)
                return new HttpNotFoundResult();

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(BlogPost post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            _blogPosts.Edit(post);

            return RedirectToAction("Detail", new { id = post.Id });
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpNotFoundResult();

            var post = _blogPosts.GetById(id.Value);

            if (post == null)
                return new HttpNotFoundResult();

            _blogPosts.Delete(post);


            return RedirectToAction("index");
        }
    }
}
