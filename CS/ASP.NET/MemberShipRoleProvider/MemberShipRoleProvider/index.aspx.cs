using System;
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

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        create_Menu();
        String html = "Welcome to Kerala Tourism </h2>Kerala's history is closely linked with its commerce, which until recent times revolved around its spice trade. Celebrated as the Spice Coast of India, ancient Kerala played host to travellers and traders from across the world including the Greeks, Romans, Arabs, Chinese, Portuguese, Dutch, French and the British. Almost all of them have left their imprint on this land in some form or the other - architecture, cuisine, literature.";
        description.Text = html;
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
        learn_more_destination.PostBackUrl = "popular_destinations.aspx";
        learn_more_history.PostBackUrl = "overview.aspx";
        travel_more.PostBackUrl = "travel_assistance.aspx";
        kerala_special.PostBackUrl = "food_accomodation.aspx";
    }
}
