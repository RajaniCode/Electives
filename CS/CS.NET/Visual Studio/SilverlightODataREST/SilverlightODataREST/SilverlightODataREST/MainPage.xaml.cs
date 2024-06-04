using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Services.Client;
using SilverlightODataREST.ODataNetflixService;

namespace SilverlightODataREST
{
    // This code is provided for an article 
    // from www.dotnetcurry.com

    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private DataServiceCollection<Title> titlecoll;
        private NetflixCatalog catalog;

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            catalog = new NetflixCatalog(
            new Uri("http://odata.netflix.com/Catalog/", UriKind.Absolute));
            titlecoll = new DataServiceCollection<Title>(catalog);
            titlecoll.LoadCompleted +=
            new EventHandler<LoadCompletedEventArgs>(Title_LoadCompleted);
        }

        void Title_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (titlecoll.Continuation != null)
                {
                    titlecoll.LoadNextPartialSetAsync();
                }
                else
                {
                    // Bind the DataGrid to the collection
                    gridTitles.ItemsSource = titlecoll;
                    gridTitles.UpdateLayout();
                }
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }

        private void btnGetRecords_Click(object sender, RoutedEventArgs e)
        {
            // check if catalog is not null
            if (catalog != null)
            {
                gridTitles.DataContext = null;
                var titlescol = (from t in catalog.Titles
                                    where t.Name.StartsWith("X")
                                    select t).Take(10);

                titlecoll.LoadAsync(titlescol);
                btnGetRecords.IsEnabled = false;
            }
        }

    }
}
