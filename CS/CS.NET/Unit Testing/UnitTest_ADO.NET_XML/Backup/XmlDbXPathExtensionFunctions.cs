using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace OpenVue.XmlDbTier
{
	/// <summary>
	/// Definitions of all custom functions
	/// </summary>
	public class XmlDbXPathExtensionFunctions
	{
		/// <summary>
		/// Current <see cref="XsltContext"/>
		/// </summary>
		public static XsltContext currentXsltContext;

		/// <summary>
		/// Current <see cref="XPathNavigator"/>
		/// </summary>
		public static XPathNavigator currentXPathNavigator;

		/// <summary>
		/// Get current <see cref="DateTime"/>
		/// </summary>
		/// <returns></returns>
		public static long ex_now()
		{
			return DateTime.Now.Ticks;
		}
		
		/// <summary>
		/// Evaluates ticks from a Xml node
		/// </summary>
		/// <param name="it">Xml node</param>
		/// <returns></returns>
		public static long ex_ticks(XPathNodeIterator it)
		{
			return it.MoveNext() ? ex_ticks(it.Current.Value) : -1;
		}
		/// <summary>
		/// Evaluates ticks from any object
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static long ex_ticks(Object obj)
		{
			long ticks = -1;
			try
			{
				ticks = Convert.ToDateTime(obj).Ticks;
			}
			catch(Exception e)
			{
				XmlDbErrorsReport.Append(e, obj.ToString());
			}
			return ticks;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="it"></param>
		/// <returns></returns>
		public static int ex_year(XPathNodeIterator it)
		{
            return it.MoveNext() ? ex_year(it.Current.Value) : -1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static int ex_year(Object obj)
		{
			int year = -1;
			try
			{
				year = Convert.ToDateTime(obj).Year;
			}
			catch(Exception e)
			{
				XmlDbErrorsReport.Append(e, obj.ToString());
			}
			return year;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="it"></param>
		/// <returns></returns>
		public static int ex_month(XPathNodeIterator it)
		{
			return it.MoveNext() ? ex_month(it.Current.Value) : -1;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static int ex_month(Object obj)
		{
			int month = -1;
			try
			{
				month = Convert.ToDateTime(obj).Month;
			}
			catch(Exception e)
			{
				XmlDbErrorsReport.Append(e, obj.ToString());
			}
			return month;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="it"></param>
		/// <returns></returns>
		public static int ex_day(XPathNodeIterator it)
		{
			return it.MoveNext() ? ex_day(it.Current.Value) : -1;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static int ex_day(Object obj)
		{
			int day = -1;
			try
			{
				day = Convert.ToDateTime(obj).Day;
			}
			catch(Exception e)
			{
				XmlDbErrorsReport.Append(e, obj.ToString());
			}
			return day;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="it"></param>
		/// <returns></returns>
		public static int ex_hour(XPathNodeIterator it)
		{
			return it.MoveNext() ? ex_hour(it.Current.Value) : -1;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static int ex_hour(Object obj)
		{
			int hour = -1;
			try
			{
				hour = Convert.ToDateTime(obj).Hour;
			}
			catch(Exception e)
			{
				XmlDbErrorsReport.Append(e, obj.ToString());
			}
			return hour;
		}		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="it"></param>
		/// <returns></returns>
		public static int ex_minute(XPathNodeIterator it)
		{
			return it.MoveNext() ? ex_minute(it.Current.Value) : -1;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static int ex_minute(Object obj)
		{
			int minute = -1;
			try
			{
				minute = Convert.ToDateTime(obj).Minute;
			}
			catch(Exception e)
			{
				XmlDbErrorsReport.Append(e, obj.ToString());
			}
			return minute;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="it"></param>
		/// <returns></returns>
		public static int ex_second(XPathNodeIterator it)
		{
			return it.MoveNext() ? ex_second(it.Current.Value) : -1;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static int ex_second(Object obj)
		{
			int second = -1;
			try
			{
				second = Convert.ToDateTime(obj).Second;
			}
			catch(Exception e)
			{
				XmlDbErrorsReport.Append(e, obj.ToString());
			}
			return second;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="it"></param>
		/// <returns></returns>
		public static double ex_abs(XPathNodeIterator it)
		{
			return ex_abs(it.Current.Value);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static double ex_abs(Object obj)
		{
			return Math.Abs(Convert.ToDouble(obj));
		}
	}
}
