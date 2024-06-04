//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTracker.PaymentTrackerSimulator
// Simulator class for the Payment Tracking System in the end to end Service Oriented Scenario.
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
using System.Threading;
using IBM.WMQ;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTracker
{
	/// <summary>
	/// Summary description for PaymentTrackerSimulator.
	/// </summary>
	public class PaymentTrackerSimulator : IDisposable
	{
		private bool disposed;
		private MQQueueManager mqQManager ;
		private MQQueue mqRead;
		private MQQueue mqWrite;

		// Time to wait for a message when there is no message in the queue - in milliseconds
		private const int MESSAGE_WAIT_TIME = 500;

		private const int RECEIVE_NO_MESSAGE = 1;
		private const int RECEIVE_SUCCESS = 0;

		private const int SEND_SUCCESS = 0;

		/// <summary>
		/// PaymentTrackerSimulator private constructor, to support creating the queues and disposing them of
		/// properly
		/// </summary>
		/// <param name="channelDefinition" >
		/// string - MQSeries Channel Definition - when using a remote queue manager.  This should be of the form
		/// channel-name/transport/hostname(port) - refer to MQSeries docs for more info.
		/// </param>
		/// <param name="queueManagerName">
		/// string - Name of the MQ Series Queue Manager to work with
		/// </param>
		/// <param name="readQueue">
		/// string - Name of the MQ Series queue to read from for the incoming messages
		/// </param>
		/// <param name="writeQueue">
		/// string - Name of the MQ Series queue to write the result messages to
		/// </param>
		/// 
		private PaymentTrackerSimulator(string channelDefinition, string queueManagerName, string readQueue, string writeQueue)
		{
			if (0 == channelDefinition.Length)
			{
				mqQManager = new MQQueueManager(queueManagerName);
			}
			else
			{
				string channelName = "";
				string connectionName = "";
				char[] separator = {'/'};
				string[] parts;
				parts = channelDefinition.Split( separator );
				if (parts.Length > 0) channelName = parts[0];
				if (parts.Length > 2) connectionName = parts[2];

				mqQManager = new MQQueueManager(queueManagerName, channelName, connectionName);
			}
			// Open queus for read, write opes, but not when the queue manager is stopping
			mqRead = mqQManager.AccessQueue(readQueue,	MQC.MQOO_INPUT_AS_Q_DEF | MQC.MQOO_FAIL_IF_QUIESCING);

			mqWrite = mqQManager.AccessQueue(writeQueue, MQC.MQOO_OUTPUT | MQC.MQOO_FAIL_IF_QUIESCING );
		}

		// delagate to support async execution of the Run method below...

		public delegate void PaymentTrackerSimulatorDelegate(string channelDefinition, string queueManagerName, string readQueue, string writeQueue);

		/// <summary>
		/// Thread proc.
		/// </summary>
		public static void Run(string channelDefinition, string queueManagerName, string readQueue, string writeQueue)
		{
            Console.WriteLine("Simulator beginning - Thread id " + Thread.CurrentThread.ManagedThreadId );
            try
			{

				using (
					PaymentTrackerSimulator pts = new PaymentTrackerSimulator(channelDefinition, queueManagerName, readQueue, writeQueue))
				{
					while (PaymentTracker.IsPaymentTrackerRunning)
					{
						byte[] receivedMessage;
						byte[] messageID;
						byte[] messageToSend;
						byte[] sentMessageID;
						string userID;
						string password;

						int receiveStatus = pts.helperMQReceive(out receivedMessage, out messageID, out userID, out password);
					
						switch (receiveStatus)
						{
							case RECEIVE_NO_MESSAGE:
								Thread.Sleep(MESSAGE_WAIT_TIME);
								break;
						
							case RECEIVE_SUCCESS:

								Console.WriteLine("Thread {0} - Received Message ID: {1}", 
													Thread.CurrentThread.ManagedThreadId, 
													mqMessageIdToString(messageID));
                                
								MessageProcessor mp = new MessageProcessor(receivedMessage);
								
								messageToSend = mp.ProcessRequestMessage(userID, password);
								
								pts.helperSend(messageToSend, messageID, out sentMessageID);
								
								Console.WriteLine("Thread {0} - Sent Message ID: {1}", 
									Thread.CurrentThread.ManagedThreadId,
									mqMessageIdToString(sentMessageID));
								
								break;

							default:
								throw new NotSupportedException("Unsupported return code - Internal software error");
						}
					}
				}
			}
			catch (MQException mqEx)
			{
				Console.WriteLine("Worker Thread {0} - Terminating with MQ Series exception while receiving/handling messages.  Reason Code = {1}, Reason = {2}, Message = {3}, Stack Trace = {4}, Inner Exception = {5}",
                    Thread.CurrentThread,
                    mqEx.ReasonCode,
					mqEx.Reason,
					mqEx.Message,
					mqEx.StackTrace,
					(null == mqEx.InnerException ? "" : mqEx.InnerException.ToString()));

			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Worker Thread {0} - Terminating with Exception while receiving/handling messages.  Exception = {1}, Inner Exception = {2}",
					Thread.CurrentThread, 
					ex.ToString(), 
					(null == ex.InnerException ? "" : ex.InnerException.ToString()));
				throw;
			}
		}

		/// <summary>
		/// Helper method to receive a MQ series message from a queue
		/// </summary>
		/// 
		/// <param name="receivedMessage">
		/// out byte[] - received message is returned through this parameter
		/// </param>
		/// <param name="messageID">
		/// out byte[] - the message id for the received message - to be used for correlating the responses - is returned here
		/// </param>
		/// <param name="userID">
		/// out string - user id to use to process this message
		/// </param>
		/// <param name="password">
		/// out string - password 
		/// </param>
		private int helperMQReceive (out byte[] receivedMessage, out byte[] messageID, out string userID, out string password)
		{
			try 
			{
				// Prepare to Receive a message
				MQMessage rcvMessage = new MQMessage();
				MQGetMessageOptions getMsgOpts = new MQGetMessageOptions();
				getMsgOpts.Options = MQC.MQGMO_WAIT ;
				getMsgOpts.WaitInterval = MESSAGE_WAIT_TIME;

				mqRead.Get(rcvMessage, getMsgOpts);

				// If the format is CICS, then read the MQCIH struct out of the message first and then the message

				if (rcvMessage.Format.CompareTo(MQC.MQFMT_CICS) == 0)
				{
					// Read the MQCIH structure - we only need the password, ignore everythign else.
					password = readMqcihAndGetPassword(rcvMessage);

					// Message Data
					receivedMessage = rcvMessage.ReadBytes(rcvMessage.MessageLength);

					// User ID is in the MQMD header...
					userID = rcvMessage.UserId;

					// Message ID
					messageID = rcvMessage.MessageId;

					return RECEIVE_SUCCESS;
				}
				else
				{
					throw new NotSupportedException(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Unsupported message format '{0}' read from queue.", rcvMessage.Format));
				}
			}
			catch (MQException mqe) 
			{
				if (MQC.MQRC_NO_MSG_AVAILABLE == mqe.ReasonCode)
				{
					receivedMessage = null;
					messageID = null;
					userID = null;
					password = null;
					return RECEIVE_NO_MESSAGE;
				}
				else
				{
					Console.Error.WriteLine( "MQSeries Exception:\n" + mqe.ToString());
					throw ;
				}
			}
		}

		/// <summary>
		/// Helper method to send a message through the MQ Series Queue
		/// </summary>
		/// <param name="messageToSend">
		/// byte[] - message is sent from this buffer.
		/// </param>
		/// <param name="correlationID">
		/// byte[] - the correlation ID of the outgoing message is set to this value.
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		private int helperSend(byte[] messageToSend, byte[] correlationID, out byte[] sentMessageID)
		{
			try 
			{
				MQMessage sndMessage = new MQMessage();
				sndMessage.Write(messageToSend);
				sndMessage.Format = MQC.MQFMT_STRING;
				sndMessage.CorrelationId = correlationID;

				//CustomerServiceResponse2(MQSeries.MQMD_CorrelId) = CustomerServiceRequest (MQSeries.MQMD_MsgId);

				MQPutMessageOptions putMsgOptions = new MQPutMessageOptions();
				
				byte[] sendMsgID = Guid.NewGuid().ToByteArray();
				sndMessage.MessageId = sendMsgID;

				mqWrite.Put( sndMessage, putMsgOptions );
				sentMessageID = sendMsgID;

				return SEND_SUCCESS;
			}
			catch (MQException mqe) 
			{
				Console.Error.WriteLine( "MQSeries Exception:\n" + mqe.ToString());
				throw ;
			}
		}

		private static string readMqcihAndGetPassword(MQMessage rcvMessage)
		{
                         
			// Read MQCIH struct from the message buffer...
			// Using the description of MQCIH struct in in the MQSeries reference...

			rcvMessage.ReadString(4);  //MQCHAR4   StrucId;         /* Structure identifier */

			int mqcihVersion = rcvMessage.ReadInt();	//MQLONG    Version;         /* Structure version number 1 or 2 */
			
			rcvMessage.ReadInt();    //MQLONG    StrucLength;     /* Length of MQCIH structure V1=164 V2=180 */
			rcvMessage.ReadInt();		//MQLONG    Encoding;        /* Reserved */
			rcvMessage.ReadInt();			//MQLONG    CodedCharSetId;  /* Reserved */
			rcvMessage.ReadString(8);	//MQCHAR8   Format;          /* MQ Format name */
			rcvMessage.ReadInt();           //MQLONG    Flags;           /* Reserved */
			rcvMessage.ReadInt();      //MQLONG   ReturnCode;       /* Return code from bridge */          
			rcvMessage.ReadInt();        //MQLONG   CompCode;         /* MQ completion code or CICS EIBRESP */                          
			rcvMessage.ReadInt();		    //MQLONG   Reason;           /* MQ reason or feedback code, or CICS EIBRESP2 */                         
			rcvMessage.ReadInt();      //MQLONG   UOWControl;       /* Unit-of-work control */             
			rcvMessage.ReadInt();    //MQLONG   GetWaitInterval;  /* Wait interval for MQGET call issued by bridge */                        
			rcvMessage.ReadInt();	    //MQLONG   LinkType;            /* Link type */                        
			rcvMessage.ReadInt();      //MQLONG   OutputDataLength;    /* Output commarea data length */      
			rcvMessage.ReadInt();		//MQLONG   FacilityKeepTime;    /* Bridge facility release time */     
			rcvMessage.ReadInt();         //MQLONG   ADSDescriptor;       /* Send/receive ADS descriptor */      
			rcvMessage.ReadInt();        //MQLONG   ConversationalTask;  /* Whether task can be conversational */                   
			rcvMessage.ReadInt();      //MQLONG   TaskEndStatus;       /* Status at end of task */            

			rcvMessage.ReadBytes(8);  //MQBYTE   Facility[8];         /* BVT token value */
			rcvMessage.ReadString(4);      //MQCHAR4  Function;          /* MQ call name or CICS EIBFN function name */

			rcvMessage.ReadString(4); //MQCHAR4  AbendCode;           /* Abend code */                       
			
			string password = rcvMessage.ReadString(8);  //MQCHAR8  Authenticator;       /* Password or passticket */

			rcvMessage.ReadString(8);     //MQCHAR8  Reserved1;           /* Reserved */                         
			rcvMessage.ReadString(8);  //MQCHAR8  ReplyToFormat;       /* MQ format name of reply message */  
			rcvMessage.ReadString(4);           //MQCHAR4  RemoteSysId;         /* Remote sysid to use */              
			rcvMessage.ReadString(4);           //MQCHAR4  RemoteTransId;       /* Remote transid to attach */         
			rcvMessage.ReadString(4);     //MQCHAR4  TransactionId;       /* Transaction to attach */            
			rcvMessage.ReadString(4);      //MQCHAR4  FacilityLike;        /* Terminal emulated attributes */     
			rcvMessage.ReadString(4); //MQCHAR4  AttentionId;         /* AID key */                          
			rcvMessage.ReadString(4);   //MQCHAR4  StartCode;           /* Transaction start code */           
			rcvMessage.ReadString(4);  //MQCHAR4  CancelCode;          /* Abend transaction code */           
			rcvMessage.ReadString(4);  //MQCHAR4  NextTransactionId;   /* Next transaction to attach */       
			rcvMessage.ReadString(8);       //MQCHAR8  Reserved2;           /* Reserved */                         
			rcvMessage.ReadString(8);       //MQCHAR8  Reserved3;           /* Reserved */                         

			//Version 2 fields

			if (2 ==  mqcihVersion )
			{
				rcvMessage.ReadInt();        //MQLONG   CursorPosition;      /* Cursor position */
				rcvMessage.ReadInt();        //MQLONG   ErrorOffset;         /* Error offset */
				rcvMessage.ReadInt();        //MQLONG   InputItem;           /* Input item */
				rcvMessage.ReadInt();            //MQLONG   Reserved4;           /* Reserved */
			}

			return password;
		}

		private static string mqMessageIdToString(byte[] mqMsgId)
		{
			StringBuilder buf = new StringBuilder("");
			char[] hexDigits = new char[] {'0','1','2', '3','4','5','6','7','8','9','A','B','C','D','E','F'};

			for (int i = 0 ; i < mqMsgId.Length ; i++)
			{
				uint low = (uint)mqMsgId[i] & (uint)0x0F;
				uint high = ((uint)(mqMsgId[i]) & (uint)0xF0) >> 4;
				buf.Append(hexDigits[high]);
				buf.Append(hexDigits[low]);
			}
			return buf.ToString();
		}
		#region IDisposable Members

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);

		}

		#endregion

		private void Dispose(bool disposing)
		{
			if (! this.disposed)
			{
				if (disposing)
				{
					try
					{
						if (null != mqRead)
						{
							mqRead.Close();
						}
						if (null != mqWrite)
						{
							mqWrite.Close();
						}
						if (null != mqQManager)
						{
							mqQManager.Close();
						}
					}
					catch (MQException mqEx)
					{
						Console.WriteLine("MQSeries Exception while closing the simulator: MQ Reason Code = <{0}> MQ Message <{1}> \n Inner Exception: {2}",
							mqEx.ReasonCode,
							mqEx.Message,
							(null == mqEx.InnerException ? "" : mqEx.InnerException.ToString()));
					}
					catch (System.Exception ex)
					{
						Console.WriteLine("Exception while closing the simulator: {0}\n Inner Exception: {1}",
							ex.ToString(),
							(null == ex.InnerException ? "" : ex.InnerException.ToString()));
						throw;
					}
				}
				disposed = true;
			}
		}
	}
}
