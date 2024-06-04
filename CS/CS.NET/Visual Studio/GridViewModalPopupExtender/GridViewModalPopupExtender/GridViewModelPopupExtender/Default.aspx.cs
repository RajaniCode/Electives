using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

protected void lnkCustDetails_Click(object sender, EventArgs e)
{
    // Fetch the customer id
    LinkButton lb = sender as LinkButton;
    string custID = lb.Text;
    lblCustValue.Text = custID;
    // Connection
    string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
    string sql = "SELECT CompanyName, ContactName, Address FROM Customers WHERE CustomerID = @CustID";
    SqlConnection connection = new SqlConnection(constr);
    SqlCommand cmd = new SqlCommand(sql, connection);
    cmd.Parameters.AddWithValue("@CustID", custID);
    cmd.CommandType = CommandType.Text;
    connection.Open();
    SqlDataReader dr = cmd.ExecuteReader(); 
    // Bind the reader to the GridView
    // You can also use a lighter control 
    // like the Repeater to display data
    GridView2.DataSource = dr;
    GridView2.DataBind();
    connection.Close();
    // Show the modalpopupextender
    ModalPopupExtender1.Show();
    
}
}
