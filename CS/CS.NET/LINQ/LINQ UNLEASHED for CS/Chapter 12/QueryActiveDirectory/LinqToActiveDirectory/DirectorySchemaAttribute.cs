using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToActiveDirectory
{
  public sealed class DirectorySchemaAttribute : Attribute
  {

    public DirectorySchemaAttribute(string schema)
    {
      Schema = schema;
    }

    public DirectorySchemaAttribute(string schema, Type type)
    {
      Schema = schema;
      HelperType = type;
    }

    public string Schema { get; private set; }
    public Type HelperType { get; set; }
  }
}