using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using System.Data.SqlClient;
using System.Data;

using GCheckout.Util;
using GCheckout.Checkout;
using System.Configuration;

public partial class Bus : System.Web.UI.Page
{
    SqlDataAdapter adp, adp1, adp2, adp3;
    public static DataSet dataset = new DataSet();
    DataSet ds= new DataSet();
   // SqlConnection conn = new SqlConnection("Data Source=ANILKBARNWAL;Initial Catalog=Travel;Integrated Security=True");
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString.ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Retrieving the city names from the database.
            adp = new SqlDataAdapter("Select distinct [BFrom] from BusDetails", conn);
            ds.Clear();
            adp.Fill(ds, "BusDetails");

            //binding the items in the From drop down list
            dlFrom.Items.Clear();
            dlFrom.Items.Add("Select a City");
            foreach (DataRow dr in ds.Tables["BusDetails"].Rows)
            {
                dlFrom.Items.Add(dr["BFrom"].ToString());
            }

            adp1 = new SqlDataAdapter("Select distinct [BTo] from BusDetails", conn);
            ds.Clear();
            adp1.Fill(ds, "BusDetails");

            //binding the items in the To drop down list
            dlTo.Items.Clear();
            dlTo.Items.Add("Select a City");
            foreach (DataRow dr in ds.Tables["BusDetails"].Rows)
            {
                dlTo.Items.Add(dr["BTo"].ToString());
            }

            if (Session["PostBack"] == "true")
            {
                string from, to, date, passenger;
                Session["PostBack"] = "false";

                from = Request.QueryString["Parameter1"].Trim();
                to = Request.QueryString["Parameter2"].Trim();
                date = Request.QueryString["Parameter3"].Trim();
                passenger = Request.QueryString["Parameter4"].Trim();

                adp2 = new SqlDataAdapter("Select * from BusDetails Where [BFrom] = '" + from + "' and [BTo] = '" + to + "' and BDate = '" + date + "' and SeatsAvailable >=" + passenger, conn);
                dataset.Clear();
                adp2.Fill(dataset, "BusDetails");
                if (dataset.Tables["BusDetails"].Rows.Count > 0)
                {
                    gvBusDetails.DataSource = dataset;
                    gvBusDetails.DataBind();
                }
                else
                {
                    string message = "No Matching record found";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                }
                dlFrom.SelectedValue = from;
                dlTo.SelectedValue = to;
                txtDepart.Text = date;
                dlPassengers.SelectedValue = passenger;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (dlFrom.SelectedValue == dlTo.SelectedValue)
        {            
            string message = "Departing and Arrival city cannot be same";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else if (Convert.ToDateTime(txtDepart.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
        {
            string message = "The Dearture date is not valid";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else
        {
            adp2 = new SqlDataAdapter("Select * from BusDetails Where [BFrom] = '" + dlFrom.SelectedValue + "' and [BTo] = '" + dlTo.SelectedValue + "' and BDate = '" + txtDepart.Text + "' and SeatsAvailable >=" + dlPassengers.SelectedValue, conn);
            dataset.Clear();
            adp2.Fill(dataset, "BusDetails");
            if (dataset.Tables["BusDetails"].Rows.Count > 0)
            {
                gvBusDetails.DataSource = dataset;
                gvBusDetails.DataBind();
            }
            else
            {                
                string message = "No record found for the selected date and location";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
        }
    }
    protected void gvBusDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = dataset.Tables["BusDetails"].Rows[gvBusDetails.SelectedIndex]["BusId"].ToString();
        adp3 = new SqlDataAdapter("Select * from BusDetails Where BusID = " + id, conn);
        ds.Clear();
        adp3.Fill(ds, "BusDetials");

        GCheckoutButton gc = new GCheckoutButton();
        Session["PostBack"] = "false";

        string route = "Ticket(s) from " + ds.Tables[0].Rows[0]["BFrom"].ToString() + " to " + ds.Tables[0].Rows[0]["BTo"].ToString() + " on " + ds.Tables[0].Rows[0]["BDate"].ToString();
        string date = ds.Tables[0].Rows[0]["BDate"].ToString();
        decimal price = Convert.ToDecimal(ds.Tables[0].Rows[0]["Fare"].ToString());
        int passengers = Convert.ToInt32(dlPassengers.SelectedValue);

        CheckoutShoppingCartRequest Req = gc.CreateRequest();
        Req.AddItem(route, date, price, passengers);
        GCheckoutResponse Resp = Req.Send();
        string link = Resp.RedirectUrl.ToString();
        
        LoginName ln = (LoginName)Master.FindControl("LoginName1");        
        string username = ln.Page.User.Identity.Name;
        if (!ln.Page.User.Identity.IsAuthenticated)
        {
            Session["PostBack"] = "false";
            string message = "Please login before booking the tickets.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else
        {
            Response.Redirect(Resp.RedirectUrl, true);
            //Response.Redirect("~/PaymentDetails_Bus.aspx?Parameter1= " + id + "&Parameter2= " + dlPassengers.SelectedValue);
        }
    }
    
}
