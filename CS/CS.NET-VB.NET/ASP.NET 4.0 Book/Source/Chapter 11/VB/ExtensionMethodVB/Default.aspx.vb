
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim Words() As String = {"lame", "name", "tame", "apple", "mango", "nice", "example", "parrot", "apricot", "banana"}
            Dim result = Words.OrderBy(Function(s) s)
            ListBox1.Items.Clear()
            For Each r In result
                ListBox1.Items.Add(r)
            Next r
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try

    End Sub
End Class
