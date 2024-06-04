' for 

Imports System

Class Module1
    Public Shared Sub Main()
        Dim i As Integer
        Dim j As Integer
        Console.WriteLine("Enter the string:")
        Dim a As String = Console.ReadLine()
        Dim t = a.ToUpper
        a = t
        Dim temp As String = ""
        j = 0
        i = a.Length - 1
        For i = a.Length - 1 To 0 Step -1
            temp += a(i)
        Next
        Console.WriteLine("The reversed string is: {0}", temp)

        If temp = a Then
            Console.WriteLine("{0} is a Palindrome!", temp)
        Else
            Console.WriteLine("{0} is not a Palindrome!", temp)
        End If
        Console.ReadLine()
    End Sub
End Class


