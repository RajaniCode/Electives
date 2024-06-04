<%@ Page Language="VB" %>
<html>
<head>
  <title>Forms Authentication - Default Page</title>
</head>

<script runat="server">
  Sub Page_Load(ByVal Src As Object, ByVal e As EventArgs)
    Welcome.Text = "Hello, " & Context.User.Identity.Name
  End Sub

  Sub Signout_Click(ByVal sender As Object, ByVal e As EventArgs)
    FormsAuthentication.SignOut()
    Response.Redirect("Logon.aspx")
  End Sub
</script>

<body>
  <h3>
    Using Forms Authentication</h3>
  <asp:Label ID="Welcome" runat="server" />
  <form id="Form1" runat="server">
    <asp:Button ID="Submit1" OnClick="Signout_Click" 
       Text="Sign Out" runat="server" /><p>
  </form>
</body>
</html>