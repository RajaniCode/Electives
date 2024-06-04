using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Commands;
using SL4_DataGrid_Custom_Command_Behavior.MyRef;
using System.Windows.Threading;
using System.Windows;

namespace SL4_DataGrid_Custom_Command_Behavior
{
    public class ViewModel : INotifyPropertyChanged
    {

        #region Local Variables
        bool isInsertOperation = false;
        bool isUpdateCompleted = false;
        bool isInsertCompleted = false;
        bool isDeleteCompleted = false;
        DispatcherTimer timer = new DispatcherTimer(); 
        #endregion


        #region Property Changed Event Declaration
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string pName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pName));
            }
        } 
        #endregion

        public IServiceAdapter SrvAdapter { get; set; }

        #region Constructors
        public ViewModel()
            : this(new ServiceAdapter())
        {

        }

        public ViewModel(IServiceAdapter srvAdpt)
        {
            if (srvAdpt != null)
            {
                SrvAdapter = srvAdpt;
                LoadEmployeeCommand = new DelegateCommand<object>(LoadingEmployeeDone, CanEmployeeLoaded);
                UpdateEmployeeCommand = new DelegateCommand<object>(UpdatingEmployeeDone, CanEmployeeUpdated);
                InsertEmployeeCommand = new DelegateCommand<object>(InsertingEmployeeDone, CanEmployeeInserted);
                DeleteEmployeeCommand = new DelegateCommand<object>(DeletingEmployeeDone, CanEmployeeDeleted);
            }
        } 
        #endregion


        #region Properties used for DataBinding with UI
        private EmployeeInfo _EmployeeSelected = new EmployeeInfo();

        public EmployeeInfo EmployeeSelected
        {
            get { return _EmployeeSelected; }
            set
            {
                if (_EmployeeSelected != value)
                {
                    _EmployeeSelected = value;
                    OnPropertyChanged("EmployeeSelected");
                    InsertEmployeeCommand.IsActive = true;
                }
            }
        }

        private ObservableCollection<EmployeeInfo> _Employees = new ObservableCollection<EmployeeInfo>();

        public ObservableCollection<EmployeeInfo> Employees
        {
            get { return _Employees; }
            set
            {
                _Employees = value;
                OnPropertyChanged("Employees");
            }
        }

        string _StrOperationStatus;

        public string StrOperationStatus
        {
            get { return _StrOperationStatus; }
            set
            {
                _StrOperationStatus = value;
                OnPropertyChanged("StrOperationStatus");
            }
        } 
        #endregion


        #region View-Model Methods Calling Methods from ServiceAdapter Class.
        private void LoadEmployees()
        {
            SrvAdapter.GetEmployees((s, e) => Employees = e.Result);
        }

        private void UpdateEmployee(EmployeeInfo objEmp)
        {
            if (isInsertOperation)
            {
                //Logic on Insert
                SrvAdapter.CreateEmployee(objEmp, (s, e) => StrOperationStatus = e.Result);
                isInsertOperation = false;
                isInsertCompleted = true;
            }
            else
            {
                //Logic of Update
                SrvAdapter.UpdateEmployee(objEmp, (s, e) => StrOperationStatus = e.Result);
                isUpdateCompleted = true;
            }
        }

        private void InsertEmployee()
        {
            Employees.Add(new EmployeeInfo());
            isInsertOperation = true;
        }

        private void DepeteEmployeeComfirm(EmployeeInfo objEmp)
        {
            SrvAdapter.DeleteEmployee(objEmp, (s, e) => StrOperationStatus = e.Result);
            isDeleteCompleted = true;
        } 
        #endregion

        #region Delegate Commands and DataEventArgs Event Handlers for Operation Notifications
        public event EventHandler<DataEventArgs<ViewModel>> LoadEmployeeCompled;
        public event EventHandler<DataEventArgs<ViewModel>> UpdateEmployeeCompled;
        public event EventHandler<DataEventArgs<ViewModel>> InsertEmployeeCompled;
        public event EventHandler<DataEventArgs<ViewModel>> DeleteEmployeeCompled;

        public DelegateCommand<object> LoadEmployeeCommand { get; private set; }
        public DelegateCommand<object> UpdateEmployeeCommand { get; private set; }
        public DelegateCommand<object> InsertEmployeeCommand { get; private set; }
        public DelegateCommand<object> DeleteEmployeeCommand { get; private set; } 
        #endregion


        #region CanExecute and Execute Methods for Delegate Commands. 
        private bool CanEmployeeLoaded(object args)
        {
            return true;
        }
        private void LoadingEmployeeDone(object obj)
        {
            StrOperationStatus = "";
            LoadEmployees();
            OnLoadEmployeeCompleted(new DataEventArgs<ViewModel>(this));
        }

        private void OnLoadEmployeeCompleted(DataEventArgs<ViewModel> handler)
        {
            EventHandler<DataEventArgs<ViewModel>> LoadEmployeeHandler = LoadEmployeeCompled;
            if (LoadEmployeeHandler != null)
            {
                LoadEmployeeHandler(this, handler);
            }
        }

        private bool CanEmployeeUpdated(object args)
        {
            return true;
        }
        private void UpdatingEmployeeDone(object obj)
        {
            UpdateEmployee(obj as EmployeeInfo);
            OnUpdatingEmployeeCompleted(new DataEventArgs<ViewModel>(this));
        }

        private void OnUpdatingEmployeeCompleted(DataEventArgs<ViewModel> handler)
        {
            EventHandler<DataEventArgs<ViewModel>> UpdateEmployeeHandler = UpdateEmployeeCompled;
            if (UpdateEmployeeHandler != null)
            {
                UpdateEmployeeHandler(this, handler);
            }
            if (isInsertCompleted || isUpdateCompleted)
            {
                timer.Interval = TimeSpan.FromMilliseconds(5000);
                timer.Start();
                timer.Tick += new EventHandler(timer_Tick);
                isInsertCompleted = false;
                isUpdateCompleted = false;
            }

        }

        void timer_Tick(object sender, EventArgs e)
        {
            LoadEmployees();
            timer.Tick -= new EventHandler(timer_Tick);
            MessageBox.Show(StrOperationStatus);
        }

        private bool CanEmployeeInserted(object args)
        {
            return true;
        }
        private void InsertingEmployeeDone(object obj)
        {
            InsertEmployee();
            OnInsertingEmployeeCompleted(new DataEventArgs<ViewModel>(this));
        }

        private void OnInsertingEmployeeCompleted(DataEventArgs<ViewModel> handler)
        {
            EventHandler<DataEventArgs<ViewModel>> InsertEmployeeHandler = InsertEmployeeCompled;
            if (InsertEmployeeHandler != null)
            {
                InsertEmployeeHandler(this, handler);
            }
        }

        private bool CanEmployeeDeleted(object args)
        {
            return true;
        }
        private void DeletingEmployeeDone(object obj)
        {
            DepeteEmployeeComfirm(obj as EmployeeInfo);
            OnDeletingEmployeeCompleted(new DataEventArgs<ViewModel>(this));
            if (isDeleteCompleted)
            {
                timer.Interval = TimeSpan.FromMilliseconds(5000);
                timer.Start();
                timer.Tick += new EventHandler(timer_Tick);
                isDeleteCompleted = false;
            }

        }

        private void OnDeletingEmployeeCompleted(DataEventArgs<ViewModel> handler)
        {
            EventHandler<DataEventArgs<ViewModel>> DeleteEmployeeHandler = DeleteEmployeeCompled;
            if (DeleteEmployeeHandler != null)
            {
                DeleteEmployeeHandler(this, handler);
            }
        } 
        #endregion
    }
}
