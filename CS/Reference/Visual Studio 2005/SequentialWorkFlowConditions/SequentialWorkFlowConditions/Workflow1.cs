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
using System.Workflow.ComponentModel;
namespace SequentialWorkFlowConditions
{
    [RuleConditionsAttribute(typeof(SequentialWorkFlowConditions.Workflow1))]
    public sealed partial class Workflow1 : SequentialWorkflow
    {
        public int age = 0;
		public Workflow1()
		{
			InitializeComponent();
		}
        private bool exit(object sender, EventArgs objargs)
        {
            Console.WriteLine("Enter your age , enter -1 to exit");
            age = Convert.ToInt16(Console.ReadLine());
            if (age == -1)
            {
              return true;
            }
            else
            {
                return false;
            }
        }
        private void old1(object sender, EventArgs e)
        {
            Console.WriteLine("You are Old");
        }

        private void young1(object sender, EventArgs e)
        {
            Console.WriteLine("You are Young");
        }
        
	}

}
