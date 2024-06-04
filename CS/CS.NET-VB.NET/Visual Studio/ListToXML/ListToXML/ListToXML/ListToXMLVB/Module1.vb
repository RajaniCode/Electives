Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Linq

Module Module1

    Sub Main(ByVal args() As String)
        Dim empList As New List(Of Employee)()
        empList.Add(New Employee() With {.ID = 1, .FName = "John", .LName = "Shields", .DOB = Date.Parse("12/11/1971"), .Sex = "M"c})
        empList.Add(New Employee() With {.ID = 2, .FName = "Mary", .LName = "Jacobs", .DOB = Date.Parse("01/17/1961"), .Sex = "F"c})
        empList.Add(New Employee() With {.ID = 3, .FName = "Amber", .LName = "Agar", .DOB = Date.Parse("12/23/1971"), .Sex = "M"c})
        empList.Add(New Employee() With {.ID = 4, .FName = "Kathy", .LName = "Berry", .DOB = Date.Parse("11/15/1976"), .Sex = "F"c})
        empList.Add(New Employee() With {.ID = 5, .FName = "Lena", .LName = "Bilton", .DOB = Date.Parse("05/11/1978"), .Sex = "F"c})
        empList.Add(New Employee() With {.ID = 6, .FName = "Susanne", .LName = "Buck", .DOB = Date.Parse("03/7/1965"), .Sex = "F"c})
        empList.Add(New Employee() With {.ID = 7, .FName = "Jim", .LName = "Brown", .DOB = Date.Parse("09/11/1972"), .Sex = "M"c})
        empList.Add(New Employee() With {.ID = 8, .FName = "Jane", .LName = "Hooks", .DOB = Date.Parse("12/11/1972"), .Sex = "F"c})
        empList.Add(New Employee() With {.ID = 9, .FName = "Robert", .LName = "", .DOB = Date.Parse("06/28/1964"), .Sex = "M"c})
        empList.Add(New Employee() With {.ID = 10, .FName = "Cindy", .LName = "Fox", .DOB = Date.Parse("01/11/1978"), .Sex = "M"c})

        Try
            Dim xEle = New XElement("Employees", _
                From emp In empList _
                Select New XElement("Employee", New XAttribute("ID", emp.ID), _
                                    New XElement("FName", emp.FName), _
                                    New XElement("LName", emp.LName), _
                                    New XElement("DOB", emp.DOB), _
                                    New XElement("Sex", emp.Sex)))

            xEle.Save("D:\employees.xml")
            Console.WriteLine("Converted to XML")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Console.ReadLine()

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
    Private privateLName As String
    Public Property LName() As String
        Get
            Return privateLName
        End Get
        Set(ByVal value As String)
            privateLName = value
        End Set
    End Property
    Private privateDOB As Date
    Public Property DOB() As Date
        Get
            Return privateDOB
        End Get
        Set(ByVal value As Date)
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

