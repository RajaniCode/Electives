' Inheritance - Constructor Overloading // MyBase.New() 

Imports System

Class BaseClass
    Public note As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal s As String)
        note = s
        Console.WriteLine(Chr(10) & "BaseClass(ByVal s As String) constructor invoked: " + note)
    End Sub
End Class

Class DerivedClass
    Inherits BaseClass

    Public Sub New()
    End Sub

    Public Sub New(ByVal s As String)
        MyBase.New(s)
        note = s
        Console.WriteLine(Chr(10) & "DerivedClass(ByVal s As String) constructor invoked: " + note)
    End Sub
End Class

Class Module1
    Public Shared Sub Main()
        Dim bc As New BaseClass("Invoking BaseClass(ByVal s As String) constructor")

        Console.WriteLine(Chr(10) & "Next")

        Dim dc As New DerivedClass("Invoking DerivedClass(ByVal s As String) constructor")
        Dim dc1 As New DerivedClass()

        Console.ReadLine()
    End Sub
End Class

