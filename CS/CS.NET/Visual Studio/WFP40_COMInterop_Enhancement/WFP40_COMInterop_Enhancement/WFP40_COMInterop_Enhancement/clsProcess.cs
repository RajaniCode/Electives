using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Diagnostics;
using System.Collections.ObjectModel;
 
namespace WFP40_COMInterop_Enhancement
{
    public class clsProcess
    {
        public string ProcessName { get; set; }
        public long MemoryUsage { get; set; }
    }

    public class ProcessInfo
    {
        public List<clsProcess> GetProcessUtilization()
        {
            List<clsProcess> lstProcess = new List<clsProcess>();

            var runningProcess = (from proc in Process.GetProcesses()
                                 select new clsProcess()
                                 {
                                     ProcessName = proc.ProcessName,
                                     MemoryUsage = proc.WorkingSet64 
                                 });

            lstProcess = runningProcess.ToList<clsProcess>();  
            return lstProcess;
        }
    }
}
