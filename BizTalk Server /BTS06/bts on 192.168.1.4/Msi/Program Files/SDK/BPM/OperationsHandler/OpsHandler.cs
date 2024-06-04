//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.Operations.OpsHandler
// Handles Operations notifications
// 
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//

#region Using directives
using System;
using System.Text;
using System.Diagnostics;
#endregion

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.Operations
{
    /// <summary>
    /// Remoted OpsHandler implementing the IOperationsSystem
    /// </summary>
    public class OpsHandler : MarshalByRefObject, IOperationsSystem
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public OpsHandler() 
        {
        }

        #region IOperationsSystem Members
        /// <summary>
        /// Initializes the instance
        /// </summary>
        /// <param name="initData">Configuration data</param>
        public void Initialize(string initData)
        {
            Trace.WriteLine("\nInitialize called with config: " + initData);
        }

        /// <summary>
        /// Posts the message to the operations system.
        /// </summary>
        /// <param name="originMachine">machine message originated from</param>
        /// <param name="message">message to post</param>
        public void Post(string originMachine, byte[] message)
        {
            char[] cArray = new char[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                cArray[i] = (char)message[i];
            }
            StringBuilder sb = new StringBuilder();
            sb.Insert(0, cArray, 0, message.Length);
            Trace.WriteLine("Received message from machine " + originMachine + " [" + message.Length + " bytes]:");
            Trace.WriteLine(sb.ToString());
        }
        #endregion // IOperationsSystem Members
    }
}
