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

namespace WorkflowSeq
{
    public partial class Workflow1 :  SequentialWorkflow
    {
        public int i;

        private void Mycode3(object sender, EventArgs e)
        {
            Console.WriteLine("This is code 3");
        }

        private void Mycode1(object sender, EventArgs e)
        {
            Console.WriteLine("This is code 1");
        }
    }
}
