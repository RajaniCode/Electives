using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ListToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID = 1, FName = "John", LName = "Shields", DOB = DateTime.Parse("12/11/1971"), Sex = 'M' });
            empList.Add(new Employee() { ID = 2, FName = "Mary", LName = "Jacobs", DOB = DateTime.Parse("01/17/1961"), Sex = 'F' });
            empList.Add(new Employee() { ID = 3, FName = "Amber", LName = "Agar", DOB = DateTime.Parse("12/23/1971"), Sex = 'M' });
            empList.Add(new Employee() { ID = 4, FName = "Kathy", LName = "Berry", DOB = DateTime.Parse("11/15/1976"), Sex = 'F' });
            empList.Add(new Employee() { ID = 5, FName = "Lena", LName = "Bilton", DOB = DateTime.Parse("05/11/1978"), Sex = 'F' });
            empList.Add(new Employee() { ID = 6, FName = "Susanne", LName = "Buck", DOB = DateTime.Parse("03/7/1965"), Sex = 'F' });
            empList.Add(new Employee() { ID = 7, FName = "Jim", LName = "Brown", DOB = DateTime.Parse("09/11/1972"), Sex = 'M' });
            empList.Add(new Employee() { ID = 8, FName = "Jane", LName = "Hooks", DOB = DateTime.Parse("12/11/1972"), Sex = 'F' });
            empList.Add(new Employee() { ID = 9, FName = "Robert", LName = "", DOB = DateTime.Parse("06/28/1964"), Sex = 'M' });
            empList.Add(new Employee() { ID = 10, FName = "Cindy", LName = "Fox", DOB = DateTime.Parse("01/11/1978"), Sex = 'M' });

            try
            {
                var xEle = new XElement("Employees",
                            from emp in empList
                            select new XElement("Employee",
                                         new XAttribute("ID", emp.ID),
                                           new XElement("FName", emp.FName),
                                           new XElement("LName", emp.LName),
                                           new XElement("DOB", emp.DOB),
                                           new XElement("Sex", emp.Sex)
                                       ));

                xEle.Save("D:\\employees.xml");
                Console.WriteLine("Converted to XML");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }
    }

    class Employee
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DOB { get; set; }
        public char Sex { get; set; }
    }
}
