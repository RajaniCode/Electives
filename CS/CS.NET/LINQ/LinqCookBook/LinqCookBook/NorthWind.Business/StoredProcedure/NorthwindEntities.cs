using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Data.Objects.DataClasses;
using System.Data;

namespace NorthWind.Business.EF.StoredProcedure
{
    public partial class NorthwindEntities
    {
        private T ExecuteFunction<T>(string functionname,DbParameter[] parameters) where T:struct
        {
            DbCommand cmd = ((EntityConnection)this.Connection).CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);
            cmd.CommandText = this.DefaultContainerName + "." + functionname;
            try
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }    
               var obj = cmd.ExecuteScalar();
               return (T)obj;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        private void ExecuteNonQuery(string functionname, DbParameter[] parameters)
        {
            DbCommand cmd = this.Connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);
            cmd.CommandText = this.DefaultContainerName + "." + functionname;
            if (cmd.Connection.State == System.Data.ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();
        }
        public void UpdateCustTotal(string custid)
        {
             var param = new EntityParameter("custid", System.Data.DbType.String);
            param.Value = custid;
            this.ExecuteNonQuery("UpdateCusTotal", new[]{param});
        }
        public void UpdateCustomerSummary(string custid)
        {
            var param = new EntityParameter("custid", System.Data.DbType.String);
            param.Value = custid;
            this.ExecuteNonQuery("UpdateCustomerSummary", new[] { param });
        }

        public decimal TotalSalesForCust(string custid)
        {
            var param = new EntityParameter("custid", System.Data.DbType.String);
            param.Value = custid;
            return ExecuteFunction<decimal>("TotalSalesForCust", new[] { param });
        }

        public void GetCustStats(string custid, ref int totalorders, ref decimal totalpurchases)
        {
            var dbparams = new DbParameter[]
            {
                new EntityParameter{ParameterName="custid",DbType= DbType.String,Value=custid},
                new EntityParameter{ParameterName="TotalOrders",DbType= System.Data.DbType.Int32,Direction = ParameterDirection.Output},
                new EntityParameter{ParameterName="TotalPurchases",DbType= System.Data.DbType.Decimal,Direction = ParameterDirection.Output}
            };
            ExecuteNonQuery("CustStats", dbparams);
            totalorders = Convert.ToInt32(dbparams[1].Value);
            totalpurchases = Convert.ToDecimal(dbparams[2].Value);
        }
    }
    
}
