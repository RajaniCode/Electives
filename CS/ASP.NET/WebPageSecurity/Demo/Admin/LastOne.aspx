<%@ Register TagPrefix="uc1" TagName="SiteMap" Src="../SiteMap.ascx" %>
<%@ Page language="c#" Inherits="SampleSecurity.Admin.LastOne" CodeFile="LastOne.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>LastOne</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"><LINK href="../Styles.css" 
type=text/css rel=stylesheet >
  </head>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:sitemap id="SiteMap1" runat="server"></uc1:sitemap>
		</form>
	</body>
</html>
