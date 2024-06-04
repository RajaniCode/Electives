using System;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using UnleashedBlog.Models;

namespace UnleashedBlog.Helpers
{
    public static class ArchiveLinkHelper
    {
        public static string ArchiveLink(this HtmlHelper helper, ArchiveInfo archiveInfo)
        {

            string monthName = GetMonthName(archiveInfo.Month); 
            string linkText = String.Format("{0}, {1} ({2})", monthName, archiveInfo.Year, archiveInfo.Count);
            return helper.RouteLink(linkText, "ArchiveYearMonth",  new {year=archiveInfo.Year, month=archiveInfo.Month});           
        }


        private static string GetMonthName(int monthNumber)
        {
            DateTimeFormatInfo dtf = new DateTimeFormatInfo();
            return dtf.GetMonthName(monthNumber);
        }

    }
}
