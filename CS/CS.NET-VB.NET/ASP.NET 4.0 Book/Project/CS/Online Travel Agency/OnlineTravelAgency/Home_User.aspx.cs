using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using System.Drawing;

////import namespace for using webparts controls
//using System.Web.UI.WebControls.WebParts;

////import namespace for using SQL Server objects
//using System.Data;
//using System.Data.SqlClient;


public partial class Home_User : System.Web.UI.Page
{
    //SqlDataAdapter adpbus1, adpbus2, adptrain1, adptrain2;
    //public static DataSet dataset = new DataSet();
    //DataSet ds = new DataSet();
    //SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Travel;Integrated Security=True");
    //string city, Rentaltype, class1, classfare;

    protected void Page_Load(object sender, EventArgs e)
    {
        //LoginName ln = (LoginName)Master.FindControl("LoginName1");
        //if (ln.Page.User.Identity.IsAuthenticated)
        //{
        //    Response.Redirect("~/Home.aspx");
        //}
        //else
        //{
        //    Menu mi1 = (Menu)Master.FindControl("Menu1");
        //    mi1.ForeColor = Color.Black;
        //    mi1.StaticMenuStyle.BackColor = Color.Yellow;

        //}
        //if (!IsPostBack)
        //{
        //    //Retrieving the city names from the database.
        //    adpbus1 = new SqlDataAdapter("Select distinct [From] from BusDetails", conn);
        //    ds.Clear();
        //    adpbus1.Fill(ds, "BusDetails");

        //    //binding the items in the From drop down list
        //    dlFrom.Items.Clear();
        //    dlFrom.Items.Add("Select a City");
        //    foreach (DataRow dr in ds.Tables["BusDetails"].Rows)
        //    {
        //        dlFrom.Items.Add(dr["From"].ToString());
        //    }

        //    adpbus2 = new SqlDataAdapter("Select distinct [To] from BusDetails", conn);
        //    ds.Clear();
        //    adpbus2.Fill(ds, "BusDetails");

        //    //binding the items in the To drop down list
        //    dlTo.Items.Clear();
        //    dlTo.Items.Add("Select a City");
        //    foreach (DataRow dr in ds.Tables["BusDetails"].Rows)
        //    {
        //        dlTo.Items.Add(dr["To"].ToString());
        //    }

        //    //CalendarExtender1.SelectedDate = DateTime.Now.Date;
        //}
        //if (!IsPostBack)
        //{
        //    //displaying the station name from the SQL Server database
        //    adptrain1 = new SqlDataAdapter("Select distinct DepartStation from TrainDetails", conn);
        //    ds.Clear();
        //    adptrain1.Fill(ds, "TrainDetails");

        //    //binding the items in the From drop down list
        //    dlFrom1.Items.Clear();
        //    dlFrom1.Items.Add("Select Station");
        //    foreach (DataRow dr in ds.Tables["TrainDetails"].Rows)
        //    {
        //        dlFrom1.Items.Add(dr["DepartStation"].ToString());
        //    }

        //    adptrain2 = new SqlDataAdapter("Select distinct ArrivalStation from TrainDetails", conn);
        //    ds.Clear();
        //    adptrain2.Fill(ds, "TrainDetails");

        //    //binding the items in the To drop down list
        //    dlTo1.Items.Clear();
        //    dlTo1.Items.Add("Select Station");
        //    foreach (DataRow dr in ds.Tables["TrainDetails"].Rows)
        //    {
        //        dlTo1.Items.Add(dr["ArrivalStation"].ToString());
        //    }
        //}
        LoginName ln = (LoginName)Master.FindControl("LoginName1");
        if (ln.Page.User.Identity.Name == "administrator")
        {
            Response.Redirect("~/Administrator.aspx");
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static AjaxControlToolkit.Slide[] GetSlides(string contextKey)
    {
        AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[8];

        imgSlide[0] = new AjaxControlToolkit.Slide("Resources/cab1.jpg", "Cars", "Cars");
        imgSlide[1] = new AjaxControlToolkit.Slide("Resources/cab2.jpg", "Cars", "Cars");
        imgSlide[2] = new AjaxControlToolkit.Slide("Resources/bus.jpg", "Cars", "Cars");
        imgSlide[3] = new AjaxControlToolkit.Slide("Resources/Train.jpg", "Cars", "Cars"); 
        imgSlide[4] = new AjaxControlToolkit.Slide("Resources/Cars1.jpg", "Cars", "Cars");
        imgSlide[5] = new AjaxControlToolkit.Slide("Resources/Cars2.jpg", "Cars", "Cars");
        imgSlide[6] = new AjaxControlToolkit.Slide("Resources/Cars3.jpg", "Cars", "Cars");
        imgSlide[7] = new AjaxControlToolkit.Slide("Resources/Cars4.jpg", "Cars", "Cars");
        
        return (imgSlide);
    }

    /*protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["PostBack"] = "true";

        if (rbBanglore.Checked == true)
        {
            city = "Banglore";
        }
        else if (rbChennai.Checked == true)
        {
            city = "Chennai";
        }
        else if (rbDelhi.Checked == true)
        {
            city = "Delhi";
        }
        else if (rbJaipur.Checked == true)
        {
            city = "Jaipur";
        }
        else if (rbKolkata.Checked == true)
        {
            city = "Kolkata";
        }
        else if (rbMumbai.Checked == true)
        {
            city = "Mumbai";
        }
        if (rbfullDay.Checked == true)
        {
            Rentaltype = "FullDayRent";
            //adp = new SqlDataAdapter("Select FullDayRent as Rent, CarModel as 'Car Model', Price_ExtraKM as 'Extra KM', Price_ExtraHour as 'Extra Hour' from CarDetails", conn);           
        }
        else if (rbHalfDay.Checked == true)
        {
            Rentaltype = "HalfDayRent";
            //adp = new SqlDataAdapter("Select HalfDayRent as Rent, CarModel as 'Car Model', Price_ExtraKM as 'Extra KM', Price_ExtraHour as 'Extra Hour' from CarDetails", conn);
        }
        Response.Redirect("~/Car.aspx?Parameter1= " + city + "&Parameter2= " + Rentaltype);
    }
    protected void btnBusSearch_Click(object sender, EventArgs e)
    {
        if (dlFrom.SelectedValue == dlTo.SelectedValue)
        {
            lblMessage.Text = "Departing and Arrival city cannot be same";
            return;
        }
        else if (Convert.ToDateTime(txtDepart.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
        {
            lblMessage.Text = "The Dearture date is not valid";
            return;
        }
        else
        {
            Session["PostBack"] = "true";
            Response.Redirect("~/Bus.aspx?Parameter1= " + dlFrom.SelectedValue + "&Parameter2= " + dlTo.SelectedValue + "&Parameter3= " + txtDepart.Text + "&Parameter4= " + dlPassengers.SelectedValue);

        }
    }
    protected void btnTrainSearch_Click(object sender, EventArgs e)
    {
        if (dlFrom1.SelectedValue == dlTo1.SelectedValue)
        {
            lblMessage1.Text = "Departing and Arrival city cannot be same";
            return;
        }
        else if (Convert.ToDateTime(txtDate.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
        {
            lblMessage1.Text = "The Dearture date is not valid";
            return;
        }
        else
        {
            if (dlClass.SelectedValue == "Sleeper Class")
            {
                class1 = "SleeperClass";
                classfare = "SleeperClassFare";
            }
            else if (dlClass.SelectedValue == "AC First Class")
            {
                class1 = "ACFirstClass";
                classfare = "ACFirstClassFare";
            }
            else if (dlClass.SelectedValue == "2 Tier")
            {
                class1 = "[2Tier]";
                classfare = "2TierFare";
            }
            else if (dlClass.SelectedValue == "3 Tier")
            {
                class1 = "[3Tier]";
                classfare = "3TierFare";
            }
            Session["PostBack"] = "true";
            Response.Redirect("~/Train.aspx?Parameter1= " + dlFrom1.SelectedValue + "&Parameter2= " + dlTo1.SelectedValue + "&Parameter3= " + txtDate.Text + "&Parameter4= " + class1 + "&Parameter5= " + dlpassengers1.SelectedValue + "&Parameter6= " + classfare);
        }
    }*/
}
