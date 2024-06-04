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

namespace WorkFlowException
{
    public sealed partial class Workflow1 : SequentialWorkflow
    {
		public Workflow1()
		{
			InitializeComponent();
		}

        private void raiseException(object sender, EventArgs e)
        {
            throw new ApplicationException("This is the exception");
        }

        public ApplicationException exception = new System.ApplicationException();

        private void handlexception(object sender, EventArgs e)
        {
            Console.WriteLine(myException.Message);
            Console.ReadLine();
        }

        public ApplicationException myException = new System.ApplicationException();
        public ApplicationException MyException = new System.ApplicationException();
	}

}
