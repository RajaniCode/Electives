using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ParentToChildCS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ParentForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label uxPrompt;
		private System.Windows.Forms.Button uxOpenForm;
		private System.Windows.Forms.Button uxOpenDialog;

		private ChildForm uxChildForm;
		private System.Windows.Forms.TextBox uxUserResponse;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Construct the Parent Form
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
			this.uxPrompt = new System.Windows.Forms.Label();
			this.uxUserResponse = new System.Windows.Forms.TextBox();
			this.uxOpenForm = new System.Windows.Forms.Button();
			this.uxOpenDialog = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// uxPrompt
			// 
			this.uxPrompt.Location = new System.Drawing.Point(8, 16);
			this.uxPrompt.Name = "uxPrompt";
			this.uxPrompt.Size = new System.Drawing.Size(168, 23);
			this.uxPrompt.TabIndex = 0;
			this.uxPrompt.Text = "Type the value for your variable:";
			// 
			// uxUserResponse
			// 
			this.uxUserResponse.Location = new System.Drawing.Point(176, 16);
			this.uxUserResponse.Name = "uxUserResponse";
			this.uxUserResponse.Size = new System.Drawing.Size(120, 20);
			this.uxUserResponse.TabIndex = 1;
			this.uxUserResponse.Text = "";
			this.uxUserResponse.TextChanged += new System.EventHandler(this.uxUserResponse_TextChanged);
			// 
			// uxOpenForm
			// 
			this.uxOpenForm.Location = new System.Drawing.Point(16, 48);
			this.uxOpenForm.Name = "uxOpenForm";
			this.uxOpenForm.Size = new System.Drawing.Size(120, 23);
			this.uxOpenForm.TabIndex = 2;
			this.uxOpenForm.Text = "Open Child Form";
			this.uxOpenForm.Click += new System.EventHandler(this.uxOpenForm_Click);
			// 
			// uxOpenDialog
			// 
			this.uxOpenDialog.Location = new System.Drawing.Point(144, 48);
			this.uxOpenDialog.Name = "uxOpenDialog";
			this.uxOpenDialog.Size = new System.Drawing.Size(152, 23);
			this.uxOpenDialog.TabIndex = 3;
			this.uxOpenDialog.Text = "Open Child Form as Dialog";
			this.uxOpenDialog.Click += new System.EventHandler(this.uxOpenDialog_Click);
			// 
			// ParentForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 86);
			this.Controls.Add(this.uxOpenDialog);
			this.Controls.Add(this.uxOpenForm);
			this.Controls.Add(this.uxUserResponse);
			this.Controls.Add(this.uxPrompt);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ParentForm";
			this.Text = "The Parent Form";
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
		/// Demonstrates how to pass a variable to a form when the form is
		/// opened.
		/// </summary>
		private void uxOpenForm_Click(object sender, System.EventArgs e)
		{
			// Get the value to be passed
			string parentValue = this.uxUserResponse.Text;

			// Create the child form and pass the value in the constructor
			this.uxChildForm = new ChildForm(parentValue);

			// Show the form which will display the user's value.
			this.uxChildForm.Show();
		}

		/// <summary>
		/// Demonstrates how to pass a variable to a dialog when the dialog is
		/// opened.
		/// </summary>
		/// <param name="sender">The object that triggered this event</param>
		/// <param name="e">The details of the event</param>
		private void uxOpenDialog_Click(object sender, System.EventArgs e)
		{
			// Get the value to be passed
			string parentValue = this.uxUserResponse.Text;

			// Create the child form.
			ChildForm child = new ChildForm(parentValue);

			// Show the form which will display the user's value.
			child.ShowDialog();
		}

		/// <summary>
		/// Demonstrates how to pass a variable to a child form while the form
		/// is already open.
		/// </summary>
		/// <param name="sender">The object that triggered this event</param>
		/// <param name="e">The details of the event</param>
		private void uxUserResponse_TextChanged(object sender, System.EventArgs e)
		{
			if (this.uxChildForm != null)
			{
				// Sets the property with the variable that needs to be passed.
				// In this case it is the value of the Text property from a
				// text box on the form. It could be any variable or value.
				this.uxChildForm.ValueFromParent = this.uxUserResponse.Text;
			}
		}


	}
}
