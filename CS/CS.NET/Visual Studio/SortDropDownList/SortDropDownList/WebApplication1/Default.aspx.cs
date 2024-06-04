using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> names = new List<string>() { "Malcolm", "Suprotim", "John", "Tony", "Alex", "Jason" };
                cboNames.DataSource = names;
                cboNames.DataBind();   
            }
        }

        protected void btnSortNames_Click(object sender, EventArgs e)
        {   
            cboNames.DataSource = cboNames.Items.Cast<ListItem>()
                                  .OrderByDescending(o => o.Text)
                                  .ToList();
            cboNames.DataBind();
        }

        protected void btnSortAscending_Click(object sender, EventArgs e)
        {
            cboNames.DataSource = cboNames.Items.Cast<ListItem>()
                                  .OrderBy(o => o.Text)
                                  .ToList();
            cboNames.DataBind();
        }        
    }
}
