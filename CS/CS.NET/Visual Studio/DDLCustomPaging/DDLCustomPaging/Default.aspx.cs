using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplication9
{
    public partial class _Default : System.Web.UI.Page
    {
        private int Take 
        {
            get 
            {
                return (int)ViewState["Take"];
            }
            set
            {
                ViewState["Take"] = value;
            }
        }

        private int Skip
        {
            get
            {
                return (int)ViewState["Skip"];
            }
            set
            {
                ViewState["Skip"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Take = 10;
                Skip = 0;
                FetchData();
            }            
        }

        private void FetchData()
        {            
            using (NorthwindDataContext dc = new NorthwindDataContext())
            {
                cboNames.Items.Clear();                
                if (Skip > 0)
                {                    
                    cboNames.Items.Add(new ListItem("<< Pre 10 Rows...", "Prev"));
                    cboNames.AppendDataBoundItems = true;                    
                }

                var query = dc.Customers
                            .OrderBy(o => o.ContactName)
                            .Take(Take)
                            .Skip(Skip);
                cboNames.DataTextField = "ContactName";
                cboNames.DataSource = query.ToList();
                cboNames.DataBind();

                if (cboNames.Items.Count >= 10)
                {
                    cboNames.Items.Add(new ListItem("Next 10 Rows >>", "Next"));    
                }
                cboNames.SelectedIndex = Skip > 0 ? 1 : 0;
            }
        }

        protected void cboNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNames.SelectedValue == "Next")
            {
                Take += 10;
                Skip += 10;
                FetchData();
            }
            else if (cboNames.SelectedValue == "Prev")
            {
                Take -= 10;
                Skip -= 10;
                FetchData();
            }   
        }
    }
}
