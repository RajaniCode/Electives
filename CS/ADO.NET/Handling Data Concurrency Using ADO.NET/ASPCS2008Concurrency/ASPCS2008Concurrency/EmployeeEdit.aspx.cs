//===============================================================================
// Filename:	EmployeeEdit.aspx.cs
// Author:		
// Date:		
// Purpose:		This file contains the codebehind logic for the EmployeeEdit.spx
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
	#region EmployeeEdit Class
	/// <summary>
	/// Summary description for EmployeeEdit.
	/// <remarks name="EmployeeEdit" classtype="Public" inherits="System.Web.UI.Page">
	/// </remarks>
	/// </summary>
	public class EmployeeEdit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtTitle;
		protected System.Web.UI.WebControls.TextBox txtBirthDate;
		protected System.Web.UI.WebControls.TextBox txtHireDate;
		protected System.Web.UI.WebControls.TextBox txtExtension;
		protected System.Web.UI.WebControls.Label lblEmployeeID;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label lblFirstName_Original;
		protected System.Web.UI.WebControls.Label lblLastName_Original;
		protected System.Web.UI.WebControls.Label lblTitle_Original;
		protected System.Web.UI.WebControls.Label lblBirthDate_Original;
		protected System.Web.UI.WebControls.Label lblHireDate_Original;
		protected System.Web.UI.WebControls.Label lblExtension_Original;
		protected System.Web.UI.WebControls.Label lblFirstName_InDB;
		protected System.Web.UI.WebControls.Label lblLastName_InDB;
		protected System.Web.UI.WebControls.Label lblTitle_InDB;
		protected System.Web.UI.WebControls.Label lblBirthDate_InDB;
		protected System.Web.UI.WebControls.Label lblHireDate_InDB;
		protected System.Web.UI.WebControls.Label lblExtension_InDB;
		protected System.Web.UI.WebControls.Button btnGoBack;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblOriginalHeader;
		protected System.Web.UI.WebControls.Label lblInDBHeader;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblLastUpdateDateTime_Original;
		protected System.Web.UI.WebControls.Label lblLastUpdateDateTime_InDB;
		protected System.Web.UI.WebControls.Button btnReloadFromDB;
		protected System.Web.UI.WebControls.Button btnSaveAnyway;
		protected System.Web.UI.WebControls.Button btnCancelChanges;
		protected System.Web.UI.WebControls.Label lblLastUpdateDateTime;
		protected ConcurrencyADONet1.dsEmployee oDsEmployee;
	
		#region EmployeeEdit - Events and Handlers
		/// <summary>
		/// This method fires when the page loads
		/// </summary>
		/// <remarks name="Page_Load" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				string sEmployeeID = Session["EmployeeID"] + "";
				if (sEmployeeID.Length > 0)
				{
					oDsEmployee = GetEmployee();
					Session["oDsEmployee"] = oDsEmployee;
					// Bind the DataSet to the controls on the form 
					BindControls();
				}
				else
				{
					GoBack();
				}
			}
			else
			{
				oDsEmployee = (dsEmployee)Session["oDsEmployee"];
			}
			ClearConcurrencyValues();
			lblMessage.Text = "";
		}

		/// <summary>
		/// This method fires when the btnGoBack is clicked
		/// </summary>
		/// <remarks name="btnGoBack_Click" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void btnGoBack_Click(object sender, System.EventArgs e)
		{
			GoBack();
		}

		/// <summary>
		/// This method fires when the btnSave is clicked
		/// </summary>
		/// <remarks name="btnSave_Click" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			SaveEmployee(false);
		}

		/// <summary>
		/// This method fires when the btnSaveAnyway is clicked
		/// </summary>
		/// <remarks name="btnSaveAnyway_Click" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void btnSaveAnyway_Click(object sender, System.EventArgs e)
		{
			// Call alternative UpdateCommand that only uses 
			// the primary key in its WHERE clause
			SaveEmployee(true);
		}

		/// <summary>
		/// This method fires when the btnCancelChanges is clicked
		/// </summary>
		/// <remarks name="btnCancelChanges_Click" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void btnCancelChanges_Click(object sender, System.EventArgs e)
		{
			// Reject the changes and store the DataSet back in the Session
			oDsEmployee.Employee.RejectChanges();
			Session["oDsEmployee"] = oDsEmployee;
			// Bind the DataSet to the controls on the form 
			BindControls();
		}

		/// <summary>
		/// This method fires when the btnReloadFromDB is clicked
		/// </summary>
		/// <remarks name="btnReloadFromDB_Click" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void btnReloadFromDB_Click(object sender, System.EventArgs e)
		{
			// Reject the changes and store the DataSet back in the Session
			oDsEmployee.Employee.RejectChanges();
			Session["oDsEmployee"] = oDsEmployee;
			// Reload the DataSet from the database
			oDsEmployee = GetEmployee();
			// Bind the DataSet to the controls on the form 
			BindControls();
		}

		/// <summary>
		/// This method fires when the txtFirstName's value is modified
		/// </summary>
		/// <remarks name="txtFirstName_TextChanged" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void txtFirstName_TextChanged(object sender, System.EventArgs e)
		{
			// Get the employee DataRow (there is only 1 row, otherwise I could do a Find)
			dsEmployee.EmployeeRow oEmpRow = (dsEmployee.EmployeeRow)oDsEmployee.Employee.Rows[0];
			oEmpRow.FirstName = txtFirstName.Text;
			// Save changes back to Session
			Session["oDsEmployee"] = oDsEmployee;
		}

		/// <summary>
		/// This method fires when the txtLastName's value is modified
		/// </summary>
		/// <remarks name="txtLastName_TextChanged" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void txtLastName_TextChanged(object sender, System.EventArgs e)
		{
			// Get the employee DataRow (there is only 1 row, otherwise I could do a Find)
			dsEmployee.EmployeeRow oEmpRow = (dsEmployee.EmployeeRow)oDsEmployee.Employee.Rows[0];
			oEmpRow.LastName = txtLastName.Text;
			// Save changes back to Session
			Session["oDsEmployee"] = oDsEmployee;
		}

		/// <summary>
		/// This method fires when the txtTitle's value is modified
		/// </summary>
		/// <remarks name="txtTitle_TextChanged" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void txtTitle_TextChanged(object sender, System.EventArgs e)
		{
			// Get the employee DataRow (there is only 1 row, otherwise I could do a Find)
			dsEmployee.EmployeeRow oEmpRow = (dsEmployee.EmployeeRow)oDsEmployee.Employee.Rows[0];
			oEmpRow.Title = txtTitle.Text;
			// Save changes back to Session
			Session["oDsEmployee"] = oDsEmployee;
		}

		/// <summary>
		/// This method fires when the txtBirthDate's value is modified
		/// </summary>
		/// <remarks name="txtBirthDate_TextChanged" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void txtBirthDate_TextChanged(object sender, System.EventArgs e)
		{
			// Get the employee DataRow (there is only 1 row, otherwise I could do a Find)
			dsEmployee.EmployeeRow oEmpRow = (dsEmployee.EmployeeRow)oDsEmployee.Employee.Rows[0];
			oEmpRow.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
			// Save changes back to Session
			Session["oDsEmployee"] = oDsEmployee;
		}

		/// <summary>
		/// This method fires when the txtHireDate's value is modified
		/// </summary>
		/// <remarks name="txtHireDate_TextChanged" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void txtHireDate_TextChanged(object sender, System.EventArgs e)
		{
			// Get the employee DataRow (there is only 1 row, otherwise I could do a Find)
			dsEmployee.EmployeeRow oEmpRow = (dsEmployee.EmployeeRow)oDsEmployee.Employee.Rows[0];
			oEmpRow.HireDate = Convert.ToDateTime(txtHireDate.Text);
			// Save changes back to Session
			Session["oDsEmployee"] = oDsEmployee;
		}

		/// <summary>
		/// This method fires when the txtExtension's value is modified
		/// </summary>
		/// <remarks name="txtExtension_TextChanged" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void txtExtension_TextChanged(object sender, System.EventArgs e)
		{
			// Get the employee DataRow (there is only 1 row, otherwise I could do a Find)
			dsEmployee.EmployeeRow oEmpRow = (dsEmployee.EmployeeRow)oDsEmployee.Employee.Rows[0];
			oEmpRow.Extension = txtExtension.Text;
			// Save changes back to Session
			Session["oDsEmployee"] = oDsEmployee;
		}

		#endregion EmployeeEdit - Events and Handlers

		#region EmployeeEdit - Private Methods
		/// <summary>
		/// This method attempts to save the changes to the databsae
		/// </summary>
		/// <remarks name="SaveEmployee" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void SaveEmployee(bool bLastInWins)
		{
			try
			{
//
//				//--- I could do it this way instead of trapping the textbox change events, 
//				//--- but then it will always look like the row has been modified
//
//				// Get the employee DataRow (there is only 1 row, otherwise I could do a Find)
//				dsEmployee.EmployeeRow oEmpRow = (dsEmployee.EmployeeRow)oDsEmployee.Employee.Rows[0];
//				// Set the values of the employee row
//				oEmpRow.BeginEdit();
//				oEmpRow.FirstName = txtFirstName.Text;
//				oEmpRow.LastName = txtLastName.Text;
//				oEmpRow.Title = txtTitle.Text;
//				oEmpRow.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
//				oEmpRow.HireDate = Convert.ToDateTime(txtHireDate.Text);
//				oEmpRow.Extension = txtExtension.Text;
//				oEmpRow.EndEdit();

				// If changes were made, then attempt to save the record
				if (oDsEmployee.HasChanges(DataRowState.Modified)) 
				{
					// Create an instance of the Employee object
					Employee oEmp = new Employee();
				
					// Save the changes to the database
					//Common.DisplayDataSet(oDsEmployee, "PRE SAVE - oDsEmployee");
					dsEmployee oDsAfterUpdate = oEmp.SaveEmployee(oDsEmployee, bLastInWins);

					//Common.DisplayDataSet(oDsAfterUpdate, "PRE MERGE - oDsAfterUpdate");
					//Common.DisplayDataSet(oDsEmployee, "PRE MERGE - oDsEmployee");

					// Merge the new LastUpdateDateTime field value back into the local DataSet
					oDsEmployee.Merge(oDsAfterUpdate);
					
					//Common.DisplayDataSet(oDsAfterUpdate, "POST MERGE - oDsAfterUpdate");
					//Common.DisplayDataSet(oDsEmployee, "POST MERGE - oDsEmployee");

					// Display success message
					lblMessage.Text = "Changes have been applied successfully";
				}
				else
				{
					// Display "nothing to do" message
					lblMessage.Text = "No modifications were made, nothing to save";
				}
			}
			catch (DBConcurrencyException exDBC)
			{
				// In addition to displaying the current values in the DataSet,
				// display the original values from the DataSet from when it was first loaded
				// and the values that are currently in the database.
				FillConcurrencyValues((dsEmployee.EmployeeRow)exDBC.Row);
				btnSaveAnyway.Visible = true;
				// Display error message
				string sMsg = "Concurrency Exception occurred and changes were not saved to the database." 
					+ "<br><br>" + exDBC.Message;
				lblMessage.Text = sMsg;
			}
			catch (Exception ex)
			{
				// Display error message
				lblMessage.Text = "Exception occurred and changes were not saved to the database." 
					+ "<br><br>" + ex.Message;
			}
			finally
			{
				// Bind the DataSet to the controls on the form 
				BindControls();
			}
		}

		/// <summary>
		/// This method binds the controls on the form to their datasource
		/// </summary>
		/// <remarks name="BindControls" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void BindControls()
		{
			// We can use the Page.DataBind method instead of binding each control
			Page.DataBind();
			//			lblEmployeeID.DataBind();
			//			txtFirstName.DataBind();
			//			txtLastName.DataBind();
			//			txtTitle.DataBind();
			//			txtBirthDate.DataBind();
			//			txtHireDate.DataBind();
			//			txtExtension.DataBind();
			//			lblLastUpdateDateTime.DataBind();
		}

		/// <summary>
		/// This method clears the Session variables used by 
		/// this page and redirects back to the Employee List
		/// </summary>
		/// <remarks name="GoBack" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void GoBack()
		{
			Session.Remove("EmployeeID");
			Session.Remove("oDsEmployee");
			Response.Redirect("EmployeeList.aspx");
		}

		/// <summary>
		/// This method goes through the Employee business object to 
		/// get the Employee data from the database 
		/// </summary>
		/// <remarks name="GetEmployee" classtype="private">
		/// </remarks>
		/// <returns type="dsEmployee">an Employee DataSet</returns>
		private dsEmployee GetEmployee()
		{
			// Get the employee data and store it in the local DataSet
			// using the EmployeeID in the Session
			int iEmployeeID = Convert.ToInt32(Session["EmployeeID"]);
			Employee oEmp = new Employee();
			dsEmployee oDs = oEmp.GetEmployee(iEmployeeID);
			return oDs;
		}

		/// <summary>
		/// This method clears all values used to demonstrate a concurrency violation
		/// </summary>
		/// <remarks name="ClearConcurrencyValues" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void ClearConcurrencyValues()
		{
			// Hide headings
			lblOriginalHeader.Visible = false;
			lblInDBHeader.Visible = false;
			// Clear fields
			lblFirstName_Original.Text = "";
			lblLastName_Original.Text = "";
			lblTitle_Original.Text = "";
			lblBirthDate_Original.Text = "";
			lblHireDate_Original.Text = "";
			lblExtension_Original.Text = "";
			lblLastUpdateDateTime_Original.Text = "";
			lblFirstName_InDB.Text = "";
			lblLastName_InDB.Text = "";
			lblTitle_InDB.Text = "";
			lblBirthDate_InDB.Text = "";
			lblHireDate_InDB.Text = "";
			lblExtension_InDB.Text = "";
			lblLastUpdateDateTime_InDB.Text = "";
		}

		/// <summary>
		/// This method displays all values used to demonstrate a concurrency violation
		/// </summary>
		/// <remarks name="FillConcurrencyValues" classtype="private">
		/// </remarks>
		/// <returns type="void"></returns>
		private void FillConcurrencyValues(dsEmployee.EmployeeRow oEmpRow)
		{
			// Turn on headings
			lblOriginalHeader.Visible = true;
			lblInDBHeader.Visible = true;

			// Load the original values for comparison
			lblFirstName_Original.Text = Convert.ToString(oEmpRow["FirstName", DataRowVersion.Original]);
			lblLastName_Original.Text = Convert.ToString(oEmpRow["LastName", DataRowVersion.Original]);
			lblTitle_Original.Text = Convert.ToString(oEmpRow["Title", DataRowVersion.Original]);
			DateTime dtBirthDate_Original = (DateTime)oEmpRow["BirthDate", DataRowVersion.Original];
			lblBirthDate_Original.Text = dtBirthDate_Original.ToShortDateString();;
			DateTime dtHireDate_Original = (DateTime)oEmpRow["HireDate", DataRowVersion.Original];
			lblHireDate_Original.Text = dtHireDate_Original.ToShortDateString();;
			lblExtension_Original.Text = Convert.ToString(oEmpRow["Extension", DataRowVersion.Original]);
			lblLastUpdateDateTime_Original.Text = Convert.ToString(oEmpRow["LastUpdateDateTime", DataRowVersion.Original]);

			// Go get a copy of the data in the database so we can visually compare the values.
			dsEmployee oDsEmployeeInDB = GetEmployee();
			lblFirstName_InDB.Text = Convert.ToString(oDsEmployeeInDB.Tables["Employee"].Rows[0]["FirstName", DataRowVersion.Original]);
			lblLastName_InDB.Text = Convert.ToString(oDsEmployeeInDB.Tables["Employee"].Rows[0]["LastName", DataRowVersion.Original]);
			lblTitle_InDB.Text = Convert.ToString(oDsEmployeeInDB.Tables["Employee"].Rows[0]["Title", DataRowVersion.Original]);
			DateTime dtBirthDate_InDB = (DateTime)oDsEmployeeInDB.Tables["Employee"].Rows[0]["BirthDate", DataRowVersion.Original];
			lblBirthDate_InDB.Text = dtBirthDate_InDB.ToShortDateString();;
			DateTime dtHireDate_InDB = (DateTime)oDsEmployeeInDB.Tables["Employee"].Rows[0]["HireDate", DataRowVersion.Original];
			lblHireDate_InDB.Text = dtHireDate_InDB.ToShortDateString();;
			lblExtension_InDB.Text = Convert.ToString(oDsEmployeeInDB.Tables["Employee"].Rows[0]["Extension", DataRowVersion.Original]);
			lblLastUpdateDateTime_InDB.Text = Convert.ToString(oDsEmployeeInDB.Tables["Employee"].Rows[0]["LastUpdateDateTime", DataRowVersion.Original]);
		}
		#endregion EmployeeEdit - Private Methods

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
			this.oDsEmployee = new ConcurrencyADONet1.dsEmployee();
			((System.ComponentModel.ISupportInitialize)(this.oDsEmployee)).BeginInit();
			this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
			this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
			this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
			this.txtBirthDate.TextChanged += new System.EventHandler(this.txtBirthDate_TextChanged);
			this.txtHireDate.TextChanged += new System.EventHandler(this.txtHireDate_TextChanged);
			this.txtExtension.TextChanged += new System.EventHandler(this.txtExtension_TextChanged);
			// 
			// oDsEmployee
			// 
			this.oDsEmployee.DataSetName = "dsEmployee";
			this.oDsEmployee.Locale = new System.Globalization.CultureInfo("en-US");
			this.btnSaveAnyway.Click += new System.EventHandler(this.btnSaveAnyway_Click);
			this.btnCancelChanges.Click += new System.EventHandler(this.btnCancelChanges_Click);
			this.btnReloadFromDB.Click += new System.EventHandler(this.btnReloadFromDB_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.oDsEmployee)).EndInit();

		}
		#endregion

	}
	#endregion EmployeeEdit Class
}
