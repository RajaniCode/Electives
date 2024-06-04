using System;
using System.Web.Mvc;

namespace Helpers
{
    public static class SubmitButtonHelper
    {
        /// <summary>
        /// Renders an HTML form submit button
        /// </summary>
        public static string SubmitButton(this HtmlHelper helper, string buttonText)
        {
            return String.Format("<input type=\"submit\" value=\"{0}\" />", buttonText);
        }

    }
}
