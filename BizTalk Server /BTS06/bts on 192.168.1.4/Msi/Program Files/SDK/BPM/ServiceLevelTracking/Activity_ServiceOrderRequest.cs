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
    public class ServiceOrderRequest : BasicActivity
    {
        //  Activity Name

        public const string ActivityName = "ServiceOrderRequest";

        //  Activity Milestones

        private const string MilestoneBeginOrder = "BeginOrder";
        private const string MilestoneEndOrder = "EndOrder";
        private const string MilestoneValidated = "Validated";
        private const string MilestoneAnalyzed = "Analyzed";
        private const string MilestoneActivatedService = "ActivatedSvc";
        private const string MilestoneChangedService = "ChangedSvc";
        private const string MilestoneCompletedService = "CompletedSvc";
        private const string MilestoneFacilitiesNotified = "Facilities Notified";
        private const string MilestoneFacilitiesResponded = "FacilitiesResponded";
        private const string MilestoneTerminated = "Terminated";
        private const string MilestoneCanceledService = "CancelledSvc";

        //  Activity Data

        private const string DataCustomerId = "CustomerID";
        private const string DataOrderId = "OrderID";
        private const string DataSequenceNumber = "SequenceNum";
        private const string DataServiceType = "ServiceType";
        private const string DataError = "ErrorInfo";

        // References

        public const string ReferenceRoot = "CableOrder";
        public const string ReferenceContinuation = "CableOrderStage";

        /// <summary>
        /// Constructor 
        /// </summary>
        public ServiceOrderRequest()
        {
        }

        /// <summary>
        /// Begins the activity and creates an activity id
        /// </summary>
        /// <param name="requestId">uniquely identifies this activity</param>
        /// <returns>activity id for this activity</returns>
        public static string StartCollecting(string requestId)
        {
            string activityID = CreateActivityId(ReferenceRoot, requestId);
            BeginActivity(ActivityName, activityID);
            return activityID;
        }

        /// <summary>
        /// Gets the activity id to continue this activity
        /// </summary>
        /// <param name="requestId">identifier for this order</param>
        /// <returns>activity id to continue tracking with</returns>
        public static string ContinueCollecting(string requestId)
        {
            // Since the stages run sequentially for any given order we can
            // use the same activity id that is started in the first stage
            // in subsequent stages.
            return CreateActivityId(ReferenceRoot, requestId);
        }

        /// <summary>
        /// Updates that data fields of the order and marks the order as started
        /// </summary>
        /// <param name="activityId">activity id of order activity</param>
        /// <param name="customerId">customer id or order</param>
        /// <param name="orderId">order id of order</param>
        /// <param name="sequenceNumber">sequence number of order</param>
        /// <param name="serviceType">service type of order</param>
        public static void BeginOrder(string activityId, string customerId, string orderId, int sequenceNumber, string serviceType)
        {
            System.Diagnostics.Debug.WriteLine("SLT: UpdateActivity (ActName:<" + ActivityName + ">, ActID:<" + activityId + ">, Milestone:<" + MilestoneBeginOrder + ">)");

            OrchestrationEventStream.UpdateActivity(
                            ActivityName, activityId,
                            DataCustomerId, customerId,
                            DataOrderId, orderId,
                            DataSequenceNumber, sequenceNumber,
                            DataServiceType, serviceType);

            UpdateMilestone(activityId, MilestoneBeginOrder);
        }


        /// <summary>
        /// Enable a continuation for this activity
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
        /// Adds error information to the BAM activity
        /// </summary>
        /// <param name="activityId">Activity ID</param>
        /// <param name="error">error to add</param>
        public static void ErrorOccurred(string activityId, string error)
        {
            OrchestrationEventStream.UpdateActivity(ActivityName, activityId, DataError, error);
        }

        /// <summary>
        /// Updates the end order milestone
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void EndOrder(string activityId)
        {
            UpdateMilestone(activityId, MilestoneEndOrder);
        }

        /// <summary>
        /// Updates the the facilities notified milestone
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void FacilityNotified(string activityId)
        {
            UpdateMilestone(activityId, MilestoneFacilitiesNotified);
        }

        /// <summary>
        /// Updates the facility responded milestone
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void FacilityResponded(string activityId)
        {
            UpdateMilestone(activityId, MilestoneFacilitiesResponded);
        }

        /// <summary>
        /// Updates the activated service milestone
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void ActivatedService(string activityId)
        {
            UpdateMilestone(activityId, MilestoneActivatedService);
        }

        /// <summary>
        /// Updates the changed service milestone
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void ChangedService(string activityId)
        {
            UpdateMilestone(activityId, MilestoneChangedService);
        }

        /// <summary>
        /// Updates the completed service milestone
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void CompletedService(string activityId)
        {
            UpdateMilestone(activityId, MilestoneCompletedService);
        }

        /// <summary>
        /// Updates the terminated milestone
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void Terminated(string activityId)
        {
            UpdateMilestone(activityId, MilestoneTerminated);
        }

        /// <summary>
        /// Updates the validated milestone
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void Validated(string activityId)
        {
            UpdateMilestone(activityId, MilestoneValidated);
        }

        /// <summary>
        /// Updates the analyzed milestone
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void Analyzed(string activityId)
        {
            UpdateMilestone(activityId, MilestoneAnalyzed);
        }

        /// <summary>
        /// Updates the canceled service milestone
        /// </summary>
        /// <param name="activityId">activity id</param>
        public static void CanceledService(string activityId)
        {
            UpdateMilestone(activityId, MilestoneCanceledService);
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
        /// Utility that helps to Update  a BAM Activity
        /// </summary>
        /// <param name="activityId">Activity ID</param>
        /// <param name="milestoneName">Milestone Name</param>
        private static void UpdateMilestone(string activityId, string milestoneName)
        {
            UpdateActivity(ActivityName, activityId, milestoneName);
        }
    }
}
