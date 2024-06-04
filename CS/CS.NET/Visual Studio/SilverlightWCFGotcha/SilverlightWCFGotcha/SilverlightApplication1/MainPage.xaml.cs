using System;
using System.Windows;
using System.Windows.Controls;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGetSurname_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(Application.Current.Host.Source, "../Person.svc");
            PersonRef.PersonClient client = new PersonRef.PersonClient("CustomBinding_Person", uri.AbsoluteUri);            
            client.GetSurnameCompleted += delegate(object s, PersonRef.GetSurnameCompletedEventArgs args)
            {
                txtSurname.Text = args.Result;
            };
            client.GetSurnameAsync();
        }      
    }
}
