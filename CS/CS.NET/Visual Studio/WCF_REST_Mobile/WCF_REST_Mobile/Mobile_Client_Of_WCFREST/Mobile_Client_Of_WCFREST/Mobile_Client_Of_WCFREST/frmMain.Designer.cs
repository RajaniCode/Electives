namespace Mobile_Client_Of_WCFREST
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.btnDML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(18, 46);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(190, 44);
            this.btnGetAll.TabIndex = 0;
            this.btnGetAll.Text = "Get All Employees";
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // btnDML
            // 
            this.btnDML.Location = new System.Drawing.Point(17, 148);
            this.btnDML.Name = "btnDML";
            this.btnDML.Size = new System.Drawing.Size(190, 47);
            this.btnDML.TabIndex = 1;
            this.btnDML.Text = "Insert or Update";
            this.btnDML.Click += new System.EventHandler(this.btnDML_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnDML);
            this.Controls.Add(this.btnGetAll);
            this.Menu = this.mainMenu1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button btnDML;
    }
}