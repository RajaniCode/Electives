using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;


namespace OpenVue.XmlDbTier
{
	/// <summary>
	/// Customized XPath execution context
	/// </summary>
	public class XmlDbXPathContext : XsltContext
	{
		#region Constructors 
		/// <summary>
		/// Initializes a new XmlDbXPathContext instance
		/// </summary>
		public XmlDbXPathContext()
		{}

		/// <summary>
		/// Initializes a new XmlDbXPathContext instance with the <see cref="System.Xml.NameTable"/>
		/// </summary>
		/// <param name="nt"></param>
		public XmlDbXPathContext(NameTable nt) : base(nt)
		{
		}
		#endregion

		/// <summary>
		/// Resolve references to custom functions.
		/// </summary>
		/// <param name="prefix"></param>
		/// <param name="funcName"></param>
		/// <param name="ArgTypes"></param>
		/// <returns></returns>
		public override IXsltContextFunction ResolveFunction(string prefix, 
			string funcName, XPathResultType[] ArgTypes)
		{
			return new XmlDbXPathExtensionFunctionWrapper(prefix + "_" + funcName, ArgTypes);
		}

		/// <summary>
		/// Resolve references to custom variables.
		/// </summary>
		/// <param name="prefix"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public override IXsltContextVariable ResolveVariable(string prefix, string name)
		{
			return null;
		}

		/// <summary>
		/// Compares the base URIs of two documents based upon the order the documents were loaded by the XSLT processor 
		/// </summary>
		/// <param name="baseUri"></param>
		/// <param name="nextbaseUri"></param>
		/// <returns></returns>
		public override int CompareDocument(string baseUri, string nextbaseUri)
		{
			return 0;
		}

		/// <summary>
		/// Evaluates whether to preserve white space nodes or strip them for the given context.
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public override bool PreserveWhitespace(XPathNavigator node)
		{
			return true;
		}

		/// <summary>
		/// Gets a value indicating whether to include white space nodes in the output.
		/// </summary>
		public override bool Whitespace
		{
			get
			{
				return true;
			}
		}
	}
}
