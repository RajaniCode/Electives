using System.Text;
using System.Reflection;
using System;
using System.Linq;

namespace Inheritance
{

  partial class InheritanceDataContext
  {
  }

  partial class Person
  {
    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      builder.Append(this.GetType().Name + "\n");
      PropertyInfo[] props = this.GetType().GetProperties();

      // using array for each
      Array.ForEach(props.ToArray(), prop =>
        builder.AppendFormat("{0} : {1}", prop.Name,
          prop.GetValue(this, null) == null ? "<empty>\n" :
          prop.GetValue(this, null).ToString() + "\n"));

      return builder.ToString();
    }
  }
}
