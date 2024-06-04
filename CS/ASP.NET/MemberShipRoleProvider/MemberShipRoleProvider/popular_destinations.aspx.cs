using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class popular_destinations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        create_Menu();
    }
    private void create_Menu()
    {
        logo.PostBackUrl = "index.aspx";
        home.PostBackUrl = "index.aspx";
        kerala_overview.PostBackUrl = "overview.aspx";
        destination.PostBackUrl = "#";
        district.PostBackUrl = "districts.aspx";
        attraction.PostBackUrl = "attractions.aspx";
        popularDestination.PostBackUrl = "popular_destinations.aspx";
        foodaccomodation.PostBackUrl = "food_accomodation.aspx";
        travelAssistance.PostBackUrl = "travel_assistance.aspx";
    }
}
