using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NorthWind.Business.LS
{
    public partial class NorthWindDataContext
    {
        partial void OnCreated()
        {
            this.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindEFConnectionString"].ConnectionString;
        }
    }
}
