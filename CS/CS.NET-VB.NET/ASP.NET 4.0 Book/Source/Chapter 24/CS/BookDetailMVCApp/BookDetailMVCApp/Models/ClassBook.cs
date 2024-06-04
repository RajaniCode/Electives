using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookDetailMVCApp.Models
{
    public class ClassBook
    {
        #region properties
        public string BName { get; set; }
        public string BPrice { get; set; }
        public string BEdition { get; set; }
        public string BISBN { get; set; }
        public string publisher { get; set; }
        #endregion

    }
}