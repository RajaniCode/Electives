//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.Operations.OpsClient
// Operations AIC for OpsAdapter
// 
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
#region Using directives
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Diagnostics;
using Microsoft.Samples.BizTalk.SouthridgeVideo.Adapters.OpsAdapter;
#endregion

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.Operations
{
    /// <summary>
    /// Implimentation of OpsAdapter configured component.
    /// </summary>
    [Serializable]
    public class OpsClient : IOpsAIC, ISerializable
    {
        [NonSerialized]
        private IOperationsSystem handler;
        // serverLocation is expected to be in the format "server:port" e.g. "localhost:8080"
        private string serverLocation = string.Empty;

        /// <summary>
        /// Default constructor
        /// </summary>
        public OpsClient()
        {
        }

        /// <summary>
        /// Gets the OpsClient.  If one hasn't been created it will create a new remote instance of one.
        /// </summary>
        private IOperationsSystem Handler
        {
            get
            {
                if (null == this.handler)
                {
                    if (string.IsNullOrEmpty(this.serverLocation))
                    {
                        throw new InvalidOperationException("Initialize with a server location must called first.");
                    }
                    else
                    {
                        this.GetRemotingInstance();
                    }
                }

                return this.handler;
            }
        }

        #region IOpsAIC Members
        /// <summary>
        /// Initializes the OpsHandler. This method will always be called before any other method
        /// </summary>
        /// <param name="config">config data passed from the adapter.  Expecting "server:port"</param>
        public void Initialize(string config)
        {
            this.serverLocation = config;
            this.Handler.Initialize(config);
        }

        /// <summary>
        /// Executes the main portion of the code
        /// </summary>
        /// <param name="message">message to execute upon</param>
        public void Execute(byte[] message)
        {
            this.Handler.Post(Environment.MachineName, message);
        }
        #endregion // IOpsAIC Memebers

        /// <summary>
        /// Gets a remote instance of an OpsHandler
        /// </summary>
        private void GetRemotingInstance()
        {
            // serverLocation is expected to be in the format "server:port" e.g. "localhost:8080"
            string uri = "tcp://" + this.serverLocation + "/OperationsServer/OpsHandler.rem";

            WellKnownClientTypeEntry entry = RemotingConfiguration.IsWellKnownClientType(typeof(IOperationsSystem));
            if (null == entry)
            {
                ChannelServices.RegisterChannel(new TcpChannel(), true);

                RemotingConfiguration.RegisterWellKnownClientType(typeof(IOperationsSystem), uri);
            }

            try
            {
                this.handler = (IOperationsSystem)Activator.GetObject(typeof(IOperationsSystem), uri);
            }
            catch (Exception e)
            {
                this.handler = null;
                Trace.WriteLine("URI: " + uri);
                Trace.WriteLine("Type: " + typeof(OpsClient));
                Trace.WriteLine(e);
                throw;
            }

            if (null == this.handler)
            {
                Trace.WriteLine("Could not locate Operations Server");
                throw new OpsClientException("Could not locate Operations Server");
            }
        }
        #region ISerializable Members

        /// <summary>
        /// Constructor needed for ISerializable
        /// </summary>
        /// <param name="info">serialization info</param>
        /// <param name="context">streaming context</param>
        protected OpsClient(SerializationInfo info, StreamingContext context)
        {
            if (null == info)
            {
                throw new ArgumentNullException("info");
            }
            serverLocation = info.GetString("serverLocation");
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
            info.AddValue("serverLocation", serverLocation);
        }

        #endregion
    }
}