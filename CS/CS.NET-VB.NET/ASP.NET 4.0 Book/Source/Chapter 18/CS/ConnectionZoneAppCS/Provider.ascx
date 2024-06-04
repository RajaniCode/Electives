<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Provider.ascx.cs" Inherits="Provider" %>
<table width="360px" cellpadding="4" cellspacing="0" bgcolor="#ececec" 		style="border-right: silver thin groove; border-top: silver thin groove; border-		left: silver thin groove; border-bottom: silver thin groove; background-color: 
 	#ececec;" title="Provider">
	<tr>
		<td align="left" style="width: 495px; text-align: center" valign="top">
		<strong><span style="color: #000099; text-decoration:underline">Provider WebPart</span></strong></td>
	</tr>
<tr>
<td align="left" valign="top" style="width: 495px">
This WebPart is acting as <span style="color: #cc0066">Provider Webpart</span> 	
for sending data to <span style="color: #cc0066">Consumer WebPart</span>
</td>
</tr>
<tr>
<td style="height: 33px; width: 495px;">
<span style="color: #000099">&nbsp;</span><strong><span style="color:#3300cc"><span
	style="color: #000099; text-decoration: underline">Enter Data:</span> </span></strong>
 	&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="173px"></asp:TextBox>
<asp:Button ID="Button1" Text="SEND" Runat="server" BorderStyle="Groove" />
</td>
</tr>
</table>
