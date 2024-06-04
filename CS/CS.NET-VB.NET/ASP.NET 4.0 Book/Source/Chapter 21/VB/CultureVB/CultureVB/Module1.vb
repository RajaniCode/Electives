Imports System.Globalization
Module Module1

    Sub Main()
        Dim cultinfo As CultureInfo
        For Each cultinfo In _
        CultureInfo.GetCultures(CultureTypes.AllCultures)
            Console.WriteLine(cultinfo)
            Console.ReadLine()
        Next cultinfo
    End Sub

End Module
