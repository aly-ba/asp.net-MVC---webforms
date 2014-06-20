using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LesVues.TableBuilder
{
    public static class TableHelper
    {
        public static void MergeAttributes(TagBuilder builder, object attributes)
        {

            if (attributes != null)
            {
                var atts = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes);

                builder.MergeAttributes(atts);
            } 

        }
    }
}