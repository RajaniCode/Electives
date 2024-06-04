using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Web;


namespace IntroAjax
{
    public partial class HelperMethods
    {
        // METHOD: GetCustomer
        public static Customer GetCustomer(SqlDataReader reader)
        {
            Customer cust = new Customer();
            if (reader.IsClosed)
                reader.Read();

            cust.ID = reader["customerid"].ToString();
            cust.CompanyName = reader["companyname"].ToString();
            cust.ContactName = reader["contactname"].ToString();
            cust.ContactTitle = reader["contacttitle"].ToString();

            cust.City = reader["city"].ToString();
            cust.Street = reader["address"].ToString();
            cust.Country = reader["country"].ToString(); 
            cust.Region = reader["region"].ToString();
            cust.PostalCode = reader["postalcode"].ToString();
            cust.Phone = reader["phone"].ToString(); 
            cust.Fax = reader["fax"].ToString();

            return cust;
        }

        // METHOD: FillCustomerList
        public static void FillCustomerList(CustomerCollection coll, SqlDataReader reader)
        {
            while (reader.Read())
            {
                Customer cust = HelperMethods.GetCustomer(reader);
                coll.Add(cust);
            }
        }


        public static string ComposeOrdersAsGrid(SqlDataReader reader)
        {
            DataGrid grid = new DataGrid();
            grid.DataSource = reader;
            grid.DataBind();

            StringWriter writer = new StringWriter();
            HtmlTextWriter html = new HtmlTextWriter(writer);
            grid.RenderControl(html);
            return writer.ToString();
        }

    }
}