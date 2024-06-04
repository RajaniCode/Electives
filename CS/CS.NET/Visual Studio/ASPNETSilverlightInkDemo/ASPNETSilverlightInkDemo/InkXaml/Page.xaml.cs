using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Ink;

namespace InkXaml
{
public partial class Page : UserControl
{
    private Stroke _stroke = null;
    private StylusPointCollection eraserPoints;
    private InkMode _mode = InkMode.Draw;

    public enum InkMode
    {
        Draw,
        Erase
    }

    public Page()
    {
        InitializeComponent();

    }

    private void inkP_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        inkP.CaptureMouse();
        if (_mode == InkMode.Draw)
        {
            _stroke = new Stroke();
            _stroke.DrawingAttributes.Color = Colors.White;
            _stroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(inkP));
            inkP.Strokes.Add(_stroke);
        }
        if (_mode == InkMode.Erase)
        {
            eraserPoints = new StylusPointCollection();
            eraserPoints = e.StylusDevice.GetStylusPoints(inkP);
        }
    }

    private void inkP_MouseMove(object sender, MouseEventArgs e)
    {
        if (_mode == InkMode.Draw)
        {
            if (null != _stroke)
            {
                _stroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(inkP));
            }
        }
        if (_mode == InkMode.Erase)
        {
            if (null != eraserPoints)
            {
                eraserPoints.Add(e.StylusDevice.GetStylusPoints(inkP));
                StrokeCollection hits = inkP.Strokes.HitTest(eraserPoints);
                for (int cnt = 0; cnt < hits.Count; cnt++)
                {
                    inkP.Strokes.Remove(hits[cnt]);
                }
            }
        }
    }

    private void inkP_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        _stroke = null;
        eraserPoints = null;
        inkP.ReleaseMouseCapture();
    }


    private void btnErase_Click(object sender, RoutedEventArgs e)
    {
        inkP.Cursor = Cursors.Eraser;
        _mode = InkMode.Erase;
    }

    private void btnDraw_Click(object sender, RoutedEventArgs e)
    {
        inkP.Cursor = Cursors.Stylus;
        _mode = InkMode.Draw;
    }
}
}
