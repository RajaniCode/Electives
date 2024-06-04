//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTracker.CallPipelinesHelper
// Helper assembly for calling pipelines from orchestrations...
// 
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//

using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.XLANGs.BaseTypes;
using Microsoft.XLANGs.Pipeline;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.Utilities
{
	/// <summary>
	/// Helper class to call receive pipelines from orchestrations.  The primary reason for this 
	/// class is to handle the non-serializable type Microsoft.XLANGs.Pipeline.ReceivePipelineOutputMessages.
	/// A variable of this type can not be declared in the orchestration without introducing 
	/// atomic scopes.  In a low latency scenario, we want to avoid atomic scopes as they introduce
	/// persistence points.
	/// 
	/// </summary>
	public sealed class ReceivePipelineHelper
	{
		/// <summary>
		/// private Constructor - no instances allowed...
		/// </summary>
		private ReceivePipelineHelper()
		{ 
		}

		/// <summary>
		/// Call a given receive pipeline with one input message and return one output message
		/// </summary>
		/// <param name="receivePipelineType">
		/// type of the receive pipeline.
		/// </param>
		/// <param name="pipelineInputMessage">
		/// message to be processed through the receive pipeline.
		/// </param>
		
		public static void CallReceivePipeline(Type receivePipelineType, XLANGMessage pipelineInputMessage, XLANGMessage pipelineOutputMessage)
		{

			// Execute the receive pipeline...

			ReceivePipelineOutputMessages receivePipelineOutput = 
				XLANGPipelineManager.ExecuteReceivePipeline(
					receivePipelineType,
					pipelineInputMessage );

			// We expect only one message in the response...
			receivePipelineOutput.MoveNext();

			receivePipelineOutput.GetCurrent(pipelineOutputMessage);
		}
	}
}
