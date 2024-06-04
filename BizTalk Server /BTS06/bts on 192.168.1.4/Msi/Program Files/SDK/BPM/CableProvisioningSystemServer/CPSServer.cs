//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.CableProvisioningSystemServer
// Remoting server for cable provisioning system
// 
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.CableProvisioningSystem
{
	/// <summary>
	/// Summary description for OrderMgmtSrv.
	/// </summary>
	class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            int port = 8080;

            using (TextWriterTraceListener writer = new TextWriterTraceListener(Console.Out))
            {
                Trace.Listeners.Add(writer);
                Trace.AutoFlush = true;
                Trace.Indent();

                if (args.Length < 1)
                {
                    Console.WriteLine("Usage: BTSScnBPMProvisioning {port}");
                    return;
                }

                try
                {
                    port = Convert.ToInt32(args[0], System.Globalization.CultureInfo.InvariantCulture);
                    if (port < System.Net.IPEndPoint.MinPort || port > System.Net.IPEndPoint.MaxPort)
                    {
                        string range = string.Format(System.Globalization.CultureInfo.InvariantCulture, "MinPort({0}) <= port >= MaxPort({1})", System.Net.IPEndPoint.MinPort, System.Net.IPEndPoint.MaxPort);
                        throw new ArgumentOutOfRangeException("port", range);
                    }
                    ChannelServices.RegisterChannel(new TcpChannel(port),false);
                    RemotingConfiguration.ApplicationName = "CableProvisioningSystemServer";
                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(OrderHandler), "OrderHandler.rem", WellKnownObjectMode.Singleton);
                    Console.WriteLine("Listening on TCP:" + args[0] + " for CableProvisioningSystemServer/OrderHandler requests\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception trying to configure remoting server. Exception: " + e);
                    return;
                }

                Console.WriteLine("Press Enter to exit...\n");
                Console.ReadLine();
            }
		}
	}
}
