Imports System

Module Module1

    Sub Main()
        Dim strTimeZone As String = String.Empty
        Dim localZone As TimeZone = TimeZone.CurrentTimeZone

        If System.TimeZone.CurrentTimeZone.IsDaylightSavingTime(Now) Then
            strTimeZone = localZone.StandardName
        Else
            strTimeZone = localZone.DaylightName
        End If
        Console.WriteLine(strTimeZone)
        MsgBox("Click OK To Close")
    End Sub

End Module