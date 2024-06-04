Imports Microsoft.VisualBasic

Public Class EmployeeList
    Shared Sub New()
        emp = New List(Of Employee)()
        emp.Add(New Employee() With {.EmpID = 1, .DeptID = 1, .EmpName = "Jack Nolas"})
        emp.Add(New Employee() With {.EmpID = 2, .DeptID = 4, .EmpName = "Mark Pine"})
        emp.Add(New Employee() With {.EmpID = 3, .DeptID = 3, .EmpName = "Sandra Simte"})
        emp.Add(New Employee() With {.EmpID = 4, .DeptID = 4, .EmpName = "Larry Lo"})
        emp.Add(New Employee() With {.EmpID = 5, .DeptID = 3, .EmpName = "Sudhir Panj"})
        emp.Add(New Employee() With {.EmpID = 6, .DeptID = 2, .EmpName = "Kathy K"})
        emp.Add(New Employee() With {.EmpID = 7, .DeptID = 1, .EmpName = "Kaff Joe"})
        emp.Add(New Employee() With {.EmpID = 8, .DeptID = 1, .EmpName = "Su Lie"})
    End Sub

    Private Shared privateemp As List(Of Employee)

    Public Shared Property emp() As List(Of Employee)
        Get
            Return privateemp
        End Get
        Set(ByVal value As List(Of Employee))
            privateemp = value
        End Set
    End Property
End Class

Public Class Employee
    Private privateEmpID As Integer
    Public Property EmpID() As Integer
        Get
            Return privateEmpID
        End Get
        Set(ByVal value As Integer)
            privateEmpID = value
        End Set
    End Property
    Private privateDeptID As Integer
    Public Property DeptID() As Integer
        Get
            Return privateDeptID
        End Get
        Set(ByVal value As Integer)
            privateDeptID = value
        End Set
    End Property
    Private privateEmpName As String
    Public Property EmpName() As String
        Get
            Return privateEmpName
        End Get
        Set(ByVal value As String)
            privateEmpName = value
        End Set
    End Property
End Class