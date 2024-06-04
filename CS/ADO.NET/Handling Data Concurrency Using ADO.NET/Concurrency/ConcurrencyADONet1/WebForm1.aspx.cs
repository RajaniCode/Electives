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
using System.Data.SqlClient;

namespace ConcurrencyADONet1
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Employee oEmp = new Employee();
			dsEmployee oDs = oEmp.GetEmployee(1);
			dsEmployee.EmployeeRow oEmpRow = (dsEmployee.EmployeeRow)oDs.Employee.Rows[0];
			oEmpRow.LastName = "Changed";

			using(SqlConnection oCn = new SqlConnection(Common.BuildConnectionString()))
			{
				//SqlCommand oCmd = new SqlCommand("UPDATE Employees SET LastName = @LastName WHERE EmployeeID = @EmployeeID", oCn);
				SqlCommand oCmd = new SqlCommand("UPDATE Employees SET LastName = @LastName WHERE EmployeeID = 9999", oCn);

				//oCmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4, "EmployeeID"));
				oCmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 20, "LastName"));
				SqlDataAdapter oDa = new SqlDataAdapter();
				oDa.UpdateCommand = oCmd;
				oDa.Update(oDs, "Employee");

				oCn.Open();
				oCmd.ExecuteNonQuery();
			}
		}
	}
}
