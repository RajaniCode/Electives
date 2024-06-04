//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.Utilities.ServiceLevelTracking
// Helper functions using the BAM API to help track service levele of the end to end
// SOA scenario.
//
// Copyright (c) Microsoft Corporation. All rights reserved. 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//

using System;
using Microsoft.BizTalk.Bam.EventObservation;

//using System.Management;

namespace Microsoft.Samples.BizTalk.WoodgroveBank
{
	/// <summary>
	/// Class with helper functions to track service levels for the end to end Service Orientd scenario.
	/// Only has static methods so there is no need for Orchestrations to create an instance
	/// Therefore no need to make this serializable
	/// </summary>
	public sealed class ServiceLevelTracking
	{

		/// <summary>
		/// Private constructor - No instances of the class are allowed...
		/// </summary>
 
		private ServiceLevelTracking()
		{ 
		}

		// Name of the Customer Service Activity - all BAM events are for this activity...
		private const string ActivityName = "CustomerServiceRequest";

		// Milestone Definitions...
		private enum CustomerServiceMilestone
		{
			RequestReceived = 0,
			RequestCreditLimitSuccess = 1,
			RequestCreditLimit_Error = 2,
			RequestLastPaymentSuccess = 3,
			RequestLastPaymentError = 4,
			RequestPendingTransactionsSuccess = 5,
			RequestPendingTransactionsError = 6,
			RequestCompleteSuccessfully = 7,
			RequestCompleteError = 8,
			RequestInvalid = 9
		} ;

		// Names of BAM Milestones - has association with the milestone definitions above via array index
		// The milestone names must match with the BAM activity definition in the spreadsheet...

		private static string[] milestoneNames = {
													 "Received", 
													 "CreditLimitSuccess", 
													 "CreditLimitError", 
													 "LastPaymentSuccess", 
													 "LastPaymentError", 
													 "PendingTransSuccess", 
													 "PendingTransError",
													 "CompletedSuccess",
													 "CompletedError",
													 "InvalidRequest"
												 } ;


		// Few other definitions for milestone specific data elements...

		private const string ErrorCode = "ErrorCode";
		private const string ErrorMessage = "ErrorMessage";
		private const string ErrorSource = "ErrorSource";
		private const string RequestResponseTime = "RequestResponseTime";
		private const string PendingTransResponseTime = "PndTranResponseTime";
		private const string Sap_ResponseTime = "SAPResponseTime";
		private const string PaymentTrackerResponseTime = "PmntTrkResponseTime";
		private const string RequestSource = "RequestSource";
		private const string RequestType = "RequestType";	
	
		/// <summary>
		/// Begins an activity in the BAM event stream and associates it with the request.  Update the
		/// activity with its source and type.
		/// Create a unique activityId id and return it for use in later milestones.
		/// </summary>
		/// <param name="requestSource">
		/// string - request source
		/// </param>
		/// <param name="requestType">
		/// string - request type
		/// </param>
		/// <returns>
		/// string - activity id
		/// </returns>

		public static string BeginRequest(string requestSource, string requestType)
		{
			string activityId = Guid.NewGuid().ToString();

			OrchestrationEventStream.BeginActivity(ActivityName, activityId);

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, RequestSource, requestSource, RequestType, requestType);
			return activityId;
		}

		/// <summary>
		/// Ends the activity in the BAM event stream. 
		/// </summary>
		/// <param name="activityId">
		/// string - activity Id
		/// </param>

		public static void EndRequest(string activityId)
		{
			OrchestrationEventStream.EndActivity(ActivityName, activityId);
		}

		/// <summary>
		/// Create the Request Received Milestone in BAM.
		/// </summary>
		/// <param name="activityId">
		/// string - activity Id
		/// </param>
		/// 
		public static void TrackRequestReceived(string activityId)
		{
			int m = (int)CustomerServiceMilestone.RequestReceived ;

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, milestoneNames[m], DateTime.UtcNow);
		}

		/// <summary>
		/// Create the Credit Limit request successfully completed milestone 
		/// </summary>
		/// <param name="activityId">
		/// string - activity id
		/// </param>
		/// <param name="responseTime">
		/// int - the reseponse time - the time it took for the credit limit request to complete.
		/// </param>
		
		public static void TrackCreditLimitSuccess(string activityId, int responseTime)
		{
			int m = (int)CustomerServiceMilestone.RequestCreditLimitSuccess;

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, milestoneNames[m], DateTime.UtcNow, 
					Sap_ResponseTime, responseTime	);
		}

		/// <summary>
		/// Create the milestone Credit Limit resulted in an error
		/// </summary>
		/// <param name="activityId">
		/// string - activity id 
		/// </param>
		/// <param name="responseTime">
		/// int - time it took in milliseconds 
		/// </param>
		/// <param name="errorCode">
		/// string - error code 
		/// </param>
		/// <param name="errorMessage">
		/// string - error message
		/// </param>
		/// <param name="errorSource">
		/// stromg - source of the error  
		/// </param>
		
		public static void TrackCreditLimitError(string activityId, int responseTime, string errorCode, string errorMessage, string errorSource)
		{
			int m = (int)CustomerServiceMilestone.RequestCreditLimit_Error;

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, 
				milestoneNames[m], DateTime.UtcNow,
				Sap_ResponseTime, responseTime,
				ErrorCode, errorCode,
				ErrorMessage, errorMessage,
				ErrorSource, errorSource
				);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="activityId">
		/// string - activity id 
		/// </param>
		/// <param name="responseTime">
		/// int - time it took in milliseconds 
		/// </param>
		
		public static void TrackLastPaymentSuccess(string activityId, int responseTime)
		{
			int m = (int)CustomerServiceMilestone.RequestLastPaymentSuccess;

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, 
				milestoneNames[m], DateTime.UtcNow,
				PaymentTrackerResponseTime, responseTime
				);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="activityId">
		/// string - activity id 
		/// </param>
		/// <param name="responseTime">
		/// int - time it took in milliseconds
		/// </param>
		/// <param name="errorCode">
		/// string - error code 
		/// </param>
		/// <param name="errorMessage">
		/// string - error message 
		/// </param>
		/// <param name="errorSource">
		/// stromg - source of the error 
		/// </param>
		
		public static void TrackLastPaymentError(string activityId, int responseTime, string errorCode, string errorMessage, string errorSource)
		{
			int m = (int)CustomerServiceMilestone.RequestLastPaymentError;

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, 
				milestoneNames[m], DateTime.UtcNow,
				PaymentTrackerResponseTime, responseTime,
				ErrorCode, errorCode,
				ErrorMessage, errorMessage,
				ErrorSource, errorSource
				);
		}

		/// <summary>
		/// Create the 'Pending Transactions Request Completed Successfully' BAM milestone.
		/// </summary>
		/// <param name="activityId">
		/// string - activity id 
		/// </param>
		/// <param name="responseTime">
		/// int - the time it took in milliseconds.
		/// </param>
		
		public static void TrackPendingTransactionsSuccess(string activityId, int responseTime)
		{
			int m = (int)CustomerServiceMilestone.RequestPendingTransactionsSuccess;

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, 
				milestoneNames[m], DateTime.UtcNow,
				PendingTransResponseTime, responseTime
				);
		}

		/// <summary>
		/// Create the 'Pending Transactions Request Completed with Error' BAM milestone
		/// </summary>
		/// <param name="activityId">
		/// string - activity id 
		/// </param>
		/// <param name="responseTime">
		/// int - the time it took to complete with an error in milliseconds
		/// </param>
		/// <param name="errorCode">
		/// string - error code 
		/// </param>
		/// <param name="errorMessage">
		/// string - error message 
		/// </param>
		/// <param name="errorSource">
		/// stromg - source of the error 
		/// </param>
		
		public static void TrackPendingTransactionsError(string activityId, int responseTime, string errorCode, string errorMessage, string errorSource)
		{
			int m = (int)CustomerServiceMilestone.RequestPendingTransactionsError;

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, 
				milestoneNames[m], DateTime.UtcNow,
				PendingTransResponseTime, responseTime,
				ErrorCode, errorCode,
				ErrorMessage, errorMessage,
				ErrorSource, errorSource
				);
		}

		/// <summary>
		/// Create the 'Request Completed Successfully' BAM milestone
		/// </summary>
		/// <param name="activityId">
		/// string - activity id 
		/// </param>
		/// <param name="responseTime">
		/// int - time it took in milliseconds
		/// </param>
		
		public static void TrackRequestCompleteSuccess(string activityId, int responseTime)
		{
			int m = (int)CustomerServiceMilestone.RequestCompleteSuccessfully;

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, 
						milestoneNames[m], DateTime.UtcNow,
						RequestResponseTime, responseTime
				);
		}

		/// <summary>
		/// Create the BAM milestone Request Completed In Error
		/// </summary>
		/// <param name="activityId">
		/// string - atcivity id
		/// </param>
		/// <param name="responseTime">
		/// int - time it took in milliseconds
		/// </param>
		/// <param name="errorCode">
		/// string - error code
		/// </param>
		/// <param name="errorMessage">
		/// string - error message
		/// </param>
		/// <param name="errorSource">
		/// stromg - source of the error 
		/// </param>
		
		public static void TrackRequestCompleteError(string activityId, int responseTime, string errorCode, string errorMessage, string errorSource)
		{
			int m = (int)CustomerServiceMilestone.RequestCompleteError;

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, 
						milestoneNames[m], DateTime.UtcNow,
						RequestResponseTime, responseTime,
						ErrorCode, errorCode,
						ErrorMessage, errorMessage,
						ErrorSource, errorSource
				);
		}
		
		/// <summary>
		/// Create BAM Milestone Invalid Request
		/// </summary>
		/// <param name="activityId">
		/// string - activity id
		/// </param>
		/// <param name="responseTime">
		/// int - time it to took to result in an invalid request.
		/// </param>
		public static void TrackInvalidRequest(string activityId, int responseTime)
		{
			int m = (int)CustomerServiceMilestone.RequestInvalid;

			OrchestrationEventStream.UpdateActivity(ActivityName, activityId, 
				milestoneNames[m], DateTime.UtcNow,
				RequestResponseTime, responseTime) ;
		}
	}
}
