using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SortingCards
{
  class Program
  {
    public enum Face { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
    public enum Suit { Club, Diamond, Heart, Spade };

    private static int width;
    private static int height;

    public struct Shuffler
    {
      public int key;
      public int random;
    }

    public class Card
    {
      public Face Face { get; set; }
      public Suit Suit { get; set; }
      
      public override string ToString()
      {
        return string.Format("{0} of {1}s", Face, Suit);
      }
    }

    static void Main(string[] args)
    {
      const int MAX = 52;

      cdtInit(ref width, ref height);
      try
      {
        Random rand = new Random(DateTime.Now.Millisecond);
        Shuffler[] shuffler = new Shuffler[MAX];

        for (int i = 0; i < MAX; i++)
        {
          shuffler[i].key = i;
          shuffler[i].random = rand.Next();
        }
                   

        // elem.key contains card number randomized by 
        // sorting on random numbers
        var shuffledCards = from s in shuffler
          orderby s.random
          select new Card { Suit = (Suit)(s.key / 13), Face = (Face)(s.key % 13) };

        using (Form form = new Form())
        {
          form.Show();
          

          int i = 0;
          foreach (var card in shuffledCards)
          {
            Graphics graphics = form.CreateGraphics();
            graphics.Clear(form.BackColor);
            string text = string.Format("Index: {0}, Card: {1}",
              i++, card);
            graphics.DrawString(text, form.Font, Brushes.Black, 10F, (float)(height + 20));
            PaintFace(graphics, card, 10, 10, width, height);
            form.Update();
            System.Threading.Thread.Sleep(500);
          }
        }

      }
      finally
      {
        cdtTerm();
      }

      Console.ReadLine();
    }

    private static void PaintFace(Graphics g, Card card, int x, int y, int dx, int dy)
    {
      IntPtr hdc = g.GetHdc();
      try
      {
        int intCard = (int)card.Face * 4 + (int)card.Suit;
        cdtDrawExt(hdc, x, y, dx, dy, intCard, 0, 0);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
      finally
      {
        g.ReleaseHdc(hdc);
      }
    }

    [DllImport("cards.dll")]
		static extern bool cdtInit(ref int width, ref int height);
		
		[DllImport("cards.dll")]
		public static extern bool cdtDraw (IntPtr hdc, int x, int y, int card, int type, long color);
		
		[DllImport("cards.dll")]
		public static extern bool cdtDrawExt(IntPtr hdc, int x, int y, int dx, int dy, int card, int suit, long color);
		
		[DllImport("cards.dll")]
		public static extern void cdtTerm();

  }
}
