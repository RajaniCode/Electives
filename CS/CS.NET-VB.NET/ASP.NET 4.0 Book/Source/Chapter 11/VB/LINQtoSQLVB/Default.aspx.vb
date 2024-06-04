
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dc As New MyClassesDataContext()
        Dim query = dc.Products
        For Each item As Product In query
            ListBox1.Items.Add(item.ProductID.ToString() & "      " & item.ProductName)
        Next item
    End Sub
End Class
