using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine ; 
using CrystalDecisions.Shared;

 
namespace MyReport
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class MyReport : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			// 1. Load report file
				String reportFile=Request.QueryString.Get("Report") +".rpt";
				String appPath=MapPath(".");
				String reportPath = appPath + "\\" + reportFile;
				ReportDocument theReport=new ReportDocument();
				theReport.Load (reportPath);

				//2. set logon info 
				CrystalDecisions.Shared.ConnectionInfo conn= new ConnectionInfo() ; 
				CrystalDecisions.CrystalReports.Engine.Table myTable; 
				CrystalDecisions.Shared.TableLogOnInfo  myLog;
				conn.ServerName ="My-SQL-Server";
				conn.DatabaseName ="pubs";
				conn.UserID ="sa";
				conn.Password ="password";

				for (int i=0;i<theReport.Database.Tables.Count;i++)
				{
						myTable=theReport.Database.Tables[i];			
						myLog = myTable.LogOnInfo;
						myLog.ConnectionInfo = conn;
						myTable.ApplyLogOnInfo(myLog);
						myTable.Location = myLog.TableName;
				}
				// In case there are subreports in report file

				for (int i=0;i<theReport.ReportDefinition.ReportObjects.Count-1;i++)

				{
						CrystalDecisions.CrystalReports.Engine.ReportObject rpt;
						rpt=theReport.ReportDefinition.ReportObjects [i];
						if (rpt.Kind==CrystalDecisions.Shared.ReportObjectKind.SubreportObject)
						{
								CrystalDecisions.CrystalReports.Engine.SubreportObject subrpt=(SubreportObject)rpt;
								CrystalDecisions.CrystalReports.Engine.ReportDocument r=theReport.OpenSubreport (subrpt.SubreportName  );
								for (int j=0;j<r.Database.Tables.Count -1;j++)
								{
										myTable=r.Database.Tables [j];
										myLog=myTable.LogOnInfo ;
										myTable.ApplyLogOnInfo(myLog);
										myTable.Location=myLog.TableName ;
								}
						}  
										 
				}
				
				// 3. process paramters received from URL and pass them to report file
				
				String paramName,paramValue;
				CrystalDecisions.Shared.ParameterValues pList = new  ParameterValues();
						CrystalDecisions.Shared.ParameterDiscreteValue pV=new ParameterDiscreteValue ();
				for( int i=0;i<theReport.DataDefinition.ParameterFields.Count;i++)
				{
						paramName=theReport.DataDefinition.ParameterFields[i].Name;
						paramValue=Request.QueryString.Get(paramName); 
						pV.Value =paramValue;
						pList.Add(pV);
						theReport.DataDefinition.ParameterFields[paramName].ApplyCurrentValues(pList);
				}	
				
				// 4.  export report to PDF file and write back to client browser
				System.IO.MemoryStream  m;
				m=(System.IO.MemoryStream)theReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat );
				theReport.Close ();
				this.Response.ClearContent();
				this.Response.ClearHeaders(); 
				this.Response.AddHeader("Title", reportPath); 
				this.Response.ContentType="Application/pdf";
				this.Response.Buffer=true;
				this.Response.BinaryWrite (m.ToArray());	
				this.Response.End ();	        
	
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
