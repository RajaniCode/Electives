
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim data() As Object = {1, "one", 2, "two", 3, "three", 4, "four", 5, "five", 6, "six", 7, "seven", 8, "eight", 9, "nine", 10, "ten"}
        Dim query = data.OfType(Of String)()
        For Each s In query
            ListBox1.Items.Add(s)
        Next s

    End Sub
End Class
