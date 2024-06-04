using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using System.Data.SqlClient;
using System.Data;

using GCheckout.Checkout;
using GCheckout.Util;
using System.Configuration;

public partial class Train : System.Web.UI.Page
{
    public static int passengers;
    public static string class1, classfare;
    SqlDataAdapter adp, adp1, adp2, adp3;
    public static DataSet dataset = new DataSet();
    DataSet ds = new DataSet();   
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            //displaying the station name from the SQL Server database
            adp = new SqlDataAdapter("Select distinct DepartStation from TrainDetails", conn);
            ds.Clear();
            adp.Fill(ds, "TrainDetails");

            //binding the items in the From drop down list
            dlFrom.Items.Clear();
            dlFrom.Items.Add("Select Station");
            foreach (DataRow dr in ds.Tables["TrainDetails"].Rows)
            {
                dlFrom.Items.Add(dr["DepartStation"].ToString());
            }

            adp1 = new SqlDataAdapter("Select distinct ArrivalStation from TrainDetails", conn);
            ds.Clear();
            adp1.Fill(ds, "TrainDetails");

            //binding the items in the To drop down list
            dlTo.Items.Clear();
            dlTo.Items.Add("Select Station");
            foreach (DataRow dr in ds.Tables["TrainDetails"].Rows)
            {
                dlTo.Items.Add(dr["ArrivalStation"].ToString());
            }
            if (Session["PostBack"] == "true")
            {
                string from, to, date, passengers;

                from = Request.QueryString["Parameter1"].Trim();
                to = Request.QueryString["Parameter2"].Trim();
                date = Request.QueryString["Parameter3"].Trim();
                class1 = Request.QueryString["Parameter4"].Trim();
                passengers = Request.QueryString["Parameter5"].Trim();
                classfare = Request.QueryString["Parameter6"].Trim();

                dlFrom.SelectedValue = from;
                dlTo.SelectedValue = to;
                txtDate.Text = date;
                dlClass.SelectedValue = class1;
                dlpassengers.SelectedValue = passengers;

                adp2 = new SqlDataAdapter("Select * from TrainDetails Where DepartStation = '" + from + "' and ArrivalStation = '" + to + "' and DepartureDate = '" + date + "' and " + class1 + ">=" + passengers, conn);
                dataset.Clear();
                adp2.Fill(dataset, "TrainDetails");
                if (dataset.Tables["TrainDetails"].Rows.Count > 0)
                {
                    gvTrainDetails.DataSource = dataset;
                    gvTrainDetails.DataBind();
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
        else if (Convert.ToDateTime(txtDate.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
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
            adp2 = new SqlDataAdapter("Select TrainID, DepartStation as 'Departure Station', ArrivalStation as 'Arrival Station', DepartureDate as 'Depart Date', DepartureTime as 'Depart Time', [" + classfare + "] as Fare from TrainDetails Where DepartStation = '" + dlFrom.SelectedValue + "' and ArrivalStation = '" + dlTo.SelectedValue + "' and DepartureDate = '" + txtDate.Text + "' and " + class1 + ">=" + dlpassengers.SelectedValue, conn);
            dataset.Clear();
            adp2.Fill(dataset, "TrainDetails");
            if (dataset.Tables["TrainDetails"].Rows.Count > 0)
            {                
                gvTrainDetails.DataSource = dataset;
                gvTrainDetails.DataBind();
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
        }
    }


    protected void gvTrainDetails_SelectedIndexChanged(object sender, EventArgs e)
    {        
        Session["PostBack"] = "false";
        string id = dataset.Tables["TrainDetails"].Rows[gvTrainDetails.SelectedIndex]["TrainId"].ToString();
        adp3 = new SqlDataAdapter("Select * from TrainDetails Where TrainId = " + id, conn);
        ds.Clear();
        adp3.Fill(ds, "TrainDetials");

        GCheckoutButton gc = new GCheckoutButton();
        string route = "Ticket(s) from " + ds.Tables[0].Rows[0]["DepartStation"].ToString() + " to " + ds.Tables[0].Rows[0]["ArrivalStation"].ToString() + " on " + ds.Tables[0].Rows[0]["DepartureDate"].ToString();
        string Travelclass = "In " + dlClass.SelectedValue;
        decimal price = Convert.ToDecimal(ds.Tables[0].Rows[0][classfare].ToString());
        int passengers = Convert.ToInt32(dlpassengers.SelectedValue);

        CheckoutShoppingCartRequest Req = gc.CreateRequest();
        Req.AddItem(route, Travelclass, price, passengers);
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
        }
    }
    protected void dlpassengers_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
