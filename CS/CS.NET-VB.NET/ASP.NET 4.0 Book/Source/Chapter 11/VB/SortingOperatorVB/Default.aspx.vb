
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim doubles() As Double = {500, 700, 100, 200, 400, 600, 900, 300, 800}

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        Dim sorting = From d In doubles _
         Order By d _
         Select d
        For Each d In sorting
            ListBox1.Items.Add(d.ToString())
        Next d

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        Dim DescendingSorting = From d In doubles _
         Order By d Descending _
         Select d
        For Each d In DescendingSorting
            ListBox1.Items.Add(d.ToString())
        Next d

    End Sub
End Class
