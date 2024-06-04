using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Hypergraph
{
  public class Hypergraph : IHypergraph
  {
    private static Random random = new Random(DateTime.Now.Millisecond);
    private static float NextRandom(float scalar)
    {
      return (float)random.NextDouble() * scalar;
    }

    private static int NextRandom(int scalar)
    {
      return random.Next(scalar);
    }

    /// <summary>
    /// Didn't use auto-implemented here - choice
    /// </summary>
    private float angle = NextRandom(5f);
    public float Angle
    {
    	get {	return angle; }
    	set { angle = value;	}
    }
    
    private float speed = NextRandom(1f);
    public float Speed
    {
    	get {	return speed; }
    	set { speed = value;	}
    }

    private float centerX = NextRandom(200f);
    public float CenterX
    {
    	get {	return centerX; }
    	set { centerX = value;	}
    }

    private float centerY = NextRandom(200f);
    public float CenterY
    {
    	get {	return centerY; }
    	set { centerY = value;	}
    }

    private float innerRingRadius = NextRandom(81f);
    public float InnerRingRadius
    {
    	get {	return innerRingRadius; }
    	set { innerRingRadius = value;	}
    }

    private float outerRingRadius = NextRandom(100f);
    public float OuterRingRadius
    {
    	get {	return outerRingRadius; }
    	set { outerRingRadius = value;	}
    }

    private float angleOfPen = NextRandom(3.5f);
    public float AngleOfPen
    {
    	get {	return angleOfPen; }
    	set { angleOfPen = value;	}
    }

    private float penRadialDistanceFromCenter = NextRandom(70f);
    public float PenRadialDistanceFromCenter
    {
    	get {	return penRadialDistanceFromCenter; }
    	set { penRadialDistanceFromCenter = value;	}
    }

    /// <summary>
    /// Can't use auto-implemented type here because we have behaviors
    /// </summary>
    private Color penColor = Color.FromArgb(NextRandom(255), NextRandom(255),
      NextRandom(255));
    public Color PenColor
    {
    	get {	return penColor; }
    	set 
      { 
        penColor = value;	
        MyPen = new Pen(value);
      }
    }

    /// <summary>
    /// Auto-implemented field only accessible here
    /// </summary>
    public Pen MyPen{ get; set; }

    /// <summary>
    /// No auto-implemented here because construction of object field 
    /// is easier without it
    /// </summary>
    private ColoredPointList list = new ColoredPointList();
    public ColoredPointList List
    {
      get {	return list; }
    }

    public void Clear()
    {
      Broadcaster.Broadcast("Clear");
    	list.Clear();
    }

    public PointF[] Points
    {
    	get {	return list.GetPoints(); }
    }

    public ColoredPoint PlotNextPoint()
    {
    	angle += speed;
      angleOfPen = angle - angle * outerRingRadius / innerRingRadius;
      
      // object initializer with named types
      ColoredPoint point = new ColoredPoint{MyColor=penColor, 
          X=GetX(), Y=GetY()};
      
      list.Add(point);
      const string mask = "Step: {0}";
      Broadcaster.Broadcast(mask, point.ToString());
      return point;
    }

    private float GetCsx()
    {
      return (float)(centerX + Math.Cos(angle) 
        * (outerRingRadius - innerRingRadius));
    }

    private float GetCsy()
    {
      return (float)(centerY + Math.Sin(angle) 
        * (outerRingRadius - innerRingRadius));
    }
    

    private float GetX()
    {
      return (float)(GetCsx() + Math.Cos(angleOfPen) 
        * penRadialDistanceFromCenter);
    }

    private float GetY()
    {
      return (float)(GetCsy() + Math.Sin(angleOfPen) * 
        penRadialDistanceFromCenter);
    }

    public RectangleF OuterRingBoundsRect()
    {
      return new RectangleF(centerX-outerRingRadius, 
        centerY - outerRingRadius, 
        2 * outerRingRadius, 2 * OuterRingRadius);
    }

    public RectangleF GetAxis()
    {
      return new RectangleF(GetX(), GetY(), 
        innerRingRadius, innerRingRadius);
    }

    public RectangleF InnerRingBoundsRect()
    {
      return new RectangleF(GetCsx() - innerRingRadius, 
        GetCsy() - innerRingRadius, 2 * innerRingRadius, 
        2 * innerRingRadius);
    }

    /// <summary>
    /// Initializes a new instance of the Hypergraph class.
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="speed"></param>
    /// <param name="centerX"></param>
    /// <param name="centerY"></param>
    /// <param name="innerRingRadius"></param>
    /// <param name="outerRingRadius"></param>
    /// <param name="angleOfPen"></param>
    /// <param name="penRadialDistanceFromCenter"></param>
    /// <param name="penColor"></param>
    /// <param name="list"></param>
    public Hypergraph(float angle, float speed, 
      float centerX, float centerY, float innerRingRadius, 
      float outerRingRadius, float angleOfPen, 
      float penRadialDistanceFromCenter, Color penColor, 
      ColoredPointList list)
    {
    		this.angle = angle;
    		this.speed = speed;
    		this.centerX = centerX;
    		this.centerY = centerY;
    		this.innerRingRadius = innerRingRadius;
    		this.outerRingRadius = outerRingRadius;
    		this.angleOfPen = angleOfPen;
    		this.penRadialDistanceFromCenter = penRadialDistanceFromCenter;
    		this.penColor = penColor;
    		this.list = list;
    }

    /// <summary>
    /// Initializes a new instance of the Hypergraph class.
    /// </summary>
    public Hypergraph(Hypergraph o)
    {
      	this.angle = o.angle;
    		this.speed = o.speed;
    		this.centerX = o.centerX;
    		this.centerY = o.centerY;
    		this.innerRingRadius = o.innerRingRadius;
    		this.outerRingRadius = o.outerRingRadius;
    		this.angleOfPen = o.angleOfPen;
    		this.penRadialDistanceFromCenter = o.penRadialDistanceFromCenter;
    		this.penColor = o.penColor;
    		this.list = o.List.Clone();
    }

    /// <summary>
    /// Initializes a new instance of the Hypergraph class.
    /// </summary>
    public Hypergraph()
    {
      MyPen = new Pen(Color.FromArgb(NextRandom(255), NextRandom(255),
        NextRandom(255)));
    }


    public Hypergraph Clone()
    {
      return new Hypergraph(this);
    }

    private GraphicsPath path = new GraphicsPath();
    public GraphicsPath Path
    {
      get
      {
        path.Reset();
        if(List.Count > 2) path.AddPolygon(Points);
        path.CloseAllFigures();
        return path;
      }
    }

    public void SaveToyToFile(string filename)
    {
      Broadcaster.Broadcast("Saving to {0}", filename);
      Hypergraph copy = this.Clone();
      foreach (var p in copy.List)
      {
        p.MyPoint = new PointF(p.MyPoint.X - copy.CenterX +
          (copy.OuterRingRadius + copy.InnerRingRadius) / 2,
          p.MyPoint.Y - copy.CenterY +
          (copy.OuterRingRadius + copy.InnerRingRadius) / 2);
      }

      GraphicsPath path = copy.Path;
      RectangleF bounds = path.GetBounds();
      Bitmap bitmap = new Bitmap((int)bounds.Width, (int)bounds.Height);
      Graphics graphics = Graphics.FromImage(bitmap);
      graphics.DrawCurve(MyPen, copy.Points);
      bitmap.Save(filename, ImageFormat.Jpeg);
      Broadcaster.Broadcast("Saved");
    }

    public void Draw(Graphics g)
    {
      if(Points.Length < 2) return;
      Broadcaster.Broadcast("Drawing");
      g.SmoothingMode = SmoothingMode.AntiAlias;
      g.DrawCurve(MyPen, this.Points);
      if (toyVisible) ShowToy(g);
    }

    private void ShowToy(Graphics g)
    {
      g.DrawEllipse(Pens.Silver, OuterRingBoundsRect());
      g.DrawEllipse(Pens.Silver, InnerRingBoundsRect());
      RectangleF rect = GetAxis();
      g.FillEllipse(new SolidBrush(PenColor), rect.X, rect.Y, 6, 6);
    }

    internal void CenterImage(int width, int height)
    {
      Clear();
      CenterX = width / 2;
      CenterY = height / 2;
      Broadcaster.Broadcast("Centered image at {0} x {1}", CenterX, CenterY);
    }

    
    #region IHypergraph Members

    private bool toyVisible;
    public bool ToyVisible
    {
      get
      {
        return toyVisible;
      }
      set
      {
        toyVisible = value;
      }
    }

    #endregion

    internal void Plot(int p)
    {
      for(var i=0; i<p; i++)
        this.PlotNextPoint();
    }
  }
}

    