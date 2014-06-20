using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LesVues.Extensions
{
    public static class DateTimeExtension
    {
        //extension method
        public static string FriendlyTimestamp(this DateTime dt)
        {
            var now = DateTime.Now;

            var span = now - dt;

            if(span > TimeSpan.FromHours(24))
            {
                return dt.ToString("MMM dd");

            }

            if( span>TimeSpan.FromMinutes(60))
            {
                return string.Format("{0}h", span.Hours);
            }

            if( span>TimeSpan.FromSeconds(60))
            {
                return string.Format("{0}m", span.Minutes);
            }

            return "now";
        }
    }
}