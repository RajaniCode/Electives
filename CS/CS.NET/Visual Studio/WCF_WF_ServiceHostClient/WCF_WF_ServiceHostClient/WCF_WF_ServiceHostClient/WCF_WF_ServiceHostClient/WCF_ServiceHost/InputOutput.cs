using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using System.Runtime.Serialization;


namespace WCF_ServiceHost
{
    [DataContract]
    public class clsInput
    {
        [DataMember]
        public string DbName { get; set; }
        [DataMember]
        public string TbName { get; set; }

        
    }

    [DataContract]
    public class clsOutput
    {
        [DataMember]
        public DataSet Ds { get; set; }
    }

    public class CDataAccess
    {
        public clsOutput RetDs(clsInput objIn)
        {
            string DbName = objIn.DbName;
            string TbName = objIn.TbName;

            SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=" + DbName + ";Integrated Security=SSPI");
            SqlDataAdapter AdTable = new SqlDataAdapter("Select * from " + TbName, Conn);

            DataSet Ds = new DataSet(); 

            AdTable.Fill(Ds,TbName);

            clsOutput objOp = new clsOutput();
            objOp.Ds = Ds;

            return objOp;
            
        }
        public DataSet GetDs(string dbName,string tbName)
        {
            string DbName = dbName;
            string TbName = tbName;

            SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=" + DbName + ";Integrated Security=SSPI");
            SqlDataAdapter AdTable = new SqlDataAdapter("Select * from " + TbName, Conn);

            clsOutput objOut = new clsOutput();
            DataSet Ds = new DataSet();

            AdTable.Fill(objOut.Ds, TbName);

            return Ds;

        }
    }

}
