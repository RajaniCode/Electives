//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTrackerCall
// Helper assembly to call the Payment Tracking System inline from orchestrations.
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

namespace Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTrackerCall
{
	/// <summary>
	/// Summary description for Exceptions.
	/// </summary>
	[Serializable]
	public class PaymentTrackerTimeoutException : Microsoft.XLANGs.BaseTypes.TimeoutException
	{
		public PaymentTrackerTimeoutException () : base()
		{
		}
				
		protected PaymentTrackerTimeoutException (SerializationInfo si,	StreamingContext sc) 
			: base(si, sc)
		{
		}
	}

	[Serializable]
	public class PaymentTrackerQueueManagerException : System.Exception
	{
		public PaymentTrackerQueueManagerException(string queueManager) 
			: base ("Unable to access MQ Series queue manager: " + queueManager)
		{
		}

		public PaymentTrackerQueueManagerException()
			: base("Unable to access MQ Series queue manager")
		{ 
		}

		public PaymentTrackerQueueManagerException(string msg, Exception innerEx) 
			: base (msg, innerEx)
		{ 
		}

		protected PaymentTrackerQueueManagerException(SerializationInfo si, StreamingContext sc)
			: base(si, sc)
		{ 
		}

	}
	
	//[Serializable]
	//public class PaymentTrackerQueueAccessException : System.Exception
	//{
	//    public PaymentTrackerQueueAccessException (string queueName) 
	//        : base ("Unable to access MQ series queue: " + queueName)
	//    {
	//    }

	//    public PaymentTrackerQueueAccessException() : base ("Unable to access MQ series queue")
	//    {
	//    }
	//}

}
