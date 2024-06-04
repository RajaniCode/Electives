

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        MessageBox.Show(NameEvent())

    End Sub

   

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        MessageBox.Show(NameEvent())


    End Sub


    Private Function NameEvent() As String
        Dim traceStack As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace
        Dim frameStack As System.Diagnostics.StackFrame = traceStack.GetFrame(1)
        Dim baseMethod As System.Reflection.MethodBase = frameStack.GetMethod

        Return baseMethod.Name

    End Function
End Class
