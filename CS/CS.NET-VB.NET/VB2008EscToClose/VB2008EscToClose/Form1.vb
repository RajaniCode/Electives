Public Class Form1

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try
            If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
                Me.Close()
            Else
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If

        Catch ex As Exception
            Return False
        End Try
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class
