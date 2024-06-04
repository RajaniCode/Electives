using System;
using System.Web.Mvc;
using System.Text;
using System.Drawing;

namespace MvcApplication1.Controllers
{
    public class ColorController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult FetchColors()
        {
            var count = 0;
            var sb = new StringBuilder();
            sb.Append("<table><tbody><tr>");
            
            foreach (var color in Enum.GetNames(typeof(KnownColor)))
            {
                var colorValue = ColorTranslator.FromHtml(color);
                var html = string.Format("#{0:X2}{1:X2}{2:X2}",
                                    colorValue.R, colorValue.G, colorValue.B);
                sb.AppendFormat("<td bgcolor=\"{0}\">&nbsp;</td>", html);
                if (count < 20)
                {
                    count++;
                }
                else
                {
                    sb.Append("</tr><tr>");
                    count = 0;
                }
            }
            sb.Append("</tbody></table>");
            return Json(sb.ToString());
        }
    }
}
