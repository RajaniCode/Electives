#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

#endregion

namespace SimpleSequentialWorkFlow
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            workflowRuntime.StartRuntime();

            workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;

            Type type = typeof(SimpleSequentialWorkFlow.Workflow1);
            workflowRuntime.StartWorkflow(type);

            waitHandle.WaitOne();

            workflowRuntime.StopRuntime();
        }

        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            waitHandle.Set();
        }
    }
}
