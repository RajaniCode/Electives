//===============================================================================
// Filename:	EmployeeList.aspx.cs
// Author:		
// Date:		
// Purpose:		This file contains the codebehind logic for the EmployeeList.spx
//===============================================================================

#region namespaces
/// <summary>
/// Declare all the NameSpaces to be referenced
///</summary>
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
#endregion namespaces

namespace ConcurrencyADONet1
{
	#region EmployeeList Class
	/// <summary>
	/// Summary description for EmployeeList.
	/// <remarks name="EmployeeList" classtype="Public" inherits="System.Web.UI.Page">
	/// </remarks>
	/// </summary>
	public class EmployeeList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid grdEmployees;
		protected ConcurrencyADONet1.dsEmployee oDsAllEmployees;
	
		#region EmployeeList - Events and Handlers
		/// <summary>
		/// This method fires when the page loads
		/// </summary>
		/// <remarks name="Page_Load" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Clear the Session value for the selected EmployeeID
			Session["EmployeeID"] = "";
			// Create an instance of the Employee object
			Employee oEmp = new Employee();
			// Retrieve the employees into a dsEmployee DataSet 
			oDsAllEmployees = oEmp.GetEmployee();
			// Bind the employee dataset to the datagrid
			grdEmployees.DataBind();
		}

		/// <summary>
		/// This method fires when a row is selected
		/// </summary>
		/// <remarks name="grdEmployees_SelectedIndexChanged" classtype="oublic">
		/// </remarks>
		/// <returns type="void"></returns>
		public void grdEmployees_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Retrieve the selected EmployeeID from the DataGrid and store it in the session
			Session["EmployeeID"] = grdEmployees.DataKeys[grdEmployees.SelectedIndex];
			// Redirect to the EmployeeEdit.aspx to edit the employee record
			Response.Redirect("EmployeeEdit.aspx");
		}
		#endregion EmployeeList - Events and Handlers

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
			this.oDsAllEmployees = new ConcurrencyADONet1.dsEmployee();
			((System.ComponentModel.ISupportInitialize)(this.oDsAllEmployees)).BeginInit();
			// 
			// oDsAllEmployees
			// 
			this.oDsAllEmployees.DataSetName = "oDsAllEmployees";
			this.oDsAllEmployees.Locale = new System.Globalization.CultureInfo("en-US");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.oDsAllEmployees)).EndInit();

		}
		#endregion

	}
	#endregion EmployeeList Class
}
