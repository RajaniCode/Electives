using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {        
        [WebMethod]
        public static List<ProcessInfo> GetRunningProcesses()
        {
            var query = (from p in System.Diagnostics.Process.GetProcesses()
                         select new ProcessInfo
                         {
                             ProcessName = p.ProcessName,
                             MainWindowTitle = p.MainWindowTitle,
                             PagedMemorySize64 = p.PagedMemorySize64                             
                         }).ToList();
            return query;
        }
    }
}
