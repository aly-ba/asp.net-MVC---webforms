using Lesson14.Areas.Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lesson14.Areas.Blog.Data
{
    public class BlogDatabase : DbContext
    {
        public BlogDatabase() : base("DefaultConnection") { }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}