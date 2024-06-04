//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.PendingTransactionsCall
// Helper assembly to call the Pending Transaction System inline from orchestrations.
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

namespace Microsoft.Samples.BizTalk.WoodgroveBank.PendingTransactionsCall
{
	/// <summary>
	/// Summary description for Exceptions.
	/// </summary>
	
	[Serializable]
	public class PendingTransactionsTimeoutException : Microsoft.XLANGs.BaseTypes.TimeoutException
	{
		public PendingTransactionsTimeoutException () : base()
		{
		}

		protected PendingTransactionsTimeoutException(SerializationInfo si,	StreamingContext sc)
			: base(si, sc)
		{
		}
	}
}
