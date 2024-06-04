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

namespace SequentialWorkFlowConditions
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
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.conditionedActivityGroup1 = new System.Workflow.Activities.ConditionedActivityGroup();
            this.code1 = new System.Workflow.Activities.Code();
            this.code2 = new System.Workflow.Activities.Code();
            // 
            // conditionedActivityGroup1
            // 
            this.conditionedActivityGroup1.Activities.Add(this.code2);
            this.conditionedActivityGroup1.Activities.Add(this.code1);
            this.conditionedActivityGroup1.ID = "conditionedActivityGroup1";
            codecondition1.Condition += new System.Workflow.Activities.ConditionalExpression(this.exit);
            this.conditionedActivityGroup1.UntilCondition = codecondition1;
            ruleconditionreference2.Condition = "old";
            // 
            // code1
            // 
            this.code1.ID = "code1";
            this.code1.ExecuteCode += new System.EventHandler(this.young1);
            this.code1.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference2);
            ruleconditionreference1.Condition = "young";
            // 
            // code2
            // 
            this.code2.ID = "code2";
            this.code2.ExecuteCode += new System.EventHandler(this.old1);
            this.code2.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference1);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.conditionedActivityGroup1);
            this.DynamicUpdateCondition = null;
            this.ID = "Workflow1";

		}

		#endregion

        private ConditionedActivityGroup conditionedActivityGroup1;
        private Code code1;
        private Code code2;





















    }
}
