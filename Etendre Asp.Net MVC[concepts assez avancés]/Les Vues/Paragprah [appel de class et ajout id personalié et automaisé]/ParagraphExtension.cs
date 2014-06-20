using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LesVues
{
    public static class ParagraphExtension
    {
        public static MvcHtmlString Paragraph(this HtmlHelper html, string content)
        {
            //return MvcHtmlString.Create(string.Format("<p>{0}</p>", content));
            return Paragraph(html, content, null);
        }


        public static MvcHtmlString Paragraph(this HtmlHelper html, string content, object attributes)
        {
            var builder = new TagBuilder("p") { InnerHtml = content };

            if (attributes != null)
            {

                var atts = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes);
                builder.MergeAttributes(atts);

            }
            return MvcHtmlString.Create(builder.ToString());
        }


        ////public static string Paragraph(this HtmlHelper html, string content)
        //{
        //    //return string.Format("<p>{0}</p>", content);
        //}
    }
}