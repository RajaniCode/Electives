namespace Wordpress
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
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 50);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(34, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Post :";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(57, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Post Title :";
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(6, 68);
            this.txtPost.Multiline = true;
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(330, 222);
            this.txtPost.TabIndex = 6;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(8, 24);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(330, 20);
            this.txtTitle.TabIndex = 5;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(6, 305);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(330, 55);
            this.btnPost.TabIndex = 7;
            this.btnPost.Text = "Post to Blog";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 366);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnPost);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtPost;
        internal System.Windows.Forms.TextBox txtTitle;
        internal System.Windows.Forms.Button btnPost;
    }
}

