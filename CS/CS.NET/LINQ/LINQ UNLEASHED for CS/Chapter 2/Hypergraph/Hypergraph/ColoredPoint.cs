using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hypergraph
{
  public class ColoredPoint
  {
    // Auto-implemented property
    public Color MyColor{ get; set; }

    // can't use need because we need to modify X and Y properties
    private PointF myPoint;
    public PointF MyPoint
    {
      get
      {
        return myPoint;
      }
      set
      {
        myPoint = value;
      }
    }

    public float X
    {
      get
      {
        return myPoint.X;
      }
      set
      {
        myPoint.X = value;
      }
    }

    public float Y
    {
      get
      {
        return myPoint.Y;
      }
      set
      {
        myPoint.Y = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the ColoredPoint class.
    /// </summary>
    public ColoredPoint()
    {
    }
   
    public override string ToString()
    {
      return MyPoint.ToString();
    }

    internal ColoredPoint Clone()
    {
      return new ColoredPoint{MyColor=this.MyColor, MyPoint=this.MyPoint};
    }
  }
}
