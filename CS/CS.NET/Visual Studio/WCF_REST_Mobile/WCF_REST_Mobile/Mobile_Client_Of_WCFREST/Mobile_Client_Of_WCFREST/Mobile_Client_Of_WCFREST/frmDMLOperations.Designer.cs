namespace Mobile_Client_Of_WCFREST
{
    partial class frmDMLOperations
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
            this.label1 = new System.Windows.Forms.Label();
            this.txteno = new System.Windows.Forms.TextBox();
            this.txtename = new System.Windows.Forms.TextBox();
            this.txtsal = new System.Windows.Forms.TextBox();
            this.txtdno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.Text = "EmpNo";
            // 
            // txteno
            // 
            this.txteno.Location = new System.Drawing.Point(121, 21);
            this.txteno.Name = "txteno";
            this.txteno.Size = new System.Drawing.Size(100, 21);
            this.txteno.TabIndex = 1;
            // 
            // txtename
            // 
            this.txtename.Location = new System.Drawing.Point(121, 63);
            this.txtename.Name = "txtename";
            this.txtename.Size = new System.Drawing.Size(100, 21);
            this.txtename.TabIndex = 2;
            // 
            // txtsal
            // 
            this.txtsal.Location = new System.Drawing.Point(121, 104);
            this.txtsal.Name = "txtsal";
            this.txtsal.Size = new System.Drawing.Size(100, 21);
            this.txtsal.TabIndex = 3;
            // 
            // txtdno
            // 
            this.txtdno.Location = new System.Drawing.Point(121, 144);
            this.txtdno.Name = "txtdno";
            this.txtdno.Size = new System.Drawing.Size(100, 21);
            this.txtdno.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.Text = "EmpName";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.Text = "Salary";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.Text = "DeptNo";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(3, 185);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(96, 52);
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Text = "Insert";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(121, 185);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 52);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmDMLOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdno);
            this.Controls.Add(this.txtsal);
            this.Controls.Add(this.txtename);
            this.Controls.Add(this.txteno);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "frmDMLOperations";
            this.Text = "frmDMLOperations";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txteno;
        private System.Windows.Forms.TextBox txtename;
        private System.Windows.Forms.TextBox txtsal;
        private System.Windows.Forms.TextBox txtdno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
    }
}