<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
	Protected Sub Button1_Click(ByVal sender As Object, _
		ByVal e As System.EventArgs)
		Label1.Text = "Clicked at " & DateTime.Now.ToString()
	End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Single File Page Model</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" 
			runat="server"></asp:Label>
			<asp:Button ID="Button1" 
				runat="server" OnClick="Button1_Click" Text="Click Me!">
			</asp:Button>
    </div>
    </form>
</body>
</html>
