//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.Utilities
// Exception classes for cable orders
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
using System.Runtime.Serialization;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.Utilities
{
    /// <summary>
    /// Business exceptions when handling cable orders
    /// </summary>
    [Serializable]
    public class CableOrderException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of a CableOrderException
        /// </summary>
        public CableOrderException() { }

        /// <summary>
        /// Initializes a new instance of the CableOrderException class with a
        /// specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public CableOrderException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the CableOrderException class with a
        /// specified error message and a reference to the inner exception that is the
        /// cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the
        /// innerException parameter is not a null reference, the current exception
        /// is raised in a catch block that handles the inner exception. 
        /// </param>
        public CableOrderException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the CableOrderException class with
        /// serialized data.
        /// </summary>
        /// <remarks>
        /// System.Exception impliments ISerializable and therefore the derived
        /// class must impliment its deserialization constructor as orchestrations
        /// will reconstruct objects during the dehyrdration/rehydration process.
        /// </remarks>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected CableOrderException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Exception thrown when a cable order activation fails
    /// </summary>
    [Serializable]
    public class ActivateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of a ActivateException
        /// </summary>
        public ActivateException() { }

        /// <summary>
        /// Initializes a new instance of the ActivateException class with a
        /// specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public ActivateException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the ActivateException class with a
        /// specified error message and a reference to the inner exception that is the
        /// cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the
        /// innerException parameter is not a null reference, the current exception
        /// is raised in a catch block that handles the inner exception. 
        /// </param>
        public ActivateException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the ActivateException class with
        /// serialized data.
        /// </summary>
        /// <remarks>
        /// System.Exception impliments ISerializable and therefore the derived
        /// class must impliment its deserialization constructor as orchestrations
        /// will reconstruct objects during the dehyrdration/rehydration process.
        /// </remarks>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected ActivateException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Exception thrown when a cable order has been interrupted
    /// </summary>
    [Serializable]
    public class InterruptException : Exception
    {
        /// <summary>
        /// Initializes a new instance of a InterruptException
        /// </summary>
        public InterruptException() { }

        /// <summary>
        /// Initializes a new instance of the InterruptException class with a
        /// specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public InterruptException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the InterruptException class with a
        /// specified error message and a reference to the inner exception that is the
        /// cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the
        /// innerException parameter is not a null reference, the current exception
        /// is raised in a catch block that handles the inner exception. 
        /// </param>
        public InterruptException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the InterruptException class with
        /// serialized data.
        /// </summary>
        /// <remarks>
        /// System.Exception impliments ISerializable and therefore the derived
        /// class must impliment its deserialization constructor as orchestrations
        /// will reconstruct objects during the dehyrdration/rehydration process.
        /// </remarks>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected InterruptException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    /// <summary>
    /// Exception thrown when the order manager has an error
    /// </summary>
    [Serializable]
    public class OrderManagerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of a OrderManagerException
        /// </summary>
        public OrderManagerException() { }

        /// <summary>
        /// Initializes a new instance of the OrderManagerException class with a
        /// specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public OrderManagerException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the OrderManagerException class with a
        /// specified error message and a reference to the inner exception that is the
        /// cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the
        /// innerException parameter is not a null reference, the current exception
        /// is raised in a catch block that handles the inner exception. 
        /// </param>
        public OrderManagerException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the OrderManagerException class with
        /// serialized data.
        /// </summary>
        /// <remarks>
        /// System.Exception impliments ISerializable and therefore the derived
        /// class must impliment its deserialization constructor as orchestrations
        /// will reconstruct objects during the dehyrdration/rehydration process.
        /// </remarks>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected OrderManagerException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

