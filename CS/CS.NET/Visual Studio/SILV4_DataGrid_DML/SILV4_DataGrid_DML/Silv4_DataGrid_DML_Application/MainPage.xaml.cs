using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Services.Client;
using System.Collections.ObjectModel;

namespace Silv4_DataGrid_DML_Application
{
    /// <summary>
    /// Code file for the www.dotnetcurry.com article - www.dotnetcurry.com/ShowArticle.aspx?ID=571
    /// </summary>
    public partial class MainPage : UserControl
    {

        MyRef.CompanyEntities ProxyEntities;
        MyRef.Customer objCust,objMyCust;
        List<MyRef.Customer> Result = null;
        ObservableCollection<MyRef.Customer> ResultCustomer =null;
        bool IsUpdated = false;
        bool IsDeleted = false;
        bool IsInserted = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ProxyEntities = new MyRef.CompanyEntities(new Uri("http://localhost:8090/CUST_WCF_Vd/CustomerDataService.svc/"));
            ResultCustomer = new ObservableCollection<MyRef.Customer>(); 
            BindCustomerGrid();
        }

        private void BindCustomerGrid()
        {
            var custToBind = from Cust in ProxyEntities.Customer
                                select Cust;

            var dsQueryCust = (DataServiceQuery<MyRef.Customer>)custToBind;


            dsQueryCust.BeginExecute(OnCallCompleted, dsQueryCust);
        }

        void OnCallCompleted(IAsyncResult ar)
        {
            try 
            {
                ResultCustomer.Clear();  
                var qry = ar.AsyncState as DataServiceQuery<MyRef.Customer>;

                Result = qry.EndExecute(ar).ToList<MyRef.Customer>();

                dgCustomer.ItemsSource = ConvertListToObservableCollection(Result);
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                
            }
        }

        private ObservableCollection<MyRef.Customer> ConvertListToObservableCollection(List<MyRef.Customer> lstCustomers)
        {
            foreach (var item in lstCustomers)
            {
                ResultCustomer.Add(item);
            }

            return ResultCustomer;
        }

        private void onDataGridRowEditSelected(IAsyncResult ar)
        {
            try
            {
                var qry = ar.AsyncState as DataServiceQuery<MyRef.Customer>;

                var Result = qry.EndExecute(ar).ToList<MyRef.Customer>();

                objMyCust = Result.First<MyRef.Customer>();

                ProxyEntities.UpdateObject(objMyCust);  

                ProxyEntities.BeginSaveChanges(SaveChangesOptions.Batch, OnUpdateComplete, ProxyEntities);

                DisableAll(); 
            }
            catch (Exception ex)
            {
                string s = ex.Message;

            }
        }

        private void OnUpdateComplete(IAsyncResult ar)
        {
            var dataToUpdate = ar.AsyncState as MyRef.CompanyEntities;
            ProxyEntities.EndSaveChanges(ar);

            if (IsUpdated)
            {
                MessageBox.Show("Record Updated Successfully");
                IsUpdated = false;
            }
            if (IsInserted)
            {
                MessageBox.Show("Record Inserted Successfully");
                IsInserted = false;
            }
        }

        private void dgCustomer_RowEditEnded(object sender, DataGridRowEditEndedEventArgs e)
        {
             #region Editing Operation
                if (IsUpdated)
                {
                    var dsQrycutoToEdit = (from Cust in ProxyEntities.Customer
                                           where Cust.CustomerID == objCust.CustomerID
                                           select Cust) as DataServiceQuery<MyRef.Customer>;

                    dsQrycutoToEdit.BeginExecute(onDataGridRowEditSelected, dsQrycutoToEdit);

                    FrameworkElement elementCustAddress = dgCustomer.Columns[2].GetCellContent(e.Row);
                    string txtAddress = ((TextBlock)elementCustAddress).Text;
                    objCust.Address = txtAddress;

                    FrameworkElement elementCustCity = dgCustomer.Columns[3].GetCellContent(e.Row);
                    string txtCity = ((TextBlock)elementCustCity).Text;
                    objCust.Address = txtCity;

                    FrameworkElement elementCustState = dgCustomer.Columns[4].GetCellContent(e.Row);
                    string txtState = ((TextBlock)elementCustState).Text;
                    objCust.State = txtState;

                    FrameworkElement elementCustAge = dgCustomer.Columns[5].GetCellContent(e.Row);
                    string txtAge = ((TextBlock)elementCustAge).Text;
                    objCust.Age = Convert.ToInt32(txtAge);
                }
                #endregion

            #region Insert new Row

                if (IsInserted)
                {
                    FrameworkElement elementCustId = dgCustomer.Columns[0].GetCellContent(e.Row);
                    string txtCustId = ((TextBlock)elementCustId).Text;
                    objCust.CustomerID = Convert.ToUInt16(txtCustId);

                    FrameworkElement elementCustName = dgCustomer.Columns[1].GetCellContent(e.Row);
                    string txtCustName = ((TextBlock)elementCustName).Text;
                    objCust.CustomerName = txtCustName;


                    FrameworkElement elementCustAddress = dgCustomer.Columns[2].GetCellContent(e.Row);
                    string txtAddress = ((TextBlock)elementCustAddress).Text;
                    objCust.Address = txtAddress;

                    FrameworkElement elementCustCity = dgCustomer.Columns[3].GetCellContent(e.Row);
                    string txtCity = ((TextBlock)elementCustCity).Text;
                    objCust.Address = txtCity;

                    FrameworkElement elementCustState = dgCustomer.Columns[4].GetCellContent(e.Row);
                    string txtState = ((TextBlock)elementCustState).Text;
                    objCust.State = txtState;

                    FrameworkElement elementCustAge = dgCustomer.Columns[5].GetCellContent(e.Row);
                    string txtAge = ((TextBlock)elementCustAge).Text;
                    objCust.Age = Convert.ToInt32(txtAge);


                    ProxyEntities.AddToCustomer(objCust);

                    ProxyEntities.BeginSaveChanges(SaveChangesOptions.Batch, OnUpdateComplete, ProxyEntities);

                }

            #endregion

        }

        private void dgCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objCust = dgCustomer.SelectedItem as MyRef.Customer; 
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            IsUpdated = true;

            dgCustomer.Columns[2].IsReadOnly = false;
            dgCustomer.Columns[3].IsReadOnly = false;
            dgCustomer.Columns[4].IsReadOnly = false;
            dgCustomer.Columns[5].IsReadOnly = false;
        }

        private void DisableAll()
        {
            dgCustomer.Columns[2].IsReadOnly = true;
            dgCustomer.Columns[3].IsReadOnly = true;
            dgCustomer.Columns[4].IsReadOnly = true;
            dgCustomer.Columns[5].IsReadOnly = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            IsDeleted = true;
            var Res =  MessageBox.Show("Do you want to delete this record?","Warning",MessageBoxButton.OKCancel);

            if (Res == MessageBoxResult.OK)
            {
                ProxyEntities.DeleteObject(objCust);
                ProxyEntities.BeginSaveChanges(SaveChangesOptions.Batch, OnUpdateComplete, ProxyEntities);
                MessageBox.Show("Deleted");
                BindCustomerGrid();
            }
        }

        private void btnInsertRow_Click(object sender, RoutedEventArgs e)
        {
            ResultCustomer.Add(new MyRef.Customer());
            dgCustomer.ItemsSource = ResultCustomer;

            dgCustomer.Columns[0].IsReadOnly = false;
            dgCustomer.Columns[1].IsReadOnly = false;
            dgCustomer.Columns[2].IsReadOnly = false;
            dgCustomer.Columns[3].IsReadOnly = false;
            dgCustomer.Columns[4].IsReadOnly = false;
            dgCustomer.Columns[5].IsReadOnly = false;

            IsInserted = true;
        }

    }
}
