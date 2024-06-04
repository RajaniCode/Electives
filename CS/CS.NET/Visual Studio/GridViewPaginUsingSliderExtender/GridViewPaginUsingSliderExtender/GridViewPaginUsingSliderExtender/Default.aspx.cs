using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

protected void txtSlide_Changed(object sender, EventArgs e)
{
    TextBox txtCurrentPage = sender as TextBox;
    GridViewRow rowPager = GridView1.BottomPagerRow;
    TextBox txtSliderExt = (TextBox)rowPager.Cells[0].FindControl("txtSlide");
    GridView1.PageIndex = Int32.Parse(txtSliderExt.Text) - 1;        
}

protected void GridView1_DataBound(object sender, EventArgs e)
{
    GridViewRow rowPager = GridView1.BottomPagerRow;
    SliderExtender slide = (SliderExtender)rowPager.Cells[0].FindControl("ajaxSlider");
    slide.Minimum = 1;
    slide.Maximum = GridView1.PageCount;
    slide.Steps = GridView1.PageCount;
}
}
