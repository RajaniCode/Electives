
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim numbers = From n In Enumerable.Range(1, 50)
                      Select New With {Key .Number = n, Key .OddEven = If(n Mod 2 = 1, "odd", "even")}
        For Each n In numbers
            ListBox1.Items.Add("The number is " & n.Number & n.OddEven)
        Next n

    End Sub
End Class
