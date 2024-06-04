using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToActiveDirectory;
using ActiveDs;

namespace QueryActiveDirectory
{
  [DirectorySchema("user", typeof(IADsUser))]
  class User
  {
    public string Name { get; set; }

    public string Description { get; set; }

    public int LogonCount { get; set; }

    [DirectoryAttribute("PasswordLastChanged", DirectoryAttributeType.ActiveDs)]
    public DateTime PasswordLastSet { get; set; }

    [DirectoryAttribute("distinguishedName")]
    public string Dn { get; set; }

    [DirectoryAttribute("memberOf")]
    public string[] Groups { get; set; }
  }
}