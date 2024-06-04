
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim names As String() = New String() {"Ram", "Priya", "Puja", "Rita", "Jhonny", "Steve"}
        Dim position As String() = New String() {"Manager", "Team Leader", "Developer", "Writer", "Director"}
        Dim years As Integer() = New Integer() {1, 2, 4, 8, 9}
        Dim q = names.Zip(position, Function(a, b) a & " is the " & b & " of the company")
        Dim r = q.Zip(years, Function(c, d) c & " with " & d & " years of experience.")

        For Each result In r
            ListBox1.Items.Add(result)
        Next result

    End Sub
End Class
