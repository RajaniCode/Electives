using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SiblingToSiblingCS
{
	/// <summary>
	/// Summary description for ChildAForm.
	/// </summary>
	public class ChildAForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// The label next to the text box that show the value
		/// that the user typed in to this form.
		/// </summary>
		private System.Windows.Forms.Label uxMyValueLabel;

		/// <summary>
		/// The textbox that the user can type into.
		/// </summary>
		private System.Windows.Forms.TextBox uxMyValue;

		/// <summary>
		/// The label next to the text box that shows the value that the user
		/// typed in to the sibling form.
		/// </summary>
		private System.Windows.Forms.Label uxOtherValueLabel;

		/// <summary>
		/// The readonly text box that is updated when the user types into
		/// the text box on the sibling form.
		/// </summary>
		private System.Windows.Forms.TextBox uxOtherValue;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// The event that interested parties (observers) can register with
		/// if they want to know when the user updates the value.
		/// </summary>
		public event ValueUpdatedEventHandler ValueUpdated;

		/// <summary>
		/// Constructs the form
		/// </summary>
		public ChildAForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			this.uxMyValueLabel = new System.Windows.Forms.Label();
			this.uxMyValue = new System.Windows.Forms.TextBox();
			this.uxOtherValueLabel = new System.Windows.Forms.Label();
			this.uxOtherValue = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// uxMyValueLabel
			// 
			this.uxMyValueLabel.Location = new System.Drawing.Point(8, 8);
			this.uxMyValueLabel.Name = "uxMyValueLabel";
			this.uxMyValueLabel.Size = new System.Drawing.Size(56, 23);
			this.uxMyValueLabel.TabIndex = 0;
			this.uxMyValueLabel.Text = "My Value:";
			// 
			// uxMyValue
			// 
			this.uxMyValue.Location = new System.Drawing.Point(88, 8);
			this.uxMyValue.Name = "uxMyValue";
			this.uxMyValue.Size = new System.Drawing.Size(192, 20);
			this.uxMyValue.TabIndex = 1;
			this.uxMyValue.Text = "";
			this.uxMyValue.TextChanged += new System.EventHandler(this.uxMyValue_TextChanged);
			// 
			// uxOtherValueLabel
			// 
			this.uxOtherValueLabel.Location = new System.Drawing.Point(8, 40);
			this.uxOtherValueLabel.Name = "uxOtherValueLabel";
			this.uxOtherValueLabel.Size = new System.Drawing.Size(72, 23);
			this.uxOtherValueLabel.TabIndex = 2;
			this.uxOtherValueLabel.Text = "Other Value:";
			// 
			// uxOtherValue
			// 
			this.uxOtherValue.Location = new System.Drawing.Point(88, 40);
			this.uxOtherValue.Name = "uxOtherValue";
			this.uxOtherValue.ReadOnly = true;
			this.uxOtherValue.Size = new System.Drawing.Size(192, 20);
			this.uxOtherValue.TabIndex = 3;
			this.uxOtherValue.Text = "";
			// 
			// ChildAForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 70);
			this.Controls.Add(this.uxOtherValue);
			this.Controls.Add(this.uxOtherValueLabel);
			this.Controls.Add(this.uxMyValue);
			this.Controls.Add(this.uxMyValueLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChildAForm";
			this.Text = "Child \'A\' Form";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Event handler that is called when the value changes in the sibling
		/// form.
		/// </summary>
		/// <param name="sender">The object that fired the event</param>
		/// <param name="e">The event arguments that contain the new value</param>
		public void childB_ValueUpdated(object sender, ValueUpdatedEventArgs e)
		{
			// Update the text box on this form (child A) with the new value
			this.uxOtherValue.Text = e.NewValue;
		}

		/// <summary>
		/// Event handler that is called when the user types into the text box
		/// on this form.
		/// </summary>
		/// <param name="sender">The object that fired the event</param>
		/// <param name="e">The event arguments</param>
		/// <event name="ValueUpdated">Fires the <b>ValueUpdated</b> event in
		/// order that observers are told when the value changes</event>
		private void uxMyValue_TextChanged(object sender, System.EventArgs e)
		{
			string newValue = this.uxMyValue.Text;
			ValueUpdatedEventArgs valueArgs = new ValueUpdatedEventArgs(newValue);
			ValueUpdated(this, valueArgs);
		}
	}
}
