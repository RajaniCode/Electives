using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient; 
using BusinessDataObject;
using System.ServiceModel.MsmqIntegration;
using System.ServiceModel;
namespace WPF_WCFServiceHost
{
    public class CService : IService
    {

        #region IService Members
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void RegisterPatient(MsmqMessage<PatientMaster> objPatient)
        {
            SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=Medical;Integrated Security=SSPI");
            SqlCommand Cmd = new SqlCommand();
            string InsSql = null;
            Conn.Open(); 
            Cmd.Connection = Conn;

            PatientMaster objPat = objPatient.Body;

            InsSql = "Insert into PatientMaster Values(@PatientName,@PatientAddress,@PatientAge)";

            Cmd.CommandText = InsSql;
            Cmd.Parameters.AddWithValue("@PatientName", objPat.PatientName);
            Cmd.Parameters.AddWithValue("@PatientAddress", objPat.PatientAddress);
            Cmd.Parameters.AddWithValue("@PatientAge", objPat.PatientAge);

            Cmd.ExecuteNonQuery();

            Conn.Close();
            Conn.Dispose(); 
        }

        #endregion
    }
}
