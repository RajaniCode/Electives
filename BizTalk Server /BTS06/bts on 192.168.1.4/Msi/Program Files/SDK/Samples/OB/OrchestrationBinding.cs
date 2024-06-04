#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.BizTalk.ExplorerOM;

#endregion

namespace OrchestrationBinding
{
	class OrchestrationBinding
	{
		static void Main(string[] args)
		{

		}

		public void BindOrchestration()
		{
			// Create the root object and set the connection string
			BtsCatalogExplorer catalog = new BtsCatalogExplorer();
			catalog.ConnectionString = "SERVER=.;DATABASE=BizTalkMgmtDb;Integrated Security=SSPI";

			try
			{
				BtsOrchestrationCollection orchestrations = catalog.Assemblies[0].Orchestrations;
				// Specify either a sendport or a sendportgroup for the orchestration outbound port
				orchestrations["BizTalkProject.Orchestration1"].Ports["OutboundPort_1"].SendPort = catalog.SendPorts["SendPort_1"];
				orchestrations["BizTalkProject.Orchestration1"].Ports["OutboundPort_2"].SendPortGroup = catalog.SendPortGroups["SendPortGroup_1"];
				// Specify a receiveport for orchestration inbound port
				orchestrations["BizTalkProject.Orchestration1"].Ports["InboundPort_1"].ReceivePort = catalog.ReceivePorts["ReceivePort_1"];

				// Commit the changes
				catalog.SaveChanges();
			}
			catch (Exception e)
			{
				catalog.DiscardChanges();
				throw e;
			}
		}

		public void EnlistOrchestration()
		{
			// Create the root object and set the connection string
			BtsCatalogExplorer catalog = new BtsCatalogExplorer();
			catalog.ConnectionString = "SERVER=.;DATABASE=BizTalkMgmtDb;Integrated Security=SSPI";

			try
			{
				BtsOrchestrationCollection orchestrations = catalog.Assemblies[0].Orchestrations;
				// Set the orchestration status to enlisted
				orchestrations["BizTalkProject.Orchestration1"].Status = OrchestrationStatus.Enlisted;
				// Commit the changes
				catalog.SaveChanges();
			}
			catch (Exception e)
			{
				catalog.DiscardChanges();
				throw e;
			}
		}

		public void StartOrchestration()
		{
			// Create the root object and set the connection string
			BtsCatalogExplorer catalog = new BtsCatalogExplorer();
			catalog.ConnectionString = "SERVER=.;DATABASE=BizTalkMgmtDb;Integrated Security=SSPI";

			try
			{
				BtsOrchestrationCollection orchestrations = catalog.Assemblies[0].Orchestrations;
				// Set the orchestration status to started
				orchestrations["BizTalkProject.Orchestration1"].Status = OrchestrationStatus.Started;
				// Commit the changes
				catalog.SaveChanges();
			}
			catch (Exception e)
			{
				catalog.DiscardChanges();
				throw e;
			}
		}

		public void StopOrchestration()
		{
			// Create the root object and set the connection string
			BtsCatalogExplorer catalog = new BtsCatalogExplorer();
			catalog.ConnectionString = "SERVER=.;DATABASE=BizTalkMgmtDb;Integrated Security=SSPI";

			try
			{
				BtsOrchestrationCollection orchestrations = catalog.Assemblies[0].Orchestrations;
				// set the orchestration status to enlisted
				orchestrations["BizTalkProject.Orchestration1"].Status = OrchestrationStatus.Enlisted;
				// commit the changes
				catalog.SaveChanges();
			}
			catch (Exception e)
			{
				catalog.DiscardChanges();
				throw e;
			}
		}

		public void UnenlistOrchestration()
		{
			// Create the root object and set the connection string
			BtsCatalogExplorer catalog = new BtsCatalogExplorer();
			catalog.ConnectionString = "SERVER=.;DATABASE=BizTalkMgmtDb;Integrated Security=SSPI";

			try
			{
				BtsOrchestrationCollection orchestrations = catalog.Assemblies[0].Orchestrations;
				// Set the orchestration status to Unenlisted
				orchestrations["BizTalkProject.Orchestration1"].Status = OrchestrationStatus.Unenlisted;
				// Commit the changes
				catalog.SaveChanges();
			}
			catch (Exception e)
			{
				catalog.DiscardChanges();
				throw e;
			}
		}

	}
}
