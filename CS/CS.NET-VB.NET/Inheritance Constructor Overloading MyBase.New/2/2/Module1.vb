'Inheritance - Constructor Overloading

Imports System

Class BaseClass
    Public note As String

    Public Sub New()
        ' *Note: WON'T BE INVOKED as it is not called 
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
    Public Sub New()
        ' constructor overloading 
        Console.WriteLine(Chr(10) & "DerivedClass(ByVal s As String) constructor invoked: ")
    End Sub
End Class

Class Module1
    Public Shared Sub Main()
        Dim bc As New BaseClass("Invoking BaseClass(ByVal s As String) constructor")
        Console.WriteLine(Chr(10) & "Next")
        Console.ReadLine()
    End Sub
End Class
