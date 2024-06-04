namespace WCF_WindowsClient
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdbname = new System.Windows.Forms.TextBox();
            this.txttbname = new System.Windows.Forms.TextBox();
            this.brnGetData = new System.Windows.Forms.Button();
            this.dgdata = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.label1.Location = new System.Drawing.Point(90, 22);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.label2.Location = new System.Drawing.Point(555, 31);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Table Name";
            // 
            // txtdbname
            // 
            this.txtdbname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdbname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdbname.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtdbname.Location = new System.Drawing.Point(35, 54);
            this.txtdbname.Name = "txtdbname";
            this.txtdbname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtdbname.Size = new System.Drawing.Size(238, 20);
            this.txtdbname.TabIndex = 2;
            // 
            // txttbname
            // 
            this.txttbname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttbname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttbname.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txttbname.Location = new System.Drawing.Point(504, 54);
            this.txttbname.Name = "txttbname";
            this.txttbname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txttbname.Size = new System.Drawing.Size(238, 20);
            this.txttbname.TabIndex = 3;
            // 
            // brnGetData
            // 
            this.brnGetData.Cursor = System.Windows.Forms.Cursors.Default;
            this.brnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnGetData.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.brnGetData.Location = new System.Drawing.Point(35, 89);
            this.brnGetData.Name = "brnGetData";
            this.brnGetData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.brnGetData.Size = new System.Drawing.Size(707, 23);
            this.brnGetData.TabIndex = 4;
            this.brnGetData.Text = "Get Data";
            this.brnGetData.UseVisualStyleBackColor = true;
            this.brnGetData.Click += new System.EventHandler(this.brnGetData_Click);
            // 
            // dgdata
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdata.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdata.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgdata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgdata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgdata.Location = new System.Drawing.Point(35, 142);
            this.dgdata.Name = "dgdata";
            this.dgdata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgdata.Size = new System.Drawing.Size(707, 204);
            this.dgdata.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 358);
            this.Controls.Add(this.dgdata);
            this.Controls.Add(this.brnGetData);
            this.Controls.Add(this.txttbname);
            this.Controls.Add(this.txtdbname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdbname;
        private System.Windows.Forms.TextBox txttbname;
        private System.Windows.Forms.Button brnGetData;
        private System.Windows.Forms.DataGridView dgdata;
    }
}

