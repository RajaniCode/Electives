using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Ria.Data;
using SilverlightApplication1.Web;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        private DomainContext Context
        {
            get
            {
                return dds.DomainContext;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }        

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {     
            Context.Entities.PropertyChanged += (s, o) =>
            {
                if (o.PropertyName == "HasChanges")
                {
                    UpdateHasChanges();
                }
            };
        }

        private void UpdateHasChanges()
        {            
            EntityChangeSet changes = Context.Entities.GetChanges();
            btnUpdate.IsEnabled = Context.HasChanges;
        }       

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {            
            Context.SubmitChanges(DataSaved, null);
        }

        private void DataSaved(SubmitOperation sender)
        {            
        }

        private void dgSupplier_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && dgSupplier.SelectedItem != null)
            {
                var supplier = dgSupplier.SelectedItem as Supplier;
                (dds.DomainContext as NorthwindContext).Suppliers.Remove(supplier);
                UpdateHasChanges();
            }

            if (e.Key == Key.Insert)
            {
                (dds.DomainContext as NorthwindContext).Suppliers.Add(new Supplier()
                {
                    Address = "", City = "",
                    Country = "", PostalCode = "",
                    Region = "", CompanyName = "",
                    ContactName = "", ContactTitle = "",
                    Fax = "", Phone = ""
                });
                dds.SubmitChanges();
                dds.Load();
            }
        }

        private void dgSupplier_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            UpdateHasChanges();
        }
    }
}
