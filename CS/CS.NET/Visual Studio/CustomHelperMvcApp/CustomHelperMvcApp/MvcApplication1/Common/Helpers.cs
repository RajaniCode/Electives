using System.Web.Mvc;

namespace MvcApplication1.Common
{
    public static class Helpers
    {
        public static string Span(this HtmlHelper html, string text)
        {
            var builder = new TagBuilder("span");
            builder.GenerateId("firstName");
            builder.SetInnerText(text);
            return builder.ToString(TagRenderMode.Normal);
        }        
    }
}
