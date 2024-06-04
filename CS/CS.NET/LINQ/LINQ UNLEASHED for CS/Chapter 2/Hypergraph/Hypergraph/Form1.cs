using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hypergraph
{
  public partial class Form1 : Form, IListener
  {
    public Form1()
    {
      InitializeComponent();
    }

    private Hypergraph hypergraph = new Hypergraph();

    private void Form1_Load(object sender, EventArgs e)
    {
      Initialize();
      UpdateStatus("Ready");
    }

    private void Initialize()
    {
      Broadcaster.Add(this);
      hyperGraphController1.Timer = Timer1;
      hyperGraphController1.Subject = hypergraph;
      CenterImage();
      SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
        | ControlStyles.DoubleBuffer, true);
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      hypergraph.Draw(e.Graphics);
    }

    
    private void Timer1_Tick(object sender, EventArgs e)
    {
      hypergraph.PlotNextPoint();
      Invalidate();
    }

    private void MenuItem3_Click(object sender, EventArgs e)
    {
      Timer1.Enabled = false;
      Close();
    }

  


    private void MenuItem5_Click(object sender, EventArgs e)
    {
      Suspend();
      AboutBox1.Execute(this);
      Resume();
    }  

    private void CenterImage()
    {
      hypergraph.CenterImage(Width, this.Height-hyperGraphController1.Height);
    }


    private bool state = false;
    private void Suspend()
    {
      state = Timer1.Enabled;
      if(state) Timer1.Enabled = false;
    }

    private void Resume()
    {
      Timer1.Enabled = state;
    }

    private void MenuItem7_Click(object sender, EventArgs e)
    {
      Suspend();
      ColorDialog1.Color = hypergraph.PenColor;
      if(ColorDialog1.ShowDialog(this) == DialogResult.OK)
      {
        hypergraph.PenColor = ColorDialog1.Color;
      }
      Resume();

    }

    
    private void MenuItem8_Click(object sender, EventArgs e)
    {
      hypergraph.Clear();
      Invalidate();
      
    }

    private void MenuItemStop_Click(object sender, EventArgs e)
    {
      ChangeState(false, "Stopped");
    }

    private void ChangeState(bool running, string message)
    {
      MenuItemStop.Enabled = running;
      MenuItemStart.Enabled = !running;
      Timer1.Enabled = running;
      UpdateStatus(message);
    }

    private void MenuItemStart_Click(object sender, EventArgs e)
    {
      ChangeState(true, "Started");
    }

    private void MenuItem9_Click(object sender, EventArgs e)
    {
      Suspend();
      if (SaveFileDialog1.ShowDialog() == DialogResult.OK) 
      {
        hypergraph.SaveToyToFile(SaveFileDialog1.FileName);
      }
      Resume();
    }

    

    private void UpdateStatus(string message)
    {
      StatusBar1.Text = message;
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      if(hypergraph == null) return;
      hypergraph.Clear();
      CenterImage();
    }

    private void MenuItem11_Click(object sender, EventArgs e)
    {
      ColoredPoint point = hypergraph.PlotNextPoint();
      Invalidate();
     
    }


    #region IListener Members

    public void Listen(string message)
    {
      UpdateStatus(message);
    }

    public bool Listening
    {
      get { return true; }
    }

    #endregion

    private void menuItem12_Click(object sender, EventArgs e)
    {
      Plot500();
    }

    private void Plot500()
    {
      ChangeState(false, "Stopped");
      hypergraph.Clear();
      hypergraph.Plot(500);
      Invalidate();
    }

    private void menuItem13_Click(object sender, EventArgs e)
    {
      menuItem13.Checked = !menuItem13.Checked;
      try
      {
        while(menuItem13.Checked)
        {
          hyperGraphController1.Random();
          Plot500();
          Application.DoEvents();
          System.Threading.Thread.Sleep(500);
        }
      }
      catch{}
    }

  }
}

