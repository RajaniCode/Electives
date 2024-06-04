using System;
using System.Collections.Generic;

public class Employee
{
    public int ID { get; set; }
    public string FName { get; set; }
    public string MName { get; set; }
    public string LName { get; set; }
    public DateTime DOB { get; set; }
    public char Sex { get; set; }

    public List<Employee> GetEmployeeList()
    {
        List<Employee> empList = new List<Employee>();
        empList.Add(new Employee() { ID = 1, FName = "John", MName = "", LName = "Shields", DOB = DateTime.Parse("12/11/1971"), Sex = 'M' });
        empList.Add(new Employee() { ID = 2, FName = "Mary", MName = "Matthew", LName = "Jacobs", DOB = DateTime.Parse("01/17/1961"), Sex = 'F' });
        empList.Add(new Employee() { ID = 3, FName = "Amber", MName = "Carl", LName = "Agar", DOB = DateTime.Parse("12/23/1971"), Sex = 'M' });
        empList.Add(new Employee() { ID = 4, FName = "Kathy", MName = "", LName = "Berry", DOB = DateTime.Parse("11/15/1976"), Sex = 'F' });
        empList.Add(new Employee() { ID = 5, FName = "Lena", MName = "Ashco", LName = "Bilton", DOB = DateTime.Parse("05/11/1978"), Sex = 'F' });
        empList.Add(new Employee() { ID = 6, FName = "Susanne", MName = "", LName = "Buck", DOB = DateTime.Parse("03/7/1965"), Sex = 'F' });
        empList.Add(new Employee() { ID = 7, FName = "Jim", MName = "", LName = "Brown", DOB = DateTime.Parse("09/11/1972"), Sex = 'M' });
        empList.Add(new Employee() { ID = 8, FName = "Jane", MName = "G", LName = "Hooks", DOB = DateTime.Parse("12/11/1972"), Sex = 'F' });
        empList.Add(new Employee() { ID = 9, FName = "Robert", MName = "", LName = "", DOB = DateTime.Parse("06/28/1964"), Sex = 'M' });
        empList.Add(new Employee() { ID = 10, FName = "Krishna", MName = "Murali", LName = "Sunkam", DOB = DateTime.Parse("04/18/1969"), Sex = 'M' });
        empList.Add(new Employee() { ID = 11, FName = "Cindy", MName = "Preston", LName = "Fox", DOB = DateTime.Parse("06/15/1978"), Sex = 'M' });
        empList.Add(new Employee() { ID = 12, FName = "Nicole", MName = "G", LName = "Holiday", DOB = DateTime.Parse("08/21/1974"), Sex = 'F' });
        empList.Add(new Employee() { ID = 13, FName = "Sandra", MName = "T", LName = "Feng", DOB = DateTime.Parse("04/15/1976"), Sex = 'F' });
        empList.Add(new Employee() { ID = 14, FName = "Roberto", MName = "", LName = "Tamburello", DOB = DateTime.Parse("01/06/1982"), Sex = 'M' });
        empList.Add(new Employee() { ID = 15, FName = "Cynthia", MName = "O", LName = "Lugo", DOB = DateTime.Parse("01/21/1968"), Sex = 'M' });
        empList.Add(new Employee() { ID = 16, FName = "Yuhong", MName = "R", LName = "Li", DOB = DateTime.Parse("08/22/1979"), Sex = 'M' });
        empList.Add(new Employee() { ID = 17, FName = "Alex", MName = "", LName = "Shoop", DOB = DateTime.Parse("03/01/1972"), Sex = 'M' });
        empList.Add(new Employee() { ID = 18, FName = "Jack", MName = "K", LName = "Brown", DOB = DateTime.Parse("04/11/1978"), Sex = 'M' });
        empList.Add(new Employee() { ID = 19, FName = "Andrew", MName = "U", LName = "Gibson", DOB = DateTime.Parse("08/21/1977"), Sex = 'M' });
        empList.Add(new Employee() { ID = 20, FName = "George", MName = "K", LName = "Wood", DOB = DateTime.Parse("07/15/1972"), Sex = 'M' });
        empList.Add(new Employee() { ID = 21, FName = "Eugene", MName = "", LName = "Miller", DOB = DateTime.Parse("09/13/1974"), Sex = 'M' });
        empList.Add(new Employee() { ID = 22, FName = "Russell", MName = "", LName = "Gorgi", DOB = DateTime.Parse("08/19/1978"), Sex = 'M' });
        empList.Add(new Employee() { ID = 23, FName = "Katie", MName = "", LName = "Sylar", DOB = DateTime.Parse("08/21/1978"), Sex = 'M' });
        empList.Add(new Employee() { ID = 24, FName = "Michael", MName = "M", LName = "Bentler", DOB = DateTime.Parse("11/26/1977"), Sex = 'M' });
        empList.Add(new Employee() { ID = 25, FName = "Barbara", MName = "L", LName = "Duffy", DOB = DateTime.Parse("05/29/1972"), Sex = 'M' });
        empList.Add(new Employee() { ID = 26, FName = "Stefen", MName = "J", LName = "Northup", DOB = DateTime.Parse("01/26/1972"), Sex = 'M' });
        empList.Add(new Employee() { ID = 27, FName = "Shane", MName = "", LName = "Nay", DOB = DateTime.Parse("02/21/1978"), Sex = 'M' });
        empList.Add(new Employee() { ID = 28, FName = "Brenda", MName = "", LName = "Lugo", DOB = DateTime.Parse("08/18/1981"), Sex = 'F' });
        empList.Add(new Employee() { ID = 29, FName = "Shammi", MName = "I", LName = "Rai", DOB = DateTime.Parse("03/13/1968"), Sex = 'M' });
        empList.Add(new Employee() { ID = 30, FName = "Rajesh", MName = "H", LName = "Vyas", DOB = DateTime.Parse("04/19/1969"), Sex = 'M' });
        empList.Add(new Employee() { ID = 31, FName = "Gabe", MName = "P", LName = "Lloyd", DOB = DateTime.Parse("08/21/1971"), Sex = 'M' });
        return empList;
    }
}
