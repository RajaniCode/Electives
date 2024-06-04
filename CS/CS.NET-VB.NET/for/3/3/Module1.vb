' for

Imports System

Class Module1
    Public Shared Sub Main()

        Dim i As Integer
        Dim j As Integer
        Dim temp As Integer = 0

        Console.WriteLine("Enter the number of elements (integers) in the integer array: ")
        Dim n As Integer = Integer.Parse(Console.ReadLine())

        Console.WriteLine("Enter the elements (integers)")
        Dim a As Integer() = New Integer(n - 1) {}
        For i = 0 To a.Length - 1
            a(i) = Integer.Parse(Console.ReadLine())
        Next
        For i = 0 To a.Length - 1
            For j = 0 To a.Length - 1
                If a(i) < a(j) Then
                    ' Note: (a[i] > a[j]) Descending order 
                    temp = a(i)
                    a(i) = a(j)
                    a(j) = temp
                End If
            Next
        Next
        Console.WriteLine("Ascending order")
        For i = 0 To a.Length - 1
            Console.WriteLine(a(i))
        Next
        Console.WriteLine("Descending order")
        For i = a.Length - 1 To 0 Step -1
            Console.WriteLine(a(i))
        Next

        Console.ReadLine()
    End Sub
End Class
