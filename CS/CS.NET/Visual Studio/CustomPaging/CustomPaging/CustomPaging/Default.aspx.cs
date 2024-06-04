using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class _Default : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SetPaging();    
            }            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {            
            GridView1.PageIndex = e.NewPageIndex;                      
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {   
            SetPaging();
        }

        private void SetPaging()
        {
            GridViewRow row = GridView1.BottomPagerRow;
            int alphaStart = 65;
            
            for (int i = 1; i < GridView1.PageCount; i++)
            {                
                LinkButton btn = new LinkButton();
                btn.CommandName = "Page";
                btn.CommandArgument = i.ToString();

                if (i == GridView1.PageIndex + 1)
                {
                    btn.BackColor = Color.BlanchedAlmond;
                }

                btn.Text = Convert.ToChar(alphaStart).ToString();
                btn.ToolTip = "Page " + i.ToString();
                alphaStart++;
                PlaceHolder place = row.FindControl("PlaceHolder1") as PlaceHolder;
                place.Controls.Add(btn);

                Label lbl = new Label();
                lbl.Text = " ";
                place.Controls.Add(lbl);
            }
        }            
    }
}
