#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.BizTalk.ExplorerOM;

#endregion

namespace CBR
{
	class ContentBasedRouting
	{
		static void Main(string[] args)
		{
			// connect to the local BizTalk Configuration database
			BtsCatalogExplorer catalog = new BtsCatalogExplorer();
			catalog.ConnectionString = "Server=.;Initial Catalog=BizTalkMgmtDb;Integrated Security=SSPI;";

			try
			{
				//***************************************************
				// create Sendport for processing US orders          
				//***************************************************
				SendPort sendportUSOrders = catalog.AddNewSendPort(false, false);
				sendportUSOrders.Name = "sendportUSOrders";
				sendportUSOrders.PrimaryTransport.TransportType = catalog.ProtocolTypes[0];
				sendportUSOrders.PrimaryTransport.Address = "http://process_orders_US.asp";
				sendportUSOrders.SendPipeline = catalog.Pipelines["Microsoft.BizTalk.DefaultPipelines:3.0.1.0:Microsoft.BizTalk.DefaultPipelines.XMLTransmit"];

				// specify filter for content-based routing of US orders
				sendportUSOrders.Filter =
					"<Filter><Group>" +
					"<Statement Property='BTS.ReceivePortName' Operator='0' Value='ReceivePortPO'/>" +
					"<Statement Property='CBRSample.CountryCode' Operator='0' Value='US'/>" +
					"</Group></Filter>";

				// enumerate all transforms and add a transform map that can normalize documents for US orders
				foreach (Transform transform in catalog.Transforms)
				{
					if (transform.SourceSchema.FullName == "CBRSample.POSchema" &&
					   transform.TargetSchema.FullName == "CBRSample.POSchemaUS")
					{
						sendportUSOrders.OutboundTransforms.Add(catalog.Transforms);
						break;
					}
				}

				// enlist and start the send port
				sendportUSOrders.Status = PortStatus.Started;

				//***************************************************
				// create Sendport for processing CAN orders         
				//***************************************************
				SendPort sendportCANOrders = catalog.AddNewSendPort(false, false);
				sendportCANOrders.Name = "sendportCANOrders";
				sendportCANOrders.PrimaryTransport.TransportType = catalog.ProtocolTypes[0];
				sendportCANOrders.PrimaryTransport.Address = "http://process_orders_CAN.asp";
				sendportCANOrders.SendPipeline = catalog.Pipelines["Microsoft.BizTalk.DefaultPipelines:3.0.1.0:Microsoft.BizTalk.DefaultPipelines.XMLTransmit"];

				// specify filter for content-based routing of CAN orders
				sendportCANOrders.Filter =
					"<Filter><Group>" +
					"<Statement Property='BTS.ReceivePortName' Operator='0' Value='ReceivePortPO'/>" +
					"<Statement Property='CBRSample.CountryCode' Operator='0' Value='CAN'/>" +
					"</Group></Filter>";

				// add a specific transform map to normalize documents for CAN orders
				Transform map = catalog.Transforms["CBRSample.POtoCANmap"];
				if (map != null)
					sendportCANOrders.OutboundTransforms.Add(map);

				// enlist and start the send port
				sendportCANOrders.Status = PortStatus.Started;

				// persist changes to BizTalk Configuration database
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
