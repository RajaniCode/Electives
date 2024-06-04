//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.Operations.OpsExceptions
// Exception classes for Operations components
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

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.Operations
{
    /// <summary>
    /// Exception thrown from business logic portion of code.
    /// </summary>
    [Serializable]
    public class OpsClientException : Exception
    {
        /// <summary>
        /// OpsClientException constructor
        /// </summary>
        public OpsClientException() : base() { }
        /// <summary>
        /// OpsClientException constructor
        /// </summary>
        /// <param name="msg">exception message</param>
        public OpsClientException(string msg) : base(msg) { }
        /// <summary>
        /// OpsClientException constructor
        /// </summary>
        /// <param name="inner">inner exception</param>
        public OpsClientException(Exception inner) : base(string.Empty, inner) { }
        /// <summary>
        /// OpsClientException constructor
        /// </summary>
        /// <param name="msg">exception message</param>
        /// <param name="ex">inner exception</param>
        public OpsClientException(string msg, Exception ex) : base(msg, ex) { }
        /// <summary>
        /// OpsClientException constructor for serialization
        /// </summary>
        /// <param name="info">serialization info</param>
        /// <param name="context">streaming context</param>
        protected OpsClientException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
