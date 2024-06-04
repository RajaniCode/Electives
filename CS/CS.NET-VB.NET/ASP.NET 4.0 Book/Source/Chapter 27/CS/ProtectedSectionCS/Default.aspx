<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Web.Configuration" %>

<script runat="server" language="C#">
	const string PROVIDER = "DataProtectionConfigurationProvider";
	protected void button1_Click(object sender, EventArgs e)
	{
		Configuration con = 
 		WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
		ConnectionStringsSection sect = con.ConnectionStrings;
		sect.SectionInformation.ProtectSection(PROVIDER);
		con.Save();
		label1.Text = "Section of web.config is now encrypted<br>";
		label1.Text += "Connection String you have provided is:" +
        ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
	}
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProtectSection demo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
			<strong><span style="text-decoration: underline"><em>Use of 
 			ProtectSection Method
			<br />
			</em></span></strong>
			<br />
			<br />
			<asp:Button ID="button1" runat="server" Text="Click Me to Encrypt the Connection String"
			Width="481px" Height="35px" OnClick="button1_Click" Font-Size="Medium" />
			<br />
			<br />
			<br />
			<asp:Label ID="label1" runat="server" Height="19px" 
 			Width="435px"></asp:Label>

    </div>
    </form>
</body>
</html>
