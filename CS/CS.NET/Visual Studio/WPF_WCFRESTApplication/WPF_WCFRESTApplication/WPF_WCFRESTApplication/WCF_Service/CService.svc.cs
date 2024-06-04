using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using clsDataContracts;

namespace WCF_Service
{
    public class CService : IService
    {

        SqlConnection Conn;
        SqlCommand Cmd;
        SqlDataReader Reader;

        #region IService Members

        public List<clsEmployee> GetAllEmployee()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from Employee";
            List<clsEmployee> lstEmp = new List<clsEmployee>();

            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                lstEmp.Add
                    (
                        new clsEmployee() 
                        {
                            EmpNo=Convert.ToInt32(Reader["EmpNo"]),
                            EmpName=Reader["EmpName"].ToString(),
                            Salary=Convert.ToInt32(Reader["Salary"]),
                            DeptNo=Convert.ToInt32(Reader["DeptNo"])
                        }
                    );  
            }
            Reader.Close();
            Conn.Close();
            return lstEmp;
        }

        #endregion

        #region IService Members


        public List<clsSales> GetSalesDetails()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            List<clsSales> lstSales = new List<clsSales>();
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from Sales";

            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                lstSales.Add
                    (
                            new clsSales()
                            {
                                CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                                CompanyName = Reader["CompanyName"].ToString(),
                                Q1 = Convert.ToInt32(Reader["Q1"]),
                                Q2 = Convert.ToInt32(Reader["Q2"]),
                                Q3 = Convert.ToInt32(Reader["Q3"]),
                                Q4 = Convert.ToInt32(Reader["Q4"])
                            }
                    );  
            }
            Reader.Close();
            Conn.Close(); 

            return lstSales;
        }

        public List<clsSalesData> GetSalesData()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            List<clsSalesData> lstSalesData = new List<clsSalesData>();
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select  Top 8 ItemName,SalesQty from SalesData";
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                lstSalesData.Add
                    (
                        new clsSalesData() 
                            {
                                ItemName = Reader["ItemName"].ToString(), 
                                SalesQty = Convert.ToInt32(Reader["SalesQty"]) 
                            }
                     );
            }
            Reader.Close();
            Conn.Close();
            return lstSalesData; 
        }

        #endregion

        #region IService Members


        public List<clsStatewiseSales> GetStatewiseSales()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
            List<clsStatewiseSales> lstStatewiseSales = new List<clsStatewiseSales>();
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;

            Cmd.CommandText = "Select  StateName,Salesquantity from Statewisesales";
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                lstStatewiseSales.Add
                    (
                        new clsStatewiseSales()
                        {
                             StateName = Reader["StateName"].ToString(),
                             SalesQuantity = Convert.ToInt32(Reader["Salesquantity"])
                        }
                     );
            }
            Reader.Close();
            Conn.Close();
            return lstStatewiseSales;

        }

        #endregion
    }
}
