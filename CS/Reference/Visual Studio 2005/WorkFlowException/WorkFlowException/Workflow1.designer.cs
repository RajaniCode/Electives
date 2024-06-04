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

namespace WorkFlowException
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.code1 = new System.Workflow.Activities.Code();
            this.exceptionHandlers1 = new System.Workflow.Activities.ExceptionHandlers();
            this.compensationHandler1 = new System.Workflow.Activities.CompensationHandler();
            this.eventHandlers1 = new System.Workflow.Activities.EventHandlers();
            this.exceptionHandler1 = new System.Workflow.Activities.ExceptionHandler();
            this.code2 = new System.Workflow.Activities.Code();
            // 
            // code1
            // 
            this.code1.ID = "code1";
            this.code1.ExecuteCode += new System.EventHandler(this.raiseException);
            // 
            // exceptionHandlers1
            // 
            this.exceptionHandlers1.Activities.Add(this.exceptionHandler1);
            this.exceptionHandlers1.ID = "exceptionHandlers1";
            // 
            // compensationHandler1
            // 
            this.compensationHandler1.ID = "compensationHandler1";
            // 
            // eventHandlers1
            // 
            this.eventHandlers1.ID = "eventHandlers1";
            activitybind1.ID = "/Workflow";
            activitybind1.Path = "myException";
            // 
            // exceptionHandler1
            // 
            this.exceptionHandler1.Activities.Add(this.code2);
            this.exceptionHandler1.ID = "exceptionHandler1";
            this.exceptionHandler1.Type = typeof(System.ApplicationException);
            this.exceptionHandler1.SetBinding(System.Workflow.Activities.ExceptionHandler.VariableProperty, ((System.Workflow.ComponentModel.Bind)(activitybind1)));
            // 
            // code2
            // 
            this.code2.ID = "code2";
            this.code2.ExecuteCode += new System.EventHandler(this.handlexception);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.code1);
            this.Activities.Add(this.exceptionHandlers1);
            this.Activities.Add(this.compensationHandler1);
            this.Activities.Add(this.eventHandlers1);
            this.DynamicUpdateCondition = null;
            this.ID = "Workflow1";

		}

		#endregion

        private CompensationHandler compensationHandler1;
        private EventHandlers eventHandlers1;
        private ExceptionHandlers exceptionHandlers1;
        private ExceptionHandler exceptionHandler1;
        private Code code2;
        private Code code1;






    }
}
