namespace Weather
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.weatherImage = new System.Windows.Forms.PictureBox();
            this.RTTemp = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTWeatherType = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.weatherImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // weatherImage
            // 
            this.weatherImage.Location = new System.Drawing.Point(6, 20);
            this.weatherImage.Name = "weatherImage";
            this.weatherImage.Size = new System.Drawing.Size(52, 52);
            this.weatherImage.TabIndex = 0;
            this.weatherImage.TabStop = false;
            // 
            // RTTemp
            // 
            this.RTTemp.BackColor = System.Drawing.SystemColors.Control;
            this.RTTemp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTTemp.Enabled = false;
            this.RTTemp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTTemp.ForeColor = System.Drawing.Color.Teal;
            this.RTTemp.Location = new System.Drawing.Point(64, 24);
            this.RTTemp.Name = "RTTemp";
            this.RTTemp.Size = new System.Drawing.Size(65, 23);
            this.RTTemp.TabIndex = 8;
            this.RTTemp.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTWeatherType);
            this.groupBox1.Controls.Add(this.weatherImage);
            this.groupBox1.Controls.Add(this.RTTemp);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 80);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // RTWeatherType
            // 
            this.RTWeatherType.BackColor = System.Drawing.SystemColors.Control;
            this.RTWeatherType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTWeatherType.Enabled = false;
            this.RTWeatherType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTWeatherType.ForeColor = System.Drawing.Color.Teal;
            this.RTWeatherType.Location = new System.Drawing.Point(64, 49);
            this.RTWeatherType.Name = "RTWeatherType";
            this.RTWeatherType.Size = new System.Drawing.Size(92, 23);
            this.RTWeatherType.TabIndex = 9;
            this.RTWeatherType.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(168, 80);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.weatherImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox weatherImage;
        private System.Windows.Forms.RichTextBox RTTemp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox RTWeatherType;
    }
}

