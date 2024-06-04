
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i, j, n As Integer
        i = Convert.ToInt32(TextBox1.Text)
        j = Convert.ToInt32(TextBox2.Text)
        n = Convert.ToInt32(TextBox3.Text)
        Dim source = Enumerable.Range(i, j)


        Dim parallelQuery = From num In source.AsParallel().AsOrdered() Where num Mod n = 0 Select num


        For Each v In parallelQuery
            If v < j Then
                ListBox1.Items.Add(v.ToString())
            End If
        Next v

    End Sub
End Class
