' Inheritance - Constructor Overloading // MyBase.New() 

Imports System

Class BaseClass
    Public note As String

    Public Sub New(ByVal s As String)
        ' constructor overloading // ~NOTE 
        note = s
        ' %Note 
        Console.WriteLine(Chr(10) & "BaseClass(ByVal s As String) constructor invoked: " + note)
    End Sub
End Class

Class DerivedClass
    Inherits BaseClass
    Public Sub New(ByVal s As String)
        MyBase.New(s)
        ' constructor overloading // ~NOTE // %Note 
        Console.WriteLine(Chr(10) & "DerivedClass(ByVal s As String) constructor invoked: " + note)
    End Sub
End Class

Class Module1
    Public Shared Sub Main()
        Dim bc As New BaseClass("BaseClass(ByVal s As String) constructor call argument")

        Console.WriteLine(Chr(10) & "Next")

        Dim dc As New DerivedClass("DerivedClass(ByVal s As String) constructor call argument")
        ' %Note 

        Console.ReadLine()
    End Sub
End Class
