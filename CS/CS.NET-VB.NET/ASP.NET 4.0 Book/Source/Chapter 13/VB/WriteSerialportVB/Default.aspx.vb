Imports System.IO.Ports
Partial Class _Default
    Inherits System.Web.UI.Page

    

    Protected Sub BtnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        Try
            Dim senddata As New SerialPort()
            senddata.PortName = "COM1"
            senddata.Open()
            senddata.Write(TextBox1.Text & "!%")
            senddata.Close()
            Label2.Text = "Data is sent to the serial port"

        Catch ex As Exception
        End Try

    End Sub
End Class
