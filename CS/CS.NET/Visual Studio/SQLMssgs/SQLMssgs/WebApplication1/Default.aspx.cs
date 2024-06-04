using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCustomers();
        }

        private void GetCustomers()
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString))
            {
                cn.Open();
                cn.InfoMessage += delegate(object sender, SqlInfoMessageEventArgs e) 
                                {                                    
                                    txtMessages.Text += "\n" + e.Message;                                    
                                };

                SqlCommand cmd = new SqlCommand("CustOrderHist", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CustomerID", "ALFKI"));
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string productName = dr.GetString(dr.GetOrdinal("ProductName"));       
                    }
                }
            }
        }
    }
}
