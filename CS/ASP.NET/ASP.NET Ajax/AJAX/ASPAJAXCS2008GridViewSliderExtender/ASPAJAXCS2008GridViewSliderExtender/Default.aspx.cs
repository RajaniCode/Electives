using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        string Path = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/Product.xml");
        DataSet ds = new DataSet();
        ds.ReadXml(Path);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void txtSlider_TextChanged(object sender, EventArgs e)
    {
        GridViewRow rowPager = GridView1.BottomPagerRow;
        TextBox txtSliderExt = (TextBox)rowPager.Cells[0].FindControl("txtSlider");
        GridView1.PageIndex = Int32.Parse(txtSliderExt.Text) - 1;

        BindGrid();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "First")
        {
            GridView1.PageIndex = 0;
        }
        else if (e.CommandName == "Prev")
        {
            if (GridView1.PageIndex > 0)
                GridView1.PageIndex = GridView1.PageIndex - 1;
        }
        else if (e.CommandName == "Next")
        {
            if (GridView1.PageIndex < GridView1.PageCount - 1)
                GridView1.PageIndex = GridView1.PageIndex + 1;
        }
        else if (e.CommandName == "Last")
        {

            GridView1.PageIndex = GridView1.PageCount - 1;
        }
        BindGrid();
    }
}

