<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <strong><span style="text-decoration: underline"><em>Updating the users properties<br />
		</em></span></strong>
		<br />
		<br />
		&nbsp; &nbsp;&nbsp;
		<table id="update" cellpadding="0" cellspacing="0" >
		<tr>
			<td style="width: 218px">
			<asp:DetailsView AutoGenerateRows="False" 
 			  DataSourceID="ObjectDataSource1" Height="50px"
			ID="DetailsView1" runat="server" Width="268px" 
 			  AutoGenerateEditButton="True"  
			OnItemUpdating="DetailsView1_ItemUpdating" BackColor="White" 
 			  BorderColor="#CC9966" BorderStyle="None"  
			BorderWidth="1px" CellPadding="4">
			<Fields>
			<asp:BoundField DataField="Email" HeaderText="Email" 
 			  SortExpression="Email"></asp:BoundField>
			<asp:BoundField DataField="Comment" HeaderText="Comment" 
 			  SortExpression="Comment"></asp:BoundField>
			<asp:BoundField DataField="UserName" HeaderText="UserName" 
 			  ReadOnly="True" SortExpression="UserName">
			<HeaderStyle Font-Bold="True" />
			<ItemStyle Font-Bold="True" />
			</asp:BoundField>
			<asp:BoundField DataField="IsLockedOut" HeaderText="IsLockedOut" 
 			  SortExpression="IsLockedOut" ReadOnly="True">
			</asp:BoundField>
			</Fields>
			<HeaderTemplate>
				<div style="text-align: center">
					Updating Properties
				</div>
			</HeaderTemplate>
			<FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
			<RowStyle BackColor="White" ForeColor="#330099" />
			<PagerStyle BackColor="#FFFFCC" ForeColor="#330099" 
 			  HorizontalAlign="Center" />
			<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
			<EditRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
			</asp:DetailsView>
			<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"  
			DataObjectTypeName="System.Web.Security.MembershipUser" 
 			  SelectMethod="GetUser"  
			TypeName="System.Web.Security.Membership"></asp:ObjectDataSource> 
			</td> 
		</tr>
		</table>
		<hr />
		<asp:Button ID="Button1" runat="server" Text="Sign Out" OnClick="Button1_Click" 
 		  /><br />       
		<asp:LinkButton ID="LinkButton1" runat="server" 
 		 OnClick="LinkButton1_Click">Delete Current Profile:</asp:LinkButton>

    </div>
    </form>
</body>
</html>
