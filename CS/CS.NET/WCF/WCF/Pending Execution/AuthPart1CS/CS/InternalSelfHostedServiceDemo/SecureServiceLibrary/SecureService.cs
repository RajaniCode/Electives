﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SecureServiceLibrary
{
  public class SecureService : ISecureService
  {
    public string SayHello()
    {
      return string.Format("Hello {0}", 
        System.Threading.Thread.CurrentPrincipal.Identity.Name);
    }

    public decimal ReportSales()
    {
      return 10000M;
    }
  }
}
