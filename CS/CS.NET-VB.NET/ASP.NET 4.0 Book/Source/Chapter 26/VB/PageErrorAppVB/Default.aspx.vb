
Partial Class _Default
    Inherits System.Web.UI.Page
    Private Sub Page_Error(ByVal sender As Object, ByVal e As EventArgs)
        Response.Write("Error occurred: <br />" & Server.GetLastError().ToString())
        Server.ClearError()
    End Sub
    Private Sub PageLevelErrorTest()
        Dim array(8) As Integer
        For intCounter As Integer = 0 To 9
            array(intCounter) = intCounter
            Response.Write("The value of the counter is:" & intCounter & "<br />")
        Next intCounter
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call PageLevelErrorTest()
    End Sub

End Class
