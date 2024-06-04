Imports System.Security.Cryptography
Imports System.Text

Partial Class _Default
    Inherits System.Web.UI.Page
    Private hashValue(), MessageBytes() As Byte
    Private StringtoConvert As String
    Private MyUniCodeEncoding As UnicodeEncoding

    Protected Sub Btnsha1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsha1.Click

        StringtoConvert = TextBox1.Text
        MyUniCodeEncoding = New UnicodeEncoding()
        MessageBytes = MyUniCodeEncoding.GetBytes(StringtoConvert)
        Dim SHhash As New SHA1Managed()
        hashValue = SHhash.ComputeHash(MessageBytes)
        For Each b As Byte In hashValue
            TextBox2.Text = TextBox2.Text + String.Format("{0:X2}", b)
        Next b
    End Sub

    Protected Sub btnsh256_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsh256.Click

        StringtoConvert = TextBox1.Text
        MyUniCodeEncoding = New UnicodeEncoding()
        MessageBytes = MyUniCodeEncoding.GetBytes(StringtoConvert)
        Dim SHhash As New SHA256Managed()
        hashValue = SHhash.ComputeHash(MessageBytes)
        For Each b As Byte In hashValue
            TextBox3.Text = TextBox3.Text + String.Format("{0:X2}", b)
        Next b

    End Sub

    Protected Sub Btnsh384_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsh384.Click

        StringtoConvert = TextBox1.Text
        MyUniCodeEncoding = New UnicodeEncoding()
        MessageBytes = MyUniCodeEncoding.GetBytes(StringtoConvert)
        Dim SHhash As New SHA384Managed()
        hashValue = SHhash.ComputeHash(MessageBytes)
        For Each b As Byte In hashValue
            TextBox4.Text = TextBox4.Text + String.Format("{0:X2}", b)
        Next b

    End Sub

    Protected Sub BTN512_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN512.Click

        StringtoConvert = TextBox1.Text
        MyUniCodeEncoding = New UnicodeEncoding()
        MessageBytes = MyUniCodeEncoding.GetBytes(StringtoConvert)
        Dim SHhash As New SHA512Managed()
        hashValue = SHhash.ComputeHash(MessageBytes)
        For Each b As Byte In hashValue
            TextBox5.Text = TextBox5.Text + String.Format("{0:X2}", b)
        Next b

    End Sub
End Class
