'Inheritance - Constructor Overloading

Imports System

Class BaseClass
    Public note As String


    Public Sub New()
        ' &Note: WILL BE INVOKED as it is also called by DerivedClass(ByVal s As String) invocation 
        Console.WriteLine(Chr(10) & "BaseClass() constructor invoked")
    End Sub

    Public Sub New(ByVal s As String)
        ' constructor overloading 
        note = s
        Console.WriteLine(Chr(10) & "BaseClass(ByVal s As String) constructor invoked: " + note)
    End Sub
End Class

Class DerivedClass
    Inherits BaseClass
    Public Sub New(ByVal s As String)
        ' constructor overloading 
        note = s
        Console.WriteLine(Chr(10) & "DerivedClass(ByVal s As String) constructor invoked: " + note)
    End Sub
End Class

Class Module1
    Public Shared Sub Main()
        Dim bc As New BaseClass("Invoking BaseClass(ByVal s As String) constructor")

        Console.WriteLine(Chr(10) & "Next")

        Dim dc As New DerivedClass("Invoking DerivedClass(ByVal s As String) constructor")
        ' @Note: Also: invokes base class paramterless constructor 

        Console.ReadLine()
    End Sub
End Class