#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.BizTalk.ExplorerOM;

#endregion

namespace ApplicationManager
{
	class Program
	{
		static void Main(string[] args)
		{
			// Handle the command-line arguments and switches
			if (args.Length != 2)
			{
				PrintUsage();
				return;
			}

			if (args[0] != "start" && args[0] != "stop" )
			{
				PrintUsage();
				return;
			}

			// Create the root object and set the connection string
			BtsCatalogExplorer catalog = new BtsCatalogExplorer();
			catalog.ConnectionString = "SERVER=.;DATABASE=BizTalkMgmtDb;Integrated Security=SSPI";

			string applicationName = args[1];
			Application app = catalog.Applications[applicationName];
			if (null == app)
			{
				Console.WriteLine("Application " + applicationName + " does not exist.");
				return;
			}

			if (args[0] == "start")
			{
				app.Start(ApplicationStartOption.StartAll);
			}
			else
			{
				app.Stop(ApplicationStopOption.StopAll);
			}

			catalog.SaveChanges();
		}

		static private void PrintUsage()
		{
			Console.WriteLine("Usage:");
			Console.WriteLine();
			Console.WriteLine("ApplicationManager <start|stop> <Application Name>");
			Console.WriteLine();
			Console.WriteLine(" Where: ");
			Console.WriteLine("  <Application Name> = The name of the application that needs to be changed ");
			Console.WriteLine();
			Console.WriteLine("Example: ApplicationManager start Application1");
			Console.WriteLine();
		}
	}
}
