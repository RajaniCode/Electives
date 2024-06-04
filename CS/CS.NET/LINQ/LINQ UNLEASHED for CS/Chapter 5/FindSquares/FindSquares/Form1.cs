using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FindSquares
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    Rectangle[] rects = new Rectangle[100];

    private void Form1_Load(object sender, EventArgs e)
    {
      Random random = new Random(DateTime.Now.Millisecond);
      int x, y, width, height;

      for(int i=0; i<100; i++)
      { 
        x = random.Next(this.ClientRectangle.Width / 2);
        y = random.Next(this.ClientRectangle.Height / 2);
        width = random.Next(200);
        height = random.Next(200);
        rects[i] = new Rectangle(x, y, width, height);
      }
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      Random random = new Random(DateTime.Now.Millisecond);
      Predicate<Rectangle> area = rect => 
        (rect.Width * rect.Height) <= (random.Next(200) * 
        random.Next(200));

      Rectangle[] matches = Array.FindAll(rects, area);
      e.Graphics.Clear(this.BackColor);

      foreach(var rect in matches)
        e.Graphics.DrawRectangle(Pens.Red, rect);
      e.Graphics.DrawString("Found: " + matches.Length.ToString(), 
        this.Font, Brushes.Black, 10, ClientRectangle.Height - 40);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Invalidate();
    }
  }
}
