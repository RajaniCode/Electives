namespace ScreenShotOneClick
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grabScreenShotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grabScreenShotToolStripMenuItem,
            this.selectAreaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 48);
            // 
            // grabScreenShotToolStripMenuItem
            // 
            this.grabScreenShotToolStripMenuItem.Name = "grabScreenShotToolStripMenuItem";
            this.grabScreenShotToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.grabScreenShotToolStripMenuItem.Text = "Grab Screenshot";
            this.grabScreenShotToolStripMenuItem.Click += new System.EventHandler(this.grabScreenShotToolStripMenuItem_Click);
            // 
            // selectAreaToolStripMenuItem
            // 
            this.selectAreaToolStripMenuItem.Name = "selectAreaToolStripMenuItem";
            this.selectAreaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.selectAreaToolStripMenuItem.Text = "Select Area";
            this.selectAreaToolStripMenuItem.Click += new System.EventHandler(this.selectAreaToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 339);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Opacity = 0.2;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem grabScreenShotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAreaToolStripMenuItem;
    }
}

