using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Diagnostics;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.IO;

namespace SimpleSubscriber
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [SoapDocumentMethod(Action = "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify", RequestNamespace = "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03")]
        [WebMethod(MessageName = "Notify")]
        public void Notify(string eventXml, string tfsIdentityXml)
        {
            if (!EventLog.SourceExists("TfsSource"))
                EventLog.CreateEventSource("TfsSource", "TfsLogs");
            EventLog ThisLog = new EventLog();
            ThisLog.Source = "TfsSource";
            try
            {
                XmlDocument eventDoc = new XmlDocument();
                eventDoc.LoadXml(eventXml);
                //eventDoc.Load(@"C:\Documents and Settings\TfsSetup\My Documents\eventXml.xml");
                eventDoc.Save(@"D:\XmlText\eventXml.xml");
            
                XmlNode node1 = eventDoc.DocumentElement.SelectSingleNode("//StringFields/Field[Name='Work Item Type']/NewValue");
                XmlNode node2 = eventDoc.DocumentElement.SelectSingleNode("//StringFields/Field[Name='State']/NewValue");
                //ThisLog.WriteEntry("Node1: " + node1.InnerText + " Node2: " + node2.InnerText);
                if (node1.InnerText == "Task" && node2.InnerText == "Closed")
                {
                    TeamFoundationServer tfs = TeamFoundationServerFactory.GetServer("http://to-intra:8080/Tfs/DefaultCollection");
                    WorkItemStore WIStore = new WorkItemStore(tfs);
                    WorkItem ClosingTask = WIStore.GetWorkItem(Int32.Parse(eventDoc.DocumentElement.SelectSingleNode("//IntegerFields/Field[Name='ID']/OldValue").InnerText));
                    WorkItemLinkCollection AllLinksToClosingTask = ClosingTask.WorkItemLinks;
                    //ThisLog.WriteEntry("Links: " + AllLinksToClosingTask.Count.ToString());
                    WorkItemLink ParentLink = null;
                    foreach (WorkItemLink link in AllLinksToClosingTask)
                    {
                        if (link.LinkTypeEnd.Name == "Parent")
                        {
                            ParentLink = link;
                            //ThisLog.WriteEntry(ParentLink.TargetId.ToString());
                            break;
                        }
                    }
                    WorkItem Parent = WIStore.GetWorkItem(ParentLink.TargetId);
                    WorkItemLinkCollection AllLinksToParent = Parent.WorkItemLinks;
                    //ThisLog.WriteEntry(AllLinksToParent.Count.ToString());
                    bool AllChildrenWorkItemsClosed = true;
                    foreach (WorkItemLink child in AllLinksToParent)
                    {
                        if (WIStore.GetWorkItem(child.TargetId).State != "Closed")
                            AllChildrenWorkItemsClosed = false;
                    }
                    //ThisLog.WriteEntry(AllChildrenWorkItemsClosed.ToString());
                    if (AllChildrenWorkItemsClosed)
                    {
                        Parent.State = "Resolved";
                        Parent.Save();
                    }
                }
                else if (node1.InnerText == "User Story" && node2.InnerText == "Closed")
                {
                    TeamFoundationServer tfs = TeamFoundationServerFactory.GetServer("http://to-intra:8080/Tfs/DefaultCollection");
                    WorkItemStore WIStore = new WorkItemStore(tfs);
                    WorkItem ClosingStory = WIStore.GetWorkItem(Int32.Parse(eventDoc.DocumentElement.SelectSingleNode("//IntegerFields/Field[Name='ID']/OldValue").InnerText));
                    WorkItemLinkCollection AllLinksToClosingStory = ClosingStory.WorkItemLinks;
                    foreach (WorkItemLink link in AllLinksToClosingStory)
                    {
                        WorkItem RelatedTask = WIStore.GetWorkItem(link.TargetId);
                        RelatedTask.State = "Closed";
                        RelatedTask.Save();
                    }

                }
            }
            catch (Exception ex)
            {
                ThisLog.WriteEntry(ex.Message + ex.InnerException.Message);
            }
        }
    }
}
