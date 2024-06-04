using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{

    
    protected void GridViewEmailIDs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Insert")
        {
            string ei = ((TextBox)GridViewEmailIDs.FooterRow.FindControl("InserttxtEmailId")).Text;
            string ui = ((TextBox)GridViewEmailIDs.FooterRow.FindControl("InserttxtUserID")).Text;


            ObjectDataSourceEmailIDs.InsertParameters.Add("ei", ei);
            ObjectDataSourceEmailIDs.InsertParameters.Add("ui", ui);


            ObjectDataSourceEmailIDs.Insert();
        }
    }

    protected void GridViewEmailIDs_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewEmailIDs.EditIndex = e.NewEditIndex;
    }

    protected void GridViewEmailIDs_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(((Label)GridViewEmailIDs.Rows[e.RowIndex].FindControl("lblId")).Text);
        string ei = ((TextBox)GridViewEmailIDs.Rows[e.RowIndex].FindControl("txtEmailId")).Text;
        string ui = ((TextBox)GridViewEmailIDs.Rows[e.RowIndex].FindControl("txtUserId")).Text;


        ObjectDataSourceEmailIDs.UpdateParameters.Add("Identity", TypeCode.Int32, id.ToString());
        ObjectDataSourceEmailIDs.UpdateParameters.Add("EmailId", ei);
        ObjectDataSourceEmailIDs.UpdateParameters.Add("UserID", ui);

        ObjectDataSourceEmailIDs.Update();

        GridViewEmailIDs.EditIndex = -1;
    }

    protected void GridViewEmailIDs_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewEmailIDs.EditIndex = -1;
    }

    protected void GridViewEmailIDs_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(((Label)GridViewEmailIDs.Rows[e.RowIndex].FindControl("lblId")).Text);

        ObjectDataSourceEmailIDs.DeleteParameters.Add("Identity", TypeCode.Int32, id.ToString());

        ObjectDataSourceEmailIDs.Delete();
    }
}
