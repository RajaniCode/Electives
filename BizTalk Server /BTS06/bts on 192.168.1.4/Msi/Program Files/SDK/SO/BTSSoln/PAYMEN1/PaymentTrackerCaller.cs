//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTrackerCall
// Helper assembly to call the Payment Tracking System inline from orchestrations.
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
using System.Xml;
using System.Diagnostics;
using System.Text;

using Microsoft.XLANGs.BaseTypes;
using Microsoft.BizTalk.SSOClient.Interop;

using Microsoft.Samples.BizTalk.WoodgroveBank.ConfigHelper;
using IBM.WMQ;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTrackerCall
{

	public sealed class PaymentTrackerCaller
	{
		/// <summary>
		/// Instances of this class are not allowed...
		/// </summary>
		private PaymentTrackerCaller()
		{
		}

		// SSO Ticket interface for redeeming tickets...
		private static ISSOTicket ssoTicket = new ISSOTicket();


		/// <summary>
		/// Send the request message to the Payment Tracking System using MQ Series and get a response
		/// within the timeout specified.
		/// </summary>
		/// <param name="requestMsg">
		/// XLangMessage from the orchestration - request message to be sent
		/// </param>
		/// <param name="responseMsg">
		/// Response Message in the orchestration - this should have been initialized with null in a message assignment
		/// before calling this function.  The first message part in this will be filled in with the response message.
		/// 
		/// </param>
		/// <returns>
		/// </returns>
		public static void GetPaymentTrackerResponse(XLANGMessage requestMsg, XLANGMessage responseMsg)
		{
			if (null == requestMsg) throw new ArgumentNullException("requestMsg", "Request Message can not be null");
			if (null == responseMsg) throw new ArgumentNullException("responseMsg", "Response Message can not be null");

			try
			{
				// Get config parameter values...
				int ptTimeout = Convert.ToInt32(
					ConfigParameters.GetConfigParameter(ConfigParameters.SsoConfigParameter.PaymentTrackingInlineTimeout),
					System.Globalization.CultureInfo.CurrentCulture );
				string qManager = ConfigParameters.GetConfigParameter(ConfigParameters.SsoConfigParameter.PaymentTrackingQManager);
				string requestQueue = ConfigParameters.GetConfigParameter(ConfigParameters.SsoConfigParameter.PaymentTrackingRequestQueue);
				string responseQueue = ConfigParameters.GetConfigParameter(ConfigParameters.SsoConfigParameter.PaymentTrackingResponseQueue);
				string ssoAffliateApp = ConfigParameters.GetConfigParameter(ConfigParameters.SsoConfigParameter.PaymentTrackingSsoAffiliateApp);
				string mqChannelDef = ConfigParameters.GetConfigParameter(ConfigParameters.SsoConfigParameter.PaymentTrackingMQChannelDef );

				// Rededdm the SSO ticket and get the userid/password to use to interact with Payment Tracking System 
				string msgTicket = (string)requestMsg.GetPropertyValue(typeof(BTS.SSOTicket));
				string originatorSID = (string)requestMsg.GetPropertyValue(typeof(Microsoft.BizTalk.XLANGs.BTXEngine.OriginatorSID));

				string ptUserName;
				string[] paymentTrackerCredential = ssoTicket.RedeemTicket(ssoAffliateApp, originatorSID, msgTicket, SSOFlag.SSO_FLAG_NONE, out ptUserName); 

				// Retrieve the message format and the data format from the MQSeries header properties
				// these propoerties should have been set by the send pipeline.
				string msgFormat = (string)requestMsg.GetPropertyValue(typeof(MQSeries.MQMD_Format));
				string msgDataFormat = (string)requestMsg.GetPropertyValue(typeof(MQSeries.MQCIH_Format));
				
				byte[] responseBytes = helperMQSendReceive(
						(Stream)requestMsg[0].RetrieveAs(typeof(Stream)),
						qManager,
						mqChannelDef,
						requestQueue,
						responseQueue, 
						ptUserName, 
						paymentTrackerCredential[0],
						ptTimeout,
						msgFormat,
						msgDataFormat
					);
			
				// Fill the message in from the stream.  This avoids creating the XML Document. 
				// Since the message received is expecetd to be small here, using MemoryStream is ok here.  
				// If the message is large, then an alternalte for MemoryStream (possibly Virtual Stream) 
				// is required.
				using (MemoryStream ms = new MemoryStream(responseBytes,0, responseBytes.Length, false, true))
				{
					responseMsg[0].LoadFrom(ms);
				}
			}

			catch (MQException mqEx)
			{
				Trace.WriteLine ("MQ Exception " + mqEx.ToString());
				if (mqEx.ReasonCode == MQC.MQRC_NO_MSG_AVAILABLE)	// No message was available - timed out...
				{
					// we could throw the .net timeout exception.  But the orchestrations 
					// are already using the XLang version as they were ported from the adapter 
					// scenario.  Use the XLang timeout instead here...
					throw new PaymentTrackerTimeoutException ();
				}
				else
				{
					throw;
				}
			}
			finally
			{
			}
		}

		private static byte[] helperMQSendReceive (Stream msgStreamToSend, string qManager, string mqChannelDef, string sndQueue, string rcvQueue, 
				string ptUserName, string ptPassword, 
				int timeOutMilliSeconds, string msgFormat, string msgDataFormat)
		{
			MQQueueManager mqQManager = null;
			MQQueue mqSend = null;
			MQQueue mqReceive = null;
			const int MAX_MQ_MSGID_SIZE_IN_BYTES = 24;

			try 
			{

				if (0 == mqChannelDef.Length)
				{
					mqQManager = new MQQueueManager(qManager);
				}
				else
				{
					string channelName = "";
					string connectionName = "";
					char[] separator = {'/'};
					string[] parts;
					parts = mqChannelDef.Split( separator );

					if (parts.Length > 0) channelName = parts[0];

					if (parts.Length > 2) connectionName = parts[2];

					mqQManager = new MQQueueManager(qManager, channelName, connectionName);
				}
			
				if (null == mqQManager)
				{
					throw new PaymentTrackerQueueManagerException(qManager);
				}

				mqSend = mqQManager.AccessQueue(sndQueue, 
								MQC.MQOO_OUTPUT	|					// open queue for output
								MQC.MQOO_FAIL_IF_QUIESCING |		// but not if MQM stopping
								MQC.MQOO_SET_IDENTITY_CONTEXT);     // Needed to preserve the user id when transmitting

				MQMessage sndMessage = new MQMessage();
				
				// Format of the message sent 
				if ("MQCICS  " == msgFormat)
				{
					sndMessage.Format = MQC.MQFMT_CICS;
					writeMQCIHHeader(sndMessage, ptPassword, msgDataFormat);
				}
				else
				{
					throw new NotSupportedException(
						string.Format ( System.Globalization.CultureInfo.CurrentCulture,
										"Unsupported message format '{0}' in the message to be sent", 
										msgFormat
									)
							);
				}

				byte[] data = new byte[msgStreamToSend.Length] ;
				
				msgStreamToSend.Read(data, 0, (int)msgStreamToSend.Length);

				sndMessage.Write(data);			

				// set the user id field of the message to the supplied (SSO-mapped) userid.
				sndMessage.UserId = ptUserName ;
			
				MQPutMessageOptions putMsgOptions = new MQPutMessageOptions();

				putMsgOptions.Options = MQC.MQPMO_NONE | MQC.MQPMO_SET_IDENTITY_CONTEXT ;

				// Generate a guid and append with 0's for the MQ message id.
				byte[] guidBytes = System.Guid.NewGuid().ToByteArray();
				byte[] sendMsgId = new byte[MAX_MQ_MSGID_SIZE_IN_BYTES];

				for (int i = 0; i < guidBytes.Length; i++)
				{
					sendMsgId[i] = guidBytes[i];
				}
				for (int i = guidBytes.Length; i < sendMsgId.Length; i++)
				{
					sendMsgId[i] = 0;
				}

				sndMessage.MessageId = sendMsgId;
			
				mqSend.Put( sndMessage, putMsgOptions );

				mqReceive = mqQManager.AccessQueue(rcvQueue,
					MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING);

				MQMessage rcvMessage = new MQMessage();
				MQGetMessageOptions getMsgOpts = new MQGetMessageOptions();
				getMsgOpts.Options = MQC.MQGMO_WAIT;
                getMsgOpts.MatchOptions = MQC.MQMO_MATCH_CORREL_ID;

				getMsgOpts.WaitInterval = timeOutMilliSeconds ;
				rcvMessage.CorrelationId = sendMsgId;

				mqReceive.Get(rcvMessage, getMsgOpts);

				if(rcvMessage.Format.CompareTo(MQC.MQFMT_STRING) == 0)
				{
					rcvMessage.Seek(0);
					byte[] responseMsg = rcvMessage.ReadBytes(rcvMessage.MessageLength);
					return responseMsg;
				}
				else
				{
					throw new NotSupportedException(
						string.Format(
							System.Globalization.CultureInfo.CurrentCulture,
							"Unsupported message format '{0}' read from queue.", 
							rcvMessage.Format
						)
					);
				}
			}

			finally
			{	
				if (null != mqSend)
				{
					mqSend.Close();
				}
				if (null != mqReceive)
				{
					mqReceive.Close();
				}
				if (null != mqQManager)
				{
					mqQManager.Close();
				}
			}
		}

		private static void writeMQCIHHeader(MQMessage sndMessage, string ptPassword, string msgDataFormat )
		{
			sndMessage.WriteString("CIH ");				//MQCHAR4   StrucId					-  Structure identifier 
			
			int mqCIHVersion = 1;
			sndMessage.WriteInt(mqCIHVersion);			//MQLONG    Version					- Structure version number 1 or 2

			sndMessage.WriteInt(164);					//MQLONG    StrucLength;      - Length of MQCIH structure V1=164 V2=180 
			
			sndMessage.Encoding = MQC.MQENC_NATIVE;
			sndMessage.WriteInt(sndMessage.Encoding);	//MQLONG    Encoding;     - Reserved 

			sndMessage.WriteInt(sndMessage.CharacterSet); //MQLONG    CodedCharSetId;- Reserved 

			if ("MQSTR   " == msgDataFormat)
			{
				sndMessage.WriteString(MQC.MQFMT_STRING);	//MQCHAR8   Format;           - MQ Format name 
			}
			else
			{
				throw new NotSupportedException(
								string.Format(
								System.Globalization.CultureInfo.CurrentCulture,
								"Unsupported message data format '{0}' in the message to be sent",
								msgDataFormat
							)
						);
			}

			sndMessage.WriteInt(0);                   //MQLONG    Flags;            - Reserved 
			sndMessage.WriteInt(0);                   //MQLONG   ReturnCode;        - Return code from bridge 
			sndMessage.WriteInt(0);                   //MQLONG   CompCode;          - MQ completion code or CICS EIBRESP 
			sndMessage.WriteInt(0);                   //MQLONG   Reason;            - MQ reason or feedback code, or CICS EIBRESP2 

			//MQLONG   UOWControl;        - Unit-of-work control - don't seem to find the constant definition for this
			sndMessage.WriteInt(273);                 	
			
			sndMessage.WriteInt(-2);                  //MQLONG   GetWaitInterval;   - Wait interval for MQGET call issued by bridge 
			sndMessage.WriteInt(1);                   //MQLONG   LinkType;          - Link type 
			sndMessage.WriteInt(-1);                  //MQLONG   OutputDataLength;  - Output commarea data length 
			sndMessage.WriteInt(0);                   //MQLONG   FacilityKeepTime;  - Bridge facility release time 
			sndMessage.WriteInt(0);                   //MQLONG   ADSDescriptor;     - Send/receive ADS descriptor 
			sndMessage.WriteInt(0);                   //MQLONG   ConversationalTask;- Whether task can be conversational 
			sndMessage.WriteInt(0);                   //MQLONG   TaskEndStatus;     - Status at end of task 
		
			// Facility - need to init to 0's 

			byte [] facility = new byte[8];
			for (int i = 0 ; i < facility.Length; i++)
			{
				facility[i] = 0 ;
				sndMessage.WriteByte(facility[i]);
			}

			sndMessage.WriteString(new string(' ', 4));           //MQCHAR4  Function			- MQ call name or CICS EIBFN function name 
			sndMessage.WriteString(new string(' ', 4));           //MQCHAR4  AbendCode;         - Abend code              

			//MQCHAR8  Authenticator;     - Password or passticket 

			// Note - the password to the back end system (along with the entire message) is transmitted in clear text, unless MQSeries 
			// itself has been configured to use encrypted channels (such as SSL) for the queues.

			if (ptPassword.Length <= 8)
			{
				string passwd = ptPassword + new String(' ', 8 - ptPassword.Length);
				sndMessage.WriteString (passwd);
			}
			else
			{
				sndMessage.WriteString(new String(' ', 8));		// Longer password is ignored completely...
			}

			sndMessage.WriteString(new string(' ', 8));       //MQCHAR8  Reserved1;         - Reserved     
			
			sndMessage.WriteString(MQC.MQFMT_STRING);   //MQCHAR8  ReplyToFormat;     - MQ format name of reply message 
			
			sndMessage.WriteString(new string(' ', 4));         //MQCHAR4  RemoteSysId;       - Remote sysid to use            
			sndMessage.WriteString(new string(' ', 4));         //MQCHAR4  RemoteTransId;     - Remote transid to attach 
			sndMessage.WriteString(new string(' ', 4));         //MQCHAR4  TransactionId;     - Transaction to attach        
			sndMessage.WriteString(new string(' ', 4));         //MQCHAR4  FacilityLike;      - Terminal emulated attributes 
			sndMessage.WriteString(new string(' ', 4));         //MQCHAR4  AttentionId;       - AID key              
			sndMessage.WriteString(new string(' ', 4));         //MQCHAR4  StartCode;         - Transaction start code 
			sndMessage.WriteString(new string(' ', 4));         //MQCHAR4  CancelCode;        - Abend transaction code 
			sndMessage.WriteString(new string(' ', 4));         //MQCHAR4  NextTransactionId; - Next transaction to attach 
			sndMessage.WriteString(new string(' ', 8));			//MQCHAR8  Reserved2;         - Reserved 
			sndMessage.WriteString(new string(' ', 8));			//MQCHAR8  Reserved3;         - Reserved 

			// Version 2 fields, only for version 2 of the structure...
			if ( 2 == mqCIHVersion)
			{
				sndMessage.WriteInt(0);                   //MQLONG   CursorPosition;    - Cursor position
				sndMessage.WriteInt(0);                   //MQLONG   ErrorOffset;       - Error offset
				sndMessage.WriteInt(0);                   //MQLONG   InputItem;         - Input item
				sndMessage.WriteInt(0);                   //MQLONG   Reserved4;         - Reserved
			}
		}

	}
}
