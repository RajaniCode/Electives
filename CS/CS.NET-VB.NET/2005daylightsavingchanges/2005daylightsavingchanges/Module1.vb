Imports System

Class Module1

    Public Shared Sub Main()
        Dim strTimeZone As String = String.Empty
        Dim localZone As TimeZone = TimeZone.CurrentTimeZone

        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE", "DisableAutoDaylightTimeSet", Nothing) Then
            strTimeZone = localZone.DaylightName
        Else
            strTimeZone = localZone.DaylightName
        End If
        Console.WriteLine(strTimeZone)
        MsgBox("Click OK To Close")
    End Sub

End Class