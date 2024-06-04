
Partial Class Provider
    Inherits System.Web.UI.UserControl
    Implements IDataTransmit

    <WebControls.WebParts.ConnectionProvider("Text", "TextProvider")> _
    Public Function RetriveDataInterface() As IDataTransmit
        Return CType(Me, IDataTransmit)
    End Function

    Public Function RetriveData() As String Implements IDataTransmit.RetriveData
        Return TextBox1.Text
    End Function

End Class
