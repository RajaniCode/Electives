//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.StubSAPCall
// Helper assembly to call the Stub SAP web service to get the account details
// 
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//

using System;
using System.Runtime.Serialization;

using Microsoft.XLANGs.BaseTypes;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.StubSapCall
{
	/// <summary>
	/// Stub SAP Call timeout exception.
	/// </summary>
	[Serializable]
	public class StubSapTimeoutException : Microsoft.XLANGs.BaseTypes.TimeoutException
	{
		public StubSapTimeoutException () : base()
		{
		}
		protected StubSapTimeoutException(SerializationInfo si, StreamingContext sc)
			: base(si, sc)
		{
		}
	}
}
