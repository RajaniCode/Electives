Imports System.Data
Imports System.Data.SqlClient
Public Class WebForm4
    Inherits System.Web.UI.Page
    Dim con As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString.ToString()
    Dim conn As SqlConnection = New SqlConnection(con)
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindfeedback()
        End If
    End Sub
    Public Sub bindfeedback()
        Dim dabind As New SqlDataAdapter("Select * from Feedback", conn)
        dabind.Fill(dt)
        dabind.Update(dt)
        dlFeedback.DataSource = dt
        dlFeedback.DataBind()
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Dim strmsg As String

        strmsg = editor.Content
        Dim ds As DataSet = New DataSet()
        Dim savefeedback As SqlCommand = New SqlCommand("Insert into Feedback values('" & txtName.Text & "', '" & txtEMail.Text & "','" & strmsg & "')", conn)

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        savefeedback.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        dlFeedback.DataBind()
        txtName.Text = ""
        txtEMail.Text = ""
        editor.Content = ""
        bindfeedback()

    End Sub
End Class