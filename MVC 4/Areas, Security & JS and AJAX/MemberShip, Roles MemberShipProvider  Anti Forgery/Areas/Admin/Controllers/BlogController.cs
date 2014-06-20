using Lesson13.Areas.Blog.Data;
using Lesson13.Areas.Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lesson13.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private BlogDatabase _db = new BlogDatabase();

        public ActionResult Index()
        {
            var posts = _db.BlogPosts
                .OrderByDescending(p => p.PublishDate)
                .Take(10);

            return View(posts);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(BlogPost post)
        {
            if (!ModelState.IsValidField("Title") && !ModelState.IsValidField("PublishDate") && !ModelState.IsValidField("Message"))
            {
                return View(post);
            }

            post.Created = DateTime.Now;

            post.EncodedTitle = ScrubTitle(post.Title);

            _db.BlogPosts.Add(post);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpNotFoundResult();
            }

            var post = _db.BlogPosts.Where(p => p.Id == id.Value)
                .SingleOrDefault();

            if (post == null)
            {
                return new HttpNotFoundResult();
            }

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogPost post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            var realPost = _db.BlogPosts.Where(p => p.Id == post.Id)
                .SingleOrDefault();

            if (realPost != null)
            {
                realPost.Title = post.Title;
                realPost.PublishDate = post.PublishDate;
                realPost.Message = post.Message;

                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpNotFoundResult();
            }

            var post = _db.BlogPosts.Where(p => p.Id == id.Value)
                .SingleOrDefault();

            if (post == null)
            {
                return new HttpNotFoundResult();
            }

            _db.BlogPosts.Remove(post);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        private static string ScrubTitle(string title)
        {
            var scrubbed = Regex.Replace(title, @"[^\s\w-]", "",
                                RegexOptions.None).Trim();

            return Regex.Replace(scrubbed, @"\s", "-", RegexOptions.None);
        }
    }
}
