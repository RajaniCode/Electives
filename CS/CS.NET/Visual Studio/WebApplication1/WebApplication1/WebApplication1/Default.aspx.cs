using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (PubsDataContext dc = new PubsDataContext())
            {
                List<Discount> discount = dc.Discounts.LinqCache();
                cboCategories.DataSource = discount;
                cboCategories.DataBind();
            }            
        }
    }
}
