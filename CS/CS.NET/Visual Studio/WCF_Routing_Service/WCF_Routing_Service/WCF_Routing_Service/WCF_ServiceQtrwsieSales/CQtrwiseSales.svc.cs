using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WCF_ServiceQtrwsieSales
{
    public class CQtrwiseSales : IQtrwiseSales
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        SqlDataReader Reader;

        #region IQtrwiseSales Members

        public List<Sales> GetSalesDetsils()
        {
            List<Sales> lstSales = new List<Sales>();
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            Conn.Open();
            Cmd = new SqlCommand("Select * from Sales", Conn);

            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                lstSales.Add
                    (
                    new Sales() 
                            {
                                CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                                CompanyName=Reader["CompanyName"].ToString(),
                                Q1=Convert.ToInt32(Reader["Q1"]) ,
                                Q2=Convert.ToInt32(Reader["Q2"]),
                                Q3=Convert.ToInt32(Reader["Q3"]),
                                Q4=Convert.ToInt32(Reader["Q4"])
                            }
                    );  
            }
           
            Conn.Close();

            return lstSales; 
        }

        

        #endregion
    }
}
