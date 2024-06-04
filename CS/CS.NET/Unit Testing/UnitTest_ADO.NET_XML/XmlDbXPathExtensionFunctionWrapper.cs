using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Text.RegularExpressions;
using System.Reflection;

namespace OpenVue.XmlDbTier
{
	/// <summary>
	/// A XPath custom function wrapper
	/// </summary>
	public class XmlDbXPathExtensionFunctionWrapper : IXsltContextFunction
	{
		#region Private Data
		private XPathResultType[] _argTypes;
		private XPathResultType _returnType;
		private string _functionName;
		private int _argsNum = 0;
		private MethodInfo _methodInfo;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the minimum number of arguments for the function
		/// </summary>
		public int Minargs
		{
			get
			{
				return _argsNum;
			}
		}

		/// <summary>
		/// Gets the maximum number of arguments for the function
		/// </summary>
		public int Maxargs
		{
			get
			{
				return _argsNum;
			}
		}

		/// <summary>
		/// Gets the supplied XPath types for the function's argument list
		/// </summary>
		public XPathResultType[] ArgTypes
		{
			get
			{
				return _argTypes;
			}
		}

		/// <summary>
		/// Gets the <see cref="XPathResultType"/> representing the XPath type returned by the function
		/// </summary>
		public XPathResultType ReturnType
		{
			get
			{
				return _returnType;
			}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor from the function name and the its arguments type list
		/// </summary>
		/// <param name="funcName"></param>
		/// <param name="argTypes"></param>
		public XmlDbXPathExtensionFunctionWrapper(string funcName, XPathResultType[] argTypes)
		{
			int i, j;
			_functionName = funcName;
			Type type = typeof(XmlDbXPathExtensionFunctions);
			MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
			if (methods.Length == 0) return;

			funcName = funcName.ToLower();
			for (i = 0; i < methods.Length; i++)
			{
				if (methods[i].Name.ToLower() != funcName) continue;
				ParameterInfo [] _params = methods[i].GetParameters();
				if (_params.Length != argTypes.Length) continue;
				for (j = 0; j < argTypes.Length; j++)
				{
					XPathResultType tp = ToXPathResultType(_params[j].ParameterType);
					if (!(tp == XPathResultType.Any || tp == argTypes[j])) break;
				}
				if (j == argTypes.Length)
				{
					_methodInfo = methods[i];
					break;
				}
			}
			if (_methodInfo == null) return;
			_returnType = ToXPathResultType(_methodInfo.ReturnType);
			_argsNum = argTypes.Length;
			_argTypes = argTypes;
		}
		#endregion

		#region Help Methods
		private static XPathResultType ToXPathResultType(Type t)
		{
			if (t == typeof(System.String))
				return XPathResultType.String;
			else if (t == typeof(System.Boolean))
				return XPathResultType.Boolean;
			else if (t == typeof(System.Int16) ||
				t ==  typeof(System.Int32) ||
				t ==  typeof(System.Int64) ||
				t ==  typeof(System.Double)||
				t ==  typeof(System.Single))
				return XPathResultType.Number;
			else if (t == typeof(System.Xml.XPath.XPathNodeIterator))
				return XPathResultType.NodeSet;
			else if (t == typeof(System.Xml.XPath.XPathNavigator))
				return XPathResultType.Navigator;
			else
				return XPathResultType.Any;
		}
		#endregion

		#region Methods
		/// <summary>
		/// This method is invoked at run time to execute the user defined function.
		/// </summary>
		/// <param name="xsltContext"></param>
		/// <param name="args"></param>
		/// <param name="docContext"></param>
		/// <returns></returns>
		public object Invoke(XsltContext xsltContext, object[] args, 
			XPathNavigator docContext)
		{
			XmlDbXPathExtensionFunctions.currentXPathNavigator = docContext;
			XmlDbXPathExtensionFunctions.currentXsltContext = xsltContext;
			return _methodInfo.Invoke(null, args);
		} 
		#endregion
	}
}
