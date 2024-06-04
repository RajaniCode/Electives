//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.Common.SSOApplicationConfig
// Helper console application to set values of config parameters in the SSO config store.
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Collections.Specialized;
using Microsoft.BizTalk.SSOClient.Interop;

namespace Microsoft.Samples.BizTalk.Common.SSOApplicationConfig
{
	/// <summary>
	/// Simple class to implement a property bag to support SSO interaction
	/// 
	/// </summary>
	internal class ConfigPropertyBag : IPropertyBag
	{
		private HybridDictionary configParamsValues;
		
		internal ConfigPropertyBag()
		{
            configParamsValues = new HybridDictionary();	
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
			configParamsValues[propName] = propval;
		}
	}
}
