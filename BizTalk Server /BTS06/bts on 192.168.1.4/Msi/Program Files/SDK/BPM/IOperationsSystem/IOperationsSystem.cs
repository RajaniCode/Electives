//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.IOperationsSystem
// Interface for operations system
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.Operations
{
    /// <summary>
    /// Interface used for components that handle messages for the operations system
    /// </summary>
    public interface IOperationsSystem
    {
        /// <summary>
        /// Initialize the component.
        /// </summary>
        /// <param name="initData">initialization data</param>
        void Initialize(string initData);
        /// <summary>
        /// Post a message to the operations system
        /// </summary>
        /// <param name="originMachine">machine that posted the message</param>
        /// <param name="message">message to post</param>
        void Post(string originMachine, byte[] message);
    }
}
