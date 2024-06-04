using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MvcApplication1.Models
{
    public partial class Product : IDataErrorInfo
    {

        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        partial void OnNameChanging(string value)
        {
            if (value.Trim() == String.Empty)
                _errors.Add("Name", "Name is required.");
        }


        partial void OnPriceChanging(decimal value)
        {
            if (value <= 0m)
                _errors.Add("Price", "Price must be greater than 0.");
        }


        #region IDataErrorInfo Members

        public string Error
        {
            get { return string.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                if (_errors.ContainsKey(columnName))
                    return _errors[columnName];
                return string.Empty;
            }
        }

        #endregion


    }
}
