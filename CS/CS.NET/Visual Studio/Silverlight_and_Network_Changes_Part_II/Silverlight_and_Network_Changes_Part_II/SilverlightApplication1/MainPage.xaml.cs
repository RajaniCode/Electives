using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SilverlightApplication1.Web;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        private bool Online { get; set; }        
        private bool DataSavedLocally { get; set; }
        private MyNoteContext Context
        {
            get
            {
                return dds.DomainContext as MyNoteContext;
            }
        }

        private Note CurrentNote
        {
            get
            {
                return dgNote.SelectedItem as Note;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {            
            GetNetworkStatus();
            NetworkChange.NetworkAddressChanged += new
                NetworkAddressChangedEventHandler(NetworkChange_NetworkAddressChanged);
        }        

        void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            GetNetworkStatus();
        }

        private void GetNetworkStatus()
        {
            Online = NetworkInterface.GetIsNetworkAvailable();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            if (Online)
            {
                // save to database                           
                if (DataSavedLocally)
                {
                    var note = Retrieve("test.txt");
                    CurrentNote.Entry = note.Entry;
                    DataSavedLocally = false;
                }
                Context.SubmitChanges();
            }
            else
            {
                // save to local storage
                SaveLocally("test.txt", CurrentNote);
                DataSavedLocally = true;
            }              
        }        

        public void SaveLocally(string filename, object obj)
        {
            using (var appStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var fileStream = appStore.OpenFile(filename, FileMode.Create))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(Note));
                    serializer.WriteObject(fileStream, obj);
                }
            }
        }

        public Note Retrieve(string filename)
        {
            Note note = null;
            using (var appStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (appStore.FileExists(filename))
                {
                    using (var fileStream = appStore.OpenFile(filename, FileMode.Open))
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(Note));
                        note = serializer.ReadObject(fileStream) as Note;
                    }
                }
            }
            return note;
        }
    }
}
