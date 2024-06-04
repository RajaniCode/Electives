using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008GridViewJavaScript
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Products products = new Products();
                ProductsTableAdapters.ProductsTableAdapter PTA = new ProductsTableAdapters.ProductsTableAdapter();
                PTA.Fill(products._Products);
                GridView1.DataSource = products._Products;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtReasonDiscontinue = ((TextBox)e.Row.FindControl("ReasonDiscontinue"));
                RadioButtonList rblDiscontinue = ((RadioButtonList)e.Row.FindControl("rblDiscontinued"));
                ((CheckBox)e.Row.FindControl("CheckMark")).Attributes.Add("onClick", "ColorRow(this)");
                string strDicontinued = rblDiscontinue.SelectedValue;
                if (String.Compare(strDicontinued.Trim(), "False", true) == 0)
                {
                    txtReasonDiscontinue.Attributes.Add("Style", "visibility:hidden");
                }
                rblDiscontinue.Attributes.Add("onClick", "ShowHideField(this," + txtReasonDiscontinue.ClientID + ")");
            }
        }
    }
}
