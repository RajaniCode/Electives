using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace SILV4_DatavalidationFeatures
{
    public class Employee : INotifyPropertyChanged,IDataErrorInfo
    {
        int _EmpNo;

        public int EmpNo
        {
            get
            { 
                return _EmpNo;
            }
            set
            {
                _EmpNo = value;
                ChangeValue("EmpNo");
            }
        }
        string _EmpName;

        public string EmpName
        {
            get
            { 
                return _EmpName;
            }
            set 
            {
                _EmpName = value;
                ChangeValue("EmpName");
            }
        }
        int _Salary;

        public int Salary
        {
            get
            { 
                return _Salary;
            }
            set 
            { 
                _Salary = value;
                ChangeValue("Salary");
            }
        }
        int _DeptNo;

        public int DeptNo
        {
            get 
            { 
                return _DeptNo; 
            }
            set 
            {
                _DeptNo = value;
                ChangeValue("DeptNo");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeValue(string PropName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
            }
        }

        string err;
        public string Error
        {
            get { return err; }
        }

        public string this[string columnName]
        {
            get 
            {
                string msg = null;
                if (columnName == "EmpNo")
                {
                    if (EmpNo <= 0 || EmpNo.ToString().Length >5)
                    {
                        msg = "EmpNo must not be Negative or Lenght must not be more than 5.";
                    }
                }
                 
                if (columnName == "EmpName")
                {
                    if (EmpName.Equals(string.Empty) )
                    {
                        msg = "EmpName is must,Please enter Correct Value.";
                    }
                }
                if (columnName == "Salary")
                {
                    if (Salary <= 0  )
                    {
                        msg = "Salary must not be Negative.";
                    }
                }
                if (columnName == "DeptNo")
                {
                    if (DeptNo <= 0 ) 
                    {
                        msg = "DeptNo must not be Negative.";
                    }
                }
                
                return msg;
            }
        }
    }

    public class EmployeeCollection
    {
        public ObservableCollection<Employee> ColEmployee { get; set; }

        public EmployeeCollection()
        {
            ColEmployee = new ObservableCollection<Employee>();
            ColEmployee.Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", Salary = 76000, DeptNo = 10 });
            ColEmployee.Add(new Employee() { EmpNo = 102, EmpName = "Amey", Salary = 66000, DeptNo = 20 });
            ColEmployee.Add(new Employee() { EmpNo = 103, EmpName = "Rajesh", Salary = 56000, DeptNo = 10 });
            ColEmployee.Add(new Employee() { EmpNo = 104, EmpName = "Rahul", Salary = 77000, DeptNo = 20 });
            ColEmployee.Add(new Employee() { EmpNo = 105, EmpName = "Ajay", Salary = 79000, DeptNo = 30 });
            ColEmployee.Add(new Employee() { EmpNo = 106, EmpName = "Pradnya", Salary = 86000, DeptNo = 10 });
        }
    }
}
