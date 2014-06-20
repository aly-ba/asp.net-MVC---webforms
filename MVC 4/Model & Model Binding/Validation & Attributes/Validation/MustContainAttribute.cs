using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson10.Validation
{
    public class MustContainAttribute : ValidationAttribute
    {
        public string Value { get; set; }

        public MustContainAttribute(string value)
        {
            Value = value;
        }

        public override bool IsValid(object value)
        {
            var val = value as string;

            if (string.IsNullOrEmpty(val))
            {
                return false;
            }

            return val.Contains(Value);

        }
    }
}