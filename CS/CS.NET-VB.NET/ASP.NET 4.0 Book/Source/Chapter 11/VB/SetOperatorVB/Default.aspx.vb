
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fruits() As String = {"apple", "banana", "peach", "mango"}
        Dim words() As String = {"hello", "peach", "linq", "mango", "set"}
        Dim common = fruits.Intersect(words)
        ListBox1.Items.Add("Common in both arrays: ")
        For Each n In common
            ListBox1.Items.Add(n)
        Next n
    End Sub
End Class
