//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.OperationsServer
// Operations remoting server
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Globalization;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.Operations
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (TextWriterTraceListener writer = new TextWriterTraceListener(Console.Out))
            {
                // Have the trace data go to the console
                Trace.Listeners.Add(writer);
                Trace.AutoFlush = true;
                Trace.Indent();

                if (args.Length < 1)
                {
                    Console.WriteLine("Usage: BTSScnBPMOperations {port}");
                    return;
                }

                try
                {
                    // Get the port number from the command line
                    int port = Convert.ToInt32(args[0], CultureInfo.InvariantCulture);

                    // Make sure the port number is in range
                    if (port < System.Net.IPEndPoint.MinPort || port > System.Net.IPEndPoint.MaxPort)
                    {
                        string range = string.Format(CultureInfo.InvariantCulture, "MinPort({0}) <= port >= MaxPort({1})", System.Net.IPEndPoint.MinPort, System.Net.IPEndPoint.MaxPort);
                        throw new ArgumentOutOfRangeException("port", range);
                    }

                    // Register to host the OpsHandler component
                    const string objectUri = "OpsHandler.rem";
                    ChannelServices.RegisterChannel(new TcpChannel(port),true);
                    RemotingConfiguration.ApplicationName = "OperationsServer";
                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(OpsHandler), objectUri, WellKnownObjectMode.Singleton);

                    Console.WriteLine("Listening on TCP:{0} for {1}\\{2} requests", port.ToString(CultureInfo.InvariantCulture), RemotingConfiguration.ApplicationName, objectUri);
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
