using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // C#

    protected void rbl_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        RadioButtonList rBtnList = (RadioButtonList)sender;	   
		GridViewRow gvr = (GridViewRow)rBtnList.Parent.Parent;
        if(rBtnList.SelectedValue == "1")
            SqlDataSource1.UpdateParameters[0].DefaultValue = "True";
        else
            SqlDataSource1.UpdateParameters[0].DefaultValue = "False";
        SqlDataSource1.UpdateParameters[1].DefaultValue = gvr.Cells[0].Text;
        SqlDataSource1.Update();
        GridView1.DataBind();        
    }

    //VB.NET

    //    Protected Sub rbl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    //    Dim rBtnList As RadioButtonList = CType(sender, RadioButtonList)
    //    Dim gvr As GridViewRow = CType(rBtnList.Parent.Parent, GridViewRow)
    //    If rBtnList.SelectedValue = "1" Then
    //        SqlDataSource1.UpdateParameters(0).DefaultValue = "True"
    //    Else
    //        SqlDataSource1.UpdateParameters(0).DefaultValue = "False"
    //    End If
    //    SqlDataSource1.UpdateParameters(1).DefaultValue = gvr.Cells(0).Text
    //    SqlDataSource1.Update()
    //    GridView1.DataBind()
    //End Sub

}
