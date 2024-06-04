using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using System.Data.SqlClient;  

namespace WCF_Service
{
    public class Service : IService
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        SqlDataReader Reader;

        #region IService Members

        public Customer[] GetAllCustomers()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from Customers";
            Reader = Cmd.ExecuteReader();
            DataTable dtCustomers = new DataTable ();
            dtCustomers.Load (Reader);
            Customer[] arrCustomers = new Customer[dtCustomers.Rows.Count];
            int rowCount = 0;
            foreach (DataRow Dr in dtCustomers.Rows)
            {
                arrCustomers[rowCount] = new Customer();
                arrCustomers[rowCount].CustomerID = Convert.ToInt32(Dr["CustomerID"]);
                arrCustomers[rowCount].CustomerName = Dr["CustomerName"].ToString();
                arrCustomers[rowCount].Address = Dr["Address"].ToString();  
                arrCustomers[rowCount].City = Dr["City"].ToString();
                arrCustomers[rowCount].State = Dr["State"].ToString();
                arrCustomers[rowCount].Age = Convert.ToInt32(Dr["Age"]);
                rowCount++;
            }
            Conn.Close();
            Cmd.Dispose();
            Conn.Dispose();
            return arrCustomers;
        }

        #endregion
    }
}
