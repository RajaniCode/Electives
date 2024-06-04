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
using System.Collections.ObjectModel;

namespace SILV3_DMLClientApplication
{
    public partial class HomePage : UserControl
    {
        

        public HomePage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(HomePage_Loaded);
        }

        void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
         

        private void btnLoadInsert_Click(object sender, RoutedEventArgs e)
        {
            canvMain.Children.Clear();
            InsertPage ctrlInsert = new InsertPage();
            canvMain.Children.Add(ctrlInsert); 
        }

        private void btnLoadGetAll_Click(object sender, RoutedEventArgs e)
        {
            canvMain.Children.Clear();
            GetAllPage ctrlgetAllPage = new GetAllPage();
            canvMain.Children.Add(ctrlgetAllPage); 
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            canvMain.Children.Clear ();
        }

        private void btnLoadUpdate_Click(object sender, RoutedEventArgs e)
        {
            canvMain.Children.Clear();
            UpdatePage ctrlUpdPage = new UpdatePage();
            canvMain.Children.Add(ctrlUpdPage); 
        }

        private void btnLoadDelete_Click(object sender, RoutedEventArgs e)
        {
            canvMain.Children.Clear();
            DeletePage ctrlDeletePage = new DeletePage();
            canvMain.Children.Add(ctrlDeletePage);
        }
    }
}
