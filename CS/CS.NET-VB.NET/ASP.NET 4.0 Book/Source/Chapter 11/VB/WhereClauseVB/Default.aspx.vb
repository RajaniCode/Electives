
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim numbers() As Integer = {5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95}
        Dim myNums = From n In numbers _
         Where n > 25 _
         Select n
        For Each x In myNums
            ListBox1.Items.Add(x.ToString())
        Next x

    End Sub
End Class
