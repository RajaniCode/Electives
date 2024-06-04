using System.Windows.Controls;
using System.Windows.Media;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();            
        }

        private void slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            double diff = 0;
            if (e.NewValue > e.OldValue)
            {
                diff = e.NewValue - e.OldValue;
            }
            else
            {
                diff = e.OldValue - e.NewValue;
            }
            SolidColorBrush scb = new SolidColorBrush(diff == slider.LargeChange ? Colors.Yellow : Colors.Red);
            rectangle.Fill = scb;
        }        
    }
}
