using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc.Html
{
    public static class PriceHelper
    {
        public static string Price(this HtmlHelper helper,decimal price)
        {
            var PriceClass = "";
            if (price < 20)
                PriceClass = "cheap";
            else if (price <= 50)
                PriceClass = "normal";
            else if (price > 50)
                PriceClass = "expensive";

            TagBuilder tag = new TagBuilder("span");
            tag.AddCssClass(PriceClass);
            tag.SetInnerText("$" +helper.Encode(price.ToString("f2")));

            return tag.ToString();
        }
    }
}
