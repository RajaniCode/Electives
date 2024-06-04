Module Module1

    Sub Main()
        Dim empList As New List(Of Employee)()
        empList.Add(New Employee() With {.ID = 1, .FName = "John", .MName = "", .LName = "Shields", .DOB = DateTime.Parse("12/11/1971"), .Sex = "M"c})
        empList.Add(New Employee() With {.ID = 2, .FName = "Mary", .MName = "Matthew", .LName = "Jacobs", .DOB = DateTime.Parse("01/17/1961"), .Sex = "F"c})
        empList.Add(New Employee() With {.ID = 3, .FName = "Amber", .MName = "Carl", .LName = "Agar", .DOB = DateTime.Parse("12/23/1971"), .Sex = "M"c})
        empList.Add(New Employee() With {.ID = 4, .FName = "Kathy", .MName = "", .LName = "Berry", .DOB = DateTime.Parse("11/15/1976"), .Sex = "F"c})
        empList.Add(New Employee() With {.ID = 5, .FName = "Lena", .MName = "Ashco", .LName = "Bilton", .DOB = DateTime.Parse("05/11/1978"), .Sex = "F"c})
        empList.Add(New Employee() With {.ID = 6, .FName = "Susanne", .MName = "", .LName = "Buck", .DOB = DateTime.Parse("03/7/1965"), .Sex = "F"c})
        empList.Add(New Employee() With {.ID = 7, .FName = "Jim", .MName = "", .LName = "Brown", .DOB = DateTime.Parse("09/11/1972"), .Sex = "M"c})
        empList.Add(New Employee() With {.ID = 8, .FName = "Jane", .MName = "G", .LName = "Hooks", .DOB = DateTime.Parse("12/11/1972"), .Sex = "F"c})
        empList.Add(New Employee() With {.ID = 9, .FName = "Robert", .MName = "", .LName = "", .DOB = DateTime.Parse("06/28/1964"), .Sex = "M"c})
        empList.Add(New Employee() With {.ID = 10, .FName = "Cindy", .MName = "Preston", .LName = "Fox", .DOB = DateTime.Parse("01/11/1978"), .Sex = "M"c})

        ' Printing the List
        Console.WriteLine(Constants.vbLf & "{0,2} {1,7}    {2,8}      {3,8}      {4,23}      {5,3}", "ID", "FName", "MName", "LName", "DOB", "Sex")
        empList.ForEach(AddressOf AnonymousMethod1)

        Console.ReadLine()


        ' Group People by the First Letter of their FirstName
        Dim grpOrderedFirstLetter = empList.GroupBy(Function(employees) New String(employees.FName(0), 1)).OrderBy(Function(employees) employees.Key.ToString())


        For Each employee In grpOrderedFirstLetter
            Console.WriteLine(Constants.vbLf & "'Employees having First Letter {0}':", employee.Key.ToString())
            For Each empl In employee
                Console.WriteLine(empl.FName)
            Next empl
        Next employee

        Console.ReadLine()


        ' Group People by the Year in which they were born            
        Dim grpOrderedYr = empList.GroupBy(Function(employees) employees.DOB.Year).OrderBy(Function(employees) employees.Key)

        For Each employee In grpOrderedYr
            Console.WriteLine(Constants.vbLf & "Employees Born In the Year " & employee.Key)
            For Each empl In employee
                Console.WriteLine("{0,2} {1,7}", empl.ID, empl.FName)
            Next empl
        Next employee
        Console.ReadLine()


        ' Group people by the Year and Month in which they were born
        Dim grpOrderedYrMon = empList.GroupBy(Function(employees) New DateTime(employees.DOB.Year, employees.DOB.Month, 1)).OrderBy(Function(employees) employees.Key)


        For Each employee In grpOrderedYrMon
            Console.WriteLine(Constants.vbLf & "Employees Born in Year {0} - Month {1} is/are :", employee.Key.Year, employee.Key.Month)
            For Each empl In employee
                Console.WriteLine("{0}: {1}", empl.ID, empl.FName)
            Next empl
        Next employee
        Console.ReadLine()


        ' Count people grouped by the Year in which they were born
        Dim grpCountYrMon = empList.GroupBy(Function(employees) employees.DOB.Year).Select(Function(lst) New With {Key .Year = lst.Key, Key .Count = lst.Count()})

        For Each employee In grpCountYrMon
            Console.WriteLine(Constants.vbLf & "{0} were born in {1}", employee.Count, employee.Year)
        Next employee
        Console.ReadLine()


        ' Sex Ratio
        Dim ratioSex = empList.GroupBy(Function(ra) ra.Sex).Select(Function(emp) New With {Key .Sex = emp.Key, Key .Ratio = (emp.Count() * 100) / empList.Count})

        For Each ratio In ratioSex
            Console.WriteLine(Constants.vbLf & "{0} are {1}%", ratio.Sex, ratio.Ratio)
        Next ratio
        Console.ReadLine()



    End Sub

    Private Sub AnonymousMethod1(ByVal e As Employee)
        Console.WriteLine("{0,2} {1,7}    {2,8}      {3,8}      {4,23}    {5,3}", e.ID, e.FName, e.MName, e.LName, e.DOB, e.Sex)
    End Sub




End Module

Friend Class Employee
    Private privateID As Integer
    Public Property ID() As Integer
        Get
            Return privateID
        End Get
        Set(ByVal value As Integer)
            privateID = value
        End Set
    End Property
    Private privateFName As String
    Public Property FName() As String
        Get
            Return privateFName
        End Get
        Set(ByVal value As String)
            privateFName = value
        End Set
    End Property
    Private privateMName As String
    Public Property MName() As String
        Get
            Return privateMName
        End Get
        Set(ByVal value As String)
            privateMName = value
        End Set
    End Property
    Private privateLName As String
    Public Property LName() As String
        Get
            Return privateLName
        End Get
        Set(ByVal value As String)
            privateLName = value
        End Set
    End Property
    Private privateDOB As DateTime
    Public Property DOB() As DateTime
        Get
            Return privateDOB
        End Get
        Set(ByVal value As DateTime)
            privateDOB = value
        End Set
    End Property
    Private privateSex As Char
    Public Property Sex() As Char
        Get
            Return privateSex
        End Get
        Set(ByVal value As Char)
            privateSex = value
        End Set
    End Property
End Class
