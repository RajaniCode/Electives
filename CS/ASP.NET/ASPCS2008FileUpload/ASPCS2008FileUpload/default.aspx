<%@ Page language="c#" AutoEventWireUp="false" Codebehind="default.aspx.cs" Inherits="FileUpload.WebForm1" %>

<HTML>
	<HEAD>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
				<asp:label id="lblFile" runat="server" Font-Bold="True">Picture:</asp:label>
				<input id="filMyFile" type="file" runat="server">
				<p></p>
				<asp:button id="cmdSend" runat="server" Text="Send"/>
				<p></p>
				<asp:Label id="lblInfo" runat="server" Font-Bold="True" Visible="false"></asp:Label>
				<p></p>
				<table>
						<tr>
							<td>
								<asp:Label id="lblText1" runat="server" Font-Bold="True" Visible="false">This was stored as file</asp:Label>
							</td>
							<td>
								<asp:Label id="lblText2" runat="server" Font-Bold="True" Visible="false">This was stored in database</asp:Label>
							</td>
						</tr>
						<tr>
							<td>
								<asp:Image id="imgFile" runat="server" Visible="False"></asp:Image>
							</TD>
							<td>
								<asp:Image id="imgDB" runat="server" Visible="False"></asp:Image>
							</td>
						</TR>
				</TABLE>
		</FORM>
	</body>
</HTML>
