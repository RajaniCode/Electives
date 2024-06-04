using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SimpleSequentialWorkFlow
{
    public sealed partial class Workflow1 : SequentialWorkflow
    {
		public Workflow1()
		{
			InitializeComponent();
		}
        private void MyActivity1(object sender, EventArgs e)
        {
            Console.WriteLine("This is my First Activity");
        }
        private void MyActivity2(object sender, EventArgs e)
        {
            Console.WriteLine("This is my Second Activity");
            Console.ReadLine();
        }
	}

}
