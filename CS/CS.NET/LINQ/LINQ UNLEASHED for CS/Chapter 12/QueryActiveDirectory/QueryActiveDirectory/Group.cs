using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToActiveDirectory;

namespace QueryActiveDirectory
{
  [DirectorySchema("group")]
  class Group
  {
    public string Name { get; set; }

    [DirectoryAttribute("member")]
    public string[] Members { get; set; }
  }


}