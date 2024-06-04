Class MainClass

    Public Shared Sub Main()
        Console.WriteLine("ExitCode:           " & System.Environment.ExitCode)
        Console.WriteLine("HasShutdownStarted: " & System.Environment.HasShutdownStarted)
        Console.WriteLine("MachineName:        " & System.Environment.MachineName)
        Console.WriteLine("NewLine:            " & System.Environment.NewLine)
        Console.WriteLine("OSVersion:          " & System.Environment.OSVersion.VersionString) ' 2005
        Console.WriteLine("ProcessorCount:     " & System.Environment.ProcessorCount) ' 2005
        Console.WriteLine("SystemDirectory:    " & System.Environment.SystemDirectory)
        Console.WriteLine("TickCount:          " & System.Environment.TickCount)
        Console.WriteLine("SystemDirectory:    " & System.Environment.SystemDirectory)
        Console.WriteLine("Version:            " & System.Environment.Version.ToString)
        Console.WriteLine("TickCount:          " & System.Environment.TickCount)
        Console.WriteLine(".Net Runtime Environment Version Number Version:            " & System.Environment.Version.ToString)
        Console.WriteLine("WorkingSet:         " & System.Environment.WorkingSet)
        Console.WriteLine("StackTrace:         " & System.Environment.StackTrace)
        Console.WriteLine("Environment Variable by Name:         " & Environ("UserName"))
        Console.WriteLine("************************************************************")
        For i As Integer = 1 To 255
            If Environ(i).Length = 0 Then Exit For
            Console.WriteLine(Environ(i))
        Next i
        MsgBox("Click OK To Close")
    End Sub

End Class
