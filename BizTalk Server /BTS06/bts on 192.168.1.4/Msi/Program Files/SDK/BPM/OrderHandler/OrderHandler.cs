//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.OrderHandler
// Handles service order requests
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
using System.Diagnostics;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.CableProvisioningSystem
{
    /// <summary>
    /// Summary description for OrderHandler.
    /// </summary>
    public class OrderHandler : MarshalByRefObject, IOrderHandler
    {
        private Random r;
        // Relies on the values to be in order. Do not assign values to these enums.
        // MAXSERVICESTYPE used as maximum value to count number of items in enum.
        private enum ServiceType {STANDARD=0, DELUXE, MAXSERVICETYPE};

        /// <summary>
        /// OrderHandler Constructor.  This object can only be instantiated by CableProvisioningSystemClient
        /// </summary>
        public OrderHandler() 
        {
            // Initialize the random number generator using the
            // time in ticks.
            this.r = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Analyzes the business validity and consistency of the request
        /// </summary>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        /// <param name="orderTypeCode">Order Type Code</param>
        /// <param name="orderSeqNumber">order sequence number</param>
        /// <param name="orderDate">date of the order</param>
        /// <returns>true if analysis succeeded</returns>
        public bool Analyze(string customerId, string orderId, string orderTypeCode, int orderSeqNumber, DateTime orderDate)
        {
            Trace.WriteLine("Analyze called for customer " + customerId + " for order: " + orderId + " sequence: " + orderSeqNumber);
            return true;
        }

        /// <summary>
        /// Gets the current service type for this customer
        /// </summary>
        /// <param name="customerId">customer identifier</param>
        /// <returns>the service type currently active for this customer</returns>
        public string GetServiceType(string customerId)
        {
            // Get the current service type
            // Here we will randomly pick the service type
            string serviceType = Enum.GetName(typeof(ServiceType), r.Next((int)ServiceType.MAXSERVICETYPE));
            Trace.WriteLine("GetServiceType called for customer " + customerId + ". ServiceType = " + serviceType);
            return serviceType;
        }

        /// <summary>
        /// Activates the service type specified
        /// </summary>
        /// <param name="serviceType">service type; either "STANDARD" | "DELUXE"</param>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        public void Activate(string serviceType, string customerId, string orderId)
        {
            // new service type isn't active until Complete is called
            Trace.WriteLine(serviceType + " Activate called for customer " + customerId + " for order: " + orderId);
        }

        /// <summary>
        /// Cancels the current service
        /// </summary>
        /// <param name="serviceType">type of cable service</param>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        public void Cancel(string serviceType, string customerId, string orderId)
        {
            // service isn't canceled until Complete is called
            Trace.WriteLine(serviceType + " Cancel called for customer " + customerId + " for order: " + orderId);
        }

        /// <summary>
        /// Commits the changes made in this object
        /// </summary>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        public void Complete(string customerId, string orderId)
        {
            Trace.WriteLine("Complete called for customer " + customerId + " for order: " + orderId + "\n");
        }
    }
}
