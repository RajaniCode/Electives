namespace Hypergraph
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
      this.MenuItem3 = new System.Windows.Forms.MenuItem();
      this.MenuItem10 = new System.Windows.Forms.MenuItem();
      this.MenuItem9 = new System.Windows.Forms.MenuItem();
      this.MenuItem2 = new System.Windows.Forms.MenuItem();
      this.MenuItem11 = new System.Windows.Forms.MenuItem();
      this.MenuItem6 = new System.Windows.Forms.MenuItem();
      this.MenuItem8 = new System.Windows.Forms.MenuItem();
      this.MenuItem7 = new System.Windows.Forms.MenuItem();
      this.menuItem12 = new System.Windows.Forms.MenuItem();
      this.menuItem13 = new System.Windows.Forms.MenuItem();
      this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
      this.MenuItem5 = new System.Windows.Forms.MenuItem();
      this.MenuItem4 = new System.Windows.Forms.MenuItem();
      this.MenuItemStop = new System.Windows.Forms.MenuItem();
      this.MenuItemStart = new System.Windows.Forms.MenuItem();
      this.MenuItem1 = new System.Windows.Forms.MenuItem();
      this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
      this.StatusBar1 = new System.Windows.Forms.StatusBar();
      this.Timer1 = new System.Windows.Forms.Timer(this.components);
      this.hyperGraphController1 = new HypergraphController();
      this.SuspendLayout();
      // 
      // MenuItem3
      // 
      this.MenuItem3.Index = 6;
      this.MenuItem3.Text = "E&xit";
      this.MenuItem3.Click += new System.EventHandler(this.MenuItem3_Click);
      // 
      // MenuItem10
      // 
      this.MenuItem10.Index = 5;
      this.MenuItem10.Text = "-";
      // 
      // MenuItem9
      // 
      this.MenuItem9.Index = 4;
      this.MenuItem9.Text = "Save...";
      this.MenuItem9.Click += new System.EventHandler(this.MenuItem9_Click);
      // 
      // MenuItem2
      // 
      this.MenuItem2.Index = 3;
      this.MenuItem2.Text = "-";
      // 
      // MenuItem11
      // 
      this.MenuItem11.Index = 2;
      this.MenuItem11.Shortcut = System.Windows.Forms.Shortcut.F4;
      this.MenuItem11.Text = "Ste&p";
      this.MenuItem11.Click += new System.EventHandler(this.MenuItem11_Click);
      // 
      // MenuItem6
      // 
      this.MenuItem6.Index = 1;
      this.MenuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem8,
            this.MenuItem7,
            this.menuItem12,
            this.menuItem13});
      this.MenuItem6.Text = "&Tools";
      // 
      // MenuItem8
      // 
      this.MenuItem8.Index = 0;
      this.MenuItem8.Shortcut = System.Windows.Forms.Shortcut.F7;
      this.MenuItem8.Text = "Clear";
      this.MenuItem8.Click += new System.EventHandler(this.MenuItem8_Click);
      // 
      // MenuItem7
      // 
      this.MenuItem7.Index = 1;
      this.MenuItem7.Text = "Change drawing color...";
      this.MenuItem7.Click += new System.EventHandler(this.MenuItem7_Click);
      // 
      // menuItem12
      // 
      this.menuItem12.Index = 2;
      this.menuItem12.Text = "Plot 500 and Show Me";
      this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
      // 
      // menuItem13
      // 
      this.menuItem13.Index = 3;
      this.menuItem13.Shortcut = System.Windows.Forms.Shortcut.F9;
      this.menuItem13.Text = "Random Solutions";
      this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
      // 
      // SaveFileDialog1
      // 
      this.SaveFileDialog1.DefaultExt = "jpg";
      this.SaveFileDialog1.Filter = "JPEG Image|*.jpg";
      this.SaveFileDialog1.Title = "Save Spyrograph";
      // 
      // MenuItem5
      // 
      this.MenuItem5.Index = 0;
      this.MenuItem5.Text = "&About";
      this.MenuItem5.Click += new System.EventHandler(this.MenuItem5_Click);
      // 
      // MenuItem4
      // 
      this.MenuItem4.Index = 2;
      this.MenuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem5});
      this.MenuItem4.Text = "&Help";
      // 
      // MenuItemStop
      // 
      this.MenuItemStop.Index = 1;
      this.MenuItemStop.Shortcut = System.Windows.Forms.Shortcut.F3;
      this.MenuItemStop.Text = "Stop";
      this.MenuItemStop.Click += new System.EventHandler(this.MenuItemStop_Click);
      // 
      // MenuItemStart
      // 
      this.MenuItemStart.Enabled = false;
      this.MenuItemStart.Index = 0;
      this.MenuItemStart.Shortcut = System.Windows.Forms.Shortcut.F2;
      this.MenuItemStart.Text = "&Start";
      this.MenuItemStart.Click += new System.EventHandler(this.MenuItemStart_Click);
      // 
      // MenuItem1
      // 
      this.MenuItem1.Index = 0;
      this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemStart,
            this.MenuItemStop,
            this.MenuItem11,
            this.MenuItem2,
            this.MenuItem9,
            this.MenuItem10,
            this.MenuItem3});
      this.MenuItem1.Text = "&File";
      // 
      // MainMenu1
      // 
      this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1,
            this.MenuItem6,
            this.MenuItem4});
      // 
      // StatusBar1
      // 
      this.StatusBar1.Location = new System.Drawing.Point(0, 500);
      this.StatusBar1.Name = "StatusBar1";
      this.StatusBar1.Size = new System.Drawing.Size(669, 19);
      this.StatusBar1.TabIndex = 4;
      this.StatusBar1.Text = "StatusBar1";
      // 
      // Timer1
      // 
      this.Timer1.Enabled = true;
      this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
      // 
      // hyperGraphController1
      // 
      this.hyperGraphController1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.hyperGraphController1.Location = new System.Drawing.Point(0, 395);
      this.hyperGraphController1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.hyperGraphController1.Name = "hyperGraphController1";
      this.hyperGraphController1.Size = new System.Drawing.Size(669, 105);
      this.hyperGraphController1.TabIndex = 5;
      this.hyperGraphController1.Timer = null;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(669, 519);
      this.Controls.Add(this.hyperGraphController1);
      this.Controls.Add(this.StatusBar1);
      this.Menu = this.MainMenu1;
      this.Name = "Form1";
      this.Text = "Hypergraph";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.ResumeLayout(false);

    }

    #endregion

    internal System.Windows.Forms.MenuItem MenuItem3;
    internal System.Windows.Forms.MenuItem MenuItem10;
    internal System.Windows.Forms.MenuItem MenuItem9;
    internal System.Windows.Forms.MenuItem MenuItem2;
    internal System.Windows.Forms.MenuItem MenuItem11;
    internal System.Windows.Forms.MenuItem MenuItem6;
    internal System.Windows.Forms.MenuItem MenuItem8;
    internal System.Windows.Forms.MenuItem MenuItem7;
    internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
    internal System.Windows.Forms.ColorDialog ColorDialog1;
    internal System.Windows.Forms.MenuItem MenuItem5;
    internal System.Windows.Forms.MenuItem MenuItem4;
    internal System.Windows.Forms.MenuItem MenuItemStop;
    internal System.Windows.Forms.MenuItem MenuItemStart;
    internal System.Windows.Forms.MenuItem MenuItem1;
    internal System.Windows.Forms.MainMenu MainMenu1;
    internal System.Windows.Forms.StatusBar StatusBar1;
    internal System.Windows.Forms.Timer Timer1;
    private HypergraphController hyperGraphController1;
    private System.Windows.Forms.MenuItem menuItem12;
    private System.Windows.Forms.MenuItem menuItem13;
  }
}

