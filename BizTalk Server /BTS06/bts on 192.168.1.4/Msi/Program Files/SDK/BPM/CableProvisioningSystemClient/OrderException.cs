//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.CableProvisioningSystem
// Order exceptions
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

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.CableProvisioningSystem
{
	/// <summary>
	/// Exception thrown from business logic portion of code.
	/// </summary>
	[Serializable]
	public class OrderException : ApplicationException
	{
		public OrderException() : base() {}
		public OrderException( string msg ) : base( msg ) {}
		public OrderException( Exception inner ) : base( string.Empty, inner ) {}
		public OrderException( string msg, Exception ex ) : base( msg, ex ) {}
		protected OrderException( SerializationInfo info, StreamingContext context) : base( info, context ) {}
	}
}
