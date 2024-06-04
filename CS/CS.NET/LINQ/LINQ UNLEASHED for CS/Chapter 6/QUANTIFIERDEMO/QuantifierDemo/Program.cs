using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantifierDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      var household = new List<FamilyMember>{
        new FamilyMember{Name="Paul Kimmel", Species="Lunkhead in Chief", Gender="Male"},
        new FamilyMember{Name="Dena Swanson", Species="Boss", Gender="Female"},
        new FamilyMember{Name="Alex Kimmel", Species="Princess", Gender="Female"},
        new FamilyMember{Name="Noah Kimmel", Species="Annoying Brother", Gender="Male"},
        new FamilyMember{Name="Joe Swanson", Species="Homosapien", Gender="Male"},
        new FamilyMember{Name="Ruby", Species="Canine", Gender="Female"},
        new FamilyMember{Name="Leda", Species="Canine", Gender="Female"},
        new FamilyMember{Name="Big Mama", Species="Feline", Gender="Female"}
      };

      bool anyCats = household.Any(m=>m.Species == "Feline");
      Console.WriteLine("Do you have cats? {0}", anyCats);
      
      var pooches = from member in household where household.Any(m=>m.Species=="Canine") 
        select member;

      Array.ForEach(pooches.ToArray(), m=>Console.WriteLine(m));
      Console.ReadLine();

    }
  }

  public class FamilyMember
  {
    public string Name{get; set; }
    public string Species{ get; set; }
    public string Gender{ get; set; }

    public override string ToString()
    {
      return string.Format("Name={0}, Species={1}, Gender={2}", 
        Name, Species, Gender);
    }
  }
}
