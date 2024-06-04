using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using ASPCS2008GridViewTableAdapter.TestDatabaseTableAdapters;

namespace ASPCS2008GridViewTableAdapter
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
            }
        }
        public void FillGrid()
        {
            ContactTableAdapter contact = new ContactTableAdapter();
            DataTable contacts = contact.GetData();
            if (contacts.Rows.Count > 0)
            {
                grdContact.DataSource = contacts;
                grdContact.DataBind();
            }
            else
            {
                contacts.Rows.Add(contacts.NewRow());
                grdContact.DataSource = contacts;
                grdContact.DataBind();

                int TotalColumns = grdContact.Rows[0].Cells.Count;
                grdContact.Rows[0].Cells.Clear();
                grdContact.Rows[0].Cells.Add(new TableCell());
                grdContact.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                grdContact.Rows[0].Cells[0].Text = "No Record Found";
            }
        }
        protected void grdContact_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ContactTypeTableAdapter contactType = new ContactTypeTableAdapter();
            DataTable contactTypes = contactType.GetData();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblType = (Label)e.Row.FindControl("lblType");
                if (lblType != null)
                {
                    int typeId = Convert.ToInt32(lblType.Text);
                    lblType.Text = (string)contactType.GetTypeById(typeId);
                }
                DropDownList cmbType = (DropDownList)e.Row.FindControl("cmbType");
                if (cmbType != null)
                {
                    cmbType.DataSource = contactTypes;
                    cmbType.DataTextField = "TypeName";
                    cmbType.DataValueField = "Id";
                    cmbType.DataBind();
                    cmbType.SelectedValue = grdContact.DataKeys[e.Row.RowIndex].Values[1].ToString();
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList cmbNewType = (DropDownList)e.Row.FindControl("cmbNewType");
                cmbNewType.DataSource = contactTypes;
                cmbNewType.DataBind();
            }
        }
        protected void grdContact_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdContact.EditIndex = -1;
            FillGrid();
        }
        protected void grdContact_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ContactTableAdapter contact = new ContactTableAdapter();
            bool flag = false;
            Label lblId = (Label)grdContact.Rows[e.RowIndex].FindControl("lblId");
            TextBox txtName = (TextBox)grdContact.Rows[e.RowIndex].FindControl("txtName");
            CheckBox chkActive = (CheckBox)grdContact.Rows[e.RowIndex].FindControl("chkActive");
            DropDownList cmbType = (DropDownList)grdContact.Rows[e.RowIndex].FindControl("cmbType");
            DropDownList ddlSex = (DropDownList)grdContact.Rows[e.RowIndex].FindControl("ddlSex");
            if (chkActive.Checked) flag = true; else flag = false;
            contact.Update(txtName.Text, ddlSex.SelectedValue, cmbType.SelectedValue, flag, Convert.ToInt32(lblId.Text));
            grdContact.EditIndex = -1;
            FillGrid();

        }
        protected void grdContact_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ContactTableAdapter contact = new ContactTableAdapter();
            int id = Convert.ToInt32(grdContact.DataKeys[e.RowIndex].Values[0].ToString());
            contact.Delete(id);
            FillGrid();
        }
        protected void grdContact_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ContactTableAdapter contact = new ContactTableAdapter();
            bool flag = false;
            if (e.CommandName.Equals("Insert"))
            {
                TextBox txtNewName = (TextBox)grdContact.FooterRow.FindControl("txtNewName");
                CheckBox chkNewActive = (CheckBox)grdContact.FooterRow.FindControl("chkNewActive");
                DropDownList cmbNewType = (DropDownList)grdContact.FooterRow.FindControl("cmbNewType");
                DropDownList ddlNewSex = (DropDownList)grdContact.FooterRow.FindControl("ddlNewSex");
                if (chkNewActive.Checked) flag = true; else flag = false;
                contact.Insert(txtNewName.Text, ddlNewSex.SelectedValue, cmbNewType.SelectedValue, flag);
                FillGrid();
            }
        }
        protected void grdContact_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdContact.EditIndex = e.NewEditIndex;
            FillGrid();
        }
    }
}
