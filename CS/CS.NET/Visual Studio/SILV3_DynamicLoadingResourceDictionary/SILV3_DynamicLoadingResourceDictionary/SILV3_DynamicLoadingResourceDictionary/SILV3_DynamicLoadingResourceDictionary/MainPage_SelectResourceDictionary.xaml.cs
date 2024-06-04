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

using System.Xml;
using System.Xml.Linq; 
 

namespace SILV3_DynamicLoadingResourceDictionary
{
    public partial class MainPage_SelectResourceDictionary : UserControl
    {
        ResourceDictionary rd1, rd2;
        string rdName;

        XDocument xDoc;

        string resourceKeyName;



        public MainPage_SelectResourceDictionary()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_SelectResourceDictionary_Loaded);
        }

        void MainPage_SelectResourceDictionary_Loaded(object sender, RoutedEventArgs e)
        {

            //This will Read Keys Collection for the xml file
            xDoc = XDocument.Load("ResourceDictionaryStorage.xml");
            var KeyCollection = from file in xDoc.Descendants("ResourceDictionaryData").Elements("FileName")
                                select file;

            foreach (var item in KeyCollection)
            {
                lstResourceDict.Items.Add(item.Attribute("Value").Value);    
            }
        }

        private void lstResourceDict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            rdName = lstResourceDict.SelectedItem as string; 

            xDoc = XDocument.Load("ResourceDictionaryStorage.xml");

            //This will Read ResourceDictionary file
            var FileName = from file in xDoc.Descendants("ResourceDictionaryData").Elements("FileName") 
                           where file.Attribute("Value").Value == rdName
                           select file;
            
            foreach (var item in FileName)
            {
                resourceKeyName = item.Attribute("Name").Value;  
            }

            rd1 = new ResourceDictionary();
            rd1.Source = new Uri(resourceKeyName, UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd1);
            System.Windows.Style btnStyle = rd1[rdName] as Style;
            btnOne.Style = btnStyle;

            rd2 = new ResourceDictionary();

            rd2.Source = new Uri(resourceKeyName, UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd2);

            System.Windows.Style btnStyle1 = rd2[rdName] as Style;

            btnTwo.Style = btnStyle1;

        }
    }
}
