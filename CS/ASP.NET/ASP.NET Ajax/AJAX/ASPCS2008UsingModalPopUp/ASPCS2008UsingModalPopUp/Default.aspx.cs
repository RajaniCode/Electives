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

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int _countryId = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);

        odsCities.SelectParameters["countryId"].DefaultValue = _countryId.ToString();
        GridView2.DataSource = odsCities;
        GridView2.DataBind();

        upCities.Update();
        mdlPopup.Show();
    }
}

