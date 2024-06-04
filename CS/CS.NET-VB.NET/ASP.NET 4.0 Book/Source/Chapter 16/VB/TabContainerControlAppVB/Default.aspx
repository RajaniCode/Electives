<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
		<ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Getting Started">
		<ContentTemplate>
		<p>
ASP.NET is a server-side technology for building web applications. Almost all the work
happens on the web server and not the web browser. Whenever you perform an action in
an ASP.NET page—such as clicking a button or sorting a GridView—the entire page must
be posted back to the web server. Any significant action on a page results in a postback.
		</p>
		Some of the controls within AJAX Control Toolkit are:
		<ul>
			<li>Accordion</li>
			<li>AutoComplete</li>
			<li>Calendar</li>
			<li>DropDown</li>
			<li>ListSearch</li>
			<li>ModalPopup</li>
			<li>ReorderList</li>
			<li>ValidatorCallout</li>
		</ul>
		</ContentTemplate>
		</ajaxToolkit:TabPanel>
		<ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="Walkthroughs">
		<ContentTemplate>
		<ul>
			<a href=""><li>Setup your environment</li></a>
			<a href=""><li>Creating a new extender</li></a>
			<a href=""><li>Extender base class features</li></a>
			<a href=""><li>Using Animations</li></a>
			<a href=""><li>Automated Testings</li></a>
		</ul>
		</ContentTemplate>
		</ajaxToolkit:TabPanel>
		<ajaxToolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="Samples">
		<ContentTemplate>
			<asp:RadioButtonList ID="RadioButtonList1" runat="server">
			<asp:ListItem>Using Accordion</asp:ListItem>
			<asp:ListItem>Using AutoComplete</asp:ListItem>
			<asp:ListItem>Using Calendar</asp:ListItem>
			<asp:ListItem>Using DropDown</asp:ListItem>
			<asp:ListItem>Using ListSearch</asp:ListItem>
			<asp:ListItem>Using ModalPopup</asp:ListItem>
			<asp:ListItem>Using ReorderList</asp:ListItem>
			<asp:ListItem>Using ValidatorCallout</asp:ListItem>
			</asp:RadioButtonList>
			<asp:Button ID="Button1" runat="server" Text="Go" />
		</ContentTemplate>
		</ajaxToolkit:TabPanel>
		</ajaxToolkit:TabContainer>

    </div>
    </form>
</body>
</html>
