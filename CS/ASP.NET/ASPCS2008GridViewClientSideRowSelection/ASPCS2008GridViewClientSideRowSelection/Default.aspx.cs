using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008GridViewClientSideRowSelection
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check the item being bound is actually a DataRow, if it is wire up the
            //required html events and attach the relevant javascripts 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
    }
}
