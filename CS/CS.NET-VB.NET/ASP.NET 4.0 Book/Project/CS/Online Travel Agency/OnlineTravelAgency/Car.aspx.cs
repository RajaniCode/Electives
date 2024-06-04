using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Car : System.Web.UI.Page
{
    public static String Rentaltype, city;
    SqlDataAdapter adp;   
    DataSet ds;
    //SqlConnection conn = new SqlConnection("Data Source=ANILKBARNWAL;Initial Catalog=Travel;Integrated Security=True");

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            if (Session["PostBack"] == "true")
            {
                Session["PostBack"] = "false";
                city = Request.QueryString["Parameter1"].Trim();
                Rentaltype = Request.QueryString["Parameter2"].Trim();

                if (Rentaltype == "FullDayRent")
                {
                    adp = new SqlDataAdapter("Select FullDayRent as Rent, CarModel as 'Car Model', Price_ExtraKM as 'Extra KM', Price_ExtraHour as 'Extra Hour' from CarDetails", conn);
                }
                else if (Rentaltype == "HalfDayRent")
                {
                    adp = new SqlDataAdapter("Select HalfDayRent as Rent, CarModel as 'Car Model', Price_ExtraKM as 'Extra KM', Price_ExtraHour as 'Extra Hour' from CarDetails", conn);
                }
                ds = new DataSet();
                adp.Fill(ds, "CarDetails");

                gvCarDetails.DataSource = ds;
                gvCarDetails.DataBind();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if(rbBanglore.Checked == true)
        {
            city = "Banglore";
        }
        else if(rbChennai.Checked == true)
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
            adp = new SqlDataAdapter("Select FullDayRent as Rent, CarModel as 'Car Model', Price_ExtraKM as 'Extra KM', Price_ExtraHour as 'Extra Hour' from CarDetails Where City = '"+ city+ "'", conn);           
        }
        else if (rbHalfDay.Checked == true)
        {
            Rentaltype = "HalfDayRent";
            adp = new SqlDataAdapter("Select HalfDayRent as Rent, CarModel as 'Car Model', Price_ExtraKM as 'Extra KM', Price_ExtraHour as 'Extra Hour' from CarDetails Where City = '"+ city + "'", conn);
        }
        ds = new DataSet();
        adp.Fill(ds, "CarDetails");

        gvCarDetails.DataSource = ds;
        gvCarDetails.DataBind();
    }

    protected void gvCarDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["CarPostback"] = "true";
        Response.Redirect("~/Car_Address.aspx?Parameter1=" + gvCarDetails.SelectedRow.Cells[2].Text + "&Parameter2=" + Rentaltype + "&Parameter3=" + city);
    }
}
