' for

Imports System

Class Module1
    Public Shared Sub Main()
        Console.WriteLine("Printing first 5 odd numbers in ascending order")
        Dim n As Integer = 0
        For i As Integer = 0 To 19
            If i = 10 Then
                Exit For
            End If

            If i Mod 2 = 0 Then
                Continue For
            End If
            n = i
            Console.WriteLine(n)
        Next

        Console.WriteLine("Printing next 5 odd numbers in descending order")
        For i As Integer = 20 To 1 Step -1
            If i = 10 Then
                Exit For
            End If
            If i Mod 2 = 0 Then
                Continue For
            End If
            n = i
            Console.WriteLine(n)
        Next

        Console.ReadLine()
    End Sub
End Class

