Imports System.Reflection

Module TypeCreator
    Public Function TypeGenerator(Of T)(ByVal at As T()) As List(Of T)
        Return New List(Of T)(at)
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Sub PrintToConsole(Of T)(ByRef items As List(Of T))
        Dim pi As PropertyInfo() = GetType(T).GetProperties()
        ' extra loop required to print column names only once 
        For Each p In pi
            Console.Write("{0,-12}", p.Name)
        Next
        Console.WriteLine()
        For Each item In items
            For Each p In pi
                Console.Write("{0,-12}", p.GetValue(item, Nothing))
            Next
            Console.WriteLine()
        Next
        Console.ReadLine()
    End Sub
End Module
