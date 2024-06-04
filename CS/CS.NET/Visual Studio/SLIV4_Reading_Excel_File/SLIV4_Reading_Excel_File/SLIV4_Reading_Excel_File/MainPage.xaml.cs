using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices.Automation;

namespace SLIV4_Reading_Excel_File
{
    public partial class MainPage : UserControl
    {
        /// <summary>
        /// This article is written for DotNetCurry.com
        /// www.dotnetcurry.com/BrowseArticles.aspx?CatID=56
        /// </summary>
        ObservableCollection<PopulationClass> populationData;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog flDialog = new OpenFileDialog();
            flDialog.Filter = "Excel Files(*.xlsx)|*.xlsx";

            bool res = (bool)flDialog.ShowDialog();

            if (res)
            {
                FileInfo fs = flDialog.File;

                string fileName =  fs.Name;

                #region Reading Data From Excel File

                dynamic objExcel = AutomationFactory.CreateObject("Excel.Application");

                //Open the Workbook Here
                dynamic objExcelWorkBook = 
                    objExcel.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
                    + "\\" + fileName);
                //Read the Worksheet
                dynamic objActiveWorkSheet = objExcelWorkBook.ActiveSheet();
                //Cells to Read
                dynamic objCell_1,objCell_2;

                //Iterate through Cells
                for (int count = 2; count < 17; count++)
                {
                    objCell_1 = objActiveWorkSheet.Cells[count, 1];
                    objCell_2 = objActiveWorkSheet.Cells[count, 2];
                    populationData.Add
                        (
                            new PopulationClass()
                            {
                                StateName = objCell_1.Value,
                                Population = objCell_2.Value
                            }
                        );
                }

                dgExcelData.ItemsSource = populationData;

                #endregion
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            populationData = new ObservableCollection<PopulationClass>(); 
        }

       
    }
}
