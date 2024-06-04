using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WCF_ServiceSalesData
{
    public class CSalesData : ISalesData
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        SqlDataReader Reader;

        #region ISalesData Members

       public List<SalesData> GetSalesDetsils()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI"); 
            List<SalesData> lsySalesData = new List<SalesData>();
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select  ItemName,SalesQty from SalesData";
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                lsySalesData.Add(new SalesData() { ItemName = Reader["ItemName"].ToString(), SalesQty = Convert.ToInt32(Reader["SalesQty"]) });
            }
            Reader.Close();
            Conn.Close();
            return lsySalesData;
        }

        #endregion
    }
}
