using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Net;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Configuration;
using System.Web.Configuration;
using System.IO;

namespace WISpawner
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WISpawnerService : System.Web.Services.WebService
    {
       [SoapDocumentMethod(Action="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify",RequestNamespace="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03")]
       [WebMethod(MessageName="Notify")]
        public void Notify(string eventXml, string tfsIdentityXml)
        {
            //StreamWriter sw = new StreamWriter(@"C:\Documents and Settings\TfsSetup\My Documents\eventException.txt");
            //sw.WriteLine("Error file init");
            XmlDocument eventDoc = new XmlDocument();
            eventDoc.LoadXml(eventXml);
            
                try
                {
                    XmlNode node1 = eventDoc.DocumentElement.SelectSingleNode("//StringFields/Field[Name='Work Item Type']/NewValue");
                    XmlNode node2 = eventDoc.DocumentElement.SelectSingleNode("//IntegerFields/Field[Name='ID']/OldValue");
                    if (node1.InnerText == "User Story" && Int32.Parse(node2.InnerText) == 0)
                    {
                        //eventDoc.Save(@"C:\Documents and Settings\TfsSetup\My Documents\eventXml.xml");
                        List<String> tasks = ReadTasks();
                        //sw.WriteLine(tasks.Count + " Tasks read");
                        //NetworkCredential credentials = new NetworkCredential();
                        //credentials.Domain = "To-Intra";
                        //credentials.UserName = "TfsSetup";
                        //credentials.Password = "11447@HAL";
                        
                        TeamFoundationServer tfs = TeamFoundationServerFactory.GetServer("http://to-intra:8080/Tfs/DefaultCollection");
                        //sw.WriteLine("Cred created" + tfs.Name);
                        WorkItemStore WIStore = new WorkItemStore(tfs);
                        //WorkItemStore WIStore = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));
                        //sw.WriteLine("WISt created");
                        //sw.WriteLine(WIStore.ToString());
                        //sw.WriteLine(WIStore.Projects.Count);
                        //sw.WriteLine(WIStore.Projects[0].Name);
                        //sw.WriteLine(WIStore.Projects[1].Name);
                        WorkItemTypeCollection WITCollection = WIStore.Projects["Marketing Management"].WorkItemTypes;
                        //sw.WriteLine(WITCollection.Count + " WorkItemTypes read");
                        foreach (string task in tasks)
                        {
                            WorkItem wi = new WorkItem(WITCollection["Task"]);
                            wi.Title = eventDoc.DocumentElement.SelectSingleNode("//StringFields/Field[Name='Title']/NewValue").InnerText + task;
                            //sw.WriteLine(wi.Title + " read");
                            wi.Fields["System.AssignedTo"].Value = eventDoc.DocumentElement.SelectSingleNode("//StringFields/Field[Name='Assigned To']/NewValue").InnerText;
                            //sw.WriteLine("WorkItem Assigned to " + wi.Fields["System.AssignedTo"].Value.ToString());
                            WorkItemLinkTypeEnd linkTypeEnd = WIStore.WorkItemLinkTypes.LinkTypeEnds["Parent"];
                            wi.Links.Add(new RelatedLink(linkTypeEnd, Int32.Parse(eventDoc.DocumentElement.SelectSingleNode("//IntegerFields/Field[Name='ID']/NewValue").InnerText)));
                            wi.Save();
                            //sw.WriteLine("WorkItem saved");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //sw.WriteLine(ex.Message + ex.InnerException.Message);
                    //sw.Flush();
                    //sw.Close();
                }
       }
       private List<string> ReadTasks()
       {
           List<string> tasks = new List<string>();
           Configuration appSettingsRoot = WebConfigurationManager.OpenWebConfiguration(null);
           if (0 < appSettingsRoot.AppSettings.Settings.Count)
           {
               tasks.Add("Architect Solution");
               tasks.Add("Develop Solution");
               tasks.Add("Test Solution");
               tasks.Add("Deploy Solution");
           }
           else
           {
               tasks.Add(ConfigurationManager.AppSettings.Get("ArchTask"));
               tasks.Add(ConfigurationManager.AppSettings.Get("DevTask"));
               tasks.Add(ConfigurationManager.AppSettings.Get("TestTask"));
               tasks.Add(ConfigurationManager.AppSettings.Get("DeployTask"));
           }
           return tasks;
       }
    }
}