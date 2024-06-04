//---------------------------------------------------------------------
// File:      SSOConfigHelper.cs
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
using System.Collections;
using System.Collections.Specialized;
using Microsoft.BizTalk.SSOClient.Interop;

namespace  Microsoft.Samples.BizTalk.Litware.Utilities
{
	public class ConfigurationPropertyBag : Microsoft.BizTalk.SSOClient.Interop.IPropertyBag
	{
		private HybridDictionary properties;
		
		internal ConfigurationPropertyBag() 
		{
			properties = new HybridDictionary();
		}

		public void Read(string propName, out object ptrVar, int errorLog) 
		{
			ptrVar = properties[propName];
		}

		public void Write(string propName, ref object ptrVar) 
		{
			properties.Add(propName, ptrVar);
		}

		public bool Contains(string key)
		{
			return properties.Contains(key);
		}

		public void Remove(string key)
		{
			properties.Remove(key);
		}
	}

	public sealed class SSOConfigHelper
	{
		private const string appName = "Litware.B2BHub";
		private const string idenifierGUID = "ConfigProperties";

		// No instances allowed...
		private SSOConfigHelper()
		{
		}

		public static string Read(string propertyName)
		{
			try
			{
				SSOConfigStore ssoStore = new Microsoft.BizTalk.SSOClient.Interop.SSOConfigStore();

				ConfigurationPropertyBag dbConnBag = new ConfigurationPropertyBag();
				((ISSOConfigStore)ssoStore).GetConfigInfo(appName, idenifierGUID, 4, (Microsoft.BizTalk.SSOClient.Interop.IPropertyBag)dbConnBag);
				
				object propertyValue = null;
				
				dbConnBag.Read(propertyName, out propertyValue, 0);
				return (string)propertyValue;
			}
			catch (Exception e)
			{
				System.Diagnostics.Trace.WriteLine(e.Message);
				throw ;
			}
		}

		//public static void Add(string propertyName, string propertyValue)
		//{
		//    try
		//    {
		//        SSOConfigStore ssoStore = new Microsoft.BizTalk.SSOClient.Interop.SSOConfigStore();

		//        ConfigurationPropertyBag theBag = new ConfigurationPropertyBag();
		//        try
		//        {
		//            ((ISSOConfigStore)ssoStore).GetConfigInfo(appName, idenifierGUID, 4, (Microsoft.BizTalk.SSOClient.Interop.IPropertyBag)theBag);

		//            if (theBag.Contains(propertyName))
		//                theBag.Remove(propertyName);
		//        }
		//        catch
		//        {
		//        }

		//        object datain = propertyValue;
		//        theBag.Write(propertyName, ref datain);

		//        ((ISSOConfigStore)ssoStore).SetConfigInfo(appName, idenifierGUID, (Microsoft.BizTalk.SSOClient.Interop.IPropertyBag)theBag);
		//    }
		//    catch (Exception e)
		//    {
		//        System.Diagnostics.Trace.WriteLine(e.Message);
		//        throw ;
		//    }
		//}


		//public static void RemoveAll()
		//{
		//    try
		//    {
		//        SSOConfigStore ssoStore = new Microsoft.BizTalk.SSOClient.Interop.SSOConfigStore();

		//        ((ISSOConfigStore)ssoStore).DeleteConfigInfo(appName, idenifierGUID);
		//    }
		//    catch (Exception e)
		//    {
		//        System.Diagnostics.Trace.WriteLine(e.Message);
		//        throw e;
		//    }
		//}

	}
}

 
