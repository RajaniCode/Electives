namespace win_WorkflowWCFService
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.btnGetAllEmp = new System.Windows.Forms.Button();
            this.dgEmp = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // btnGetAllEmp
            // 
            this.btnGetAllEmp.Location = new System.Drawing.Point(31, 33);
            this.btnGetAllEmp.Name = "btnGetAllEmp";
            this.btnGetAllEmp.Size = new System.Drawing.Size(887, 63);
            this.btnGetAllEmp.TabIndex = 0;
            this.btnGetAllEmp.Text = "Get All Employee";
            this.btnGetAllEmp.UseVisualStyleBackColor = true;
            this.btnGetAllEmp.Click += new System.EventHandler(this.btnGetAllEmp_Click);
            // 
            // dgEmp
            // 
            this.dgEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmp.Location = new System.Drawing.Point(31, 111);
            this.dgEmp.Name = "dgEmp";
            this.dgEmp.Size = new System.Drawing.Size(887, 247);
            this.dgEmp.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 407);
            this.Controls.Add(this.dgEmp);
            this.Controls.Add(this.btnGetAllEmp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAllEmp;
        private System.Windows.Forms.DataGridView dgEmp;
    }
}

