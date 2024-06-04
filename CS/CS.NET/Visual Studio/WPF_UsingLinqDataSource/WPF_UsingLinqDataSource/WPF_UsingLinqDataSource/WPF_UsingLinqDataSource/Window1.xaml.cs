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

using System.Xml.Linq;

using System.Collections.ObjectModel;  

namespace WPF_UsingLinqDataSource
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public static XElement empList;



        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
     //    this.lstEmp.SelectionChanged += new SelectionChangedEventHandler(lstEmp_SelectionChanged);
          this.lstCOE.SelectionChanged += new SelectionChangedEventHandler(lstCOE_SelectionChanged);
        }

        void lstCOE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            XElement listSelectedData = lstCOE.SelectedValue as XElement;
            string listAttributedData = listSelectedData.Attribute("name").Value;

            //The Collection object for Storing the Data
            ObservableCollection<CEmployee> empData = new ObservableCollection<CEmployee>();

            var nodeDepartment = from Emp in empList.Descendants("Department").Elements("COE")
                                 where Emp.Attribute("name").Value == listAttributedData
                                 select Emp;

            foreach (var item in nodeDepartment)
            {
                 var coeResult = from emp in nodeDepartment.Descendants("Employee")
                         select new CEmployee
                             {
                                 EmpName = emp.Attribute("name").Value, //Reads the Attribute EmpName
                                 EmpNo = emp.Element("no").Value //Reads the EMployee No
                             };

                            //Now Put the data in collection
                          foreach (var res in coeResult)
                            {
                                empData.Add(res);
                            }
            }

            //Assign the Data Source
            dgEmp.DataContext = empData;  
        }

        void lstEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            XElement listSelectedData = lstEmp.SelectedValue as XElement;
            string listAttributedData = listSelectedData.Attribute("name").Value;  

            var nodeDepartment = from emp in empList.Descendants("Department").Descendants("COE")
                                 .Descendants("Employee")
                                select new CEmployee
                                 {
                                     EmpNo = emp.Element("no").Value,
                                     EmpName = emp.Attribute("name").Value
                                 };
            
            ObservableCollection<CEmployee> empData = new ObservableCollection<CEmployee>();

            foreach (var item in nodeDepartment)
            {
                if (item.EmpName == listAttributedData)
                {
                    empData.Add(item);
                    break;
                }
            }
            dgEmp.DataContext = empData;  


        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            empList = (this.FindResource("EmpDs") as ObjectDataProvider).Data as XElement; 
        }


       
    }
}
