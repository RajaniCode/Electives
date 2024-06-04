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
   <ajaxToolkit:Accordion ID="Accordion1" runat="server" SelectedIndex="0" AutoSize="None" 
 		  FadeTransitions="true" TransitionDuration="300" FramesPerSecond="25" 
 		  Height="500px">
		<Panes>
		<ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
		<Header><br />
		<div style="background-color:Olive; font-size:xx-large; font-weight:bold">Getting 
 		Started</div>
		</Header>
		<Content>
		<div style="background-color:Silver">
		<p>
		ASP.NET is a server-side technology for building web applications. Almost all the 
 		  work happens on the web server and not the web browser. Whenever you perform an 
 		  action in an ASP.NET page—such as clicking a button or sorting a GridView—the 
 		  entire page must be posted back to the web server. Any significant action on a 
 		  page results in a postback.
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
		</div>
		</Content>
		</ajaxToolkit:AccordionPane>
		<ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
		<Header><br />
		<div style="background-color:Olive; font-size:xx-large; font-
 		 weight:bold">Walkthroughs</div>
		</Header>
		<Content>
			<div style="background-color:Silver">
				<ul>
					<a href=""><li>Setup your environment</li></a>
					<a href=""><li>Creating a new extender</li></a>
					<a href=""><li>Extender base class features</li></a>
					<a href=""><li>Using Animations</li></a>
					<a href=""><li>Automated Testings</li></a>
				</ul>
			</div> 
		</Content>
		</ajaxToolkit:AccordionPane> 
		<ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
		<Header><br />
		<div style="background-color:Olive; font-size:xx-large; font-weight:bold">Samples</div>
		</Header>
		<Content>
			<div style="background-color:Silver">
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
			</div>
		</Content>
		</ajaxToolkit:AccordionPane>
		</Panes>
		</ajaxToolkit:Accordion>

    </div>
    </form>
</body>
</html>
