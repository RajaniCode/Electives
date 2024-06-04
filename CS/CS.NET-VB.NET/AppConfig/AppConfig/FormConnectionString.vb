Imports System.Xml

Imports System.Data.SqlClient

Public Class FormConnectionString

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim inventory As New XmlDocument()
        Dim strKey As String = String.Empty
        Dim strValue As String = String.Empty
        Dim elements As XmlNodeList

        inventory.Load(ConfigSettings.getConfigPathAndFile())

        elements = inventory.SelectNodes("//configuration/appSettings/add")


        Dim strDataSource As String = String.Empty
        Dim strInitialCatalog As String = String.Empty
        Dim strIntegratedSecurity As String = String.Empty
        Dim strUserID As String = String.Empty
        Dim strPassword As String = String.Empty
        Dim strConnectionString As String = String.Empty

        Dim passPhrase As String = "Pas5pr@se"       'can be any string
        Dim initVector As String = "@1B2c3D4e5F6g7H8" ' must be 16 bytes

        Dim rijndaelKey As New Rijndael(passPhrase, initVector)

        Dim _ConnectionBuilder As New SqlConnectionStringBuilder

        For Each element As XmlElement In elements
            strKey = element.GetAttribute("key")
            strValue = element.GetAttribute("value")
        Next

        _ConnectionBuilder.ConnectionString = strValue

        strDataSource = _ConnectionBuilder.DataSource
        strInitialCatalog = _ConnectionBuilder.InitialCatalog
        strIntegratedSecurity = _ConnectionBuilder.IntegratedSecurity.ToString


        TextBox1.Text = strDataSource
        TextBox2.Text = strInitialCatalog
        TextBox3.Text = strIntegratedSecurity


        If _ConnectionBuilder.IntegratedSecurity = False Then
            strUserID = _ConnectionBuilder.UserID
            strPassword = _ConnectionBuilder.Password
            TextBox4.Text = strUserID
            TextBox5.Text = rijndaelKey.Decrypt(strPassword)
            _ConnectionBuilder.Password = rijndaelKey.Decrypt(strPassword)
        ElseIf _ConnectionBuilder.IntegratedSecurity = True Then
            TextBox4.Enabled = False
            TextBox5.Enabled = False
        End If

        TextBox6.Text = _ConnectionBuilder.ConnectionString

    End Sub

End Class