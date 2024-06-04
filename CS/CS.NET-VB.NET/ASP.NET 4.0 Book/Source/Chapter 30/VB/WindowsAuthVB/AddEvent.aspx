<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddEvent.aspx.vb" Inherits="AddEvent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Welcome to Kogent Intranet" 
		Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Size="X-Large"></asp:Label>
		<br /><br />
		<asp:Label ID="Label2" runat="server" Text="Please provide details of new event" 
		Font-Bold="True" Font-Names="Arial"></asp:Label>
		<br /><br />
		<table width="100%" border="0">
		<tr>
			<td class="style1">
			<asp:Label ID="Label3" runat="server" Text="Event ID:" Font-Bold="True" 
			Font-Names="Arial"></asp:Label></td>
			<td width="1%">&nbsp;</td>
			<td width="79%">
			<asp:TextBox ID="ID" runat="server"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="style1">&nbsp;</td>
			<td width="1%">&nbsp;</td>
			<td width="79%">&nbsp;</td>
		</tr>
		<tr>
			<td class="style1">
			<asp:Label ID="Label4" runat="server" Text="Event Name:" Font-Bold="True" 
			Font-Names="Arial"></asp:Label></td>
			<td width="1%">&nbsp;</td>
			<td width="79%">
			<asp:TextBox ID="name" runat="server"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="style1">&nbsp;</td>
			<td width="1%">&nbsp;</td>
			<td width="79%">&nbsp;</td>
		</tr>
		<tr>
			<td class="style1">
			<asp:Label ID="Label5" runat="server" Text="Event Time:" Font-Bold="True" 
			Font-Names="Arial"></asp:Label></td>
			<td width="1%">&nbsp;</td>
			<td width="79%">
			<asp:TextBox ID="time" runat="server"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="style1">&nbsp;</td>
			<td width="1%">&nbsp;</td>
			<td width="79%">&nbsp;</td>
		</tr>
		<tr>
			<td class="style1">
			<asp:Label ID="Label6" runat="server" Text="Event Location:" Font-Bold="True" 
			Font-Names="Arial"></asp:Label></td>
			<td width="1%">&nbsp;</td>
			<td width="79%">
			<asp:TextBox ID="location" runat="server"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="style1">&nbsp;</td>
			<td width="1%">&nbsp;</td>
			<td width="79%">&nbsp;</td>
		</tr>
		<tr>
			<td class="style1">
			<asp:Label ID="Label7" runat="server" Text="Created By:" Font-Bold="True" 
			Font-Names="Arial"></asp:Label></td>
			<td width="1%">&nbsp;</td>
			<td width="79%">
			<asp:TextBox ID="user" runat="server" Enabled="false" Height="111px" 
			TextMode="MultiLine" Width="315px"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="style1">&nbsp;</td>
			<td width="1%">&nbsp;</td>
			<td width="79%">
			<br />
			    <asp:Button ID="Button1" runat="server" Text="Insert Record" Width="119px" />
			<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:puneetConnectionString %>" 
            InsertCommand="INSERT INTO [Events] ([ID], [EventName], [Place], [Time], [CreatedBy]) VALUES (@ID, @EventName, @Place, @Time, @CreatedBy)" >						 			
			<InsertParameters>
				<asp:ControlParameter ControlID="ID" Name="ID" PropertyName="Text" Type="Int32" />
				<asp:ControlParameter ControlID="name" Name="EventName" PropertyName="Text" Type="String" />
				<asp:ControlParameter ControlID="location" Name="Place" PropertyName="Text" Type="String" />
				<asp:ControlParameter ControlID="time" Name="Time" PropertyName="Text" Type="String" />
				<asp:ControlParameter ControlID="user" Name="CreatedBy"  PropertyName="Text" Type="String" />
			</InsertParameters>
			</asp:SqlDataSource>
			<asp:Label ID="Label8" runat="server"></asp:Label>
			<br /><br />
			<asp:HyperLink ID="HyperLink1" runat="server" 
 			  NavigateUrl="~/Default.aspx">Click 
			here to see the list of events</asp:HyperLink></td>
		</tr>
		</table>

    </div>
    </form>
</body>
</html>
