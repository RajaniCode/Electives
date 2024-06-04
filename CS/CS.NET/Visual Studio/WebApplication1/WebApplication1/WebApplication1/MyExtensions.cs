using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace WebApplication1
{
    public static class MyExtensions
    {
        public static List<T> LinqCache<T>(this Table<T> query) where T : class
        {
            string tableName = query.Context.Mapping.GetTable(typeof(T)).TableName;
            List<T> result = HttpContext.Current.Cache[tableName] as List<T>;

            if (result == null)
            {
                using (SqlConnection cn = new SqlConnection(query.Context.Connection.ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(query.Context.GetCommand(query).CommandText, cn);
                    cmd.Notification = null;
                    cmd.NotificationAutoEnlist = true;
                    
                    SqlCacheDependencyAdmin.EnableNotifications(query.Context.Connection.ConnectionString);
                    if (!SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(query.Context.Connection.ConnectionString).Contains(tableName))
                    {
                        SqlCacheDependencyAdmin.EnableTableForNotifications(query.Context.Connection.ConnectionString, tableName);
                    }                    
                    
                    SqlCacheDependency dependency = new SqlCacheDependency(cmd);
                    cmd.ExecuteNonQuery();
                    HttpContext.Current.Cache.Insert(tableName, query.ToList(), dependency);
                }
            }
            return result;
        }
    }
}
