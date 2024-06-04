Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnHandled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHandled.Click
        Try
            Throw New Exception()
        Catch ex As Exception
            ' Log the error to a text file in the Error folder
            ErrHandler.WriteError(ex.Message)
        End Try
    End Sub

    Protected Sub btnUnhandled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnhandled.Click
        Dim i As Integer = 1
        Dim j As Integer = 0
        Response.Write(i \ j)
    End Sub


End Class
