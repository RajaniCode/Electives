Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim customers As List(Of Customer) = GetCustomers()
        Dim q = From c In customers _
         Where c.CustAge > 30 _
         Select c
        For Each i In q
            ListBox1.Items.Add(i.CustName & ":   " & i.CustAge.ToString())
        Next i
    End Sub
    Private Function GetCustomers() As List(Of Customer)
        Dim custs As List(Of Customer) = New List(Of Customer)()
        custs.Add(New Customer(1001, "Amit", 10))
        custs.Add(New Customer(1002, "Neha", 50))
        custs.Add(New Customer(1003, "Priya", 30))
        custs.Add(New Customer(1004, "Sneha", 40))
        custs.Add(New Customer(1005, "Jiya", 50))
        custs.Add(New Customer(1006, "Jaison", 10))
        custs.Add(New Customer(1007, "Puja", 20))
        custs.Add(New Customer(1008, "Frenscesco", 30))
        custs.Add(New Customer(1009, "Feni", 40))
        custs.Add(New Customer(10010, "Era", 50))
        custs.Add(New Customer(10011, "Raj", 60))
        custs.Add(New Customer(10012, "Vijay", 20))
        custs.Add(New Customer(10013, "Mudita", 30))
        custs.Add(New Customer(10014, "Nancy", 40))
        custs.Add(New Customer(10015, "Kapil", 10))

        Return custs
    End Function
End Class
