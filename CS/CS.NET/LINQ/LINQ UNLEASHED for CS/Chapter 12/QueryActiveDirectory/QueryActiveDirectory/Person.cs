using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToActiveDirectory;
using ActiveDs;

//ms-help://MS.VSCC.v90/MS.MSDNQTR.v90.en/adschema/adschema/c_user.htm

namespace QueryActiveDirectory
{
  [DirectorySchema("person")]
  //[DirectorySchema("Person", typeof(IADsUser))]
  public class Person
  {
    //public string Name { get; set; }

    [DirectoryAttribute("Display-Name", DirectoryAttributeType.Ldap)]
    public string DisplayName { get; set; }


    [DirectoryAttribute("User-Password", DirectoryAttributeType.Ldap)]
    public string UserPassword { get; set; }

    
  }
}