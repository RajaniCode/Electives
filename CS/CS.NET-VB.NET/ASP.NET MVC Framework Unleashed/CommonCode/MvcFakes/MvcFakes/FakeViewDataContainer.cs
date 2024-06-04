using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcFakes
{
    public class FakeViewDataContainer : IViewDataContainer
    {
        private ViewDataDictionary _viewData = new ViewDataDictionary();

        #region IViewDataContainer Members

        public ViewDataDictionary ViewData
        {
            get
            {
                return _viewData;
            }
            set
            {
                _viewData = value;
            }
        }

        #endregion
    }
}
