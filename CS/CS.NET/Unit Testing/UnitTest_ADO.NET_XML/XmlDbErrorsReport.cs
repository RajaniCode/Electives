using System;
using System.Xml;

namespace OpenVue.XmlDbTier
{
	/// <summary>
	/// Gather errors/exceptions information to generate a simple errors report
	/// </summary>
	public class XmlDbErrorsReport
	{
		private static XmlDocument _xmlErrorsReport = new XmlDocument();

		/// <summary>
		/// Clear the errors report. Before appending errors/exceptions, 
		/// you MUST call this method at least one time to initialize the errors report.
		/// </summary>
		public static void Clear()
		{
			_xmlErrorsReport.LoadXml("<ErrorsReport></ErrorsReport>");
		}

		/// <summary>
		/// Append an error to the errors report
		/// </summary>
		/// <param name="error">Error message</param>
		/// <param name="note"></param>
		public static void Append(String error, String note)
		{
			XmlElement errorElement = _xmlErrorsReport.CreateElement("Error");
			errorElement.InnerText = error;
			if (note != null)
				errorElement.SetAttribute("Note", note);
			_xmlErrorsReport.DocumentElement.AppendChild(errorElement);
		}

		/// <summary>
		/// Append an exception to the errors report
		/// </summary>
		/// <param name="ex"></param>
		/// <param name="note"></param>
		public static void Append(Exception ex, String note)
		{
			Append(ex.ToString(), note);
		}

		/// <summary>
		/// Generate a simple error report 
		/// </summary>
		/// <returns></returns>
		public static String GenerateXmlErrorsReport()
		{
			return _xmlErrorsReport.OuterXml;
		}

		/// <summary>
		/// If the "condition" is false, append an error to the errors report
		/// </summary>
		/// <param name="condition"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static bool Assert(bool condition, String message)
		{
			if (!condition) Append(message, "Assert Fail!");
			return condition;
		}

		/// <summary>
		/// Determines whether there are errors appended in the errors report
		/// </summary>
		/// <returns></returns>
		public static bool HasErrors()
		{
			return
				_xmlErrorsReport != null &&
				_xmlErrorsReport.DocumentElement != null &&
				_xmlErrorsReport.DocumentElement.HasChildNodes;
		}
	}
}
