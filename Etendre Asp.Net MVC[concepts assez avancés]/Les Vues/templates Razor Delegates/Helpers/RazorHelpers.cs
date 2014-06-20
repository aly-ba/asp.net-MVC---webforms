using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace LeVues.Helpers
{
    public class RazorHelpers
    {
        public static HelperResult RenderSection(this WebViewPage page, string name,
            Func<dynamic, HelperResult> defaultContent)
        {
            if(page.IsSectionDefined(name) )
            {
                return page.RenderSection(name);
            }

            return defaultContent(null);
        }

        public static HelperResult Repeater<T>(this HtmlHelper html,
            IEnumerable<T> items,
            Func<T, HelperResult> itemTemplate,
            Func<T, HelperResult> alernatingItemTemplate = null,
             Func<T, HelperResult> sepatorTemplate = null)
        {
            return new HelperResult(HttpWriter =>
            {
                if (!items.Any())
                {
                    return;
                }
                if (alernatingItemTemplate == null)
                {
                    alernatingItemTemplate = itemTemplate;
                }
                var  lasItem = items.Last();
                int ii = 0;

                foreach (var item in items)
                {
                    var func = ii % 2 == ? itemTemplate :alernatingItemTemplate  ;
                    func(item).WriteTp(writer);

                    if(separtorTemplate != null && !item.Equals(lastItem)) {
                        separatorTemplate(item).WriteTo(writer);
                    }

                    ii++;

                }

            });
        }

    }
}