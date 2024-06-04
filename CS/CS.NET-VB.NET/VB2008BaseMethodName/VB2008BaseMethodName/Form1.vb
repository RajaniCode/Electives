Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        MessageBox.Show(GetMethodBaseName())

        MessageBox.Show(Reflection.MethodBase.GetCurrentMethod().Name)

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Button1_Click(Button1, e)
        MessageBox.Show(Reflection.MethodBase.GetCurrentMethod().Name)

    End Sub

    Private Function GetMethodBaseName() As String
        Dim traceStack As StackTrace = New StackTrace
        Dim frameStack As StackFrame = traceStack.GetFrame(1)
        Dim BaseMethod As Reflection.MethodBase = frameStack.GetMethod

        Return BaseMethod.Name
    End Function

End Class
