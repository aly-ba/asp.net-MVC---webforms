using Lesson14.Areas.Blog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson14.Areas.Blog.Controllers
{
    public class BlogController : Controller
    {
        private BlogDatabase _db = new BlogDatabase();

        public ActionResult Index()
        {
            var posts = _db.BlogPosts
                .Where(p => DateTime.Now > p.PublishDate)
                .OrderByDescending(p => p.PublishDate)
                .Take(10);

            return View(posts);
        }

        public ActionResult Details(int year, int month, int day, string title)
        {
            var post = _db.BlogPosts.GetPublishedBy(year, month, day, title)
                .SingleOrDefault();

            if (post == null)
            {
                return new HttpNotFoundResult();
            }

            return View(post);
        }

        public ActionResult ByDay(int year, int month, int day)
        {
            var posts = _db.BlogPosts.GetPublishedBy(year, month, day)
                .OrderByDescending(p => p.PublishDate);

            if (!posts.Any())
            {
                return new HttpNotFoundResult();
            }

            return View("Index", posts);
        }

        public ActionResult ByMonth(int year, int month)
        {
            var posts = _db.BlogPosts.GetPublishedBy(year, month)
                           .OrderByDescending(p => p.PublishDate);

            if (!posts.Any())
                return new HttpNotFoundResult();

            return View("Index", posts);
        }

        public ActionResult ByYear(int year)
        {
            var posts = _db.BlogPosts.GetPublishedBy(year)
                           .OrderByDescending(p => p.PublishDate);

            if (!posts.Any())
                return new HttpNotFoundResult();

            return View("Index", posts);
        }

        public PartialViewResult SearchHtml(string value)
        {
            var posts = _db.BlogPosts
                .Where(p => p.Message.Contains(value) || p.Title.Contains(value));

            return PartialView(posts);
        }

        public ActionResult SearchJson(string value)
        {
            var posts = _db.BlogPosts
                .Where(p => p.Message.Contains(value) || p.Title.Contains(value));

            return new JsonResult()
            {
                Data = posts,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
