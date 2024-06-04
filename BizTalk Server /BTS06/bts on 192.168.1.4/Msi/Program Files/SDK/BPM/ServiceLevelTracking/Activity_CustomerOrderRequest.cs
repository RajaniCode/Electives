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
    /// <summary>
    /// This is an helper class to collect data for the [Customer Order Request] BAM Activity.
    /// 
    /// The data are collected from two orchestrations:
    /// 
    ///     OrderBroker (Prj: OrderBroker)
    /// 
    ///         MilestoneReceivedFromCustomer
    ///         MilestoneReceivedFromVendor
    ///             DataCustomerId
    ///             DataOrderId
    ///             DataSequenceNumber 
    ///             DataRequestType
    /// 
    ///         MilestonePostedToHistory
    ///         MilestonePostedToServicing
    ///         MilestoneRepliedToRequester
    ///         MilestoneUpdatedHistory
    ///         MILESTONE_ERROR
    /// 
    ///     CableOrder2 (Prj: CableOrderStage2)
    ///
    ///         MilestoneUpdatedHistory
    /// 
    /// Once the first orchestration (OrderBroker) is started and the MILESTONE_RECEIVED_FROM_*
    /// is reached a continuation statement is issued. The continuation token is the ReqID and
    /// it will be used by the second orchestration (CableOrder2) as the activityId.
    /// </summary>

    public sealed class CustomerOrderRequest : BasicActivity
    {
        //  Activity Name

        public const string ActivityName = "Customer Order Request";

        //  Activity Milestones

        private const string MilestoneReceivedFromCustomer = "Received from CSR";
        private const string MilestoneReceivedFromVendor = "Received from Vendor";
        private const string MilestonePostedToHistory = "Posted to History DB";
        private const string MilestonePostedToServicing = "Posted to Servicing";
        private const string MilestoneRepliedToRequester = "Replied to CSR";
        private const string MilestoneUpdatedHistory = "Updated History DB";

        //  Activity Data

        private const string DataCustomerId = "CustomerID";
        private const string DataOrderId = "OrderID";
        private const string DataSequenceNumber = "SequenceNum";
        private const string DataRequestType = "RequestType";
        private const string DataError = "ErrorInfo";

        // References

        public const string ReferenceRoot = "OrderBroker";
        public const string ReferenceContinuation = "OrderBrokerCompletion";
        public const string ReferenceRelationship = ServiceOrderRequest.ReferenceRoot;
        
        /// <summary>
        /// Private Constructor.  Cannot be constructed, all members are static
        /// </summary>
        private CustomerOrderRequest()
        {
        }

        /// <summary>
        /// Begins a new activity
        /// </summary>
        /// <param name="requestId">unique identifier for this activity</param>
        /// <returns>activity id</returns>
        public static string StartCollecting( string requestId )
        {
            string activityId = CreateActivityId(ReferenceRoot, requestId);
            BeginActivity(ActivityName, activityId);
            return activityId;
        }

        /// <summary>
        /// Gets the activity id to continue this activity
        /// </summary>
        /// <param name="requestId">identifier for this order</param>
        /// <returns>activity id to continue tracking with</returns>
        public static string ContinueCollecting(string requestId)
        {
            return CreateActivityId(ReferenceContinuation, requestId);
        }

        /// <summary>
        /// Begins the [Customer Order Request] BAM Activity for an Order issued by a Customer
        /// Updated the just created activity with the given parameters
        /// Set up the continuation using the ReqID (guid) as the continuation token
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="orderId">Order ID</param>
        /// <param name="sequenceNumber">Order Sequence #</param>
        /// <param name="requestType">Request Type</param>
        /// <returns>Activity ID</returns>
        public static void RequestReceivedFromCustomer(string activityId, string customerId, string orderId, int sequenceNumber, string requestType)
        {
            RequestReceived(activityId, MilestoneReceivedFromCustomer, customerId, orderId, sequenceNumber, requestType);
        }

        /// <summary>
        /// Begins the [Customer Order Request] BAM Activity for an Order issued by a Vendor
        /// Updated the just created activity with the given parameters
        /// Set up the continuation using the ReqID (guid) as the continuation token
        /// </summary>
        /// <param name="milestoneName">Milestone Name</param>
        /// <param name="customerId">Customer ID</param>
        /// <param name="orderId">Order ID</param>
        /// <param name="sequenceNumber">Order Sequence #</param>
        /// <param name="requestType">Request Type</param>
        /// <returns>Activity ID</returns>
        public static void RequestReceivedFromVendor(string activityId, string customerId, string orderId, int sequenceNumber, string requestType)
        {
            RequestReceived(activityId, MilestoneReceivedFromVendor, customerId, orderId, sequenceNumber, requestType);
        }

        /// <summary>
        /// Utility that helps to begin the [Customer Order Request] BAM Activity
        /// Updated the just created activity with the given parameters
        /// Set up the continuation using the ReqID (guid) as the continuation token
        /// </summary>
        /// <param name="milestoneName">Milestone Name</param>
        /// <param name="customerId">Customer ID</param>
        /// <param name="orderId">Order ID</param>
        /// <param name="sequenceNumber">Order Sequence #</param>
        /// <param name="requestType">Request Type</param>
        /// <returns>(string) Activity ID</returns>
        private static void RequestReceived(string activityId, string milestoneName, string customerId, string orderId, int sequenceNumber, string requestType)
        {
            System.Diagnostics.Debug.WriteLine("SLT: UpdateActivity (ActName:<" + ActivityName + ">, ActID:<" + activityId + ">, Milestone:<" + milestoneName + ">)");

            OrchestrationEventStream.UpdateActivity(ActivityName, activityId,
                            DataCustomerId, customerId,
                            DataOrderId, orderId,
                            DataSequenceNumber, sequenceNumber,
                            DataRequestType, requestType);

            UpdateMilestone(activityId, milestoneName);
        }

        /// <summary>
        /// Enable a continuation (completion) of this activity
        /// </summary>
        /// <param name="activityId">current activity id</param>
        /// <param name="requestId">uniquely identifies this order</param>
        public static void ActivateContinuation(string activityId, string requestId)
        {
            string relatedActivityId = CreateActivityId(ReferenceContinuation, requestId);

            System.Diagnostics.Debug.WriteLine("SLT: EnableContinuation (ActName:<" + ActivityName + ">, ActID:<" + activityId + ">, ContToken:<" + relatedActivityId + ">)");

            OrchestrationEventStream.EnableContinuation(ActivityName, activityId, relatedActivityId);
        }

        /// <summary>
        /// Enables a relationship with the service order request activity
        /// </summary>
        /// <param name="activityId">current activity id</param>
        /// <param name="ReqID">request id of the order</param>
        public static void ActivateRelationship(string activityId, string requestId)
        {
            string relatedActivityId = CreateActivityId(ReferenceRelationship, requestId);

            System.Diagnostics.Debug.WriteLine("SLT: AddRelatedActivity (ActName:<" + ActivityName + ">, ActID:<" + activityId + ">, RelActName:<" + ServiceOrderRequest.ActivityName + ">, RelActID: <" + relatedActivityId + ">)");

            OrchestrationEventStream.AddRelatedActivity(ActivityName, activityId, ServiceOrderRequest.ActivityName, relatedActivityId);
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
        /// Creates the [Posted To History DB] BAM Milestone
        /// </summary>
        /// <param name="activityId">Activity ID</param>
        public static void PostedToHistory(string activityId)
        {
            UpdateMilestone(activityId, MilestonePostedToHistory);
        }

        /// <summary>
        /// Creates the [Posted to Servicing] BAM Milestone
        /// </summary>
        /// <param name="activityId">Activity ID</param>
        public static void PostedToServicing(string activityId)
        {
            UpdateMilestone(activityId, MilestonePostedToServicing);
        }

        /// <summary>
        /// Creates the [Replied to CSR] BAM Milestone
        /// </summary>
        /// <param name="activityId">Activity ID</param>
        public static void RepliedToRequester(string activityId)
        {
            UpdateMilestone(activityId, MilestoneRepliedToRequester);
        }

        /// <summary>
        /// Creates the [Updated History DB] BAM Milestone
        /// </summary>
        /// <param name="activityId">Activity ID</param>
        public static void UpdatedHistory( string activityId )
        {
            UpdateMilestone(activityId, MilestoneUpdatedHistory);
        }

        /// <summary>
        /// Ends collecting BAM Data for the [Customer Order Request] Activity
        /// </summary>
        /// <param name="activityId">Activity ID</param>
        public static void EndCollecting(string activityId)
        {
            EndActivity(ActivityName, activityId);
        }

        /// <summary>
        /// Utility that helps Update a BAM Activity
        /// </summary>
        /// <param name="activityId">Activity ID</param>
        /// <param name="milestoneName">Milestone Name</param>
        private static void UpdateMilestone(string activityId, string milestoneName)
        {
            UpdateActivity(ActivityName, activityId, milestoneName);
        }
    }
}
