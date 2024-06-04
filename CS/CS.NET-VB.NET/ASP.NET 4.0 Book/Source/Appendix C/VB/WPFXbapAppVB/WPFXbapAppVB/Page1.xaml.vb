Imports System.Threading
Class Page1

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim text As New FormattedText("KOGENT SOLUTIONS!", 
 		  Thread.CurrentThread.CurrentUICulture, FlowDirection.LeftToRight, New Typeface("Arial Black"), 10, Brushes.Black)
        Dim textGeometry As Geometry = Text.BuildGeometry(New Point(0, 0))
        button1.Clip = textGeometry
    End Sub
End Class
