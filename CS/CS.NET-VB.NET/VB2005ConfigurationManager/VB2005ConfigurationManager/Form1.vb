
Imports System.Configuration

Public Class Form1

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click

        ShowConfig()

        ' Open App.Config of executable 
        Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

        ' Add an Application Setting. 
        config.AppSettings.Settings.Add(textBox1.Text, textBox2.Text + " ")
        ' Save the changes in App.config file. 
        config.Save(ConfigurationSaveMode.Modified)

        ' Force a reload of a changed section. 
        ConfigurationManager.RefreshSection("appSettings")
        ShowConfig()


    End Sub

    Private Sub ShowConfig()
        ' For read access you do not need to call OpenExeConfiguraton 
        For Each key As String In ConfigurationManager.AppSettings
            Dim value As String = ConfigurationManager.AppSettings(key)

            listBox1.Items.Add(key)

            listBox2.Items.Add(value)

            textBox3.Text = key

            textBox4.Text = value
        Next
    End Sub


End Class
