
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim list() As Object = {"hello", 34, "mango", 90, "nice", "example", 7.3D, 8.0F,"linq"}


    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        Dim str = List.OfType(Of String)()
        ListBox1.Items.Add("The String Characters are: ")
        For Each s In str
            ListBox1.Items.Add(s)
        Next s

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        Dim num = List.OfType(Of Integer)()
        ListBox1.Items.Add("The Numeric Characters are: ")
        For Each n In num
            ListBox1.Items.Add(n.ToString())
        Next n

    End Sub
End Class
