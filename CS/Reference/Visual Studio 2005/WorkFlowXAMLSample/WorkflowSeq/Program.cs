#region Using directives

using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Activities;
using System.Workflow.ComponentModel.Compiler;
#endregion

namespace WorkflowSeq
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            workflowRuntime.StartRuntime();

            workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;

            Type type = typeof(Workflow1);
            workflowRuntime.StartWorkflow(type);

            Console.ReadLine();
            waitHandle.WaitOne();

            workflowRuntime.StopRuntime();



            //TypeProvider typeprov = new TypeProvider(workflowRuntime);
            //typeprov.AddAssemblyReference(@"C:\WorkFlow\WorkFlowXAMLSample\WorkflowSeq\bin\Debug\WorkFlow1.dll");

            //CreateXoml();

            //workflowRuntime.AddService(typeprov);
            //workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
            //WorkflowMarkupSerializer objSerializer = new WorkflowMarkupSerializer();
            //TextReader objTextReader = new StreamReader(@"C:\WorkFlow\WorkFlowXAMLSample\WorkFlow1\Workflow1.xoml");
            //SequentialWorkflow obj = (SequentialWorkflow) objSerializer.Deserialize(objTextReader);

        }

        private static void CreateXoml()
        {
            Workflow1 objwrk1 = new Workflow1();

            WorkflowMarkupSerializer objSerializer = new WorkflowMarkupSerializer();
            TextWriter objTextWriter = new StreamWriter(@"c:\MyWorkFlow.xoml");
            objSerializer.Serialize(objwrk1, objTextWriter);
            objTextWriter.Close();

            TextReader objTextReader = new StreamReader(@"c:\MyWorkFlow.xoml");
            Workflow1 objwrk2 = (Workflow1)objSerializer.Deserialize(objTextReader);

            objTextReader.Close();

        }
        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            waitHandle.Set();
        }
    }
}
