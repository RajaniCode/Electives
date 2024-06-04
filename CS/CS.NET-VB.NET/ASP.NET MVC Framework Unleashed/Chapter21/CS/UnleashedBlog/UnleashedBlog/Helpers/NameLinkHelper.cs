using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnleashedBlog.Models;
using System.Web.Mvc.Html;
using System.Web.Mvc;

namespace UnleashedBlog.Helpers
{
    public static class NameLinkHelper
    {
        public static string NameLink(this HtmlHelper helper, Comment comment)
        {
            if (!String.IsNullOrEmpty(comment.Url))
            {
                var tb = new TagBuilder("a");
                tb.SetInnerText(comment.Name);
                tb.MergeAttribute("href", comment.Url);
                return tb.ToString(TagRenderMode.Normal);
            }
            return helper.Encode(comment.Name);
        }

    }
}
