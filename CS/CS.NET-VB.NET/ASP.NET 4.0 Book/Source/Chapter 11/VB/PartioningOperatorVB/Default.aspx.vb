
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim presidents() As String = {"Adams", "Arthur", "Buchanan", "Bush", "Carter",
   "Cleveland", "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Grafiled",
   "Grant", "Harrison", "Hoover", "Lincoln", "Washington", "Wilson", "Tyler",
   "Polk", "Nixon", "Truman"}
        Dim PageSize As Integer = 5
        Dim numberPages As Integer = CInt(Fix(Math.Ceiling(presidents.Count() /
         CDbl(PageSize))))
        For page As Integer = 0 To numberPages - 1

            ListBox1.Items.Add("Page " & page & ":")

            Dim names = (From p In presidents _
             Order By p Descending _
             Select p).Skip(page * PageSize).Take(PageSize)
            For Each name In names

                ListBox1.Items.Add(name)
            Next name
        Next page

    End Sub
End Class
