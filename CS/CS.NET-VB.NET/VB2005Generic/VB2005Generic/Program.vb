Option Strict On
Option Explicit On

Imports System

Class G
    Private obj As Object

    Public Sub New(ByVal obj As Object)
        Me.obj = obj
    End Sub

    Public Function GetObject() As Object
        Return obj
    End Function

    Public Sub ShowType()
        Console.WriteLine("Type: " & obj.GetType().ToString())
    End Sub
End Class

'Generic
Class G(Of T)
    Private obj As T

    Public Sub New(ByVal obj As T)
        Me.obj = obj
    End Sub

    Public Function GetObject() As T
        Return obj
    End Function

    Public Sub ShowType()
        Console.WriteLine("Type: " & GetType(T).ToString())
    End Sub
End Class

Class Program
    Public Shared Sub Main()
        Dim g As New G("Hello World!")
        Dim s As String = DirectCast(g.GetObject(), String)
        Console.WriteLine("Object: " & s)
        g.ShowType()

        g = New G(100)
        Dim i As Integer = CInt(g.GetObject())
        Console.WriteLine("Object: " & i)
        g.ShowType()

        Dim gs As New G(Of String)("Hello World!")
        s = gs.GetObject()
        Console.WriteLine("Object: " & s)
        gs.ShowType()

        Dim gi As New G(Of Integer)(100)
        i = gi.GetObject()
        Console.WriteLine("Object: " & i)
        gi.ShowType()

        Console.ReadKey()
    End Sub
End Class
