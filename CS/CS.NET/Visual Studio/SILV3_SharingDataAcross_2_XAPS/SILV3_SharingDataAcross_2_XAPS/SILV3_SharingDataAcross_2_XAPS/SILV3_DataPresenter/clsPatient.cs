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
using System.Collections.ObjectModel;

namespace SILV3_DataPresenter
{
    public class clsPatient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Dieses { get; set; }
    }

    public class PatientCollection : ObservableCollection<clsPatient>
    {
        public PatientCollection()
        {
            Add(new clsPatient() { PatientId = 101, PatientName = "Anand", Age = 56, Dieses = "Maleria"});
            Add(new clsPatient() { PatientId = 102, PatientName = "Makran", Age = 26, Dieses = "Toiphide" });
            Add(new clsPatient() { PatientId = 103, PatientName = "Sanjay", Age = 46, Dieses = "Flue" });
            Add(new clsPatient() { PatientId = 104, PatientName = "Rajan", Age = 66, Dieses = "Cynus" });
            Add(new clsPatient() { PatientId = 105, PatientName = "Amey", Age = 36, Dieses = "Cold" });
            Add(new clsPatient() { PatientId = 106, PatientName = "Sudhir", Age = 56, Dieses = "Feaver" });
            Add(new clsPatient() { PatientId = 107, PatientName = "Shailesh", Age = 36, Dieses = "Maleria" });
            Add(new clsPatient() { PatientId = 108, PatientName = "Ajay", Age = 23, Dieses = "Cold" });
            Add(new clsPatient() { PatientId = 109, PatientName = "Shrad", Age = 36, Dieses = "Flue" });
            Add(new clsPatient() { PatientId = 1010, PatientName = "Vinit", Age = 66, Dieses = "Maleria" });  
        }
    }
}
