Module Module1

    Sub Main()
        Dim assemb = From assembly In AppDomain.CurrentDomain.GetAssemblies(), aType In assembly.GetExportedTypes()
                     Select aType

        Dim filtered = assemb.Where(Function(x) x.Assembly.FullName.Contains("Version=4.0.0.0")).GroupBy(Function(a) a.Name.Length).OrderByDescending(Function(x) x.Key)

        ' Find the Longest and Shortest Types
        Dim longestType = filtered.First()
        Dim shortestType = filtered.Last()

        ' Loop and print the Longest Type Names
        For Each nm In longestType
            Console.WriteLine("Longest Type Name: {0} " & vbLf & "FullName: {1} " & vbLf & "TypeLength: {2}", nm.Name, nm.FullName, nm.Name.Length)
            Console.WriteLine("-------------------------------------------")
        Next nm


        ' Loop and print the Shortest Type Names
        For Each nm In shortestType
            Console.WriteLine("Shortest Type Name: {0} " & vbLf & "FullName: {1} " & vbLf & "TypeLength: {2}", nm.Name, nm.FullName, nm.Name.Length)
            Console.WriteLine("-------------------------------------------")
        Next nm

        Console.ReadLine()
    End Sub

End Module
