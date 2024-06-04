<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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

			<asp:Panel ID="Panel1" runat="server" HorizontalAlign="Right">			
			<asp:Label ID="Label1" runat="server" Text="Created by Kogent Solutions 
 			  Inc." Font-Bold="True" Font-Size="Larger" ForeColor="#FF3399" 
 			  BackColor="Green" Height="96px" style="margin-left: 0px" Width="427px"></asp:Label>
		     <br />
			<asp:Image ID="Image1" runat="server" ImageUrl="~/images/Tulips.jpg" 
 			  Height="275px" Width="425px" BorderWidth="1" style="margin-left: 0px" />
			</asp:Panel>
			<ajaxToolkit:alwaysvisiblecontrolextender ID="AlwaysVisibleControlExtender1" 
 			  runat="server" TargetControlID="Panel1" VerticalSide="Top" 
 			  VerticalOffset="10" HorizontalSide="Right" HorizontalOffset="10" 
 			  ScrollEffectDuration="1.0">
			</ajaxToolkit:alwaysvisiblecontrolextender> <br />
		</div>
		<div style="width:362px" align="left">
ASP.NET is a server-side technology for building web applications. Almost all the work
happens on the web server and not the web browser. Whenever you perform an action in
an ASP.NET page—such as clicking a button or sorting a GridView—the entire page must
be posted back to the web server. Any significant action on a page results in a postback.
If you think about it, this is incredibly inefficient. When you perform a postback in an
ASP.NET page, the entire page must be transported across the Internet from browser to
server. Next, the .NET class that corresponds to the page must re-render the entire page
again from scratch. Finally, the finished page must be sent back across the Internet to 
the browser. This whole long, slow, agonizing process must occur even if you are updating 
a tiny section of the page. <br /><br />
Using a server-side technology such as ASP.NET results in a bad user experience. Every
time a user performs some action on a page, the universe temporarily freezes. Whenever
you perform a postback, the browser locks, the page jumps, and the user must wait
patiently twiddling his thumbs while the page gets reconstructed. All of us have grown
accustomed to this awful user experience. However, we would never design our desktop
applications in the same way.<br /><br />
ASP.NET is a server-side technology for building web applications. Almost all the work
happens on the web server and not the web browser. Whenever you perform an action in
an ASP.NET page—such as clicking a button or sorting a GridView—the entire page must
be posted back to the web server. Any significant action on a page results in a postback.
If you think about it, this is incredibly inefficient. When you perform a postback in an
ASP.NET page, the entire page must be transported across the Internet from browser to
server. Next, the .NET class that corresponds to the page must re-render the entire page
again from scratch. Finally, the finished page must be sent back across the Internet to 
the browser. This whole long, slow, agonizing process must occur even if you are updating 
a tiny section of the page.<br /><br />
Using a server-side technology such as ASP.NET results in a bad user experience. Every
time a user performs some action on a page, the universe temporarily freezes. Whenever
you perform a postback, the browser locks, the page jumps, and the user must wait
patiently twiddling his thumbs while the page gets reconstructed. All of us have grown
accustomed to this awful user experience. However, we would never design our desktop
applications in the same way.<br /><br />

ASP.NET is a server-side technology for building web applications. Almost all the work
happens on the web server and not the web browser. Whenever you perform an action in
an ASP.NET page—such as clicking a button or sorting a GridView—the entire page must
be posted back to the web server. Any significant action on a page results in a postback.
If you think about it, this is incredibly inefficient. When you perform a postback in an
ASP.NET page, the entire page must be transported across the Internet from browser to
server. Next, the .NET class that corresponds to the page must re-render the entire page
again from scratch. Finally, the finished page must be sent back across the Internet to 
the browser. This whole long, slow, agonizing process must occur even if you are updating 
a tiny section of the page.<br /><br />
Using a server-side technology such as ASP.NET results in a bad user experience. Every
time a user performs some action on a page, the universe temporarily freezes. Whenever
you perform a postback, the browser locks, the page jumps, and the user must wait
patiently twiddling his thumbs while the page gets reconstructed. All of us have grown
accustomed to this awful user experience. However, we would never design our desktop
applications in the same way.

    </div>
    </form>
</body>
</html>
