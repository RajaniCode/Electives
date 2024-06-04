using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient; 

namespace WCF_DataService
{
    public static class DbManager
    {
        static SqlConnection Conn;

        public static void OpenConnection()
        {
            Conn = new SqlConnection("Data Source=.\\dbServer;Initial Catalog=Company;Integrated Security=SSPI");
            Conn.Open(); 
        }

        public static DataTable GetAllRecords(string query)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = query;

            SqlDataReader Reader = Cmd.ExecuteReader();

            DataTable dtVal = new DataTable();
            dtVal.Load(Reader);

            return dtVal;
        }

        public static void PerformDML(string query) 
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = query;

            Cmd.ExecuteNonQuery();
        }

        public static void CloseConnection()
        {
            if(Conn.State== ConnectionState.Open)
            {
                Conn.Close ();
            }
        }
    }
}