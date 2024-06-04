' SortedList


Imports System
Imports System.Collections

Class MainClass
    Shared Sub Main()
        Dim sl As New SortedList()

        sl.Add(1, "USA")
        sl.Add(2, "UK")
        sl.Add(3, "France")
        sl.Add(4, "Japan")
        sl.Add(5, "Spain")

        Dim ic As ICollection = sl.Keys

        For Each i As Integer In ic
            Console.WriteLine(i & ": " & sl(i))
        Next

        Console.WriteLine()

        sl.Remove(3)
        sl.Remove(4)

        For Each i As Integer In ic
            Console.WriteLine(i & ": " & sl(i))
        Next

        Console.WriteLine()

        sl(2) = "Austria"

        For Each i As Integer In ic
            Console.WriteLine(i & ": " & sl(i))
        Next

        Console.WriteLine()

        Console.WriteLine()

        Console.ReadKey()
    End Sub
End Class