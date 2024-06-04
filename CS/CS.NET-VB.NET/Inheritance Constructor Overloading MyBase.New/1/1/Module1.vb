' Inheritance - Constructor Overloading 

Imports System

Class BaseClass
    Public Sub New()
        Console.WriteLine(Chr(10) & "BaseClass() constructor invoked")
    End Sub
    Protected Overrides Sub Finalize()
        Console.WriteLine(Chr(10) & "BaseClass() destructor invoked")
    End Sub
End Class

Class DerivedClass
    Inherits BaseClass
    Public Sub New()
        Console.WriteLine(Chr(10) & "DerivedClass() constructor invoked")
    End Sub
    Protected Overrides Sub Finalize()
        Console.WriteLine(Chr(10) & "DerivedClass() destructor invoked")
    End Sub
End Class

Class Module1
    Public Shared Sub Main()
        Dim bc As New BaseClass()

        Console.WriteLine(Chr(10) & "Next")

        Dim dc As New DerivedClass()

        Console.WriteLine(Chr(10) & "Last")

        Console.ReadLine()
    End Sub
End Class
