<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Consumer.ascx.cs" Inherits="Consumer" %>
<table width="360px" cellpadding="4" cellspacing="0" style="border-right: silver thin 
 	groove;
	border-top: silver thin groove; border-left: silver thin groove;
	border-bottom: silver thin groove; background-color: #ececec; height:88pt;">
<tr>
<td align="left" valign="top" style="border-color: #ffff99; 
	text-align:center; height: 25px;">
		&nbsp;
		<span style="color: #003399; text-decoration:underline">
		<strong>
		Consumer WebPart
		</strong>
		</span>
	</td>
</tr>
<tr>
<td style="height: 46px">
	&nbsp;&nbsp;
	<asp:Label ID="Label1" runat="server" Text="Retrived Data" Width="90px" 
 	BackColor="SeaShell"
	BorderColor="Red" BorderStyle="None">
	</asp:Label>
	&nbsp;
	&nbsp;
	<asp:Label ID="Label2" runat="server" Text="Label" Width="170px">
	</asp:Label>
</td>
</tr>
</table>
