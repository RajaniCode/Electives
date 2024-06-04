//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.CableProvisioningSystem
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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.CableProvisioningSystem
{
	/// <summary>
	/// OrderHandlerWrapper wraps an OrderHandler to abstract the remoting component
	/// for easier serialization and access from an orchestration.
	/// </summary>
	/// <remarks>Custom serialization is needed here since we have a non-default constructor</remarks>
	[Serializable]
	public class OrderHandlerWrapper : IOrderHandler, ISerializable
	{
		[NonSerialized]
		IOrderHandler oh;

		string location = string.Empty;

		/// <summary>
		/// Gets or sets the location of the remoting server.  
		/// This property must be set before calling any other method.
		/// </summary>
		public string ServerLocation
		{
			get { return location; }
			set
			{
				if ( value != location )
				{
					oh = null;
				}

				location = value;
			}
		}

		/// <summary>
		/// Constructs an OrderHanderWrapper
		/// </summary>
		/// <param name="serverLocation">name of the server and the port with format "server:port"</param>
        public OrderHandlerWrapper( string serverLocation )
		{
			location = serverLocation;
		}

		/// <summary>
		/// Gets an OrderHandler.  If one hasn't been created then it will create a remote instance.
		/// </summary>
        private IOrderHandler OH
		{
			get
			{
				if ( null == oh )
				{
                    if (string.IsNullOrEmpty(location))
                    {
                        throw new InvalidOperationException("Initialize with a server location must called first.");
                    }
                    else
                    {
                        oh = GetRemotingInstance(location);
                    }
				}

				return oh;
			}
		}

		/// <summary>
		/// Creates an instance on the remote server
		/// </summary>
		/// <param name="server">remote server name and port with format "server:port"</param>
		/// <returns>a remoted instance of an OrderHandler</returns>
        private static IOrderHandler GetRemotingInstance( string server )
		{
            // server should have the format "server:port" e.g. "localhost:8080" 
            string uri = "tcp://" + server + "/CableProvisioningSystemServer/OrderHandler.rem";

            Trace.WriteLine("Connecting to remoting URI: " + uri);
            Trace.WriteLine("Type: " + typeof(IOrderHandler));

            WellKnownClientTypeEntry entry = RemotingConfiguration.IsWellKnownClientType(typeof(IOrderHandler));
			if ( null == entry )
			{
				ChannelServices.RegisterChannel( new TcpChannel(), false );

				RemotingConfiguration.RegisterWellKnownClientType( typeof(IOrderHandler), uri );
			}

			IOrderHandler service = null;
			try
			{
                service = (IOrderHandler)Activator.GetObject(typeof(IOrderHandler), uri);
			}
			catch( Exception e )
			{
				service = null;
                Trace.WriteLine(e);
				throw new OrderException( "Could not locate OrderManager Server", e );
			}

			if( service == null )
			{
				Trace.WriteLine("Could not locate OrderManager");
				throw new OrderException( "Could not locate OrderManager Server" );
			}
			
			return service;
		}

		#region IOrderHandler Members


        /// <summary>
        /// Analyzes the business validity and consistency of the request.
        /// </summary>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        /// <param name="orderTypeCode">Order Type Code</param>
        /// <param name="orderSeqNumber">order sequence number</param>
        /// <param name="orderDate">date of the order</param>
        /// <returns>true if analysis succeeded</returns>
        public bool Analyze(string customerId, string orderId, string orderTypeCode, int orderSeqNumber, DateTime orderDate)
		{
			return OH.Analyze( customerId, orderId, orderTypeCode, orderSeqNumber, orderDate );
		}

        /// <summary>
        /// Gets the current service type for this customer
        /// </summary>
        /// <param name="customerId">customer identifier</param>
        /// <returns>the service type currently active for this customer</returns>
        public string GetServiceType(string customerId)
        {
            return OH.GetServiceType( customerId );
        }

        /// <summary>
        /// Activates the service type specified
        /// </summary>
        /// <param name="serviceType">service type; either "STANDARD" | "DELUXE"</param>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        public void Activate(string serviceType, string customerId, string orderId)
		{
			OH.Activate( serviceType, customerId, orderId );
		}

        /// <summary>
        /// Cancels the current service
        /// </summary>
        /// <param name="serviceType">type of cable service</param>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        public void Cancel(string serviceType, string customerId, string orderId)
		{
			OH.Cancel( serviceType, customerId, orderId );
		}

        /// <summary>
        /// Commits the changes made in this object
        /// </summary>
        /// <param name="customerId">customer identifier</param>
        /// <param name="orderId">order identifier</param>
        public void Complete(string customerId, string orderId)
		{
			OH.Complete( customerId, orderId );
		}

		#endregion

		#region ISerializable Members

		/// <summary>
		/// Constructor needed for ISerializable
		/// </summary>
		/// <param name="info">serialization info</param>
		/// <param name="context">streaming context</param>
        protected OrderHandlerWrapper( SerializationInfo info, StreamingContext context )
		{
            if (null == info)
            {
                throw new ArgumentNullException("info");
            }
            location = info.GetString("location");
		}

		/// <summary>
		/// Adds the location to the reference data set
		/// </summary>
		/// <param name="info">serialization info</param>
		/// <param name="context">streaming context</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
            if (null == info)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("location", location);
		}

		#endregion
	}
}
