using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XMLToDict
{
    class Program
    {
static void Main(string[] args)
{
    XElement xelement = XElement.Load("..\\..\\Employees.xml");

    var empDict = (from element in xelement.Descendants("Employee")
                      let name = (string)element.Attribute("Name")
                      orderby name                    
                      select new
                      {
                          EmployeeID = element.Attribute("EmpId").Value,
                          EmployeeName = name
                      })
           .ToDictionary(a => a.EmployeeID,
                         a => a.EmployeeName);

    Console.ReadLine();

}
    }
}
