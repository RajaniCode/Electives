using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hypergraph
{
  public class ColoredPointList : List<ColoredPoint>
  {

    /// <summary>
    /// Use conversion operator ToArray
    /// </summary>
    /// <returns></returns>
    public PointF[] GetPoints()
    {
      var points = from p in this select p.MyPoint;
      return points.ToArray<PointF>();
      //return (from p in this select p.MyPoint).ToArray<PointF>();
      //return (from p in this select p.MyPoint).ToArray<PointF[]>();

      //PointF[] points = new PointF[this.Count];
      //for(int i=0; i<this.Count; i++)
      //  points[i] = this[i].MyPoint;

      //return points;
    }

    public ColoredPointList Clone()
    {
      ColoredPointList list = new ColoredPointList();
      list.AddRange((from o in this select o.Clone()));
      return list;

      //ColoredPointList list = new ColoredPointList();
      //foreach(var p in this)
      //{
      //  // object initializer
      //  list.Add(p.Clone());
      //}
      //return list;
    }
  }
}

