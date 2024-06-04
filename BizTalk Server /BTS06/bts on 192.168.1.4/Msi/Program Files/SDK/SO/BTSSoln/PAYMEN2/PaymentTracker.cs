//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTracker
// Simple simulator for the Payment Tracking System in the end to end Service Oriented Scenario.
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
using System.Threading;
using IBM.WMQ;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTracker
{
	/// <summary>
	/// Simulator for the Payment Tracking System in the end to end Service Oriented Scenario.
	/// Accepts incoming messages and respond to them in multiple threads.  The messages are
	/// accepted using IBM MQSeries.
	/// </summary>
	/// 
	class PaymentTracker
	{

		private static int numThreads;					// Num of threads
		private const int NUM_DEFAULT_THREADS = 10;		// Number of default threds, if none specified
		private const int MAX_THREADS_ALLOWED = 100;	// Max # of threads allowed...
		private static string readQueueName ;
		private static string writeQueueName;
		private static string queueManagerName;
		private static string channelDefinition;

		private static bool isRunning = true;

		private static PaymentTrackerSimulator.PaymentTrackerSimulatorDelegate[] simDelegates;
		private static IAsyncResult[] callResults;
		/// <summary>
		/// The main entry point for the application
		/// </summary>
		
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				parseArguments(args);

				simDelegates = new PaymentTrackerSimulator.PaymentTrackerSimulatorDelegate[numThreads];
				callResults = new IAsyncResult[numThreads];

				for (int i = 0; i < numThreads; i++)
				{
					simDelegates[i] = new PaymentTrackerSimulator.PaymentTrackerSimulatorDelegate(PaymentTrackerSimulator.Run);
					callResults[i] = simDelegates[i].BeginInvoke(channelDefinition, queueManagerName, readQueueName, writeQueueName, null, null);
				}

				// Wait indefinitely while allowing the worker threads to do the work.

				Console.ReadLine();

				// Stop the incoming threads from accepting anymore messages and exit.
				isRunning = false;

				// Wait for the workers to finish
				for (int i = 0; i < numThreads; i++)
				{
					simDelegates[i].EndInvoke(callResults[i]);
				}
			}

			catch (MQException mqEx)
			{
				Console.WriteLine("MQSeries Exception while creating the simulator: MQ Reason Code = <{0}> MQ Message <{1}> \n Inner Exception: {2}",
								mqEx.ReasonCode,
								mqEx.Message,
					(null == mqEx.InnerException ? "" : mqEx.InnerException.ToString()));
			}

			catch (IncorrectUsageException)
			{
				return;
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Exception while creating the simulator: {0}\n Inner Exception: {1}",
					ex.ToString(),
					(null == ex.InnerException ? "" : ex.InnerException.ToString()));
			}
		}

		/// <summary>
		/// Parse command line arguments and set appropriate member variables.
		/// </summary>
		/// <param name="args">
		/// array of strings - the command line arguments
		/// </param>
		private static void parseArguments(string[] args)
		{
			const string USAGE = "Usage:  BTSScnSOPaymentTracker  <Queue to Read> <Queue To Write> <Queue Manager Name> [<Number of Threads>] [<ChannelDefinition>]\n" +
								 "Channel Definition is of the form channel-name/transport/hostname(port)";
	
			if (args.Length < 3)
			{
				Console.Error.WriteLine(USAGE);
				throw new IncorrectUsageException();
			}
			readQueueName = args[0];
			writeQueueName = args[1];
			queueManagerName = args[2];
			
			// If the number of threads are specified, use it, otherwise default...
			numThreads = (args.Length >= 4) ? 
								System.Convert.ToInt32(args[3], System.Globalization.CultureInfo.CurrentCulture) : 
								NUM_DEFAULT_THREADS ;

			if (numThreads > MAX_THREADS_ALLOWED || numThreads < 1)
			{
				Console.Error.WriteLine("Incorrect number of threads.  Number of threads should be between 1 and {0}", MAX_THREADS_ALLOWED);
				throw new IncorrectUsageException();
			}
			// If the channel definition is specified use it otherwise, no channel definition...
			channelDefinition = (5 == args.Length) ? args[4] : "";
		}

		public static bool IsPaymentTrackerRunning
		{
			get
			{
				return isRunning;
			}
		}
	}

	/// <summary>
	/// Simple class to deal with incorrect usage of the program/incorrect command line arguments...
	/// </summary>
	internal class IncorrectUsageException : ApplicationException
	{
		internal IncorrectUsageException()
			: base("Incorrect Usage")
		{ 
		}
	}
}
