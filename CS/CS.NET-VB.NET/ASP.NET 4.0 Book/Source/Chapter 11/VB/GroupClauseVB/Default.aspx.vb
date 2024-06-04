
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim words() As String = {"apple", "banana", "pineapple", "apricot", "papaya", "blueberry", "abascus", "cheery", "parrot", "black"}
        Dim GroupWords = From w In words Group By w.First() Into Group
        For Each Group In GroupWords
            ListBox1.Items.Add("Words that starts from letter: " & Group.First.ToString())
            For Each w In Group.Group
                ListBox1.Items.Add(w)
            Next w
        Next Group

    End Sub
End Class
