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
using System.IO;
using System.Text;

namespace SilverlightSaveFileDialog
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt";
            ofd.FilterIndex = 1;          

            if (true == ofd.ShowDialog())
            {
                FileInfo info = ofd.File;
                using (StreamReader sread = info.OpenText())
                {
                    txt.Text = sread.ReadToEnd();
                }                
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            sfd.Filter = "Text Files (*.txt)|*.txt";
            sfd.FilterIndex = 1;
            if (true == sfd.ShowDialog())
            {
                using (Stream stream = sfd.OpenFile())
                {
                    byte[] tbyte = (new UTF8Encoding(true)).GetBytes(txt.Text);
                    stream.Write(tbyte, 0, tbyte.Length);
                    stream.Close();
                }
            }
        }


    }
}
