//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.CableProvisioningSystem
// Interface used for cable provisioning system service order requests
// 
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.CableProvisioningSystem
{
    /// <summary>
    /// IOrderHandler interface used to communicate with remote server
    /// </summary>
    public interface IOrderHandler
    {
        /// <summary>
        /// Business semantic checking for a cable order
        /// </summary>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        /// <param name="orderTypeCode">type of order</param>
        /// <param name="orderSeqNumber">sequence number of {customerId, orderId} order</param>
        /// <param name="orderDate">date order was placed</param>
        /// <returns>true if analyze succeeded, false otherwise</returns>
        bool Analyze(string customerId, string orderId, string orderTypeCode, int orderSeqNumber, DateTime orderDate);
        /// <summary>
        /// Gets the current service type for this customer
        /// </summary>
        /// <param name="customerId">customer identifier</param>
        /// <returns>the service type currently active for this customer</returns>
        string GetServiceType(string customerId);
        /// <summary>
        /// Activates a cable service
        /// </summary>
        /// <param name="serviceType">type of cable service</param>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        void Activate(string serviceType, string customerId, string orderId);
        /// <summary>
        /// Cancels a customer's cable service
        /// </summary>
        /// <param name="serviceType">type of cable service</param>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        void Cancel(string serviceType, string customerId, string orderId);
        /// <summary>
        /// Commits the cable service request
        /// </summary>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        void Complete(string customerId, string orderId);
    }
}
