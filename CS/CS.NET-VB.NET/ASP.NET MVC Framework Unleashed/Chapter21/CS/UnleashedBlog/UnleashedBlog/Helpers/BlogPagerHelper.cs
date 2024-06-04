using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using Paging;
using System.Collections.Generic;

namespace UnleashedBlog.Helpers
{
    public static class BlogPagerHelper
    {

        public static string BlogPager(this HtmlHelper helper, IPagedList pager)
        {
            // Don't display anything if not multiple pages
            if (pager.TotalPageCount == 1)
                return string.Empty;

            // Build route data
            var routeData = new RouteValueDictionary(helper.ViewContext.RouteData.Values);

            // Build string
            var sb = new StringBuilder();

            // Render Newer Entries
            if (pager.PageIndex > 0)
            {
                routeData["page"] = pager.PageIndex - 1;
                sb.Append(helper.ActionLink("Newer Entries", "Index", routeData));
            }

            // Render divider
            if (pager.PageIndex > 0 && pager.PageIndex < pager.TotalPageCount - 1)
                sb.Append(" | ");

            // Render Older Entries
            if (pager.PageIndex < pager.TotalPageCount - 1)
            {
                routeData["page"] = pager.PageIndex + 1;
                sb.Append(helper.ActionLink("Older Entries", "Index", routeData));
            }

            return sb.ToString();
        }


        public static string BlogPager(this AjaxHelper helper, IPagedList pager)
        {
            // Don't display anything if not multiple pages or no more entries
            if (pager.TotalPageCount == 1 || pager.PageIndex == pager.TotalPageCount -1)
                return string.Empty;

            // Build route data
            var routeData = new RouteValueDictionary(helper.ViewContext.RouteData.Values);

            // Build Ajax options
            var options = new AjaxOptions 
                { 
                    UpdateTargetId = "blogEntries", 
                    InsertionMode=InsertionMode.InsertAfter, 
                    LoadingElementId="loadingMoreEntries",
                    OnBegin= "function() {this.style.display='none';}"
                };

            // Render More Entries
            routeData["page"] = pager.PageIndex + 1;
            return helper.ActionLink("More Entries", "Index", routeData, options);
        }




    }
}
