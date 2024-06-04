using System;
using System.Windows.Browser;
using System.Windows.Controls;

namespace SilverlightApplication1
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            HtmlElement element = HtmlPage.Document.GetElementById("htmlBody");
            if (element != null)
            {
                element.AttachEvent("mousemove", new EventHandler<HtmlEventArgs>(RaiseHtmlEvent));   
            }
        }

        public void RaiseHtmlEvent(object sender, HtmlEventArgs e)
        {
            txtClientXValue.Text = e.ClientX.ToString();
            txtClientYValue.Text = e.ClientY.ToString();
        }
    }
}
