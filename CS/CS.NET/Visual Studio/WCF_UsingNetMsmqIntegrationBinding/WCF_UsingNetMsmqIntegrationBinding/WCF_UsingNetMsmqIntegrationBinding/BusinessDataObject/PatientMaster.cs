using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessDataObject
{
    [Serializable]
    public class PatientMaster
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public int PatientAge { get; set; }
    }
}
