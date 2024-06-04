using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;

using MSExcel = Microsoft.Office.Interop.Excel;

namespace WFP40_COMInterop_Enhancement
{
    /// <summary>
    /// Interaction logic for Window_SalesGraph.xaml
    /// </summary>
    public partial class Window_SalesGraph : Window
    {

        DataAccess objDs;
        public Window_SalesGraph()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            objDs = new DataAccess();
            this.DataContext = objDs.GetSalesDetails();
             
        }
        string compName;
        KeyValuePair<string, decimal>[] arrSalesData;
        private void lstCompanyName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lstSalesDetails = objDs.GetSalesDetails();

            Sales compItem = lstCompanyName.SelectedItem as Sales;

              compName = compItem.CompanyName;

            var companywiseSales = (from sales in lstSalesDetails
                                   where sales.CompanyName == compName
                                   select sales).ToList();

             arrSalesData = 
                new KeyValuePair<string, decimal>[]
                {
                    new KeyValuePair<string,decimal>(companywiseSales[0].CompanyName,companywiseSales[0].Q1_Sales),
                    new KeyValuePair<string,decimal>(companywiseSales[0].CompanyName,companywiseSales[0].Q2_Sales),
                    new KeyValuePair<string,decimal>(companywiseSales[0].CompanyName,companywiseSales[0].Q3_Sales),
                    new KeyValuePair<string,decimal>(companywiseSales[0].CompanyName,companywiseSales[0].Q4_Sales),
                };

           
            chartSales.DataContext = arrSalesData;

            PieSeries thePieChart = chartSales.Series[0] as PieSeries;

            thePieChart.ItemsSource = arrSalesData;
        }

        private void btnGenerateExcelreport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get the Excel Object

                var MyExcel = new MSExcel.Application(); 

                //Add the Workbook

                MyExcel.Workbooks.Add();
 
                //Define the Range in which the data of the Sales Information is Displayed

                MyExcel.Cells[1, 1] = "Company Name"; //The company Name
                MyExcel.Cells[1, 2] = "Q1 Sales";
                MyExcel.Cells[1, 3] = "Q2 Sales";
                MyExcel.Cells[1, 4] = "Q3 Sales";
                MyExcel.Cells[1, 5] = "Q4 Sales";

            
                //Pue the data in Cell This is the Sales daat of all four quarters

                MyExcel.Cells[2, 1] = compName;
                MyExcel.Cells[2, 2] = arrSalesData[0].Value;
                MyExcel.Cells[2, 3] = arrSalesData[1].Value;
                MyExcel.Cells[2, 4] = arrSalesData[2].Value;
                MyExcel.Cells[2, 5] = arrSalesData[3].Value;


                //Display the Excel
                MyExcel.Visible = true;  


                //Now to Generate the Excel Graph we must Read the Range

                //Here The type casting is not required (Specification of .NET 4.0)
                MSExcel.Range dataRange = MyExcel.Cells[2, 5];    

                //Select the Active Workbook for drawing the Chart
                MSExcel.Chart saleChart = MyExcel.ActiveWorkbook.Charts.Add(MyExcel.ActiveSheet);

                saleChart.ChartWizard(Source: dataRange.CurrentRegion, Title: "Quarter wise sale from :" + compName);

                saleChart.ChartType = MSExcel.XlChartType.xlPie;

                //saleChart.CopyPicture(MSExcel.XlPictureAppearance.xlScreen,
                //    MSExcel.XlCopyPictureFormat.xlBitmap,
                //    MSExcel.XlPictureAppearance.xlScreen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }
        }
    }
}
