using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace WFP40_COMInterop_Enhancement
{
    public class Sales
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal Q1_Sales { get; set; }
        public decimal Q2_Sales { get; set; }
        public decimal Q3_Sales { get; set; }
        public decimal Q4_Sales { get; set; }
    }

    public class DataAccess
    {
        public ObservableCollection<Sales> GetSalesDetails()
        {
            SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            SqlDataAdapter AdSales = new SqlDataAdapter("Select * from Sales", Conn);
            DataSet Ds = new DataSet();
            AdSales.Fill(Ds,"Sales");

            ObservableCollection<Sales> lstSales = new ObservableCollection<Sales>();

            foreach (DataRow item in Ds.Tables["Sales"].Rows )
            {
                lstSales.Add(
                                new Sales() 
                                {
                                     CompanyId = Convert.ToInt32(item["CompanyId"]),
                                      CompanyName = item["CompanyName"].ToString(),
                                     Q1_Sales = Convert.ToDecimal(item["Q1"]),
                                     Q2_Sales = Convert.ToDecimal(item["Q2"]),
                                     Q3_Sales = Convert.ToDecimal(item["Q3"]),
                                     Q4_Sales = Convert.ToDecimal(item["Q4"])
                                }
                            );  
            }
            return lstSales;
        }
    }
}
