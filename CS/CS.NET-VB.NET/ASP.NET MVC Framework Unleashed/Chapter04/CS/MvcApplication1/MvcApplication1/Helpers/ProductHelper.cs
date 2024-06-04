using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using MvcApplication1.Models;

namespace MvcApplication1.Helpers
{
    public static class ProductHelper
    {
        public static string ProductList(this HtmlHelper helper)
        {
            // Get products from view data
            var products = (IEnumerable<Product>)helper.ViewData.Model;

            // Create HTML TextWriter
            var html = new HtmlTextWriter(new StringWriter());

            // Open table
            html.RenderBeginTag(HtmlTextWriterTag.Table);

            // Render product rows
            foreach (var product in products)
            {
                // Open tr
                html.RenderBeginTag(HtmlTextWriterTag.Tr);

                // Render name
                html.RenderBeginTag(HtmlTextWriterTag.Td);
                html.Write(product.Name);
                html.RenderEndTag();
 
                // Render price
                html.RenderBeginTag(HtmlTextWriterTag.Td);
                html.Write("{0:c}", product.Price);
                html.RenderEndTag();

                // Close tr
                html.RenderEndTag();
            }

            // Close table
            html.RenderEndTag();

            return html.InnerWriter.ToString();
        }


    }
}
