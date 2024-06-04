using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace Hypergraph
{
  public interface IHypergraph
  {
    float InnerRingRadius { get; set; }
    float OuterRingRadius { get; set; }
    float AngleOfPen { get; set; }
    float PenRadialDistanceFromCenter { get; set; }
    float Speed { get; set; }
    bool ToyVisible { get; set; }
    void Clear();
    Color PenColor { get; set; }
  }

  public interface IHypergraphObserver
  {
    IHypergraph Subject {set;}
  }
}
