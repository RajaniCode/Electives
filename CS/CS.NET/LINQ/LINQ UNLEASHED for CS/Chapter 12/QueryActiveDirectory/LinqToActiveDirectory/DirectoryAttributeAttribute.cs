using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToActiveDirectory
{
  public sealed class DirectoryAttributeAttribute : Attribute
  {
    public DirectoryAttributeAttribute(string attribute)
    {
      Attribute = attribute;
      QuerySource = DirectoryAttributeType.Ldap;
    }

    public DirectoryAttributeAttribute(string attribute, 
      DirectoryAttributeType querySource)
    {
      Attribute = attribute;
      QuerySource = querySource;
    }

    public string Attribute { get; private set; }
    public DirectoryAttributeType QuerySource { get; set; }
  }
}