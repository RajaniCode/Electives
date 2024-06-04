Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Public Class frmConfiq

    Private _ConnectionBuilder As New SqlConnectionStringBuilder

#Region " Methods "

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Private Sub Authentication()
        If RadioButtonWindowsAuthentication.Checked = True Then
            TextBoxUsername.Enabled = False
            TextBoxPassword.Enabled = False
        ElseIf RadioButtonWindowsAuthentication.Checked = False Then
            TextBoxUsername.Enabled = True
            TextBoxPassword.Enabled = True
        End If
    End Sub

    Private Function ParseValues() As Boolean

        _ConnectionBuilder.DataSource = TextBoxServername.Text
        _ConnectionBuilder.InitialCatalog = TextBoxDatabasename.Text

        If RadioButtonWindowsAuthentication.Checked = True Then
            _ConnectionBuilder.IntegratedSecurity = True
        ElseIf RadioButtonWindowsAuthentication.Checked = False Then
            _ConnectionBuilder.IntegratedSecurity = False
            _ConnectionBuilder.UserID = TextBoxUsername.Text
            _ConnectionBuilder.Password = TextBoxPassword.Text
        End If

        Return True

    End Function

    Private Sub TestConnection() 

        Try
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If ParseValues() Then

                LabelFeedback.ForeColor = Color.Navy
                LabelFeedback.Text = "Testing, please wait ...."
                Application.DoEvents()

                Using con As New SqlConnection
                    'Temporary set a short timeout to avoid waiting 15 s for wrong spelled server name
                    _ConnectionBuilder.ConnectTimeout = 3

                    con.ConnectionString = _ConnectionBuilder.ConnectionString

                    con.Open()
                End Using

                LabelFeedback.ForeColor = Color.Navy
                LabelFeedback.Text = "Test connection succeeded."
                MsgBox("Test connection succeeded.")
            End If
        Catch ex As Exception
            MsgBox("Test connection failed: " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Test")
        Finally
            _ConnectionBuilder.Remove("Connect Timeout")
            System.Windows.Forms.Cursor.Current = Cursors.Default
        End Try

    End Sub


    Private Function WriteConnectionString() As String

        Dim strDataSource As String = String.Empty
        Dim strInitialCatalog As String = String.Empty
        Dim strIntegratedSecurity As String = String.Empty
        Dim strUserID As String = String.Empty
        Dim strPassword As String = String.Empty
        Dim strConnectionString As String = String.Empty

        'Dim ReturnConnString As String = String.Empty
        Dim ReturnConnectionString As String = String.Empty

        Dim passPhrase As String = "Pas5pr@se"       'can be any string
        Dim initVector As String = "@1B2c3D4e5F6g7H8" ' must be 16 bytes

        Dim rijndaelKey As New Rijndael(passPhrase, initVector)

        Try
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If ParseValues() Then

                Application.DoEvents()

                Using con As New SqlConnection
                    'Temporary set a short timeout to avoid waiting 15 s for wrong spelled server name
                    ' _ConnectionBuilder.ConnectTimeout = 3

                    con.ConnectionString = _ConnectionBuilder.ConnectionString

                    strDataSource = _ConnectionBuilder.DataSource
                    strInitialCatalog = _ConnectionBuilder.InitialCatalog
                    strIntegratedSecurity = _ConnectionBuilder.IntegratedSecurity.ToString
                    strUserID = _ConnectionBuilder.UserID
                    strPassword = _ConnectionBuilder.Password

                    If _ConnectionBuilder.IntegratedSecurity = True Then
                        strConnectionString = "Data Source=" & strDataSource & ";" & "Initial Catalog=" & strInitialCatalog & ";" & "Integrated Security=" & strIntegratedSecurity
                    ElseIf _ConnectionBuilder.IntegratedSecurity = False Then
                        strConnectionString = "Data Source=" & strDataSource & ";" & "Initial Catalog=" & strInitialCatalog & ";" & "Integrated Security=" & strIntegratedSecurity & ";"
                        strConnectionString = strConnectionString & "User ID=" & strUserID & ";" & "Password=" & rijndaelKey.Encrypt(strPassword)
                    End If

                    'ReturnConnString = _ConnectionBuilder.ConnectionString

                    ReturnConnectionString = strConnectionString

                    con.Open()
                End Using

                MsgBox("Connection String written in App.Config: " & ReturnConnectionString)

            End If


        Catch ex As Exception
            LabelFeedback.ForeColor = Color.Red
            LabelFeedback.Text = "Test connection failed."
            MsgBox("Test connection failed: " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Test")
        Finally
            _ConnectionBuilder.Remove("Connect Timeout")
            System.Windows.Forms.Cursor.Current = Cursors.Default
        End Try

        Return ReturnConnectionString

    End Function



#End Region


#Region " Events "

    Private Sub frmConfig_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RadioButtonWindowsAuthentication.Checked = True
    End Sub

    Private Sub AnyTextValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxServername.KeyUp, TextBoxDatabasename.KeyUp, TextBoxUsername.KeyUp, TextBoxPassword.KeyUp
        LabelFeedback.Text = ""
    End Sub

    Private Sub ButtonCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub ButtonOK_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        If LabelFeedback.Text <> "Test connection failed." Then
            ConfigSettings.WriteSetting("Connectionstring", WriteConnectionString())
        End If

        Dim cs As New FormConnectionString
        cs.Show()
    End Sub

    Private Sub ButtonTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTestConnection.Click
        TestConnection()
    End Sub

    Private Sub RadioButtonSQLServerAuthentication_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSQLServerAuthentication.CheckedChanged
        Authentication()
    End Sub

    Private Sub RadioButtonWindowsAuthentication_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonWindowsAuthentication.CheckedChanged
        Authentication()
    End Sub

#End Region
End Class
