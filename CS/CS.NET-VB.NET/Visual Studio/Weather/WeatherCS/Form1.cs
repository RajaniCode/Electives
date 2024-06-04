using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.Xml;
using System.Xml.XPath;


namespace Weather
{
    public partial class Form1 : Form
    {
        string[] strLocationID = { "2295411", "615702", "44418", "2295424","2295426" };
        string[] strLocations = { "Mumbai", "Paris", "London", "Chennai","Trivandrum" };
        int currentLocation = 0;
        private ThumbnailToolbarButton buttonNext;
        private ThumbnailToolbarButton buttonPrevious;
        TaskbarManager tbManager = TaskbarManager.Instance;
        public Form1()
        {
            InitializeComponent();
        }

      
        private void GetWeatherReport(int locationId)
        {
            
            this.Text = strLocations[locationId];
            XPathDocument doc = new XPathDocument("http://weather.yahooapis.com/forecastrss?w=" + strLocationID[locationId] + "&u=c");
            XPathNavigator nav = doc.CreateNavigator();

            XmlNamespaceManager ns = new XmlNamespaceManager(nav.NameTable);
            ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");
            XPathNodeIterator nodes = nav.Select("/rss/channel/item/yweather:condition", ns);

            while (nodes.MoveNext())
            {
                XPathNavigator node = nodes.Current;
                RTTemp.Text = node.GetAttribute("temp", ns.DefaultNamespace).ToString() + "°C";
                RTWeatherType.Text = node.GetAttribute("text", ns.DefaultNamespace).ToString();
                weatherImage.ImageLocation = "http://l.yimg.com/a/i/us/we/52/" + node.GetAttribute("code", ns.DefaultNamespace).ToString() + ".gif";
                SetProgressBarStyle(Convert.ToInt16(node.GetAttribute("temp", ns.DefaultNamespace)));
          
            }
            
                
           
        }

        private void SetProgressBarStyle(int weather)
        {
            //tbManager.SetProgressState(TaskbarProgressBarState.Normal);
            tbManager.SetProgressValue(50, 100);

            if (weather <= 10)
            {
                tbManager.SetProgressState(TaskbarProgressBarState.Normal);

            }
            if (weather >= 20)
            {
                tbManager.SetProgressState(TaskbarProgressBarState.Paused);

            }
            if (weather >= 30)
            {
                tbManager.SetProgressState(TaskbarProgressBarState.Error);

            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
            buttonNext = new ThumbnailToolbarButton(Properties.Resources.nextArrow, "Next Location");
            buttonNext.Enabled = true;
            buttonNext.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(buttonNext_Click);

            buttonPrevious = new ThumbnailToolbarButton(Properties.Resources.prevArrow, "Previous Location");
            buttonPrevious.Enabled = true;
            buttonPrevious.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(buttonPrevious_Click);
            TaskbarManager.Instance.ThumbnailToolbars.AddButtons(this.Handle, buttonPrevious, buttonNext);
            //TaskbarManager.Instance.TabbedThumbnail.SetThumbnailClip(this.Handle, new Rectangle(weatherImage.Location, weatherImage.Size));

            GetWeatherReport(currentLocation);
        }
        void buttonNext_Click(object sender, EventArgs e)
        { 
            
            if ((currentLocation + 1) < strLocationID.Length)
            {
                currentLocation += 1;
                GetWeatherReport(currentLocation);
            }

        }

        void buttonPrevious_Click(object sender, EventArgs e)
        {
            
            if ((currentLocation-1) >= 0)
            {
                currentLocation -= 1;
                GetWeatherReport(currentLocation);
            }
        }
    }
}
