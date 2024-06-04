<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2010SimpleFormsAuthentication.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  void Page_Load(object sender, EventArgs e)
  {
    Welcome.Text = "Hello, " + Context.User.Identity.Name;
  }

  void Signout_Click(object sender, EventArgs e)
  {
    FormsAuthentication.SignOut();
    Response.Redirect("Logon.aspx");
  }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forms Authentication - Default Page</title>
</head>
<body>
    <h3>
    Using Forms Authentication</h3>
    <asp:Label ID="Welcome" runat="server" />
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="Submit1" OnClick="Signout_Click" 
       Text="Sign Out" runat="server" /><p>

    </div>
    </form>
</body>
</html>
