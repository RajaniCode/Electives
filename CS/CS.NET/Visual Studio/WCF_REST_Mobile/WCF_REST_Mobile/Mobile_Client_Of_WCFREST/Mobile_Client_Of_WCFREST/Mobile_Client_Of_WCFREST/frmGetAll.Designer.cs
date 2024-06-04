namespace Mobile_Client_Of_WCFREST
{
    partial class frmGetAll
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
            this.dgEmployee = new System.Windows.Forms.DataGrid();
            this.SuspendLayout();
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(30, 14);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(191, 32);
            this.btnGetAll.TabIndex = 0;
            this.btnGetAll.Text = "Get All Employees";
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // dgEmployee
            // 
            this.dgEmployee.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgEmployee.Location = new System.Drawing.Point(9, 53);
            this.dgEmployee.Name = "dgEmployee";
            this.dgEmployee.Size = new System.Drawing.Size(230, 192);
            this.dgEmployee.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.dgEmployee);
            this.Controls.Add(this.btnGetAll);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.DataGrid dgEmployee;
    }
}

