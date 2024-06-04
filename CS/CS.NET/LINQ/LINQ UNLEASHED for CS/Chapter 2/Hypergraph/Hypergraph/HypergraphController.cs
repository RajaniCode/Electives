using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hypergraph
{
  public partial class HypergraphController : UserControl, IHypergraphObserver
  {
    public HypergraphController()
    {
      InitializeComponent();
    }


    #region IsubjectObserver Members
    private IHypergraph subject;
    public IHypergraph Subject
    {
      set 
      { 
        subject = value; 
        SubjectChanged();
      }
    }

    private void SubjectChanged()
    {
      if(subject == null ) return;
      TrackBarOuterDisk.Value = (int)subject.OuterRingRadius;
      TrackBarInnerDisk.Value = (int)subject.InnerRingRadius;
      TrackBarAngle.Value = (int)subject.AngleOfPen;
      TrackBarPenRadius.Value = (int)subject.PenRadialDistanceFromCenter;
    }

    #endregion

    private void TrackBarOuterDisk_Scroll(object sender, EventArgs e)
    {
      Changed();
    }

    private void TrackBarInnerDisk_Scroll(object sender, EventArgs e)
    {
      Changed();
    }

    private void TrackBarDrawSpeed_Scroll(object sender, EventArgs e)
    {
      if(timer != null)
        timer.Interval = TrackBarDrawSpeed.Value;
    }

    private Timer timer;
    public Timer Timer
    {
      get
      {
        return timer;
      }
      set
      {
        timer = value;
        if(timer != null)
          TrackBarDrawSpeed.Value = timer.Interval;
      }
    }


    private void TrackBarAngle_Scroll(object sender, EventArgs e)
    {
      Changed();
    }

    private void TrackBarPenRadius_Scroll(object sender, EventArgs e)
    {
      Changed();
    }


    private void CheckBoxShowToy_CheckedChanged(object sender, EventArgs e)
    {
      if(subject!=null)
        subject.ToyVisible = CheckBoxShowToy.Checked;
    }

    
    private void TrackBarPlotSpeed_Scroll(object sender, EventArgs e)
    {
      Changed();
    }

    private void Changed()
    {
      if(subject == null) return;
      subject.Clear();
      subject.OuterRingRadius = TrackBarOuterDisk.Value;
      toolTip1.SetToolTip(TrackBarInnerDisk, TrackBarInnerDisk.Value.ToString());
      subject.InnerRingRadius = TrackBarInnerDisk.Value;
      toolTip1.SetToolTip(TrackBarInnerDisk, TrackBarInnerDisk.Value.ToString());
      subject.AngleOfPen = TrackBarAngle.Value;
      toolTip1.SetToolTip(TrackBarAngle, TrackBarAngle.Value.ToString());
      subject.PenRadialDistanceFromCenter = TrackBarPenRadius.Value;
      toolTip1.SetToolTip(TrackBarPenRadius, TrackBarPenRadius.Value.ToString());
      subject.Speed = TrackBarDrawSpeed.Value;
      toolTip1.SetToolTip(TrackBarDrawSpeed, TrackBarDrawSpeed.Value.ToString());
    }

    internal void Random()
    {
      Random random = new Random(DateTime.Now.Millisecond);
      TrackBarAngle.Value = random.Next(TrackBarAngle.Minimum, TrackBarAngle.Maximum);
      TrackBarInnerDisk.Value = random.Next(TrackBarInnerDisk.Minimum, TrackBarInnerDisk.Maximum);
      TrackBarOuterDisk.Value = random.Next(TrackBarOuterDisk.Minimum, TrackBarOuterDisk.Maximum);
      TrackBarPenRadius.Value = random.Next(TrackBarPenRadius.Minimum, TrackBarPenRadius.Maximum);
      TrackBarPlotSpeed.Value = random.Next(TrackBarPlotSpeed.Minimum, TrackBarPlotSpeed.Maximum);
      if(subject != null)
        subject.PenColor = Color.FromArgb(random.Next(255), random.Next(255), 
          random.Next(255));
      Changed();      
    }

 
  }
}
