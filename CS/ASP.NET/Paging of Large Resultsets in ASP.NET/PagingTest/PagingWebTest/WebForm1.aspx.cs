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
using Microsoft.ApplicationBlocks.Data;

namespace PagingWebTest
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;

		//Connection string
		string conStr = "server=localhost;Trusted_Connection=True;database=PagingTest";

		string spName = "Paging_Cursor";
		string Tables = "LargeTable";
		string PK = "LargeTable.PK";
		int PageNumber = 1;
		int PageSize = 10;
		string Fields = "*";
		string Filter = "";
		string Group = "";

		/// <summary>
		/// Property Sort (string)
		/// </summary>
		public string Sort
		{
			get
			{
				if ((string)this.ViewState["Sort"]=="")
				{
					return "LargeTable.PK";
				}
				return (string)this.ViewState["Sort"];
			}
			set
			{
				this.ViewState["Sort"] = value;
			}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// This is the key line for custom paging, DataGrid will automatically calculate everything, it just needs the total number of pages
			DataGrid1.VirtualItemCount = (int)SqlHelper.ExecuteScalar(conStr, CommandType.Text, "SELECT Count(ID) FROM LargeTable");

			//Bind Grid the first time
			if(!Page.IsPostBack)
			{
				BindGrid(PageNumber);
			}
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//DataBinding
		private void BindGrid(int pageNumber)
		{
			SqlDataReader dr = null;
			try
			{
				dr = SqlHelper.ExecuteReader(conStr, spName, new object[]{Tables, PK, Sort, pageNumber, PageSize, Fields, Filter, Group});
				DataGrid1.DataSource = dr;
				DataGrid1.DataBind();
			}
			catch (Exception ex)
			{
				throw(ex);
			}
			finally
			{
				if (dr!=null) dr.Close();
			}
		}

		//Handle Paging
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex + 1;
			BindGrid(e.NewPageIndex + 1);
		}

		//Handle Sorting
		private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.Sort = e.SortExpression;
			BindGrid(DataGrid1.CurrentPageIndex);
		}

	}
}
