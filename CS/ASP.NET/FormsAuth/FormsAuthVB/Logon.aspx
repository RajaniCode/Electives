<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>

<script runat="server">
  Sub Logon_Click(ByVal sender As Object, ByVal e As EventArgs)
    If ((UserEmail.Text = "jchen@contoso.com") And _
            (UserPass.Text = "37Yj*99Ps")) Then
      FormsAuthentication.RedirectFromLoginPage _
           (UserEmail.Text, Persist.Checked)
    Else
      Msg.Text = "Invalid credentials. Please try again."
    End If
  End Sub
</script>

<html>
<head id="Head1" runat="server">
  <title>Forms Authentication - Login</title>
</head>
<body>
  <form id="form1" runat="server">
    <h3>
      Logon Page</h3>
    <table>
      <tr>
        <td>
          E-mail address:</td>
        <td>
          <asp:TextBox ID="UserEmail" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
            ControlToValidate="UserEmail"
            Display="Dynamic" 
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>
          Password:</td>
        <td>
          <asp:TextBox ID="UserPass" TextMode="Password" 
            runat="server" />
        </td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            ControlToValidate="UserPass"
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>
          Remember me?</td>
        <td>
          <asp:CheckBox ID="Persist" runat="server" /></td>
      </tr>
    </table>
    <asp:Button ID="Submit1" OnClick="Logon_Click" Text="Log On"  
       runat="server" />
    <p>
      <asp:Label ID="Msg" ForeColor="red" runat="server" />
    </p>
  </form>
</body>
</html>