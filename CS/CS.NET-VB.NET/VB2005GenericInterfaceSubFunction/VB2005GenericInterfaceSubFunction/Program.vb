Option Strict On
Option Explicit On

Imports System.Collections.Generic

Public Class Program
    Shared Sub main()
        Dim P1 As New Program1()
        P1.Print()
        Dim P2 As New Program2()
        P2.Print()
        Console.ReadKey()
    End Sub
End Class

Public Class Program1 : Implements IExample1
    Public Sub Print() Implements IExample1.Print
        Dim MessageText As String = GetMessage("World!")
        Dim Message As String = "Hello " + MessageText
        Console.WriteLine(Message)
    End Sub

    Function GetMessage(ByVal Message As String) As String Implements IExample1.GetMessage
        Return Message
    End Function
End Class

Interface IExample1
    Sub Print()
    Function GetMessage(ByVal Message As String) As String
End Interface

Public Class Program2 : Implements IExample2(Of String)

    Public Sub Print()
        GenericSub("Hello ", 1)
    End Sub
    Public Sub GenericSub(ByVal Message As String, ByVal Number As Integer) Implements IExample2(Of String).GenericSub
        Message &= GenericFunction("World!", 2)
        Console.WriteLine(Message)
    End Sub

    Function GenericFunction(ByVal Message As String, ByVal Number As Integer) As String Implements IExample2(Of String).GenericFunction
        Return Message
    End Function
End Class

Interface IExample2(Of T)
    Sub GenericSub(ByVal obj As T, ByVal Number As Integer)
    Function GenericFunction(ByVal obj As T, ByVal Number As Integer) As String
End Interface
