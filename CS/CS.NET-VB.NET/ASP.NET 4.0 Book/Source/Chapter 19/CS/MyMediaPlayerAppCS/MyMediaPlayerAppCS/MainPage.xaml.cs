using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyMediaPlayerAppCS
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void mediaOpen(object sender, RoutedEventArgs e)
        {
            mediaFile.Text += mediaEle.Source.ToString();
            duration.Text += mediaEle.NaturalDuration.TimeSpan.Hours.ToString() +
            ":" + mediaEle.NaturalDuration.TimeSpan.Minutes.ToString() + ":" +
            mediaEle.NaturalDuration.TimeSpan.Seconds.ToString();
        }
        public void mediaError(object sender, RoutedEventArgs e)
        {
            errorText.Text = "Failed to open the media";
        }
        public void mediaPlay(object sender, RoutedEventArgs e)
        {
            mediaEle.Play();
            play.Content = "Play";
        }
        public void mediaPause(object sender, RoutedEventArgs e)
        {
            mediaEle.Pause();
            play.Content = "Resume";
        }
        public void mediaStop(object sender, RoutedEventArgs e)
        {
            mediaEle.Stop();
            play.Content = "Play";
        }
    }
}

