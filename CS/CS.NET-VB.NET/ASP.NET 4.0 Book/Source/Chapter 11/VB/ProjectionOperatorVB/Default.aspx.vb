Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim text() As String = {"Hello everybody", "this is an", "example on using", "select many operator", "with linq."}
        Dim words As IEnumerable(Of String()) = text.Select(Function(w) w.Split(" "c))
        For Each segment As String() In words
            For Each word As String In segment
                ListBox1.Items.Add(word)
            Next word
        Next segment

    End Sub
End Class
