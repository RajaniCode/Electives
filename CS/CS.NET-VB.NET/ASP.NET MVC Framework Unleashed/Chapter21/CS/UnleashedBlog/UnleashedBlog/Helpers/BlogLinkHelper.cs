using System.Web.Mvc;
using System.Web.Mvc.Html;
using UnleashedBlog.Models;

namespace UnleashedBlog.Helpers
{
    public static class BlogLinkHelper
    {
        public static string BlogLink(this HtmlHelper helper, BlogEntry entry)
        {
            return helper.RouteLink(entry.Title, "Details", new { year = entry.DatePublished.Year, month = entry.DatePublished.Month, day = entry.DatePublished.Day, name = entry.Name });
        }
    }
}
