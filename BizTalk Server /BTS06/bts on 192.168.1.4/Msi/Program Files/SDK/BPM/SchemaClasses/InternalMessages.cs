//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses
// Schema classes used internally amongst orchestrations
//  
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Microsoft.XLANGs.BaseTypes;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses
{
    /// <summary>
    /// Base class for all .net messages used for inter-orchestration communication
    /// </summary>
	[Serializable]
	public class OrderHeader
	{
        [System.Xml.Serialization.XmlElement]
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [PropertyAttribute(typeof(Microsoft.Samples.BizTalk.SouthridgeVideo.Schemas.CustID))]
        public string CustomerID;

        [System.Xml.Serialization.XmlElement]
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [PropertyAttribute(typeof(Microsoft.Samples.BizTalk.SouthridgeVideo.Schemas.OrderID))]
        public string OrderID;

        [System.Xml.Serialization.XmlElement]
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [PropertyAttribute(typeof(Microsoft.Samples.BizTalk.SouthridgeVideo.Schemas.SeqNum))]
        public int SeqNum;

        [System.Xml.Serialization.XmlElement]
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [PropertyAttribute(typeof(Microsoft.Samples.BizTalk.SouthridgeVideo.Schemas.Status))]
        public string Status;
	}

	/// <summary>
	/// OrderAck used to ack receipt of an order.
	/// </summary>
	[Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.OrderAck")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.OrderAck", IsNullable = false)]
	public class OrderAck : OrderHeader
	{
		public OrderAck() {}
	}

	/// <summary>
	/// Interrupt message used to interrupt an order.
	/// </summary>
	[Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.Interrupt")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.Interrupt", IsNullable = false)]
	public class Interrupt : OrderHeader
	{
		public Interrupt() {}
	}

	/// <summary>
	/// Terminated message used to indicate that order was abruptly terminated
	/// </summary>
	[Serializable]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.Terminated")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.Terminated", IsNullable = false)]
	public class Terminated : OrderHeader
	{
		public Terminated() {}
	}

    /// <summary>
    /// Routing message used to route messages through the order manager
    /// </summary>
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.Routing")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.Routing", IsNullable = false)]
    public class Routing : OrderHeader
    {
        public Routing() { }
        [PropertyAttribute(typeof(Microsoft.Samples.BizTalk.SouthridgeVideo.Schemas.OrderMgrType))]
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [System.Xml.Serialization.XmlElement]
        public string OrderMgrType;
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [System.Xml.Serialization.XmlElement]
        public string OrderMgrReturnAddress;
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [System.Xml.Serialization.XmlElement]
        public string SourceSystem;
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [System.Xml.Serialization.XmlElement]
        public string RequestType;
        [PropertyAttribute(typeof(Microsoft.Samples.BizTalk.SouthridgeVideo.Schemas.Stage))]
        [CLSCompliant(false)]
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [System.Xml.Serialization.XmlElement]
        public uint Stage;
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [System.Xml.Serialization.XmlElement]
        public string RequestID;
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [System.Xml.Serialization.XmlElement]
        public string Error;
    }

    /// <summary>
    /// OrderStatus message used to return the status of the order
    /// </summary>
    [Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.OrderStatus")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://Microsoft.Samples.BizTalk.SouthridgeVideo.SchemaClasses.OrderStatus", IsNullable = false)]
    public class OrderStatus : OrderHeader
    {
        public OrderStatus() { }
        [PropertyAttribute(typeof(Microsoft.Samples.BizTalk.SouthridgeVideo.Schemas.Error))]
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [System.Xml.Serialization.XmlElement]
        public string Error;
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [System.Xml.Serialization.XmlElement]
        public string ErrorComplete;
        [Microsoft.XLANGs.BaseTypes.DistinguishedField]
        [System.Xml.Serialization.XmlElement]
        public string OriginalOrder;
    }
}
