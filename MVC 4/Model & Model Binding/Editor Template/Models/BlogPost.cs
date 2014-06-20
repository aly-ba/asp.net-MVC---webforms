using Lesson11.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson11.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [UIHint("MyDateTime")]
        public DateTime Created { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} must have a value.")]
        //[StringLength(20, ErrorMessage = "{0} cannot have more than {1} characters.")]
        [MaxLength(20, ErrorMessage = "{0} cannot have more than {1} characters.")]
        public string PostTitle { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "{0} must have a value.")]
        [MinLength(10, ErrorMessage = "{0} must have more than {1} characters.")]
        [MustContain("hello", ErrorMessage = "{0} must contain 'hello'")]
        public string PostMessage { get; set; }
    }
}