Imports System.Data.SqlClient

Public Class frmConfig


#Region "TELEMETRY"

    Private _ConnectionBuilderTELEMETRY As New SqlConnectionStringBuilder

    Private IsWriteappconfigTELEMETRY As Boolean

    Private IsChangeTELEMETRY As Boolean
    Private ServernameTELEMETRY As String
    Private UsernameTELEMETRY As String
    Private PasswordTELEMETRY As String
    Private DatabasenameTELEMETRY As String
    Private DataSourceNameTELEMETRY As String

    Private Function ParseValuesTELEMETRY() As Boolean

        Try
            _ConnectionBuilderTELEMETRY.DataSource = TextBoxServernameTELEMETRY.Text
            _ConnectionBuilderTELEMETRY.InitialCatalog = TextBoxDatabasenameTELEMETRY.Text

            If RadioButtonWindowsAuthenticationTELEMETRY.Checked = True Then
                _ConnectionBuilderTELEMETRY.IntegratedSecurity = True
            ElseIf RadioButtonWindowsAuthenticationTELEMETRY.Checked = False Then
                _ConnectionBuilderTELEMETRY.IntegratedSecurity = False
                _ConnectionBuilderTELEMETRY.UserID = TextBoxUsernameTELEMETRY.Text
                _ConnectionBuilderTELEMETRY.Password = TextBoxPasswordTELEMETRY.Text
            End If

            Return True

        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
            Return False
        End Try

    End Function

    Private Function IsTestConnectionTELEMETRY() As Boolean

        Try
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If ParseValuesTELEMETRY() Then

                Application.DoEvents()

                Using con As New SqlConnection
                    'Temporary set a short timeout to avoid waiting 15 s for wrong spelled server name
                    _ConnectionBuilderTELEMETRY.ConnectTimeout = 3

                    con.ConnectionString = _ConnectionBuilderTELEMETRY.ConnectionString

                    con.Open()
                End Using
            End If

            Return True
        Catch ExceptionMessage As Exception
            MsgBox("Connection failed: " & vbCrLf & ExceptionMessage.Message, MsgBoxStyle.Critical, "Connection")
            Return False
        Finally
            _ConnectionBuilderTELEMETRY.Remove("Connect Timeout")
            System.Windows.Forms.Cursor.Current = Cursors.Default
        End Try

    End Function

    Private Function GetConnectionStringTELEMETRY() As String

        Dim StrConnectionString As String = String.Empty

        Try
            StrConnectionString = System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionStringTELEMETRY")
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

        Return StrConnectionString

    End Function

    Private Function GetDataSourceNameTELEMETRY() As String

        Dim StrDataSourceName As String = String.Empty

        Try
            StrDataSourceName = System.Configuration.ConfigurationManager.AppSettings.Get("DataSourceNameTELEMETRY")
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

        Return StrDataSourceName

    End Function


    Private Sub SetConnectionStringTELEMETRY()

        Try
            _ConnectionBuilderTELEMETRY.DataSource = TextBoxServernameTELEMETRY.Text.Trim
            _ConnectionBuilderTELEMETRY.InitialCatalog = TextBoxDatabasenameTELEMETRY.Text.Trim

            If RadioButtonWindowsAuthenticationTELEMETRY.Checked = True Then
                _ConnectionBuilderTELEMETRY.IntegratedSecurity = True
            ElseIf RadioButtonWindowsAuthenticationTELEMETRY.Checked = False Then
                _ConnectionBuilderTELEMETRY.IntegratedSecurity = False
                _ConnectionBuilderTELEMETRY.UserID = TextBoxUsernameTELEMETRY.Text.Trim
                _ConnectionBuilderTELEMETRY.Password = TextBoxPasswordTELEMETRY.Text.Trim
            End If

            Updateappconfig.UpdateappSettings("DataSourceTELEMETRY", _ConnectionBuilderTELEMETRY.DataSource)
            Updateappconfig.UpdateappSettings("IntegratedSecurityTELEMETRY", _ConnectionBuilderTELEMETRY.IntegratedSecurity)
            Updateappconfig.UpdateappSettings("InitialCatalogTELEMETRY", _ConnectionBuilderTELEMETRY.InitialCatalog)

            If RadioButtonSQLServerAuthenticationTELEMETRY.Checked = True Then
                Updateappconfig.UpdateappSettings("IntegratedSecurityTELEMETRY", "False")
                Updateappconfig.UpdateappSettings("UsernameTELEMETRY", _ConnectionBuilderTELEMETRY.UserID)
                Updateappconfig.UpdateappSettings("PasswordTELEMETRY", _ConnectionBuilderTELEMETRY.Password)
            ElseIf RadioButtonWindowsAuthenticationTELEMETRY.Checked = True Then
                Updateappconfig.UpdateappSettings("IntegratedSecurityTELEMETRY", "True")
                Updateappconfig.UpdateappSettings("UsernameTELEMETRY", String.Empty)
                Updateappconfig.UpdateappSettings("PasswordTELEMETRY", String.Empty)
            End If

            Updateappconfig.UpdateappSettings("ConnectionStringTELEMETRY", _ConnectionBuilderTELEMETRY.ConnectionString)

            IsWriteappconfigTELEMETRY = True
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
            IsWriteappconfigTELEMETRY = False
        End Try

    End Sub

    Private Sub SetDataSourceNameTELEMETRY()
        Try
            Updateappconfig.UpdateappSettings("DataSourceNameTELEMETRY", TextBoxDataSourceNameTELEMETRY.Text.Trim)
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
            IsWriteappconfigTELEMETRY = False
        End Try

    End Sub

    Private Sub DisplayConnectionStringTELEMETRY()

        Try
            TextBoxDataSourceTELEMETRYConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("DataSourceTELEMETRY")

            TextBoxIntegratedSecurityTELEMETRYConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("IntegratedSecurityTELEMETRY")

            If System.Configuration.ConfigurationManager.AppSettings.Get("IntegratedSecurityTELEMETRY") = "False" Then
                RadioButtonSQLServerAuthenticationTELEMETRY.Checked = True
                TextBoxUserIDTELEMETRYConnStr.Enabled = True
                TextBoxPassswordTELEMETRYConnStr.Enabled = True
                TextBoxUserIDTELEMETRYConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("UsernameTELEMETRY")
                TextBoxPassswordTELEMETRYConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("PasswordTELEMETRY")
            ElseIf System.Configuration.ConfigurationManager.AppSettings.Get("IntegratedSecurityTELEMETRY") = "True" Then
                RadioButtonWindowsAuthenticationTELEMETRY.Checked = True
                TextBoxUserIDTELEMETRYConnStr.Text = String.Empty
                TextBoxPassswordTELEMETRYConnStr.Text = String.Empty
                TextBoxUserIDTELEMETRYConnStr.Enabled = False
                TextBoxPassswordTELEMETRYConnStr.Enabled = False
            End If

            TextBoxInitialCatalogTELEMETRYConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("InitialCatalogTELEMETRY")

            RichTextBoxConnectionStringTELEMETRYConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionStringTELEMETRY")
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub DisplayDataSourceNameTELEMETRY()

        Try
            TextBoxGetDataSourceNameTELEMETRY.Text = System.Configuration.ConfigurationManager.AppSettings.Get("DataSourceNameTELEMETRY")
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub


    Private Sub EnableButtonSaveTELEMETRY()

        Try
            If String.Compare(TextBoxServernameTELEMETRY.Text, ServernameTELEMETRY) = 0 _
        And String.Compare(TextBoxUsernameTELEMETRY.Text, UsernameTELEMETRY) = 0 _
        And String.Compare(TextBoxPasswordTELEMETRY.Text, PasswordTELEMETRY) = 0 _
        And String.Compare(TextBoxDatabasenameTELEMETRY.Text, DatabasenameTELEMETRY) = 0 _
        And String.Compare(TextBoxDataSourceNameTELEMETRY.Text, DataSourceNameTELEMETRY) = 0 _
        Then
                IsChangeTELEMETRY = False
            Else
                IsChangeTELEMETRY = True
            End If

            ButtonSaveTELEMETRY.Enabled = IsChangeTELEMETRY
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub TestConnectionTELEMETRY()

        Try
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If ParseValuesTELEMETRY() Then

                LabelFeedbackTELEMETRY.ForeColor = Color.Navy
                LabelFeedbackTELEMETRY.Text = "Testing, please wait..."
                Application.DoEvents()

                Using con As New SqlConnection
                    'Temporary set a short timeout to avoid waiting 15 s for wrong spelled server name
                    _ConnectionBuilderTELEMETRY.ConnectTimeout = 3

                    con.ConnectionString = _ConnectionBuilderTELEMETRY.ConnectionString

                    con.Open()
                End Using

                LabelFeedbackTELEMETRY.ForeColor = Color.Navy
                LabelFeedbackTELEMETRY.Text = "Test connection succeeded."
                MsgBox("Test connection succeeded.")
                LabelFeedbackTELEMETRY.Text = String.Empty
                ButtonSaveTELEMETRY.Enabled = True
            End If
        Catch ExceptionMessage As Exception
            LabelFeedbackTELEMETRY.Text = "Test connection failed."
            MsgBox("Test connection failed: " & vbCrLf & ExceptionMessage.Message, MsgBoxStyle.Critical, "Test connection")
            LabelFeedbackTELEMETRY.Text = String.Empty
            ButtonSaveTELEMETRY.Enabled = False
        Finally
            _ConnectionBuilderTELEMETRY.Remove("Connect Timeout")
            System.Windows.Forms.Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub AuthenticationTELEMETRY()

        Try
            If RadioButtonWindowsAuthenticationTELEMETRY.Checked = True Then
                TextBoxUsernameTELEMETRY.Enabled = False
                TextBoxPasswordTELEMETRY.Enabled = False
            ElseIf RadioButtonWindowsAuthenticationTELEMETRY.Checked = False Then
                TextBoxUsernameTELEMETRY.Enabled = True
                TextBoxPasswordTELEMETRY.Enabled = True
            End If
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub TextValueChangedTELEMETRY(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxServernameTELEMETRY.KeyUp, TextBoxDatabasenameTELEMETRY.KeyUp, TextBoxUsernameTELEMETRY.KeyUp, TextBoxPasswordTELEMETRY.KeyUp, TextBoxDataSourceNameTELEMETRY.KeyUp

        Try
            ButtonSaveTELEMETRY.Enabled = True
            EnableButtonSaveTELEMETRY()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub RadioButtonWindowsAuthenticationTELEMETRY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonWindowsAuthenticationTELEMETRY.CheckedChanged

        Try
            TextBoxUsernameTELEMETRY.Text = String.Empty
            TextBoxPasswordTELEMETRY.Text = String.Empty
            AuthenticationTELEMETRY()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub RadioButtonSQLServerAuthenticationTELEMETRY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSQLServerAuthenticationTELEMETRY.CheckedChanged

        Try
            TextBoxUsernameTELEMETRY.Text = String.Empty
            TextBoxPasswordTELEMETRY.Text = String.Empty
            AuthenticationTELEMETRY()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub ButtonTestConnectionTELEMETRY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTestConnectionTELEMETRY.Click

        Try
            If TextBoxServernameTELEMETRY.Text = String.Empty Then
                TextBoxServernameTELEMETRY.Text = "(local)"
            End If

            If TextBoxUsernameTELEMETRY.Text = String.Empty And RadioButtonSQLServerAuthenticationTELEMETRY.Checked = True Then
                TextBoxUsernameTELEMETRY.Text = "sa"
            End If

            If TextBoxDatabasenameTELEMETRY.Text = String.Empty Then
                TextBoxDatabasenameTELEMETRY.Text = "FBACPTELEMETRYDATA"
            End If

            TestConnectionTELEMETRY()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub ButtonDisplayConnectionStringTELEMETRY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDisplayConnectionStringTELEMETRY.Click
        Try
            DisplayConnectionStringTELEMETRY()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try
    End Sub

    Private Sub ButtonDisplayDataSourceNameTELEMETRY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDisplayDataSourceNameTELEMETRY.Click

        Try
            DisplayDataSourceNameTELEMETRY()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub TextBoxUsernameTELEMETRY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxUsernameTELEMETRY.Enter

        Try
            TextBoxUsernameTELEMETRY.Text = "sa"
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub ButtonSaveTELEMETRY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveTELEMETRY.Click

        Try
            If TextBoxServernameTELEMETRY.Text = String.Empty Then
                TextBoxServernameTELEMETRY.Text = "(local)"
            End If

            If TextBoxUsernameTELEMETRY.Text = String.Empty And RadioButtonSQLServerAuthenticationTELEMETRY.Checked = True Then
                TextBoxUsernameTELEMETRY.Text = "sa"
            End If

            If TextBoxDatabasenameTELEMETRY.Text = String.Empty Then
                TextBoxDatabasenameTELEMETRY.Text = "FBACPTELEMETRYDATA"
            End If

            If IsTestConnectionTELEMETRY() Then
                SetConnectionStringTELEMETRY()
                SetDataSourceNameTELEMETRY()
                MsgBox("Application Settings changed successfully.")
            End If
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub ButtonCloseTELEMETRY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCloseTELEMETRY.Click

        Try
            If IsChangeTELEMETRY = True And IsWriteappconfigTELEMETRY = False Then

                Dim ResultDialog As DialogResult = MessageBox.Show("Do you want to save changes?", _
                   "Configuration", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                If ResultDialog = Windows.Forms.DialogResult.Yes Then
                    ButtonSaveTELEMETRY_Click(sender, e)
                    Me.Close()
                ElseIf ResultDialog = Windows.Forms.DialogResult.No Then
                    Me.Close()
                End If
            Else
                IsWriteappconfigTELEMETRY = True
                Me.Close()
            End If
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

#End Region




#Region "EFM"

    Private _ConnectionBuilderEFM As New SqlConnectionStringBuilder

    Private IsWriteappconfigEFM As Boolean

    Private IsChangeEFM As Boolean
    Private ServernameEFM As String
    Private UsernameEFM As String
    Private PasswordEFM As String
    Private DatabasenameEFM As String
    Private DataSourceNameEFM As String

    Private Function ParseValuesEFM() As Boolean

        Try
            _ConnectionBuilderEFM.DataSource = TextBoxServernameEFM.Text
            _ConnectionBuilderEFM.InitialCatalog = TextBoxDatabasenameEFM.Text

            If RadioButtonWindowsAuthenticationEFM.Checked = True Then
                _ConnectionBuilderEFM.IntegratedSecurity = True
            ElseIf RadioButtonWindowsAuthenticationEFM.Checked = False Then
                _ConnectionBuilderEFM.IntegratedSecurity = False
                _ConnectionBuilderEFM.UserID = TextBoxUsernameEFM.Text
                _ConnectionBuilderEFM.Password = TextBoxPasswordEFM.Text
            End If

            Return True

        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
            Return False
        End Try

    End Function

    Private Function IsTestConnectionEFM() As Boolean

        Try
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If ParseValuesEFM() Then

                Application.DoEvents()

                Using con As New SqlConnection
                    'Temporary set a short timeout to avoid waiting 15 s for wrong spelled server name
                    _ConnectionBuilderEFM.ConnectTimeout = 3

                    con.ConnectionString = _ConnectionBuilderEFM.ConnectionString

                    con.Open()
                End Using
            End If

            Return True
        Catch ExceptionMessage As Exception
            MsgBox("Connection failed: " & vbCrLf & ExceptionMessage.Message, MsgBoxStyle.Critical, "Connection")
            Return False
        Finally
            _ConnectionBuilderEFM.Remove("Connect Timeout")
            System.Windows.Forms.Cursor.Current = Cursors.Default
        End Try

    End Function

    Private Function GetConnectionStringEFM() As String

        Dim StrConnectionString As String = String.Empty

        Try
            StrConnectionString = System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionStringEFM")
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

        Return StrConnectionString

    End Function

    Private Function GetDataSourceNameEFM() As String

        Dim StrDataSourceName As String = String.Empty

        Try
            StrDataSourceName = System.Configuration.ConfigurationManager.AppSettings.Get("DataSourceNameEFM")
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

        Return StrDataSourceName

    End Function

    Private Sub SetConnectionStringEFM()

        Try
            _ConnectionBuilderEFM.DataSource = TextBoxServernameEFM.Text.Trim
            _ConnectionBuilderEFM.InitialCatalog = TextBoxDatabasenameEFM.Text.Trim

            If RadioButtonWindowsAuthenticationEFM.Checked = True Then
                _ConnectionBuilderEFM.IntegratedSecurity = True
            ElseIf RadioButtonWindowsAuthenticationEFM.Checked = False Then
                _ConnectionBuilderEFM.IntegratedSecurity = False
                _ConnectionBuilderEFM.UserID = TextBoxUsernameEFM.Text.Trim
                _ConnectionBuilderEFM.Password = TextBoxPasswordEFM.Text.Trim
            End If

            Updateappconfig.UpdateappSettings("DataSourceEFM", _ConnectionBuilderEFM.DataSource)
            Updateappconfig.UpdateappSettings("IntegratedSecurityEFM", _ConnectionBuilderEFM.IntegratedSecurity)
            Updateappconfig.UpdateappSettings("InitialCatalogEFM", _ConnectionBuilderEFM.InitialCatalog)

            If RadioButtonSQLServerAuthenticationEFM.Checked = True Then
                Updateappconfig.UpdateappSettings("IntegratedSecurityEFM", "False")
                Updateappconfig.UpdateappSettings("UsernameEFM", _ConnectionBuilderEFM.UserID)
                Updateappconfig.UpdateappSettings("PasswordEFM", _ConnectionBuilderEFM.Password)
            ElseIf RadioButtonWindowsAuthenticationEFM.Checked = True Then
                Updateappconfig.UpdateappSettings("IntegratedSecurityEFM", "True")
                Updateappconfig.UpdateappSettings("UsernameEFM", String.Empty)
                Updateappconfig.UpdateappSettings("PasswordEFM", String.Empty)
            End If

            Updateappconfig.UpdateappSettings("ConnectionStringEFM", _ConnectionBuilderEFM.ConnectionString)

            IsWriteappconfigEFM = True
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
            IsWriteappconfigEFM = False
        End Try

    End Sub

    Private Sub SetDataSourceNameEFM()
        Try
            Updateappconfig.UpdateappSettings("DataSourceNameEFM", TextBoxDataSourceNameEFM.Text.Trim)
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
            IsWriteappconfigEFM = False
        End Try

    End Sub

    Private Sub DisplayConnectionStringEFM()

        Try
            TextBoxDataSourceEFMConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("DataSourceEFM")

            TextBoxIntegratedSecurityEFMConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("IntegratedSecurityEFM")

            If System.Configuration.ConfigurationManager.AppSettings.Get("IntegratedSecurityEFM") = "False" Then
                RadioButtonSQLServerAuthenticationEFM.Checked = True
                TextBoxUserIDEFMConnStr.Enabled = True
                TextBoxPassswordEFMConnStr.Enabled = True
                TextBoxUserIDEFMConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("UsernameEFM")
                TextBoxPassswordEFMConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("PasswordEFM")
            ElseIf System.Configuration.ConfigurationManager.AppSettings.Get("IntegratedSecurityEFM") = "True" Then
                RadioButtonWindowsAuthenticationEFM.Checked = True
                TextBoxUserIDEFMConnStr.Text = String.Empty
                TextBoxPassswordEFMConnStr.Text = String.Empty
                TextBoxUserIDEFMConnStr.Enabled = False
                TextBoxPassswordEFMConnStr.Enabled = False
            End If

            TextBoxInitialCatalogEFMConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("InitialCatalogEFM")

            RichTextBoxConnectionStringEFMConnStr.Text = System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionStringEFM")
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub DisplayDataSourceNameEFM()

        Try
            TextBoxGetDataSourceNameEFM.Text = System.Configuration.ConfigurationManager.AppSettings.Get("DataSourceNameEFM")
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub EnableButtonSaveEFM()

        Try
            If String.Compare(TextBoxServernameEFM.Text, ServernameEFM) = 0 _
        And String.Compare(TextBoxUsernameEFM.Text, UsernameEFM) = 0 _
        And String.Compare(TextBoxPasswordEFM.Text, PasswordEFM) = 0 _
        And String.Compare(TextBoxDatabasenameEFM.Text, DatabasenameEFM) = 0 _
        And String.Compare(TextBoxDataSourceNameEFM.Text, DataSourceNameEFM) = 0 _
        Then
                IsChangeEFM = False
            Else
                IsChangeEFM = True
            End If

            ButtonSaveEFM.Enabled = IsChangeEFM
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub TestConnectionEFM()

        Try
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If ParseValuesEFM() Then

                LabelFeedbackEFM.ForeColor = Color.Navy
                LabelFeedbackEFM.Text = "Testing, please wait..."
                Application.DoEvents()

                Using con As New SqlConnection
                    'Temporary set a short timeout to avoid waiting 15 s for wrong spelled server name
                    _ConnectionBuilderEFM.ConnectTimeout = 3

                    con.ConnectionString = _ConnectionBuilderEFM.ConnectionString

                    con.Open()
                End Using

                LabelFeedbackEFM.ForeColor = Color.Navy
                LabelFeedbackEFM.Text = "Test connection succeeded."
                MsgBox("Test connection succeeded.")
                LabelFeedbackEFM.Text = String.Empty
                ButtonSaveEFM.Enabled = True
            End If
        Catch ExceptionMessage As Exception
            LabelFeedbackEFM.Text = "Test connection failed."
            MsgBox("Test connection failed: " & vbCrLf & ExceptionMessage.Message, MsgBoxStyle.Critical, "Test connection")
            LabelFeedbackEFM.Text = String.Empty
            ButtonSaveEFM.Enabled = False
        Finally
            _ConnectionBuilderEFM.Remove("Connect Timeout")
            System.Windows.Forms.Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub AuthenticationEFM()

        Try
            If RadioButtonWindowsAuthenticationEFM.Checked = True Then
                TextBoxUsernameEFM.Enabled = False
                TextBoxPasswordEFM.Enabled = False
            ElseIf RadioButtonWindowsAuthenticationEFM.Checked = False Then
                TextBoxUsernameEFM.Enabled = True
                TextBoxPasswordEFM.Enabled = True
            End If
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub TextValueChangedEFM(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxServernameEFM.KeyUp, TextBoxDatabasenameEFM.KeyUp, TextBoxUsernameEFM.KeyUp, TextBoxPasswordEFM.KeyUp, TextBoxDataSourceNameEFM.KeyUp

        Try
            ButtonSaveEFM.Enabled = True
            EnableButtonSaveEFM()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub RadioButtonWindowsAuthenticationEFM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonWindowsAuthenticationEFM.CheckedChanged

        Try
            TextBoxUsernameEFM.Text = String.Empty
            TextBoxPasswordEFM.Text = String.Empty
            AuthenticationEFM()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub RadioButtonSQLServerAuthenticationEFM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSQLServerAuthenticationEFM.CheckedChanged

        Try
            TextBoxUsernameEFM.Text = String.Empty
            TextBoxPasswordEFM.Text = String.Empty
            AuthenticationEFM()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub ButtonTestConnectionEFM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTestConnectionEFM.Click

        Try
            If TextBoxServernameEFM.Text = String.Empty Then
                TextBoxServernameEFM.Text = "(local)"
            End If

            If TextBoxUsernameEFM.Text = String.Empty And RadioButtonSQLServerAuthenticationEFM.Checked = True Then
                TextBoxUsernameEFM.Text = "sa"
            End If

            If TextBoxDatabasenameEFM.Text = String.Empty Then
                TextBoxDatabasenameEFM.Text = "FBACPEFMDATA"
            End If

            TestConnectionEFM()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub ButtonDisplayConnectionStringEFM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDisplayConnectionStringEFM.Click

        Try
            DisplayConnectionStringEFM()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub ButtonDisplayDataSourceNameEFM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDisplayDataSourceNameEFM.Click

        Try
            DisplayDataSourceNameEFM()
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub TextBoxUsernameEFM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxUsernameEFM.Enter

        Try
            TextBoxUsernameEFM.Text = "sa"
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub ButtonSaveEFM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveEFM.Click

        Try
            If TextBoxServernameEFM.Text = String.Empty Then
                TextBoxServernameEFM.Text = "(local)"
            End If

            If TextBoxUsernameEFM.Text = String.Empty And RadioButtonSQLServerAuthenticationEFM.Checked = True Then
                TextBoxUsernameEFM.Text = "sa"
            End If

            If TextBoxDatabasenameEFM.Text = String.Empty Then
                TextBoxDatabasenameEFM.Text = "FBACPEFMDATA"
            End If

            If IsTestConnectionEFM() Then
                SetConnectionStringEFM()
                SetDataSourceNameEFM()
                MsgBox("Application Settings changed successfully.")
            End If
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub ButtonCloseEFM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCloseEFM.Click

        Try
            If IsChangeEFM = True And IsWriteappconfigEFM = False Then

                Dim ResultDialog As DialogResult = MessageBox.Show("Do you want to save changes?", _
                   "Configuration", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                If ResultDialog = Windows.Forms.DialogResult.Yes Then
                    ButtonSaveEFM_Click(sender, e)
                    Me.Close()
                ElseIf ResultDialog = Windows.Forms.DialogResult.No Then
                    Me.Close()
                End If
            Else
                IsWriteappconfigEFM = True
                Me.Close()
            End If
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

#End Region




#Region "TELEMETRY and EFM"

    Private Sub TabControlConfiguration_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlConfiguration.SelectedIndexChanged

        Try
            If TabControlConfiguration.SelectedIndex = 1 Then
                TextBoxServernameTELEMETRY.Focus()
                TextBoxServernameTELEMETRY.SelectAll()
            ElseIf TabControlConfiguration.SelectedIndex = 2 Then
                TextBoxServernameEFM.Focus()
                TextBoxServernameEFM.SelectAll()
            End If
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Sub CheckDebugMode()

        Try
            Dim StrDebugMode As String = String.Empty

            StrDebugMode = System.Configuration.ConfigurationManager.AppSettings.Get("DebugMode")

            If StrDebugMode.ToLower = "true" Then
                TabControlConnectionString.Enabled = True
                TabControlDataSourceName.Enabled = True
            Else
                TabControlConnectionString.Enabled = False
                TabControlDataSourceName.Enabled = False
            End If
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

#End Region





    Private Sub frmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            ServernameTELEMETRY = TextBoxServernameTELEMETRY.Text
            UsernameTELEMETRY = TextBoxUsernameTELEMETRY.Text
            PasswordTELEMETRY = TextBoxPasswordTELEMETRY.Text
            DatabasenameTELEMETRY = TextBoxDatabasenameTELEMETRY.Text
            DataSourceNameTELEMETRY = TextBoxDataSourceNameTELEMETRY.Text

            ServernameEFM = TextBoxServernameEFM.Text
            UsernameEFM = TextBoxUsernameEFM.Text
            PasswordEFM = TextBoxPasswordEFM.Text
            DatabasenameEFM = TextBoxDatabasenameEFM.Text
            DataSourceNameEFM = TextBoxDataSourceNameEFM.Text

            CheckDebugMode()

        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

End Class
