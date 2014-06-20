using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson14.Areas.Blog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        [UIHint("MyDateTime")]
        public DateTime PublishDate { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }
        public string EncodedTitle { get; set; }
    }
}