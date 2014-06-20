using Lesson13.Areas.Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lesson13.Areas.Blog.Data
{
    public static class DbSetBlogPostExtensions
    {
        public static IEnumerable<BlogPost> GetPublishedBy(this DbSet<BlogPost> p, int year, int? month = null, int? day = null,
                                                  string title = null)
        {
            var posts = p.Where(b => b.PublishDate.Year == year && DateTime.Now > b.PublishDate);

            if (month.HasValue)
            {
                posts = posts.Where(b => b.PublishDate.Month == month.Value);
            }

            if (day.HasValue)
            {
                posts = posts.Where(b => b.PublishDate.Day == day.Value);
            }

            if (!string.IsNullOrEmpty(title))
            {
                posts = posts.Where(b => b.EncodedTitle == title);
            }

            return posts;
        }
    }
}