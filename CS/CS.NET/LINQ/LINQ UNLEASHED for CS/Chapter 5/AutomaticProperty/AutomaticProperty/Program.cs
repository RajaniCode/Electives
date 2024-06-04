using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticProperty
{
  class Program
  {
    static void Main(string[] args)
    {
      IronChef Batali = new IronChef{
        Name="Mariio Batali", Specialty="Italian" };
      Console.WriteLine(Batali.Name);
      Console.ReadLine();
    }
  }

  public class IronChef
  {
    public string Name{ get; set; }
    public string Specialty{ get; set; }
  }
}
