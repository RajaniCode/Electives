using System;

namespace WebApplication1
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string ValidationGroup
        {
            set { valErrorSummary.ValidationGroup = value; }
        }        
    }
}
