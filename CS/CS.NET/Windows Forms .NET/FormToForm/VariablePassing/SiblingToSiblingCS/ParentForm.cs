using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SiblingToSiblingCS
{
	/// <summary>
	/// The parent form is the form opened on application start.
	/// </summary>
	public class ParentForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// A reference to Child 'A'
		/// </summary>
		private ChildAForm childA;

		/// <summary>
		/// A reference to Child 'B'
		/// </summary>
		private ChildBForm childB;

		/// <summary>
		/// The button that opens Child 'A'
		/// </summary>
		private System.Windows.Forms.Button uxOpenChildA;

		/// <summary>
		/// The button that opens Child 'B'
		/// </summary>
		private System.Windows.Forms.Button uxOpenChildB;

		/// <summary>
		/// Label next to the Child 'A' value text box
		/// </summary>
		private System.Windows.Forms.Label uxChildAValueLabel;

		/// <summary>
		/// Label next to the Child 'B' value text box
		/// </summary>
		private System.Windows.Forms.Label uxChildBValueLabel;

		/// <summary>
		/// The readonly text box that will display the value of Child 'A'
		/// </summary>
		private System.Windows.Forms.TextBox uxChildAValue;

		/// <summary>
		/// The readonly text box that will display the value of Child 'B'
		/// </summary>
		private System.Windows.Forms.TextBox uxChildBValue;
		
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constructs the parent form
		/// </summary>
		public ParentForm()
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
				if (components != null) 
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
			this.uxOpenChildA = new System.Windows.Forms.Button();
			this.uxOpenChildB = new System.Windows.Forms.Button();
			this.uxChildAValueLabel = new System.Windows.Forms.Label();
			this.uxChildBValueLabel = new System.Windows.Forms.Label();
			this.uxChildAValue = new System.Windows.Forms.TextBox();
			this.uxChildBValue = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// uxOpenChildA
			// 
			this.uxOpenChildA.Location = new System.Drawing.Point(8, 16);
			this.uxOpenChildA.Name = "uxOpenChildA";
			this.uxOpenChildA.Size = new System.Drawing.Size(104, 23);
			this.uxOpenChildA.TabIndex = 0;
			this.uxOpenChildA.Text = "Open Child \'A\'";
			this.uxOpenChildA.Click += new System.EventHandler(this.uxOpenChildA_Click);
			// 
			// uxOpenChildB
			// 
			this.uxOpenChildB.Location = new System.Drawing.Point(120, 16);
			this.uxOpenChildB.Name = "uxOpenChildB";
			this.uxOpenChildB.Size = new System.Drawing.Size(104, 23);
			this.uxOpenChildB.TabIndex = 1;
			this.uxOpenChildB.Text = "Open Child \'B\'";
			this.uxOpenChildB.Click += new System.EventHandler(this.uxOpenChildB_Click);
			// 
			// uxChildAValueLabel
			// 
			this.uxChildAValueLabel.Location = new System.Drawing.Point(8, 48);
			this.uxChildAValueLabel.Name = "uxChildAValueLabel";
			this.uxChildAValueLabel.Size = new System.Drawing.Size(100, 16);
			this.uxChildAValueLabel.TabIndex = 2;
			this.uxChildAValueLabel.Text = "Child \'A\' Value:";
			// 
			// uxChildBValueLabel
			// 
			this.uxChildBValueLabel.Location = new System.Drawing.Point(120, 48);
			this.uxChildBValueLabel.Name = "uxChildBValueLabel";
			this.uxChildBValueLabel.Size = new System.Drawing.Size(100, 16);
			this.uxChildBValueLabel.TabIndex = 3;
			this.uxChildBValueLabel.Text = "Child \'B\' Value:";
			// 
			// uxChildAValue
			// 
			this.uxChildAValue.Location = new System.Drawing.Point(8, 64);
			this.uxChildAValue.Name = "uxChildAValue";
			this.uxChildAValue.ReadOnly = true;
			this.uxChildAValue.TabIndex = 4;
			this.uxChildAValue.Text = "";
			// 
			// uxChildBValue
			// 
			this.uxChildBValue.Location = new System.Drawing.Point(120, 64);
			this.uxChildBValue.Name = "uxChildBValue";
			this.uxChildBValue.ReadOnly = true;
			this.uxChildBValue.TabIndex = 5;
			this.uxChildBValue.Text = "";
			// 
			// ParentForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 96);
			this.Controls.Add(this.uxChildBValue);
			this.Controls.Add(this.uxChildAValue);
			this.Controls.Add(this.uxChildBValueLabel);
			this.Controls.Add(this.uxChildAValueLabel);
			this.Controls.Add(this.uxOpenChildB);
			this.Controls.Add(this.uxOpenChildA);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ParentForm";
			this.Text = "Parent Form";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ParentForm());
		}

		/// <summary>
		/// The event handler for the Click event for the button that opens
		/// Child 'A'
		/// </summary>
		/// <param name="sender">The object that fired the event</param>
		/// <param name="e">Arguments for the event</param>
		private void uxOpenChildA_Click(object sender, System.EventArgs e)
		{
			// Create the child form
			this.childA = new ChildAForm();

			// Add an event so that the parent form is informed when the child
			// is updated.
			this.childA.ValueUpdated += new ValueUpdatedEventHandler(childA_ValueUpdated);

			// Add an event to each child form so that they are notified of each
			// others changes.
			if (this.childB != null)
			{
				this.childA.ValueUpdated += new ValueUpdatedEventHandler(this.childB.childA_ValueUpdated);
				this.childB.ValueUpdated += new ValueUpdatedEventHandler(this.childA.childB_ValueUpdated);
			}

			this.childA.Show();
		}

		/// <summary>
		/// The event handler for the Click event for the button that opens
		/// Child 'B'
		/// </summary>
		/// <param name="sender">The object that fired the event</param>
		/// <param name="e">Arguments for the event</param>
		private void uxOpenChildB_Click(object sender, System.EventArgs e)
		{
			this.childB = new ChildBForm();
			this.childB.ValueUpdated += new ValueUpdatedEventHandler(childB_ValueUpdated);
			if (this.childA != null)
			{
				this.childA.ValueUpdated += new ValueUpdatedEventHandler(this.childB.childA_ValueUpdated);
				this.childB.ValueUpdated += new ValueUpdatedEventHandler(this.childA.childB_ValueUpdated);
			}
			this.childB.Show();
		}

		/// <summary>
		/// The event handler for when Child 'A' updated its value
		/// </summary>
		/// <param name="sender">The object that fired the event</param>
		/// <param name="e">The arguments for the event</param>
		private void childA_ValueUpdated(object sender, ValueUpdatedEventArgs e)
		{
			// Update the text box on this form (the parent) with the new value
			this.uxChildAValue.Text = e.NewValue;
		}

		/// <summary>
		/// The event handler for when Child 'B' updated its value
		/// </summary>
		/// <param name="sender">The object that fired the event</param>
		/// <param name="e">The arguments for the event</param>
		private void childB_ValueUpdated(object sender, ValueUpdatedEventArgs e)
		{
			this.uxChildBValue.Text = e.NewValue;
		}
	}
}
