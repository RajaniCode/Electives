namespace WindowsApplicationCodeDom
{
	partial class frmCodeDom
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmdGenerateCodeDom = new System.Windows.Forms.Button();
			this.txtCodeDom = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
// 
// cmdGenerateCodeDom
// 
			this.cmdGenerateCodeDom.Location = new System.Drawing.Point(36, 158);
			this.cmdGenerateCodeDom.Name = "cmdGenerateCodeDom";
			this.cmdGenerateCodeDom.Size = new System.Drawing.Size(194, 27);
			this.cmdGenerateCodeDom.TabIndex = 0;
			this.cmdGenerateCodeDom.Text = "Generate Code from CodeDom";
			this.cmdGenerateCodeDom.Click += new System.EventHandler(this.cmdGenerateCodeDom_Click);
// 
// txtCodeDom
// 
			this.txtCodeDom.AutoSize = false;
			this.txtCodeDom.Location = new System.Drawing.Point(24, 25);
			this.txtCodeDom.Multiline = true;
			this.txtCodeDom.Name = "txtCodeDom";
			this.txtCodeDom.Size = new System.Drawing.Size(220, 110);
			this.txtCodeDom.TabIndex = 1;
// 
// frmCodeDom
// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.txtCodeDom);
			this.Controls.Add(this.cmdGenerateCodeDom);
			this.Name = "frmCodeDom";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmdGenerateCodeDom;
		private System.Windows.Forms.TextBox txtCodeDom;
	}
}

