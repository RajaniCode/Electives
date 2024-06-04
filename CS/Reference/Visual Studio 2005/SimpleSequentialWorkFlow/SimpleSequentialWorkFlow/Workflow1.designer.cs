using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
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
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.code1 = new System.Workflow.Activities.Code();
            this.code2 = new System.Workflow.Activities.Code();
            // 
            // code1
            // 
            this.code1.ID = "code1";
            this.code1.ExecuteCode += new System.EventHandler(this.MyActivity1);
            // 
            // code2
            // 
            this.code2.ID = "code2";
            this.code2.ExecuteCode += new System.EventHandler(this.MyActivity2);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.code1);
            this.Activities.Add(this.code2);
            this.DynamicUpdateCondition = null;
            this.ID = "Workflow1";

		}

		#endregion

        private Code code2;
        private Code code1;



    }
}
