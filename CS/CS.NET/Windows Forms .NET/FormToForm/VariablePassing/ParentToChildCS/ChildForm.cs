using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ParentToChildCS
{
	/// <summary>
	/// Summary description for ChildForm.
	/// </summary>
	public class ChildForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox uxParentValue;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constructs the ChildForm object.
		/// </summary>
		/// <param name="initialValue">Allows the caller to set up the initial 
		/// value in advance without having to construct the object then call
		/// ValueFromParent</param>
		public ChildForm(string initialValue)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			ValueFromParent = initialValue;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.uxParentValue = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "The value from the parent form:";
			// 
			// uxParentValue
			// 
			this.uxParentValue.Location = new System.Drawing.Point(184, 16);
			this.uxParentValue.Name = "uxParentValue";
			this.uxParentValue.ReadOnly = true;
			this.uxParentValue.Size = new System.Drawing.Size(144, 20);
			this.uxParentValue.TabIndex = 1;
			this.uxParentValue.Text = "";
			// 
			// ChildForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 46);
			this.Controls.Add(this.uxParentValue);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChildForm";
			this.Text = "Child Form";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// This is the property that receives the value from the parent form.
		/// </summary>
		public string ValueFromParent
		{
			set
			{
				// This could be setting a field variable, or in this case
				// it is setting the Text property of a control directly.
				this.uxParentValue.Text = value;
			}
		}
	}
}
