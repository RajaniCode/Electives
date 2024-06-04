namespace WFCClientGetCost
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
            this.lstMultiProtocol = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstMultiProtocol
            // 
            this.lstMultiProtocol.FormattingEnabled = true;
            this.lstMultiProtocol.Location = new System.Drawing.Point(26, 12);
            this.lstMultiProtocol.Name = "lstMultiProtocol";
            this.lstMultiProtocol.Size = new System.Drawing.Size(120, 56);
            this.lstMultiProtocol.TabIndex = 0;
            this.lstMultiProtocol.SelectedIndexChanged += new System.EventHandler(this.lstMultiProtocol_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 103);
            this.Controls.Add(this.lstMultiProtocol);
            this.Name = "Form1";
            this.Text = "frmMultiProtocolClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstMultiProtocol;

    }
}