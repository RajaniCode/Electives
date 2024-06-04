//---------------------------------------------------------------------
// This file is part of the Microsoft BizTalk Server 2006 SDK
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft BizTalk
// Server 2006 release and/or on-line documentation. See these other
// materials for detailed information regarding Microsoft code samples.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
// PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Xml;
using System.Collections;
using Microsoft.Samples.BizTalk.UtilObjects;
using Microsoft.Samples.BizTalk.UtilObjects.HwsWebService;
using System.Diagnostics;
using System.IO;
using System.Web.Mail;
using System.Runtime.Serialization;

namespace Microsoft.Samples.BizTalk.UtilObjects
{
	[Serializable()]
	public class HwsBreakReminderLoopException : Exception
	{
		public HwsBreakReminderLoopException():
			base()
		{
		}
		
		protected HwsBreakReminderLoopException(SerializationInfo info, StreamingContext context): 
			base(info, context) 
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info==null) 
				throw new ArgumentNullException("info");
			base.GetObjectData(info, context);
		}
	}

	[Serializable]
	public class BaseObj
	{ 
		public void LogMessage(string msg)
		{
			// Not implemented for the sample
		}
	}

	[Serializable]
	public class BaseTaskMgr : BaseObj
	{
		public BaseTaskMgr()
		{
			m_tasks = new ArrayList();
			NameTable nameTable = new NameTable();
			m_nsmgrActivation = new XmlNamespaceManager(nameTable);
			m_nsmgrActivation.AddNamespace("hws","http://schemas.microsoft.com/Hws/2003");
			m_nsmgrActivation.AddNamespace("xs","http://www.w3c.org/2001/XMLSchema");
			
			NameTable nameTable2 = new NameTable();
			m_nsmgrResponse = new XmlNamespaceManager(nameTable2);
			m_nsmgrResponse.AddNamespace("hws","http://schemas.microsoft.com/Hws/2003");
			m_nsmgrResponse.AddNamespace("xs","http://www.w3c.org/2001/XMLSchema");
            m_nsmgrResponse.AddNamespace("ns0", "http://tempuri.org/Hws_Task_Message");
            m_hwss = new HwsService();
		}
        
		public Task CreateTask()
		{
			Task retVal = new Task();
			retVal.m_status = (int) TaskStatus.Waiting;
			retVal.m_id = System.Guid.NewGuid().ToString();
			return retVal;
		}

		public virtual void SendReminderEmail()
		{
			// This method loops through all unfinished tasks and check elapsed time against 
			// reminder interval.  If Elapsed time > reminder interval then an reminder email
			// is sent out.  This functionality is omitted in this version of the SDK sample. 
		}

		public virtual void SendSummaryEmail()
		{
			// This method send out an email at the end of the Action
			// to report the execution summary.
			//  This functionality is omitted in this version of the SDK sample. 
		}

		public virtual Task GetTaskByIndex(int i) 
		{
			return (Task) m_tasks[i];
		}
		
		public virtual Task GetTaskById(string taskId)
		{
			Task retVal = null;
			foreach(Task task in m_tasks) // Could use a map - but since this is not frequent, liner search would do	
			{   
				System.Guid x = new Guid(task.m_id);
				System.Guid y = new Guid(taskId);
				if(x.CompareTo(y) == 0)
					retVal = task;
			}
			return retVal;
		}
	
		public virtual void ProcessResponseMessage(XmlDocument responseMessage)
		{
			int newStatus = 0;
			XmlNode bizActionSection = responseMessage.SelectSingleNode("/ns0:HwsMessage/ActionSection", m_nsmgrResponse);
			XmlNode taskIdNode = responseMessage.SelectSingleNode("/ns0:HwsMessage/HwsSection/TaskID", m_nsmgrResponse);
			if(bizActionSection == null)
				return;  // Error.  Message ignored
			XmlNode newStatusNode = responseMessage.SelectSingleNode("/ns0:HwsMessage/HwsSection/TaskStatus", m_nsmgrResponse);
			string taskId = "";
			if(taskIdNode != null)
			    taskId = taskIdNode.InnerText;
			Task task = GetTaskById(taskId);
			if(task == null)
				return;  // Error. Message ignored
			if(newStatusNode != null)
			{
				if(newStatusNode.InnerText != "")
				{
					newStatus = (int) Enum.Parse(typeof(TaskStatus), newStatusNode.InnerText);
					task.m_status = newStatus;
				}
			}
		}

		public virtual int WaitForMoreResponses
		{
			get{return 0;}
		}

		public void SendEmail(Task task)
		{
			// This method send various emails such as task notification.  
			// The method implementation is omitted for this version of the SDK sample.
		}

		public virtual int NumOfTasks
		{
			get{return m_tasks.Count;}
		}

		protected void OnDeserialization() 
		{
			NameTable nameTable = new NameTable();
			m_nsmgrActivation = new XmlNamespaceManager(nameTable);
			m_nsmgrActivation.AddNamespace("hws","http://schemas.microsoft.com/Hws/2003");
			m_nsmgrActivation.AddNamespace("xs","http://www.w3c.org/2001/XMLSchema");
			
			NameTable nameTable2 = new NameTable();
			m_nsmgrResponse = new XmlNamespaceManager(nameTable2);
			m_nsmgrResponse.AddNamespace("hws","http://schemas.microsoft.com/Hws/2003");
			m_nsmgrResponse.AddNamespace("xs","http://www.w3c.org/2001/XMLSchema");
			m_nsmgrResponse.AddNamespace("ns0", "http://tempuri.org/Hws_Task_Message");
            m_hwss = new HwsService();
		}

		protected ArrayList m_tasks;
		[NonSerialized()] protected XmlNamespaceManager m_nsmgrActivation;
		[NonSerialized()] protected XmlNamespaceManager m_nsmgrResponse;
		[NonSerialized()]protected HwsService m_hwss;
        protected string m_activationMessageSerialized;
		protected string m_webServiceUrl;
	}

	[Serializable]
	public class AssignTaskMgr : BaseTaskMgr, IDeserializationCallback
	{
		public AssignTaskMgr(XmlDocument activationMessage, XmlDocument shellTaskMessage)
		{
			m_nsmgrActivation.AddNamespace("ns0", "http://tempuri.org/Hws_AssignTask_Activate");
			Init(activationMessage, shellTaskMessage);
			LogMessage("AssignTaskMgr Created.");
		}

		public void Init(XmlDocument activation, XmlDocument shellTaskMessage)
		{
			m_activationMessageSerialized = activation.OuterXml;
			Task taskTemp;
			XmlNodeList taskList = activation.SelectNodes("/ns0:HwsMessage/ActionSection/Task", m_nsmgrActivation);
			if(taskList == null)
			{
				LogMessage("Action section missing in activation message.  No task generated.");
				return;
			}
			foreach (XmlNode task in taskList)
			{
				XmlNode taskWithSingleTarget = task.Clone();
				XmlNodeList targetList = taskWithSingleTarget.SelectNodes("./Target");
				int count = 0;
				foreach(XmlNode x in targetList)
				{
					if(count != 0)
						taskWithSingleTarget.RemoveChild(x);
					count ++;
				}
				foreach(XmlNode y in targetList)
				{
					taskTemp = CreateTask();
					taskTemp.TaskMessage = shellTaskMessage;
					taskWithSingleTarget.SelectSingleNode("./Target").InnerText = y.InnerText;
					taskTemp.SetTaskInTaskMessage(taskWithSingleTarget);		
					m_tasks.Add(taskTemp);
					XmlDocument tm = taskTemp.TaskMessage;
					taskTemp.AddActionProperties(tm.SelectSingleNode("/ns0:HwsMessage/ActionSection/Task/Name", taskTemp.m_nsmgr).InnerText, "Title");
					taskTemp.AddActionProperties(tm.SelectSingleNode("/ns0:HwsMessage/ActionSection/Task/Description", taskTemp.m_nsmgr).InnerText, "Description");
					taskTemp.AddActionProperties(tm.SelectSingleNode("/ns0:HwsMessage/ActionSection/Task/Deadline", taskTemp.m_nsmgr).InnerText, "Deadline");
					taskTemp.AddActionProperties(tm.SelectSingleNode("/ns0:HwsMessage/ActionSection/Task/Priority", taskTemp.m_nsmgr).InnerText, "Priority");
					taskTemp.AddActionProperties(tm.SelectSingleNode("/ns0:HwsMessage/HwsSection/ActionTypeID", taskTemp.m_nsmgr).InnerText, "ActionTypeID");
					SendEmail(taskTemp);
				}
			}
		}

		public XmlDocument GetSyncMsgInstance(XmlDocument activationMsg)
		{
			XmlDocument syncMsg = new XmlDocument();
			syncMsg.LoadXml("<ns0:HwsMessage xmlns:ns0=\"http://tempuri.org/Hws_Synchronize\"><HwsSection HwsMessageType=\"Hws_Synchronize\"><ActivityFlowID /><ActionInstanceID /><ActivityModelInstanceID /><HwsWebServiceUrl /></HwsSection><ActionSection /><Payloads><Payload ID=\"ID\"><any0/></Payload></Payloads></ns0:HwsMessage>");
			syncMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActivityFlowID']").InnerText 
				= activationMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActivityFlowID']").InnerText;
			syncMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActionInstanceID']").InnerText 
				= activationMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActionInstanceID']").InnerText;
			syncMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActivityModelInstanceID']").InnerText 
				= activationMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActivityModelInstanceID']").InnerText;
			syncMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='HwsWebServiceUrl']").InnerText 
				= activationMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='HwsWebServiceUrl']").InnerText;
			return syncMsg; 
		}

		override public int WaitForMoreResponses
		{
			get
			{
				int numOfUnfinishedRequiredTasks = 0, finished = 0, retVal = 0;
				foreach(Task task in m_tasks)
				{
					if(task.m_status != (int) TaskStatus.Completed 
                        && task.m_status != (int)TaskStatus.Cancelled 
						&& task.m_status != (int) TaskStatus.Declined)
					{
						numOfUnfinishedRequiredTasks ++;
					}
					else
					   finished ++;
				}
				if(!(numOfUnfinishedRequiredTasks == 0))
				{
					 retVal = 1;
				}
                LogMessage("AssignTaskMgr.WaitForMoreResponses returned " + retVal.ToString());
				return retVal;
			}
		}
		void IDeserializationCallback.OnDeserialization(Object sender) 
		{
			base.OnDeserialization();
			m_nsmgrActivation.AddNamespace("ns0", "http://tempuri.org/Hws_AssignTask_Activate");
		}
	}

	[Serializable]
	public class DelegateTaskMgr : BaseTaskMgr, IDeserializationCallback
	{
		public DelegateTaskMgr(XmlDocument activationMessage, XmlDocument shellTaskMessage)
		{
		    m_nsmgrActivation.AddNamespace("ns0", "http://tempuri.org/Hws_DelegateTask_Activate");
			Init(activationMessage, shellTaskMessage);
	        LogMessage("DelegateTaskMgr Created.");
		}

		public XmlDocument ConstructOutGoingTaskMessage(XmlDocument msg)
		{
			return msg;
		}
		public void Init(XmlDocument activation, XmlDocument shellTaskMessage)
		{
			m_activationMessageSerialized = activation.OuterXml;
			Task taskTemp;
            XmlNode bizActionSection = activation.SelectSingleNode("/ns0:HwsMessage/ActionSection", m_nsmgrActivation);
			XmlNode webServiceUrl = activation.SelectSingleNode("/ns0:HwsMessage/HwsSection/HwsWebServiceUrl", m_nsmgrActivation);

			if(bizActionSection == null)
			{
				LogMessage("Action section missing in activation message.  No task generated.");
				return;
			}
			XmlNode taskIdNode = bizActionSection.SelectSingleNode("./TaskId", m_nsmgrActivation);
			XmlNode newTargetNode = bizActionSection.SelectSingleNode("./NewTarget", m_nsmgrActivation);
			XmlNode newCommentNode = bizActionSection.SelectSingleNode("./ReasonForDelegate", m_nsmgrActivation);

			taskTemp = CreateTask();
			taskTemp.TaskMessage = shellTaskMessage;  // default value
			XmlDocument retrievedTaskMessage = new XmlDocument();
            m_hwss.Credentials = System.Net.CredentialCache.DefaultCredentials;
			try
			{
				if(webServiceUrl != null)
				{
					m_webServiceUrl = webServiceUrl.InnerText;
					m_hwss.Url = m_webServiceUrl; 
				}

				string taskMessageText = m_hwss.GetTaskMessage(new Guid(taskIdNode.InnerText), activation.SelectSingleNode("/ns0:HwsMessage/HwsSection/InitiatingActor", m_nsmgrActivation).InnerText);	
			    if(taskMessageText != null)
				{
					retrievedTaskMessage.LoadXml(taskMessageText);
					XmlNode originalTaskNode = retrievedTaskMessage.SelectSingleNode("/ns0:HwsMessage/ActionSection/Task",taskTemp.m_nsmgr);
					taskTemp.SetTaskInTaskMessage(originalTaskNode);
				}
			}
			catch(Exception e)
			{
                LogMessage("Web service call RetrieveBizTaskMessage failed.  See event log for more details. Task details not retrieved.");
				LogMessage("Exception: " + e.ToString());
				string passedInTaskMessageString = GetAdditionalParametersByName("TaskInfo", activation);
				if(passedInTaskMessageString != "")
				{
					XmlDocument passedInTaskMessage = new XmlDocument();
					passedInTaskMessage.LoadXml(passedInTaskMessageString);
					XmlNode passedInTaskNode = passedInTaskMessage.SelectSingleNode("//ns0:HwsMessage/ActionSection/Task", m_nsmgrResponse);
					taskTemp.SetTaskInTaskMessage(passedInTaskNode);
				}
			}
		    if(newTargetNode !=null)
			{
				string newTarget = newTargetNode.InnerText;
				taskTemp.m_target = newTarget;
			}
			m_tasks.Add(taskTemp);
            XmlDocument tm = taskTemp.TaskMessage;
			taskTemp.AddActionProperties(tm.SelectSingleNode("/ns0:HwsMessage/ActionSection/Task/Name", taskTemp.m_nsmgr).InnerText, "Title");
			taskTemp.AddActionProperties(tm.SelectSingleNode("/ns0:HwsMessage/ActionSection/Task/Description", taskTemp.m_nsmgr).InnerText, "Description");
			taskTemp.AddActionProperties(tm.SelectSingleNode("/ns0:HwsMessage/ActionSection/Task/Deadline", taskTemp.m_nsmgr).InnerText, "Deadline");
			taskTemp.AddActionProperties(tm.SelectSingleNode("/ns0:HwsMessage/ActionSection/Task/Priority", taskTemp.m_nsmgr).InnerText, "Priority");
			taskTemp.AddActionProperties(tm.SelectSingleNode("/ns0:HwsMessage/HwsSection/ActionTypeID", taskTemp.m_nsmgr).InnerText, "ActionTypeID");
		    taskTemp.FillReassignment(taskIdNode.InnerText, activation.SelectSingleNode("/ns0:HwsMessage/HwsSection/InitiatingActor", m_nsmgrActivation).InnerText);
			SendEmail(taskTemp);
		}

		public XmlDocument GetSyncMsgInstance(XmlDocument activationMsg)
		{
			XmlDocument syncMsg = new XmlDocument();
			syncMsg.LoadXml("<ns0:HwsMessage xmlns:ns0=\"http://tempuri.org/Hws_Synchronize\"><HwsSection HwsMessageType=\"Hws_Synchronize\"><ActivityFlowID /><ActionInstanceID /><ActivityModelInstanceID /><HwsWebServiceUrl /></HwsSection><ActionSection /><Payloads><Payload ID=\"ID\"><any0/></Payload></Payloads></ns0:HwsMessage>");
			syncMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActivityFlowID']").InnerText 
				= activationMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActivityFlowID']").InnerText;
			syncMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActionInstanceID']").InnerText 
				= activationMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActionInstanceID']").InnerText;
			syncMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActivityModelInstanceID']").InnerText 
				= activationMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='ActivityModelInstanceID']").InnerText;
			syncMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='HwsWebServiceUrl']").InnerText 
				= activationMsg.SelectSingleNode("//*[local-name()='HwsMessage']/*[local-name()='HwsSection']/*[local-name()='HwsWebServiceUrl']").InnerText;
			return syncMsg; 
		}

		public string GetAdditionalParametersByName(string name, XmlDocument activation)  // Assumes string value
		{
			XmlNodeList additionalParam = activation.SelectNodes("/ns0:HwsMessage/ActionSection/AdditionalActionParameters", m_nsmgrActivation);
			foreach(XmlNode param in additionalParam)
			{
				if(param.SelectSingleNode("Name").InnerText == name)
				   return param.SelectSingleNode("StringVal").InnerText;
			}
			return null;
		}

		override public void ProcessResponseMessage(XmlDocument responseMessage)
		{
			base.ProcessResponseMessage(responseMessage);
			XmlDocument outGoingResponseMessage = ConstructOutGoingResponseMessage(responseMessage);
			string targetUserID = outGoingResponseMessage.SelectSingleNode("/ns0:HwsMessage/HwsSection/TargetActor", m_nsmgrResponse).InnerText;
			m_hwss.Credentials = System.Net.CredentialCache.DefaultCredentials;
			if(m_webServiceUrl != null)
				m_hwss.Url = m_webServiceUrl; 
			try
			{
				m_hwss.SendTaskResponse(outGoingResponseMessage.OuterXml, targetUserID);
			}
			catch(Exception e)
			{
				LogMessage("Web service call SendTaskresponse failed.  See event log for more details. Task details not retrieved.");
				LogMessage("Exception: " + e.ToString());
			}
		}
 
		override public int WaitForMoreResponses
		{
			get
			{
				int numOfUnfinishedRequiredTask = 0;
				foreach(Task task in m_tasks)
				{
					if(task.m_status != (int) TaskStatus.Completed 
                        && task.m_status != (int) TaskStatus.Cancelled
						&& task.m_status != (int) TaskStatus.Declined)
					{
						numOfUnfinishedRequiredTask ++;
					}
				}
                LogMessage("DelegateTaskMgr.WaitForMoreResponses returned " + numOfUnfinishedRequiredTask.ToString());
				return numOfUnfinishedRequiredTask;
			}
		}

		public XmlDocument ConstructOutGoingResponseMessage(XmlDocument msg)
		{
			XmlDocument activation = new XmlDocument();
			activation.LoadXml(m_activationMessageSerialized);
			string prefix = @"/ns0:HwsMessage";
			try
			{
				msg.SelectSingleNode(prefix + "/HwsSection/TaskID", m_nsmgrResponse).InnerText = activation.SelectSingleNode(prefix + "/ActionSection/TaskId", m_nsmgrActivation).InnerText;
				msg.SelectSingleNode(prefix + "/HwsSection/ActionInstanceID", m_nsmgrResponse).InnerText = activation.SelectSingleNode(prefix + "/HwsSection/ParentActionInstanceID", m_nsmgrActivation).InnerText;
            }
			catch
			{
				LogMessage("Forwarding response message failed.");
			}
			return msg;
		}

		void IDeserializationCallback.OnDeserialization(Object sender) 
		{
			base.OnDeserialization();
			m_nsmgrActivation.AddNamespace("ns0", "http://tempuri.org/Hws_DelegateTask_Activate");
		}
	}

	[Serializable]
	public class Task : BaseObj, IDeserializationCallback
	{
		public Task()
		{
			NameTable nameTable = new NameTable();
			m_nsmgr = new XmlNamespaceManager(nameTable);
			m_nsmgr.AddNamespace("hws","http://schemas.microsoft.com/Hws/2003");
			m_nsmgr.AddNamespace("xs","http://www.w3c.org/2001/XMLSchema");
			m_nsmgr.AddNamespace("ns0", "http://tempuri.org/Hws_Task_Message");
			m_target = "";
			m_status = -1;
			m_id = "";
		}

		public void SetTaskInTaskMessage(XmlNode taskNode)
		{
			XmlNode localNode = taskNode.Clone();
			XmlDocument localRef = TaskMessage;
			XmlNode bizActionSection = localRef.SelectSingleNode("/ns0:HwsMessage/ActionSection",m_nsmgr);
			if(bizActionSection == null)
			{
				LogMessage("Action section is missing in taskMessage.  Task can't be set in the task message.");
				return;
			}
			XmlNode oldTaskNode = bizActionSection.SelectSingleNode("./Task",m_nsmgr);
			if(oldTaskNode != null)
				bizActionSection.RemoveChild(oldTaskNode);
			XmlNode newTaskNode = localRef.ImportNode(localNode, true);

			XmlNode field, field2;
			string[] targetXpath = new string[3];
			targetXpath[0] = "/ns0:HwsMessage/HwsSection/TaskDescription";
			targetXpath[1] = "/ns0:HwsMessage/HwsSection/TargetActor";
			targetXpath[2] = "/ns0:HwsMessage/HwsSection/ActorElementXPath";
			string[] sourceXpath = new string[3];
			sourceXpath[0] = "./Description";
			sourceXpath[1] = "./Target";
			sourceXpath[2] = "./Xpath";
			
			for(int i=0; i<2; i++)
			{
				field = localRef.SelectSingleNode(targetXpath[i], m_nsmgr);
				field2 = newTaskNode.SelectSingleNode(sourceXpath[i]);
				if(field != null && field2 != null)
					field.InnerText = field2.InnerText;
			}
			m_status = System.Convert.ToInt32(newTaskNode.SelectSingleNode("./Status").InnerText);
			m_target = localRef.SelectSingleNode(targetXpath[1], m_nsmgr).InnerText;
            m_initiator = localRef.SelectSingleNode("/ns0:HwsMessage/HwsSection/InitiatingActor", m_nsmgr).InnerText;
			bizActionSection.PrependChild(newTaskNode);
			TaskMessage = localRef;
		}
	
		public XmlDocument TaskMessage
		{
			get 
			{
				XmlDocument retVal = new XmlDocument();
				retVal.LoadXml(m_taskMessageSerialized);
				XmlNode taskNode = retVal.SelectSingleNode("/ns0:HwsMessage/ActionSection/Task",m_nsmgr);
				try  // Throw away exceptions - no-op if node doesn't exist
				{
					XmlNode taskIdNode = retVal.SelectSingleNode("/ns0:HwsMessage/HwsSection/TaskID", m_nsmgr);
					if( (taskIdNode != null) && (m_id != "") )
						taskIdNode.InnerText = m_id;
					if(m_target != "")
					{
						taskNode.SelectSingleNode("Target").InnerText = m_target;
						retVal.SelectSingleNode("/ns0:HwsMessage/HwsSection/TargetActor",m_nsmgr).InnerText = m_target;
					}
					if(m_status != -1)
					{
							taskNode.SelectSingleNode("Status").InnerText = m_status.ToString();
							retVal.SelectSingleNode("/ns0:HwsMessage/HwsSection/TaskStatus", m_nsmgr).InnerText = convertIntToEmunString(m_status);
					}
				}
				catch
				{
					LogMessage("Task section missing in TaskMessage.  Return task message as is.");
				};
			
				m_taskMessageSerialized = retVal.OuterXml;
				return retVal;
			}
			set 
			{
				m_taskMessageSerialized = value.OuterXml;
			}
		}

		public void AddActionProperties(string msg, string type)
		{
			XmlDocument newDoc = new XmlDocument();
			newDoc.LoadXml("<Property Name=\""  + type + "\" Description=\"Description_1\" Type=\"Type_2\"></Property>");
			XmlNode property = newDoc.SelectSingleNode("/Property");
			property.InnerText = msg;
			XmlDocument TaskMsg = TaskMessage;
			XmlNode taskProperties = TaskMsg.SelectSingleNode("//ns0:HwsMessage/HwsSection/TaskProperties", m_nsmgr);
			XmlNode newProperty = TaskMsg.ImportNode(property, true);
			taskProperties.AppendChild(newProperty);
			m_taskMessageSerialized = TaskMsg.OuterXml;
		}

		public void FillReassignment(string taskID, string originator)
		{
			XmlDocument TaskMsg = TaskMessage;
			XmlNode reassignment = TaskMsg.SelectSingleNode("//ns0:HwsMessage/HwsSection/Reassignment", m_nsmgr);
			reassignment.SelectSingleNode("./ReassignedByActor").InnerText = originator;
			reassignment.SelectSingleNode("./FromTaskID").InnerText = taskID;
			m_taskMessageSerialized = TaskMsg.OuterXml;
		}

		public string convertIntToEmunString(int x)
		{
		    return ((TaskStatus) x).ToString();
		}
		
		void IDeserializationCallback.OnDeserialization(Object sender) 
		{
			NameTable nameTable = new NameTable();
			m_nsmgr = new XmlNamespaceManager(nameTable);
			m_nsmgr.AddNamespace("hws","http://schemas.microsoft.com/Hws/2003");
			m_nsmgr.AddNamespace("xs","http://www.w3c.org/2001/XMLSchema");
			m_nsmgr.AddNamespace("ns0", "http://tempuri.org/Hws_Task_Message");
		}

		private string m_taskMessageSerialized;
		[NonSerialized()] public XmlNamespaceManager m_nsmgr;
		public int m_status;
		public string m_id;
		public string m_target;
		public string m_initiator;

	}
}
