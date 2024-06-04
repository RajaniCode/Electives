Imports System.Web.Security
Imports System.Web
Imports System.Security.Principal
Partial Class AddEvent
    Inherits System.Web.UI.Page

   
   
  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        time.Text = DateTime.Now.ToString()
        Dim WP As WindowsPrincipal = CType(HttpContext.Current.User, WindowsPrincipal)
        Dim WI As WindowsIdentity = CType(WP.Identity, WindowsIdentity)
        Dim winUser As String = "Name: " & WI.Name
        winUser &= Constants.vbLf & "Authentication Type: " & WI.AuthenticationType
        winUser &= Constants.vbLf & "Authenticated: " & (If((WI.IsAuthenticated), "Yes", "No"))
        user.Text = winUser

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        SqlDataSource1.Insert()
        ID.Text = ""
        name.Text = ""
        time.Text = ""
        location.Text = ""
        Label8.Text = "1 new event created"
    End Sub
End Class
