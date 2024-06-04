Imports System.IO
Imports System.Web.Security
Imports System.Security.Principal

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label2.Text = "Impersonated account: " & WindowsIdentity.GetCurrent().Name
        Dim directory As New DirectoryInfo("D:\MyFolder")
        Dim files() As FileInfo = directory.GetFiles("*.*")
        For Each f As FileInfo In files
            ListBox1.Items.Add(f.FullName)
        Next f

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = "Welcome, " & HttpContext.Current.User.Identity.Name
    End Sub
End Class
