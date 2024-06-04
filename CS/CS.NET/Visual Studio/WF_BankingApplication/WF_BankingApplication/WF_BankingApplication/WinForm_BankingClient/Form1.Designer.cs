namespace WinForm_BankingClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtaccname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtaccaddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtopeningbalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttranamount = new System.Windows.Forms.TextBox();
            this.rdDeposit = new System.Windows.Forms.RadioButton();
            this.rdWithdrawal = new System.Windows.Forms.RadioButton();
            this.btnPerformTransaction = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnetbalance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name";
            // 
            // txtaccname
            // 
            this.txtaccname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtaccname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaccname.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtaccname.Location = new System.Drawing.Point(172, 18);
            this.txtaccname.Name = "txtaccname";
            this.txtaccname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtaccname.Size = new System.Drawing.Size(171, 20);
            this.txtaccname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.label2.Location = new System.Drawing.Point(398, 21);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account Address";
            // 
            // txtaccaddress
            // 
            this.txtaccaddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtaccaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaccaddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtaccaddress.Location = new System.Drawing.Point(524, 21);
            this.txtaccaddress.Name = "txtaccaddress";
            this.txtaccaddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtaccaddress.Size = new System.Drawing.Size(161, 20);
            this.txtaccaddress.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Opening Balance";
            // 
            // txtopeningbalance
            // 
            this.txtopeningbalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtopeningbalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtopeningbalance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtopeningbalance.Location = new System.Drawing.Point(172, 76);
            this.txtopeningbalance.Name = "txtopeningbalance";
            this.txtopeningbalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtopeningbalance.Size = new System.Drawing.Size(171, 20);
            this.txtopeningbalance.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.label4.Location = new System.Drawing.Point(18, 183);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Transaction Amount";
            // 
            // txttranamount
            // 
            this.txttranamount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttranamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttranamount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txttranamount.Location = new System.Drawing.Point(172, 176);
            this.txttranamount.Name = "txttranamount";
            this.txttranamount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txttranamount.Size = new System.Drawing.Size(171, 20);
            this.txttranamount.TabIndex = 6;
            // 
            // rdDeposit
            // 
            this.rdDeposit.AutoSize = true;
            this.rdDeposit.Cursor = System.Windows.Forms.Cursors.Default;
            this.rdDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDeposit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.rdDeposit.Location = new System.Drawing.Point(172, 125);
            this.rdDeposit.Name = "rdDeposit";
            this.rdDeposit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdDeposit.Size = new System.Drawing.Size(61, 17);
            this.rdDeposit.TabIndex = 4;
            this.rdDeposit.TabStop = true;
            this.rdDeposit.Text = "Deposit";
            this.rdDeposit.UseVisualStyleBackColor = true;
            // 
            // rdWithdrawal
            // 
            this.rdWithdrawal.AutoSize = true;
            this.rdWithdrawal.Cursor = System.Windows.Forms.Cursors.Default;
            this.rdWithdrawal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdWithdrawal.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.rdWithdrawal.Location = new System.Drawing.Point(401, 125);
            this.rdWithdrawal.Name = "rdWithdrawal";
            this.rdWithdrawal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdWithdrawal.Size = new System.Drawing.Size(78, 17);
            this.rdWithdrawal.TabIndex = 5;
            this.rdWithdrawal.TabStop = true;
            this.rdWithdrawal.Text = "Withdrawal";
            this.rdWithdrawal.UseVisualStyleBackColor = true;
            // 
            // btnPerformTransaction
            // 
            this.btnPerformTransaction.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPerformTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerformTransaction.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.btnPerformTransaction.Location = new System.Drawing.Point(21, 221);
            this.btnPerformTransaction.Name = "btnPerformTransaction";
            this.btnPerformTransaction.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPerformTransaction.Size = new System.Drawing.Size(664, 23);
            this.btnPerformTransaction.TabIndex = 7;
            this.btnPerformTransaction.Text = "Perform Transaction";
            this.btnPerformTransaction.UseVisualStyleBackColor = true;
            this.btnPerformTransaction.Click += new System.EventHandler(this.btnPerformTransaction_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.label5.Location = new System.Drawing.Point(18, 277);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Net Balance";
            // 
            // txtnetbalance
            // 
            this.txtnetbalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnetbalance.Enabled = false;
            this.txtnetbalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnetbalance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtnetbalance.Location = new System.Drawing.Point(172, 277);
            this.txtnetbalance.Name = "txtnetbalance";
            this.txtnetbalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtnetbalance.Size = new System.Drawing.Size(260, 20);
            this.txtnetbalance.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 456);
            this.Controls.Add(this.txtnetbalance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPerformTransaction);
            this.Controls.Add(this.rdWithdrawal);
            this.Controls.Add(this.rdDeposit);
            this.Controls.Add(this.txttranamount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtopeningbalance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtaccaddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtaccname);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtaccname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtaccaddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtopeningbalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttranamount;
        private System.Windows.Forms.RadioButton rdDeposit;
        private System.Windows.Forms.RadioButton rdWithdrawal;
        private System.Windows.Forms.Button btnPerformTransaction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnetbalance;
    }
}

