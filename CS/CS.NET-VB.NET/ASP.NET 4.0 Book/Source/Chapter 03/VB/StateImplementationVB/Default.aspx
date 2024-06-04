<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Application("visits") = Int(Application("visits") + 1)
        Label2.Text = Application("visits").ToString()
        Label3.Text = Session("mytext").ToString
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtvalue As String = txtName.Text
        ViewState.Add("item", txtvalue)
        Dim item As String = ViewState("item").ToString
        Label1.Text = item
    End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Implementing States</title>
</head>
<body bgcolor="#FFFFFF">
    <form id="form1" runat="server" action="default.aspx" method="post">
    <div>
    <strong><span style="text-decoration: underline">View State</span></strong><br />
	<br />
	Enter Your Name:
	<asp:TextBox ID="txtName" runat="server" />
	<br />
	&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
	&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
	<br />
	&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
	&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
	<asp:Button ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" runat="server" />
	<br />
	<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
	&nbsp;
	<br />
	<br />
	<br />  
	<span style="text-decoration: underline"><strong>Application State<br />
	<br />
	</strong></span>Number of last visits:
	<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
	<br />
	<br />
	<strong><span style="text-decoration: underline">Session State<br />
	</span></strong>
	<br />
	<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
    </div>
    </form>
</body>
</html>
