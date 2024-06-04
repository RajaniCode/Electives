using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

namespace WF_TransactionScope
{
    public class clsDML
    {
        SqlConnection Conn_Bill, Conn_Insurance;
        SqlCommand Cmd_Bill, Cmd_Insurance;

        public void GenerateBill(int billNo, int patientId, string patientName, int billAmount)
        {
            Conn_Bill = new SqlConnection("Data Source=.;Initial Catalog=Medical;Integrated Security=SSPI");
            Conn_Bill.Open();
            Cmd_Bill = new SqlCommand();
            Cmd_Bill.Connection = Conn_Bill; 
            Cmd_Bill.CommandText = "Insert into BillMaster Values (@BillNo,@PatientId,@PatientName,@BillAmount)";

            Cmd_Bill.Parameters.AddWithValue("@BillNo", billNo);
            Cmd_Bill.Parameters.AddWithValue("@PatientId", patientId);
            Cmd_Bill.Parameters.AddWithValue("@PatientName", patientName);
            Cmd_Bill.Parameters.AddWithValue("@BillAmount", billAmount);
           
            Cmd_Bill.ExecuteNonQuery();
            Conn_Bill.Close();
        }

        public void SubmitClaim(int claimId,string patientName,int policyNo,int policyAmount,int claimAmount)
        {
            Conn_Insurance = new SqlConnection("Data Source=.;Initial Catalog=Insurance;Integrated Security=SSPI");
            Conn_Insurance.Open();
            Cmd_Insurance = new SqlCommand();
            Cmd_Insurance.Connection = Conn_Insurance;
            Cmd_Insurance.CommandText = "Insert into ClaimMaster Values (@ClaimId,@PatientName,@PolicyNo,@PolicyAmount,@ClaimAmount)";

            Cmd_Insurance.Parameters.AddWithValue("@ClaimId",claimId);
            Cmd_Insurance.Parameters.AddWithValue("@PatientName", patientName);
            Cmd_Insurance.Parameters.AddWithValue("@PolicyNo", policyNo);
            Cmd_Insurance.Parameters.AddWithValue("@PolicyAmount", policyAmount);
            Cmd_Insurance.Parameters.AddWithValue("@ClaimAmount", claimAmount);

            Cmd_Insurance.ExecuteNonQuery();
            Conn_Insurance.Close();
        }
    }
}
