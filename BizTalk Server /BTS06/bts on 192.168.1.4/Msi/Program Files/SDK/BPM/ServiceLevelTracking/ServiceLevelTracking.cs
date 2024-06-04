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
    /// Abstract base class of activities for BAM tracking
    /// </summary>
    public abstract class BasicActivity 
    {
        /// <summary>
        /// Protected constructor -- Abstract base class
        /// </summary>
        protected BasicActivity()
        {
        }

        /// <summary>
        /// Creates an activity id to be used in tracking
        /// </summary>
        /// <param name="reference">reference used for activity</param>
        /// <param name="requestId">unique identifier for request</param>
        /// <returns>activty id</returns>
        public static string CreateActivityId(string reference, string requestId)
        {
            string activityId = reference + "_" + requestId;
            return activityId;
        }

        /// <summary>
        /// Creates an activity Id and starts the event stream for the activity
        /// </summary>
        /// <param name="activityName">name of the activity to start</param>
        /// <returns>created activity id</returns>
        protected static string BeginActivity( string activityName )
        {
            string activityId = Guid.NewGuid().ToString();

            BeginActivity( activityName, activityId ) ;

            return activityId;
        }

        /// <summary>
        /// Begins the event stream for the activity
        /// </summary>
        /// <param name="activityName">name of the activity to start</param>
        /// <param name="activityId">activity id</param>
        protected static void BeginActivity( string activityName, string activityId )
        {
            System.Diagnostics.Debug.WriteLine("SLT: BeginActivity (ActName:<" + activityName + ">, ActID:<" + activityId + ">)");

            OrchestrationEventStream.BeginActivity(activityName, activityId);
        }

        /// <summary>
        /// Updates an activity
        /// </summary>
        /// <param name="activityName">name of the activity to update</param>
        /// <param name="activityId">activity id</param>
        /// <param name="milestoneName">milestone to update</param>
        protected static void UpdateActivity( string activityName, string activityId, string milestoneName )
        {
            System.Diagnostics.Debug.WriteLine("SLT: UpdateActivity (ActName:<" + activityName + ">, ActID:<" + activityId + ">, Milestone:<" + milestoneName + ">)");

            OrchestrationEventStream.UpdateActivity(activityName, activityId, milestoneName, DateTime.UtcNow);
        }
 
        /// <summary>
        /// Ends an activity
        /// </summary>
        /// <param name="activityName">name of the activity to end</param>
        /// <param name="activityId">activity id</param>
        protected static void EndActivity( string activityName, string activityId)
        {
            System.Diagnostics.Debug.WriteLine("SLT: EndActivity (ActName:<" + activityName + ">, ActID:<" + activityId + ">)");

            OrchestrationEventStream.EndActivity(activityName, activityId);
        }
    }
}
