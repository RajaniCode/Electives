using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtId1.Attributes.Add("onblur", "javascript:CallMe('" + txtId1.ClientID + "', '" + txtContact1.ClientID + "')");
            txtId2.Attributes.Add("onblur", "javascript:CallMe('" + txtId2.ClientID + "', '" + txtContact2.ClientID + "')");
        }
    }

    [System.Web.Services.WebMethod]
    public static string GetContactName(string custid)
    {
        if (custid == null || custid.Length == 0)
            return String.Empty;
        SqlConnection conn = null;
        try
        {
            string connection = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            conn = new SqlConnection(connection);
            string sql = "Select ContactName from Customers where CustomerId = @CustID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("CustID", custid);
            conn.Open();
            string contNm = Convert.ToString(cmd.ExecuteScalar());
            return contNm;
        }
        catch (SqlException ex)
        {
            return "error";
        }
        finally
        {
            conn.Close();
        }
    }

   
}