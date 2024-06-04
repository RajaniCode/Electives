using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Net;
using System.Windows.Resources;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using Microsoft.Win32;

namespace WPF40_ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string SrcPath = @"H:\SrcFiles";
        string TgtPath = @"H:\TgtFiles";
        string[] Files;
        string strFileName = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtStatus.Visibility = System.Windows.Visibility.Hidden;
        }
        
        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Files = Directory.GetFiles(SrcPath);
            txtStatus.Visibility = System.Windows.Visibility.Visible; 
            DispatcherTimer timer = new DispatcherTimer();
            foreach (string s in Files)
            {

                Thread t = new Thread(
                    new ThreadStart(
                        delegate()
                        {
                            DispatcherOperation dispOp =
                                downloadProgress.Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
                                new Action(
                                    delegate()
                                    {
                                        strFileName = s;
                                        string fileName = System.IO.Path.GetFileName(strFileName);
                                        string destFile = System.IO.Path.Combine(TgtPath, fileName);
                                        System.IO.File.Copy(strFileName, destFile, true);
                                        lstTgrFiles.Items.Add(destFile);
                                        downloadProgress.Value = lstTgrFiles.Items.Count;
                                        txtFileCopied.Text = lstTgrFiles.Items.Count + " File(s) Copied.";
                                     
                                        Thread.Sleep(100); 
                                    }
                                    ));
                            dispOp.Completed += new EventHandler(dispOp_Completed); 
                        }
                        ));
                t.Start(); 
                
            }
        }

        void dispOp_Completed(object sender, EventArgs e)
        {
            txtStatus.Visibility = System.Windows.Visibility.Collapsed;
            btnCopy.IsEnabled = false;
        }

        private void btnSourcePath_Click(object sender, RoutedEventArgs e)
        {
            string[] Files = Directory.GetFiles(SrcPath);

            foreach (string s in Files)
            {
                lstSourceFiles.Items.Add(s); 
            }
            downloadProgress.Maximum = Files.Length;
        }

    }
}
