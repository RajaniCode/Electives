using System;
using System.Xml;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.ServiceModel.Syndication;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace ConsumingRSS
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            
        }

        protected void LoadRSS(string uri)
        {
            WebClient wc = new WebClient();            
            wc.OpenReadCompleted +=new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
            Uri feedUri = new Uri(uri, UriKind.Absolute); 
            wc.OpenReadAsync(feedUri);
        }

        private void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                txtFeedLoc.Text = "Error in Reading Feed. Try Again later!!";
                return;
            }
            using (Stream s = e.Result)
            {
                SyndicationFeed feed;                

                using (XmlReader reader = XmlReader.Create(s))
                {
                    feed = SyndicationFeed.Load(reader);                    
                    var posts = from item in feed.Items 
                                select new RSSFeed()
                                {
                                    Title = item.Title.Text,
                                    NavURL = item.Links[0].Uri.AbsoluteUri,
                                    Description = item.Summary.Text
                                };
                    dGrid.ItemsSource = posts;                    
                    dGrid.Visibility = Visibility.Visible;
                }                
            }
        }
 
        private void btnFetch_Click(object sender, RoutedEventArgs e)
        {
            if(txtFeedLoc.Text != String.Empty)
                LoadRSS(txtFeedLoc.Text.Trim());
        }
    }

    public class RSSFeed
    {
        public string Title { get; set; }
        public string NavURL { get; set; }
        public string Description { get; set; }
    }

}
