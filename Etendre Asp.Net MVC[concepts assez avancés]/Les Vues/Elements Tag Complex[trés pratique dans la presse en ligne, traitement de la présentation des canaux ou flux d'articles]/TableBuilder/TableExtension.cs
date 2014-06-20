using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LesVues.TableBuilder
{
    public static class TableExtension
    {
        

        public static MvcHtmlTable Table(this HtmlHelper html)
        {
            
            //return new MvcHtmlTable(html.ViewContext.Writer);
            return Table(html, null);
        }

        public static MvcHtmlTable Table(this HtmlHelper html, object attributes)
        {

            return new MvcHtmlTable(html.ViewContext.Writer, attributes);
        }

        public static MvcHtmlTableRow Row(this MvcHtmlTable tbl)
        {
            return Row(tbl, CellType.Data);
        }

        public static  MvcHtmlTableRow Row(this MvcHtmlTable tbl, CellType cellType)
        {
            return Row(tbl, cellType, null);
        } 

        public static MvcHtmlTableRow Row(this MvcHtmlTable tbl,CellType cellType, object attributes)
        {
            return new MvcHtmlTableRow(tbl.Writer, cellType, attributes);
        }

        public static MvcHtmlString Cell(this MvcHtmlTableRow row, string content)
        {
            return Cell(row, content, null);
        }

        public static MvcHtmlString Cell(this MvcHtmlTableRow row, string content, object attributes)
        {
            var name = row.Type ==  CellType.Data? "td":"th" ;

            var builder = new TagBuilder(name)
            {
                InnerHtml = content
            };

            TableHelper.MergeAttributes(builder, attributes);

            return MvcHtmlString.Create(builder.ToString());
        }
    }
} 