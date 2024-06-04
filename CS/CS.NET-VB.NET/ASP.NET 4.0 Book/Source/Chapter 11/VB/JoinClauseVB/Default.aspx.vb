Partial Class _Default
    Inherits System.Web.UI.Page
    Public Class Customer
        Public Key As Integer
        Public Name As String
    End Class
    Public Class Order
        Public Key As Integer
        Public OrderNumber As String
    End Class
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim customers = New List(Of Customer)(New Customer() {New Customer With {.Key =
         1, .Name = "Neha"}, New Customer With {.Key = 2, .Name = "Amar"}, New Customer With {.Key = 3, .Name = "Neeraj"}, New Customer With {.Key = 4, .Name = "Priya"}, New Customer With {.Key = 5, .Name = "Jyoti"}})
        Dim orders = New List(Of Order)(New Order() {New Order With {.Key = 1,
         .OrderNumber = "Number 1"}, New Order With {.Key = 2, .OrderNumber = "Number 2"},
         New Order With {.Key = 3, .OrderNumber = "Number 3"}, New Order With {.Key = 4,
         .OrderNumber = "Number 4"}, New Order With {.Key = 5, .OrderNumber = "Number 5"}})
        Dim q = From c In customers _
         Join o In orders On c.Key Equals o.Key _
         Select New With {Key c.Name, Key o.OrderNumber}
        For Each i In q
            ListBox1.Items.Add(i.OrderNumber.ToString() & " " & i.Name)
        Next i
    End Sub
End Class
