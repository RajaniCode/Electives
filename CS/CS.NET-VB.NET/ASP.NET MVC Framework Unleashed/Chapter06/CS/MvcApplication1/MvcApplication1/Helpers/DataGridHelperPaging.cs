using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.Mvc.Html;
using Paging;

namespace Helpers
{

    public static class DataGridHelper
    {
        public static string DataGrid<T>(this HtmlHelper helper)
        {
            return DataGrid<T>(helper, null, null);
        }

        public static string DataGrid<T>(this HtmlHelper helper, object data)
        {
            return DataGrid<T>(helper, data, null);
        }

        public static string DataGrid<T>(this HtmlHelper helper, object data, string[] columns)
        {
            // Get items
            var items = (PagedList<T>)data;
            if (items == null)
                items = (PagedList<T>)helper.ViewData.Model;

            // Get column names
            if (columns == null)
                columns = typeof(T).GetProperties().Select(p => p.Name).ToArray();

            // Create HtmlTextWriter
            var writer = new HtmlTextWriter(new StringWriter());

            // Open table tag
            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            // Render table header
            writer.RenderBeginTag(HtmlTextWriterTag.Thead);
            RenderHeader(helper, writer, columns);
            writer.RenderEndTag();

            // Render table body
            writer.RenderBeginTag(HtmlTextWriterTag.Tbody);

            foreach (var item in items)
                RenderRow<T>(helper, writer, columns, item);

            // Render pager row
            RenderPagerRow(helper, writer, items, columns.Length);

            writer.RenderEndTag();


            // Close table tag
            writer.RenderEndTag();

            // Return the string
            return writer.InnerWriter.ToString();
        }


        private static void RenderHeader(HtmlHelper helper, HtmlTextWriter writer, string[] columns)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            var currentAction = (string)helper.ViewContext.RouteData.Values["action"];
            foreach (var columnName in columns)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Th);
                var link = helper.ActionLink(columnName, currentAction, new { sort = columnName });
                writer.Write(link);
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
        }


        private static void RenderRow<T>(HtmlHelper helper, HtmlTextWriter writer, string[] columns, T item)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            foreach (var columnName in columns)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                var value = typeof(T).GetProperty(columnName).GetValue(item, null) ?? String.Empty;
                writer.Write(helper.Encode(value.ToString()));
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
        }


        private static void RenderPagerRow<T>(HtmlHelper helper, HtmlTextWriter writer, PagedList<T> items, int columnCount)
        {
            // Don't show paging UI for only 1 page
            if (items.TotalPageCount == 1)
                return;

            // Render page numbers
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.AddAttribute(HtmlTextWriterAttribute.Colspan, columnCount.ToString());
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            var currentAction = (string)helper.ViewContext.RouteData.Values["action"];
            for (var i = 0; i < items.TotalPageCount; i++)
            {
                if (i == items.PageIndex)
                {
                    writer.Write(String.Format("<strong>{0}</strong>&nbsp;", i + 1));
                }
                else
                {
                    var linkText = String.Format("{0}", i + 1);
                    var link = helper.ActionLink(linkText, currentAction, new { page = i, sort = items.SortExpression });
                    writer.Write(link + "&nbsp;");
                }
            }
            writer.RenderEndTag();
            writer.RenderEndTag();
        }


    }
}
