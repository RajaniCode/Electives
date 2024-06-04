//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.Config
// Helper class to read configuration values of the scenario.
//
// Copyright (c) Microsoft Corporation. All rights reserved  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Collections.Specialized;
using Microsoft.BizTalk.SSOClient.Interop;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.ConfigHelper
{
	/// <summary>
	/// Simple class to implement a property bag to support SSO interaction
	/// 
	/// </summary>
	internal class ConfigPropertyBag : IPropertyBag
	{
		private NameValueCollection configParamsValues;
		
		internal ConfigPropertyBag()
		{
			configParamsValues = new NameValueCollection();	
		}

		/// <summary>
		/// Read a propertie's value from the bag...
		/// </summary>
		/// <param name="propName"></param>
		/// <param name="propval"></param>
		/// <param name="errorlog"></param>
		public void Read(string propName, out object propval, int errorlog)
		{
			try
			{
				propval = configParamsValues[propName];
			}
			catch (System.ArgumentOutOfRangeException)
			{
				propval = "";
			}
		}

		/// <summary>
		/// Write method
		/// </summary>
		/// <param name="propName"></param>
		/// <param name="propval"></param>
		public void Write(string propName, ref object propval)
		{
			configParamsValues[propName] = (string)propval;
		}
	}
}
