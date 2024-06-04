namespace WF_CustomActivityCOntainer
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Activities;
    using System.Activities.Statements;
    using System.Collections.Generic;
    using System.Data;

    class Program
    {
        static void Main(string[] args)
        {

            DataSet Ds = new DataSet();
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            #region Pass The Parameter
            Dictionary<string, object> Par = new Dictionary<string, object>();
            Par.Add("dbServerName",".");
            Par.Add("dbName","Company");
            Par.Add("tbName","Employee");
            Par.Add("oDs",Ds); 
            #endregion


            WorkflowInstance myInstance = new WorkflowInstance(new WF_DataActivity(),Par);
            myInstance.OnCompleted = delegate(WorkflowCompletedEventArgs e) 
            {
                 Ds = (DataSet) e.Outputs["oDs"];
                Console.WriteLine(Ds.GetXml());
                syncEvent.Set(); 
            };
            myInstance.OnUnhandledException = delegate(WorkflowUnhandledExceptionEventArgs e)
            {
                Console.WriteLine(e.UnhandledException.ToString());
                return UnhandledExceptionAction.Terminate;
            };
            myInstance.OnAborted = delegate(WorkflowAbortedEventArgs e)
            {
                Console.WriteLine(e.Reason);
                syncEvent.Set();
            };

            myInstance.Run();

            syncEvent.WaitOne();

            Console.ReadLine();
        }
    }
}
