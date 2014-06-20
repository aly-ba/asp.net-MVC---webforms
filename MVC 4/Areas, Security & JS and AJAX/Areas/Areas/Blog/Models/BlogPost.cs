using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson12.Areas.Blog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string EncodedTitle { get; set; }
    }
}