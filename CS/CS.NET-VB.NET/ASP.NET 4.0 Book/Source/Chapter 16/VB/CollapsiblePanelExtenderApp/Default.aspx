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
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1"
            runat="server">
        </ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="Label2" runat="server" BackColor="#999999" BorderStyle="Dotted" 
		Font-Names="Iskoola Pota"> 
		<asp:LinkButton ID="LinkButton1" runat="server">
		About AJAX
		</asp:LinkButton>
		<asp:Label ID="Label1" runat="server" />

</asp:Label><asp:Panel ID="Panel1" runat="server" BackColor="LightGray" >
Microsoft has a complicated relationship with Ajax. On the one hand, the company wants
to provide its existing ASP.NET developers with an easy way to implement Ajax 
functionality without having to learn JavaScript. On the other hand, Microsoft recognizes 
that the future is on the client. Therefore, it wants to provide web developers with the 
tools they need to build pure client-side Ajax applications. For these reasons, Microsoft 
has both a server-side Ajax framework and a client-side Ajax framework.
If you want to retrofit an existing ASP.NET application to take advantage of Ajax, you can
take advantage of Microsoft’s server-side Ajax framework. To take advantage of the 
serverside framework, you don’t need to write a single line of JavaScript code. You can 
continue to build ASP.NET pages with server-side controls in the standard way. You learn 
how to take advantage of the server-side Ajax framework in this chapter.
The advantage of the server-side framework is that it provides existing ASP.NET developers
with a painless method of doing Ajax. The disadvantage of the server-side framework is
that it doesn’t escape all the problems associated with a server-side framework. You still
have to run back to the server whenever you perform any client-side 
action.</asp:Panel><ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1"   
SuppressPostBack="true" runat="server" TargetControlID="Panel1" 
CollapseControlID="LinkButton1" ExpandControlID="LinkButton1" Collapsed="true" 
CollapsedSize="0" ExpandedSize="250" ExpandedText="(Collapse it......)" 
CollapsedText="(Expand it......)" TextLabelID="Label1" ExpandDirection="Vertical">
	</ajaxToolkit:CollapsiblePanelExtender> 

    </div>
    </form>
</body>
</html>
