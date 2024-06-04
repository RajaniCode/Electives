<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Web.Configuration" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Xml" %>

<script runat="server" language="VB">  
	Public Sub Page_Load(ByVal source As Object, ByVal e As EventArgs)
		Label1.Visible = False
		ConfigSections.Visible = False
	End Sub
	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		Label1.Text = TextBox1.Text
		Dim con As System.Configuration.Configuration = 
 		WebConfigurationManager.OpenWebConfiguration(TextBox1.Text)
		Dim textwriter As StringWriter = New StringWriter()
		Dim textXml As XmlTextWriter = New XmlTextWriter(textwriter)
		textXml.Formatting = Formatting.Indented
		textXml.WriteStartElement("configuration")
		Enumerate(con.RootSectionGroup, textXml)
		textXml.WriteFullEndElement()
		textXml.Flush()
		ConfigSections.Text = Chr(13) & Chr(10) & 
 		Server.HtmlEncode(textwriter.ToString())
		Label1.Visible = True
		ConfigSections.Visible = True
		Try
			Dim section As PagesSection = CType(con.GetSection("system.web/pages"), 
 			PagesSection)
			Label2.Text = section.SectionInformation.ToString()
			Label3.Text = section.EnableViewState.ToString()
			Dim sec As String = TextBox2.Text
			Dim Settings As ConfigurationSection = con.GetSection(sec)
			Label6.Text = Chr(13) & Chr(10) & 
 			Server.HtmlEncode(Settings.SectionInformation.GetRawXml())
			Label5.Text = TextBox2.Text
			Catch
			TextBox1.Text = "invalid section name"
		End Try
	End Sub
	Sub Enumerate(ByVal grp As ConfigurationSectionGroup, ByVal writeXML As XmlWriter)
		Dim x As Integer
		Dim configsection As ConfigurationSectionCollection = grp.Sections
		For x = 0 To configsection.Count - 1
			writeXML.WriteStartElement(configsection(x).SectionInformation.Name)
			writeXML.WriteEndElement()
		Next
	End Sub
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Configuration Sections</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>
			Enter the Virtual Path of the WebSite:</h2>
			<p>
			&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderStyle="Double" 
 			Width="464px"></asp:TextBox></p>
			<p>
			Enter section you need to verify &nbsp; &nbsp; &nbsp; &nbsp;<asp:TextBox 
 			ID="TextBox2"
			runat="server" BorderStyle="Double" Width="201px"></asp:TextBox>
			</p>
			<p>
			<asp:Button ID="Button1" runat="server" Text="Verify Settings" 
 			OnClick="Button1_Click" />&nbsp;</p>
			<h2>
			<asp:Label runat="server" ID="Label1" />&nbsp;</h2>
			<p>
			SectionInformation:&nbsp; &nbsp;<asp:Label runat="server" ID="Label2" 
 			/>&nbsp;</p>
			<p>
			EnableViewState: &nbsp; &nbsp; &nbsp;<asp:Label runat="server" 
 			ID="Label3" /></p>
			<p>
				<asp:Label runat="server" ID="Label5" Width="111px" />&nbsp;
				<asp:Label runat="server" ID="Label6" /></p>
			<p>
				_____________________________________________</p>
			<p>
				&nbsp;<asp:Label runat="server" ID="ConfigSections" /></p>
			<pre>            
			</pre>

    </div>
    </form>
</body>
</html>
