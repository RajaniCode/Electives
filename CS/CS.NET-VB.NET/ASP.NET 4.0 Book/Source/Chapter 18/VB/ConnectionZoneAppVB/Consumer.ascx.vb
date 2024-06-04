
Partial Class Consumer
    Inherits System.Web.UI.UserControl
    <WebControls.WebParts.ConnectionConsumer("Text", "TextConsumer")> _
    Public Sub RetriveDataInterface(ByVal sender As IDataTransmit)
        Label2.Text = sender.RetriveData()
    End Sub
End Class
