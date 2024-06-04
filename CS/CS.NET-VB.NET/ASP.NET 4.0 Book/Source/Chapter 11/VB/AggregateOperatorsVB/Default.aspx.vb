
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim numbers() As Integer = {5, 4, 1, 3, 9, 10, 35, 29, 20, 87, 100, 26, 42,
    78, 91}
        Dim OddNumbers As Integer = numbers.Count(Function(n) n Mod 2 = 1)
        ListBox1.Items.Add("The Count of odd Numbers are: " & OddNumbers)

        Dim numSum As Double = numbers.Sum()
        ListBox1.Items.Add("The sum of numbers is :" & numSum)
        Dim minNum As Integer = numbers.Min()
        ListBox1.Items.Add("Minimum number is:" & minNum)

        Dim maxNum As Integer = numbers.Max()
        ListBox1.Items.Add("Maximum number is :" & maxNum)

        Dim avgNum As Double = numbers.Average()
        ListBox1.Items.Add("Average of numbers is : " & avgNum)

    End Sub
End Class
