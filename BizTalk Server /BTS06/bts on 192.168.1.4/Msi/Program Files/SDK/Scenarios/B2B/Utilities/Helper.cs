//---------------------------------------------------------------------
// File:      Helper.cs
// 
// Summary:   
//
// Sample:    Litware scenario
//
//---------------------------------------------------------------------
// This file is part of the Microsoft BizTalk Server 2006 SDK
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft BizTalk
// Server 2006 release and/or on-line documentation. See these other
// materials for detailed information regarding Microsoft code samples.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
// PURPOSE.
//---------------------------------------------------------------------
using System;
using System.Xml;

namespace Microsoft.Samples.BizTalk.Litware.Utilities
{
	public sealed class XmlHelper
	{
		// No instances allowed...
		private XmlHelper()
		{ 
		}

		public static System.Xml.XmlDocument ConvertStringToXml(string xmlText)
		{
			if (null == xmlText) return null;
			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
			doc.LoadXml(xmlText);
			return doc;
		}

		public static string ConvertXmlToString(System.Xml.XmlDocument doc)
		{
			if (null != doc)
				return doc.OuterXml;
			else
				return null;
		}

		public static string GetPartnerEmail(System.Xml.XmlDocument doc)
		{
			if (null == doc) throw new ArgumentNullException("doc", "Partner xml document can not be null");

			XmlNode firstEmailNode = doc.DocumentElement.SelectSingleNode("*[local-name()='Contacts' and namespace-uri()='http://www.microsoft.com/BizTalk/KwTpm']/*[local-name()='Contact' and namespace-uri()='http://www.microsoft.com/BizTalk/KwTpm'][1]/*[local-name()='Emails' and namespace-uri()='http://www.microsoft.com/BizTalk/KwTpm'][1]/*[local-name()='Email' and namespace-uri()='http://www.microsoft.com/BizTalk/KwTpm']/*[local-name()='EmailAddress' and namespace-uri()='http://www.microsoft.com/BizTalk/KwTpm']");
			return "mailto:" + firstEmailNode.InnerText.Trim();
		}
	}

	public sealed class ResourceHelper
	{
		// No instances allowed...
		private ResourceHelper()
		{ 
		}

		public static System.Xml.XmlDocument GetEmptyUserMessage()
		{
			return GetEmptyMessage("ProfileMessage");
		}

		public static System.Xml.XmlDocument GetEmptyOrderMessage()
		{
			return GetEmptyMessage("POMessage");
		}

		public static System.Xml.XmlDocument GetEmptyProfileAck()
		{
			return GetEmptyMessage("ProfileAck");
		}

		public static System.Xml.XmlDocument GetEmptyOrderAck()
		{
			return GetEmptyMessage("OrderAck");
		}

		public static System.Xml.XmlDocument GetEmptyBusinessFault()
		{
			return GetEmptyMessage("BusinessFault");
		}

		public static System.Xml.XmlDocument GetEmptySystemFault()
		{
			return GetEmptyMessage("SystemFault");
		}

		public static System.Xml.XmlDocument GetEmptyMessage(string messageID)
		{
			System.Resources.ResourceManager resMgr = Microsoft.Samples.BizTalk.Litware.Utilities.Resources.ResourceManager;
			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
			doc.LoadXml(resMgr.GetString(messageID));
			return doc;
		}

		public static string GetMessageString(string resourceId)
		{
			System.Resources.ResourceManager resMgr = Microsoft.Samples.BizTalk.Litware.Utilities.Resources.ResourceManager;
			return resMgr.GetString(resourceId);
		}
	}

	//public class ConfigHelper
	//{
	//    public static int GetRetryCount()
	//    {
	//        return Convert.ToInt32(
	//                        SSOConfigHelper.Read("retryCount"),
	//                        System.Globalization.CultureInfo.CurrentCulture
	//                    );
	//    }
	//}
}