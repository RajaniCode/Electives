using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Data;
using System.Data.SqlClient;


namespace WF_CustomDataActivity
{
    public class GetAllDataActivity:CodeActivity<string>
    {
        InArgument<string> _DbServerName;

        public InArgument<string> DbServerName
        {
            get { return _DbServerName; }
            set { _DbServerName = value; }
        }
        InArgument<string> _DbName;

        public InArgument<string> DbName
        {
            get { return _DbName; }
            set { _DbName = value; }
        }
        InArgument<string> _TbName;

        public InArgument<string> TbName
        {
            get { return _TbName; }
            set { _TbName = value; }
        }

        OutArgument<DataSet> _Ds;

        public OutArgument<DataSet> Ds
        {
            get { return _Ds; }
            set { _Ds = value; }
        } 

        protected override void Execute(CodeActivityContext context)
        {
            string dbServerName = DbServerName.Get(context);
            string dbName = DbName.Get(context);
            string tbName = TbName.Get(context);
            DataSet oDs = Ds.Get(context); 

            SqlConnection Conn = new SqlConnection("Data Source=" + dbServerName + ";Initial Catalog=" + dbName +";Integrated Security=SSPI");
            SqlDataAdapter AdTanble = new SqlDataAdapter("Select * from " + tbName, Conn);
            AdTanble.Fill(oDs, tbName);  
        }

        

    }
}
