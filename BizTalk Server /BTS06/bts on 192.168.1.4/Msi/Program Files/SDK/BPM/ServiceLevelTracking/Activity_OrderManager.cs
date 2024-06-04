//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.ServiceLevelTracking
// Helper functions for collecting BAM data of the end-to-end BPM scenario
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------

using System;
using System.Text;
using System.Management;
using System.Collections.Generic;
using Microsoft.BizTalk.Bam.EventObservation;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.ServiceLevelTracking
{
    public class OrderManager : BasicActivity
    {
        //  Activity Name

        private const string ActivityName = "OrderManager";

        //  Activity Milestones

        private const string MilestoneOrderStarted = "Order Started";
        private const string MilestoneUpdateReceived = "Update Received";
        private const string MilestoneTerminateReceived = "Terminate Received";
        private const string MilestoneOrderCompleted = "Order Complete";

        //  Activity Data

        private const string DataCustomerId = "CustomerID";
        private const string DataOrderId = "OrderID";
        private const string DataSequenceNumber = "SequenceNum";
        private const string DataError = "ErrorInfo";

        // References

        public const string ReferenceRoot = "OrderManager";
        public const string ReferenceRelationship = ServiceOrderRequest.ReferenceRoot;

        /// <summary>
        /// Constructor
        /// </summary>
        public OrderManager()
        {
        }

        /// <summary>
        /// Starts collecting BAM data from the current Activity
        /// </summary>
        /// <param name="requestId">request id of the order</param>
        /// <returns>Activity ID</returns>
        public static string StartCollecting(string requestId)
        {
            string activityID = CreateActivityId(ReferenceRoot, requestId);
            BeginActivity(ActivityName, activityID);
            return activityID;
        }

        /// <summary>
        /// Creates a relationship with the Service Order Request activity
        /// </summary>
        /// <param name="activityId">activity id of this activity</param>
        /// <param name="requestId">request id of order</param>
        public static void ActivateRelationship(string activityId, string requestId)
        {
            string relatedActivityID = CreateActivityId(ReferenceRelationship, requestId);

            System.Diagnostics.Debug.WriteLine("SLT: AddRelatedActivity (ActName:<" + ActivityName + ">, ActID:<" + activityId + ">, RelActName:<" + ServiceOrderRequest.ActivityName + ">, RelActID: <" + relatedActivityID + ">)");

            OrchestrationEventStream.AddRelatedActivity(ActivityName, activityId, ServiceOrderRequest.ActivityName, relatedActivityID);
        }

        /// <summary>
        /// Order manager has received an order and is starting the staged order process
        /// </summary>
        /// <param name="activityId">activity id</param>
        /// <param name="customerId">customer id</param>
        /// <param name="orderId">order id</param>
        /// <param name="sequenceNumber">sequence number of order</param>
        public static void OrderStarted(string activityId, string customerId, string orderId, int sequenceNumber)
        {
            OrchestrationEventStream.UpdateActivity(
                            ActivityName, activityId,
                            DataCustomerId, customerId,
                            DataOrderId, orderId,
                            DataSequenceNumber, sequenceNumber);

            UpdateMilestone(activityId, MilestoneOrderStarted);
        }

        /// <summary>
        /// Ends collecting BAM Data for the [Customer Order Request] Activity
        /// </summary>
        /// <param name="activityId">activity Id</param>
        public static void EndCollecting(string activityId)
        {
            EndActivity(ActivityName, activityId);
        }

        /// <summary>
        /// Adds error information to the BAM activity
        /// </summary>
        /// <param name="activityId">Activity ID</param>
        /// <param name="error">error to add</param>
        public static void ErrorOccurred(string activityId, string error)
        {
            OrchestrationEventStream.UpdateActivity(ActivityName, activityId, DataError, error);
        }

        /// <summary>
        /// An update to the order has been received
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void UpdateReceived(string activityId)
        {
            UpdateMilestone(activityId, MilestoneUpdateReceived);
        }

        /// <summary>
        /// A terminate request has been received
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void TerminateReceived(string activityId)
        {
            UpdateMilestone(activityId, MilestoneTerminateReceived);
        }

        /// <summary>
        /// Order has completed
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void OrderCompleted(string activityId)
        {
            UpdateMilestone(activityId, MilestoneOrderCompleted);
        }

        /// <summary>
        /// Utility that helps to Update  a BAM Activity
        /// </summary>
        /// <param name="activityId">Activity Id</param>
        /// <param name="milestoneName">Milestone Name</param>
        private static void UpdateMilestone(string activityId, string milestoneName)
        {
            UpdateActivity(ActivityName, activityId, milestoneName);
        }
    }
}
