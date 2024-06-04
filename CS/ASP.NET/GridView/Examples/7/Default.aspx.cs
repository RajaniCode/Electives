using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    static int i;
    static int count;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            binddata();
        }

    }


    void binddata()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("empdata.xml"));
        gv.DataSource = ds;
        gv.DataBind();
    }

    protected void Deletedata(object s, GridViewDeleteEventArgs e)
    {
        binddata();
        DataSet ds = gv.DataSource as DataSet;
        ds.Tables[0].Rows[gv.Rows[e.RowIndex].DataItemIndex].Delete();
        ds.WriteXml(Server.MapPath("empdata.xml"));
        binddata();
    }
    protected void Canceldata(object s, GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
        binddata();
    }


    protected void pageddata(object s, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        binddata();
    }

    protected void insertinXML(object sender, EventArgs e)
    {
        txtempID.Text = string.Empty;
        txtName.Text = string.Empty;
        txtCity.Text = string.Empty;
        txtSalary.Text = string.Empty;
        count = 99;
        popup.Show();
    }


    protected void Edit(object sender, EventArgs e)
    {


        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {

            txtempID.Text = row.Cells[0].Text;
            txtName.Text = row.Cells[1].Text;
            txtCity.Text = row.Cells[2].Text;
            txtSalary.Text = row.Cells[3].Text;
            popup.Show();



        }
    }






    protected void Save(object sender, EventArgs e)
    {
        binddata();
        DataSet ds = gv.DataSource as DataSet;
        DataRow dr = ds.Tables[0].NewRow();
        dr[0] = txtempID.Text;
        dr[1] = txtName.Text;
        dr[2] = txtCity.Text;
        dr[3] = txtSalary.Text;
        ds.Tables[0].Rows.Add(dr);
        ds.AcceptChanges();
        ds.WriteXml(Server.MapPath("empdata.xml"));
        binddata();
        txtempID.Text = string.Empty;
        txtName.Text = string.Empty;
        txtCity.Text = string.Empty;
        txtSalary.Text = string.Empty;
    }

    protected void Update(object sender, EventArgs e)
    {

        gv.EditIndex = -1;
        binddata();
        DataSet ds = (DataSet)gv.DataSource;
        int i = Convert.ToInt32(txtempID.Text);
        ds.Tables[0].Rows[i - 1]["empid"] = txtempID.Text;
        ds.Tables[0].Rows[i - 1]["empname"] = txtName.Text;
        ds.Tables[0].Rows[i - 1]["empcity"] = txtCity.Text;
        ds.Tables[0].Rows[i - 1]["empsalary"] = txtSalary.Text;
        ds.WriteXml(Server.MapPath("empdata.xml"));
        binddata();

    }
}