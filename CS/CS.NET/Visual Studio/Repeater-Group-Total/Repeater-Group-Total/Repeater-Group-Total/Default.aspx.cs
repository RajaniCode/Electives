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

    protected void Page_Load(object sender, EventArgs e)
    {

    }

Int64 cntView;
Int64 cntClick;

public void ChildRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
{
ListItemType lt = e.Item.ItemType;
if (lt == ListItemType.Item || lt == ListItemType.AlternatingItem)
{
    DataRowView dv = e.Item.DataItem as DataRowView;
    if (dv != null)
    {
        cntView += Convert.ToInt64(dv["AdImpression"]);
        cntClick += Convert.ToInt64(dv["AdClicks"]);
    }

}
else if (e.Item.ItemType == ListItemType.Footer)
{
    Label lblCount = e.Item.FindControl("lblImpressionCount") as Label;
    lblCount.Text = cntView.ToString();

    Label lblSum = e.Item.FindControl("lblClickCount") as Label;
    lblSum.Text = cntClick.ToString();
    cntView = 0;
    cntClick = 0;
}
}
}
