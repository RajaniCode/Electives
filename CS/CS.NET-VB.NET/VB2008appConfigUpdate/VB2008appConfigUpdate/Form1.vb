Public Class Form1

    Private Sub frmChaneSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadConfigValueToControls()
    End Sub

    ''' <summary>
    ''' This Will set the appConfigs Paramters values to Text box Controls
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadConfigValueToControls()
        txtServerName.Text = System.Configuration.ConfigurationManager.AppSettings.Get("DBServerName")
        txtDBName.Text = System.Configuration.ConfigurationManager.AppSettings.Get("DatabaseName")
        txtDBUserID.Text = System.Configuration.ConfigurationManager.AppSettings.Get("DatabaseUserID")
        txtDBPwd.Text = System.Configuration.ConfigurationManager.AppSettings.Get("DatabasePwd")
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        Try
            AppConfigFileSettings.UpdateAppSettings("DBServerName", txtServerName.Text)
            AppConfigFileSettings.UpdateAppSettings("DatabaseName", txtDBName.Text)
            AppConfigFileSettings.UpdateAppSettings("DatabaseUserID", txtDBUserID.Text)
            AppConfigFileSettings.UpdateAppSettings("DatabasePwd", txtDBPwd.Text)
            MsgBox("Application Settings has been Changed successfully.")
        Catch ex As Exception
            Dim s As String = ex.Message.ToString()
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub
End Class
