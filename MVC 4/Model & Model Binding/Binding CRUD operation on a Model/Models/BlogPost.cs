using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson09.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        [Display(Name = "Title")]
        public string PostTitle { get; set; }

        [Display(Name = "Message")]
        public string PostMessage { get; set; }
    }
}