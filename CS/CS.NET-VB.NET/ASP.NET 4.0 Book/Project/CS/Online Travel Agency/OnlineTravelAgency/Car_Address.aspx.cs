using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

using GCheckout.Checkout;
using GCheckout.Util;
using System.Configuration;

public partial class Car_Address : System.Web.UI.Page
{
    public static string carmodel, carrent, city, rentaltype, purpose, pdate, ptime, passengers, paddress, daddress;
    public decimal price;
    public string renttype;
    SqlDataAdapter adp;
    DataSet ds = new DataSet();
  //  SqlConnection conn = new SqlConnection("Data Source=ANILKBARNWAL;Initial Catalog=Travel;Integrated Security=True");
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (Session["CarPostback"] == "true")
        {
            carmodel = Request.QueryString["Parameter1"];
            rentaltype = Request.QueryString["Parameter2"];
            city = Request.QueryString["Parameter3"];
        }
        LoginName ln = (LoginName)Master.FindControl("LoginName1");
        if (!ln.Page.User.Identity.IsAuthenticated)
        {
            Session["CarPostback"] = "false";
            Response.Redirect("~/Login.aspx?ReturnUrl=Car_Address.aspx");//?Parameter1= " + carmodel + "&Parameter2= " + rentaltype + "&Parameter3= " + city);
        }
        else
        {   
        adp = new SqlDataAdapter("Select " + rentaltype + ", CarModel, Price_ExtraKM, Price_ExtraHour, CarCapacity from CarDetails Where CarModel = '" + carmodel + "' and City = '"+ city +"'", conn);
        adp.Fill(ds, "CarDetails");
        lblCarModel.Text += ds.Tables[0].Rows[0]["CarModel"].ToString();
        lblCarCapacity.Text += ds.Tables[0].Rows[0]["CarCapacity"].ToString();
        lblExtraHour.Text += ds.Tables[0].Rows[0]["Price_ExtraHour"].ToString();
        lblExtraKM.Text += ds.Tables[0].Rows[0]["Price_ExtraKM"].ToString();
        if (rentaltype == "FullDayRent")
        {           
            lblRent.Text += ds.Tables[0].Rows[0]["FullDayRent"].ToString();
            lblPurpose.Text += "Full Day (80 Kms or 8 Hours)";
            carrent = ds.Tables[0].Rows[0]["FullDayRent"].ToString();
            purpose = "Full Day (80 Kms or 8 Hours)";
        }
        else if (rentaltype == "HalfDayRent")
        {            
            lblRent.Text += ds.Tables[0].Rows[0]["HalfDayRent"].ToString();
            lblPurpose.Text += "Half Day (40 Kms or 4 Hours)";
            carrent = ds.Tables[0].Rows[0]["HalfDayRent"].ToString();
            purpose = "Half Day (40 Kms or 4 Hours)";
            price = Convert.ToDecimal(ds.Tables[0].Rows[0]["HalfDayRent"].ToString());
        }
       // imgCar.ImageUrl = "~/Resources/" + ds.Tables[0].Rows[0]["CarImage"].ToString();

        CalendarExtender1.SelectedDate = DateTime.Today.Date.AddDays(2);

        RangeValidator1.Type = ValidationDataType.Date;
        RangeValidator1.MinimumValue = DateTime.Now.AddDays(2).ToShortDateString();
        RangeValidator1.MaximumValue = DateTime.Now.AddDays(20000).ToShortDateString();
        RangeValidator1.ErrorMessage = "Please select a date two days after the current date!";

        int cap = Convert.ToInt32(ds.Tables[0].Rows[0]["CarCapacity"].ToString().Substring(0,1));
        RangeValidator2.MaximumValue = (cap + 1).ToString();
        RangeValidator2.ErrorMessage = "Number of passenger is more than the car capacity";

        }
    }
  
    protected void GCheckoutButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (cbConfirm.Checked == false)
        {
            cbConfirm.Font.Bold = true;
            cbConfirm.ForeColor = System.Drawing.Color.Red;
        }
        else
        {            
            CheckoutShoppingCartRequest Req = GCheckoutButton1.CreateRequest();
            Req.AddItem(carmodel, "Booked for " + purpose + " on " + txtPickupDate.Text + "(" + dlHours.SelectedValue.ToString() + ":" + dlMinutes.SelectedValue.ToString() + " Hrs)", Convert.ToDecimal(carrent), 1);
            GCheckoutResponse Resp = Req.Send();
            Response.Redirect(Resp.RedirectUrl, true);
        }
    }
}


