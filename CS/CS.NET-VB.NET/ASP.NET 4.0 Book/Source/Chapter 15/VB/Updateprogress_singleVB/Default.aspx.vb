
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub BtnProgress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnProgress.Click
        System.Threading.Thread.Sleep(5000)
        LabelDemo.Text = "Demonstration on UpdateProgress Control taken place last time at " +
         System.DateTime.Now.ToLongTimeString
    End Sub
End Class
