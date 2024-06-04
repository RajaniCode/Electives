//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WOodgroveBank.PaymentTracker.MessageProcessor
// Process payment tracking system messages and generate appropriate output messages
// 
//
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Samples.BizTalk.WoodgroveBank.SchemaClasses;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTracker
{
	/// <summary>
	/// Process a message received by the Payment Tracking System.
	/// </summary>
	public class MessageProcessor
	{
		private byte[] requestMessage ;

		/// <summary>
		/// Constructor 
		/// </summary>
		/// <param name="inMsg">
		/// byte[] representing the Last Payment Request XML document.
		/// </param>
		public MessageProcessor(byte[] inMsg)
		{
			requestMessage = inMsg;
		}

		/// <summary>
		/// Process the Last Payment request message received and return a corresponding response message
		/// </summary>
		/// <param name="userid" >
		/// string - user id to use to process the message...
		/// </param>
		/// <param name="password">
		/// string - password
		/// </param>
		/// <returns>
		/// byte[] representing the Last Payment Response XML document.
		/// </returns>
		public byte[] ProcessRequestMessage(string userId, string password)
		{
			LastPaymentRequest req = messageToRequest(requestMessage);

			LastPaymentResponse resp ;

			if (authenticateUser (userId, password))
			{
				resp = processRequest(req);
			}
			else
			{
				resp = assembleAuthenticationFailedResponse(req);
			}
			
			return responseToMessage(resp);
		}

		/// <summary>
		/// Authenticate the user using the payment tracking system specific user id and password.
		/// </summary>
		/// <param name="userid">
		/// string - user id
		/// </param>
		/// <param name="password">
		/// string - password
		/// </param>
		/// <returns></returns>
		private static bool authenticateUser(string userId, string password)
		{
			// For testing - all user ids beginning with PT are allowed.
			bool authResult = userId.IndexOf("PT") == 0;

			Console.WriteLine("Authenticating User: <{0}>, with password <{1}>, result <{2}>", userId, password, authResult);
			return authResult;
		}

		/// <summary>
		/// Assemble a Last Payment Response message indicating that authentication failed
		/// </summary>
		/// <param name="req">
		/// LastPaymentRequest - instance of the last payment request.
		/// </param>
		/// <returns>
		/// LastPaymentResponse - instance of the Last Payment Response
		/// </returns>
		private static LastPaymentResponse assembleAuthenticationFailedResponse(LastPaymentRequest req)
		{

			// Create response status 
			LastPaymentResponseResponseStatusError lpError = new LastPaymentResponseResponseStatusError();
			lpError.ErrorNumber = "0100";
			lpError.ErrorDescription = "Authentication failed";
			lpError.ErrorSource = "Payment Tracking System Authenticator";

			LastPaymentResponseResponseStatus responseStatus = new LastPaymentResponseResponseStatus();
			responseStatus.Error = lpError;
			responseStatus.Result = "ERROR";

			// Assemble the response
			LastPaymentResponse	resp = new LastPaymentResponse();
			resp.ResponseStatus = responseStatus;
			resp.Payment = null;				// No payments

			// Copy the account number and name info from the request itself...
			resp.AccountNumber = req.AccountNumber;
			resp.CustomerName = req.CustomerName;

			return resp;
		}

		/// <summary>
		/// Deserialize the received message into a Last Payment Request insance
		/// </summary>
		/// <param name="message">
		/// byte[] receive message with the XML document 
		/// </param>
		/// <returns>
		/// LastPaymentRequest - instance of the LastPaymentRequest
		/// </returns>
		private static LastPaymentRequest messageToRequest (byte[] message)
		{
			XmlSerializer xs = new XmlSerializer(typeof(LastPaymentRequest), "http://Microsoft.Samples.BizTalk.WOodgroveBank.Schemas.LastPaymentRequest");
			
			MemoryStream ms = new MemoryStream(message);
			
			LastPaymentRequest req = (LastPaymentRequest)(xs.Deserialize(new XmlTextReader(ms)));
			
			ms.Close();
			
			return req;
		}

		/// <summary>
		/// Process the incoming request and generate a response.
		/// </summary>
		/// <param name="req">
		/// LastPaymentRequest - Instance of a Last Payment Request to be processed
		/// </param>
		/// <returns>
		/// LastPaymentResponse  - Last Payment Response instance
		/// </returns>
		private static LastPaymentResponse processRequest(LastPaymentRequest req)
		{
			const int MAX_LAST_PAYMENTS = 10;

			// Generate a random number (upto the max allowed) of payments...
			// Make sure there is at least one payment...
			Random rand = new Random (unchecked((int)DateTime.Now.Ticks));
			int numPayments = rand.Next(MAX_LAST_PAYMENTS - 1) + 1;
			LastPaymentResponsePayment[] payments = new LastPaymentResponsePayment[numPayments];

			// Fill in each of these payments with values that are randomly generated...
			for (int i = 0 ; i < numPayments ; i++)
			{
				payments[i] = new LastPaymentResponsePayment();
				// Each payment was made (randomly) between now and 60 days ago...
				TimeSpan ts = new TimeSpan(rand.Next(60),0,0,0);
				payments[i].DateLastPayment = System.DateTime.Now.Subtract(ts);

				// Each payment can be between 1 and 10,000
				payments[i].AmountLastPayment = new Decimal (rand.Next(10000));
			}

			// Create response status 
			LastPaymentResponseResponseStatusError lpError = new LastPaymentResponseResponseStatusError();
			lpError.ErrorNumber = "0000";
			lpError.ErrorDescription = "";
			lpError.ErrorSource = "";

			LastPaymentResponseResponseStatus responseStatus = new LastPaymentResponseResponseStatus();
			responseStatus.Error = lpError;
			responseStatus.Result = "SUCCESS";

			// Assemble the response
			LastPaymentResponse	resp = new LastPaymentResponse();
			resp.ResponseStatus = responseStatus;
			resp.Payment = payments;

			// Copy the account number and name info from the request itself...
			resp.AccountNumber = req.AccountNumber;
			resp.CustomerName = req.CustomerName;

			return resp;
		}
		
		/// <summary>
		/// Serialize the Last Payment Response into XML and then to a byte array, ready to be transmitted
		/// </summary>
		/// <param name="resp">
		/// Last Payment response
		/// </param>
		/// <returns>
		/// byte[] - message with the XML doc corresponding to the response 
		/// </returns>
		private static byte[]responseToMessage(LastPaymentResponse resp)
		{
			XmlSerializer xs = new XmlSerializer(typeof(LastPaymentResponse),"http://Microsoft.Sampsles.BizTalk.WOodgroveBank.Schemas.LastPaymentResponse");
			
			MemoryStream ms = new MemoryStream();
			
			xs.Serialize(ms, resp);
			
			byte[] msg = ms.ToArray();
			
			ms.Close();
			
			return msg;
		}
	}
}
