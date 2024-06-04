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
using System.Windows.Data;

namespace SilverlightDataPagerCS
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            PagedCollectionView pagedcollectionview = new PagedCollectionView("W E L C O M E T O S I L V E R L I G H T 3".Split(' '));
            pagedcollectionview.PageSize = 5;
            myDatagrid.ItemsSource = pagedcollectionview;
        }
    }
}
