using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;
using System.Workflow.Runtime;
namespace SimpleWorkFlowSampleManual
{
    class mySequentialWorkFlow : SequentialWorkflow
    {
        public  mySequentialWorkFlow()
        {
            
            Code codeActivity1 = new Code();
            codeActivity1.ExecuteCode += new EventHandler(codeActivity1_ExecuteCode);
            
            Code codeActivity2 = new Code();
            codeActivity2.ExecuteCode += new EventHandler(codeActivity2_ExecuteCode);
            this.Activities.Add(codeActivity1);
            this.Activities.Add(codeActivity2);
        }
        private void codeActivity1_ExecuteCode(object obj, EventArgs objargs)
        {
            Console.WriteLine("This is the first activity to be performed");
        }
        private void codeActivity2_ExecuteCode(object obj, EventArgs objargs)
        {
            Console.WriteLine("This is our second activity to be performed");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowRuntime objWorkFlowRuntime = new WorkflowRuntime();

            objWorkFlowRuntime.StartRuntime();

            WorkflowInstance objwrkInstance = 
            objWorkFlowRuntime.StartWorkflow(typeof(mySequentialWorkFlow));

            Console.ReadLine();

            objwrkInstance.Unload();
            objWorkFlowRuntime.StopRuntime();
        }
    }
}
