//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.Utilities.CustomerServiceErrors
// Helper class to support error handling
//
// Copyright (c) Microsoft Corporation. All rights reserved  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------

using System;
using System.Collections.Specialized;



namespace Microsoft.Samples.BizTalk.WoodgroveBank.ErrorHelper
{
	/// <summary>
	/// Summary description for CustomerServiceErrors.
	/// </summary>
	public sealed class CustomerServiceErrors
	{
		private static NameValueCollection customerServiceErrors;

		/// <summary>
		/// Static constructor - initialzie other static members here...
		/// </summary>
		static CustomerServiceErrors()
		{
			// Customer service error codes and descriptions...
			initializeCustomerServiceErrors();
		}

		// constructor - can't prvent the creation of instances for this class as mapper needs 
		// to create instances to call the functions.

		public CustomerServiceErrors()
		{
		}

		// Error codes used by the orchestration...
		public const string CustomerServiceTimeoutError = "1000";
		public const string CustomerServiceInvalidRequest = "1100";
		public const string CustomerServiceOtherError = "2000";
		public const string CustomerServiceExceptionError = "2002";

        public const string CustomerServiceResultSuccess = "SUCCESS";
		public const string CustomerServiceResultError = "ERROR";

		private const string CustomerServiceTimeoutErrorSource = "CustomerService Orchestration";
		
		/// <summary>
		/// Initialize the error code+description table here...
		/// </summary>
		private static void initializeCustomerServiceErrors()
		{
			customerServiceErrors = new NameValueCollection();

			// Add descriptiong to each of the publicly known error codes...
			customerServiceErrors.Add(CustomerServiceTimeoutError, "Timeout waiting for responses from the back end systems");
			customerServiceErrors.Add(CustomerServiceInvalidRequest, "Required authentication elements not present, and/or the account number not present or invalid in the message ");
			customerServiceErrors.Add(CustomerServiceOtherError, "Error in customer service orchestration");
			customerServiceErrors.Add(CustomerServiceExceptionError, "Exception occurred in customer service orchestration");
        }


        /// <summary>
		/// Transform an error in the orchestration to its description.
		/// </summary>
		/// <param name="errorCode">
		/// string - error code
		/// </param>
		/// <returns>
		/// string - error description
		/// </returns>
		public static string GetCustomerServiceErrorDescription(string errorCode)
		{
			try
			{
				return customerServiceErrors[errorCode];
			}
			catch (System.ArgumentOutOfRangeException)
			{
				return "Error code " + errorCode + " is not recognized";
			}
		}

		/// <summary>
		/// Assemble error description to respond with in the case of an exception
		/// </summary>
		/// <param name="ex">
		/// Exception that occurred
		/// </param>
		/// <returns>
		/// error description string
		/// </returns>
		public static string GetCustomerServiceErrorDescription(System.Exception ex)
		{
			if (null == ex) throw new ArgumentNullException("ex", "Parameter of type Exception can not be null");
			string exceptionTxt = customerServiceErrors[CustomerServiceExceptionError] + ": " 
				+ ex.ToString() 
				+ (null == ex.InnerException ? "" : 
				("Inner Exception:\n" + ex.InnerException.ToString())
				) ;
			return exceptionTxt;
		}

		/// <summary>
		/// Transform an error in the orchestration to its source...
		/// </summary>
		/// <param name="errorCode">
		/// string - error code
		/// </param>
		/// <returns>
		/// string - error source
		/// </returns>
		public static string GetCustomerServiceErrorSource(string errorCode)
		{
			// To do - the error source can be found from the error code... 
			return CustomerServiceTimeoutErrorSource;
		}

		/// <summary>
		/// Helper function to decide the error code to return, based on the error codes 
		/// from the back end systems
		/// </summary>
		/// <param name="SAPErrorCode">
		/// string - SAP error code
		/// </param>
		/// <param name="pmntTrackErrorCode">
		/// string - payment tracking system code
		/// </param>
		/// <param name="pendTransErrorCode">
		/// string - pending transaction system code
		/// </param>
		/// <returns>
		/// </returns>

		public static string GetCustomerServiceErrorCode(string sapErrorCode, string paymentTrackerErrorCode, string pendingTransactionsErrorCode)
		{
			// For timeouts return a timeout error... otherwise a general error...

			if (sapErrorCode == _SapTimeoutErrorCode ||
					paymentTrackerErrorCode == _PaymentTrackerTimeoutErrorCode ||
					pendingTransactionsErrorCode == _PendingTransactionsTimeoutErrorCode
				)
			{
				return CustomerServiceTimeoutError;
			}
			else
			{
				return CustomerServiceOtherError;
			}
		}

		/// <summary>
		/// Helper function (primarily for the mapper) to get the result code when the
		/// orchestration is successful
		/// </summary>
		/// <returns>
		/// string result code corresponding to successful processing of the request.
		/// </returns>
		public static string GetCustomerServiceResultSuccess()
		{
			return CustomerServiceResultSuccess;
		}

		/// <summary>
		/// Helper function (primarily for the mapper) to get the result code when the
		/// orchestration completes with an error
		/// </summary>
		/// <returns>
		/// string result code indicating a failure to process the request.
		/// </returns>

		public static string GetCustomerServiceResultError()
		{
			return CustomerServiceResultError;
		}
		// members to support timeout errors from SAP...

		// to do - need to use a value here that SAP itself doesn't use -
		private const string _SapTimeoutErrorCode = "1000";
		private const string _SapTimeoutErrorDescription = "SAP system timed out";
		private const string _SapTimeoutErrorSource = "SAP or the SAP adapter";

		/// <summary>
		/// Helper function to indicate a timeout from the SAP system, in the response messages.
		/// This value is be assigned to the return code (E_RC) field of the SAP response message 
		/// when a timeout error occurs. The helper functions DecodeSapErrorCodeToDescription and
		/// DecodeSapErrorCodeToSource use this value to return appropriate text.
		/// 
		/// This is designed as a method rather than a property is because it used both from the
		/// mapper and the orchestrations.  Mapper doesn't have a clean way to get properties
		/// (although it can call the get... method corresponding to the property, but this is 
		/// not as clean as calling a method)
		/// </summary>
		/// <returns>
		/// string - error code indicating timeout from SAP.
		/// </returns>

		public static string SapTimeoutErrorCode()
		{
			return _SapTimeoutErrorCode;
		}

		/// <summary>
		/// Helper function to translate an SAP return code into its error message...
		/// </summary>
		/// <param name="sapReturnCode">
		/// string - return code from SAP or the timeout error code
		/// </param>
		/// <returns>
		/// string - Error description corresponding to the SAP error code
		/// </returns>
		public static string DecodeSapErrorCodeToDescription(string sapReturnCode)
		{
			string errDesc;

			switch (sapReturnCode)
			{
				case _SapTimeoutErrorCode:
					errDesc = _SapTimeoutErrorDescription;
					break;

				case "":
					errDesc = "";
					break;
				
				default:

					// to do - really map the SAP error codes....
					errDesc =  "Some error yet to be translated from SAP";
					break;
			}

			return errDesc;
		}
		
		/// <summary>
		/// Helper function to translate an SAP return code to its source...
		/// </summary>
		/// <param name="sapReturnCode">
		/// string - return code from SAP or the timeout error code.
		/// </param>
		/// <returns>
		/// string - error source corresponding the SAP error code
		/// </returns>
		public static string DecodeSapErrorCodeToSource (string sapReturnCode)
		{
			string errSrc;

			switch (sapReturnCode)
			{
				case _SapTimeoutErrorCode:
					errSrc = _SapTimeoutErrorSource;
					break;

				case "":
					errSrc = "";
					break;
				
				default:

					// to do - really map the SAP error codes....
					errSrc =  "Some error yet to be translated from SAP to source";
					break;
			}
			return errSrc;
		}

		// members to support timeout errors from the payment tracking system

		private const string _PaymentTrackerTimeoutErrorCode = "1000";
		private const string _PaymentTrackerTimeoutErrorDescription = "Timed out waiting for a response from payment tracking system";
		private const string _PaymentTrackerTimeoutErrorSource = "Payment tracking system or the MQ Series Adapter";

		/// <summary>
		/// Helper function to indicate a timeout from the payment tracking system.
		/// The helper functions DecodePmntTrackErrorCodeToDescription and
		/// DecodePmntTrackErrorCodeToSource use this value to return appropriate text.
		/// 
		/// This is designed as a method rather than a property is because it used both from the
		/// mapper and the orchestrations.  Mapper doesn't have a clean way to get properties
		/// (although it can call the get... method corresponding to the property, but this is 
		/// not as clean as calling a method)
		/// </summary>
		/// <returns>
		/// string - error code indicating timeout from the pending transactions system
		/// </returns>

		public static string PaymentTrackerTimeoutErrorCode()
		{
			return _PaymentTrackerTimeoutErrorCode;
		}

		/// <summary>
		/// Helper function to translate the payment trackign system error code into its error message...
		/// </summary>
		/// <param name="ptErrorCode">
		/// string - error code from the payment tracking system or the timeout error code
		/// </param>
		/// <returns>
		/// string - error description corresponding to the payment tracking system error code
		/// </returns>
		public static string DecodePaymentTrackerErrorCodeToDescription(string ptErrorCode)
		{
			if (ptErrorCode == _PaymentTrackerTimeoutErrorCode)
			{
				return _PaymentTrackerTimeoutErrorDescription;
			}
			else
			{
				return "Error from the Payment Tracking System";
			}
		}
		
		/// <summary>
		/// Helper function to translate the Payment Tracking system error code to its source...
		/// </summary>
		/// <param name="ptErrorCode">
		/// string - error code from the payment tracking system or the timeout error code.
		/// </param>
		/// <returns>
		/// string - error source corresponding to the payment tracking system error code.
		/// </returns>
		public static string DecodePaymentTrackerErrorCodeToSource (string ptErrorCode)
		{
			if (ptErrorCode == _PaymentTrackerTimeoutErrorCode)
			{
				return _PaymentTrackerTimeoutErrorSource;
			}
			else
			{
				return "Payment Tracking System";
			}
		}

		// members to support timeout errors from the pending transactions system

		private const string _PendingTransactionsTimeoutErrorCode = "1000";
		private const string _PendingTransactionsTimeoutErrorDescription = "Timed out waiting for a response from pending transactions web service";
		private const string _PendingTransactionsTimeoutErrorSource = "Pending transactions system or the SOAP adapter";

		/// <summary>
		/// Helper function to indicate a timeout from the pending transactions system.
		/// The helper functions DecodePendTransErrorCodeToDescription and
		/// DecodePendTransErrorCodeToSource use this value to return appropriate text.
		/// 
		/// This is designed as a method rather than a property is because it used both from the
		/// mapper and the orchestrations.  Mapper doesn't have a clean way to get properties
		/// (although it can call the get... method corresponding to the property, but this is 
		/// not as clean as calling a method)
		/// </summary>
		/// <returns>
		/// string - error indicating a timeout from the Pending transactions system
		/// </returns>

		public static string PendingTransactionsTimeoutErrorCode()
		{
			return _PendingTransactionsTimeoutErrorCode;
		}

		/// <summary>
		/// Helper function to translate the pending transaction system error code into its error message...
		/// </summary>
		/// <param name="ptErrorCode">
		/// string - error code from the pending transaction system or the timeout error code
		/// </param>
		/// <returns>
		/// string - error descripting corresponding to the given error code from the pending 
		/// transaction system
		/// </returns>
		public static string DecodePendingTransactionsErrorCodeToDescription(string ptErrorCode)
		{
			if (ptErrorCode == _PendingTransactionsTimeoutErrorCode)
			{
				return _PendingTransactionsTimeoutErrorDescription;
			}
			else
			{
				return "Error from the pending transactions web service";
			}
		}
		
		/// <summary>
		/// Helper function to translate the pending transaction system error code to its source...
		/// </summary>
		/// <param name="ptErrorCode">
		/// string - error code from the pending transaction system or the timeout error code.
		/// </param>
		/// <returns>
		/// error source corresponding to the given error code from the pending transaction system
		/// </returns>
		public static string DecodePendingTransactionsErrorCodeToSource (string ptErrorCode)
		{
			if (ptErrorCode == _PendingTransactionsTimeoutErrorCode)
			{
				return _PendingTransactionsTimeoutErrorSource;
			}
			else
			{
				return "Pending transaction system";
			}
		}	
	}
}
