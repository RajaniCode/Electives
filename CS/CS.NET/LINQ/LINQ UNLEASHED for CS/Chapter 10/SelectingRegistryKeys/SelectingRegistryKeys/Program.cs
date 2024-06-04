using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace SelectingRegistryKeys
{
  class Program
  {
    static void Main(string[] args)
    {
      var localMachineKeys = Registry.LocalMachine.OpenSubKey("Software").GetSubKeyNames();
      var userKeys = Registry.CurrentUser.OpenSubKey("Software").GetSubKeyNames();

      // keys in common
      var commonKeys = from machineKey in localMachineKeys
                       where machineKey.StartsWith("A")
                       from userKey in userKeys
                       where userKey.StartsWith("A") && 
                       /*where*/ machineKey == userKey
                       select machineKey;

      Array.ForEach(commonKeys.ToArray(), key => Console.WriteLine(key));
      Console.ReadLine();
    }
  }
}

