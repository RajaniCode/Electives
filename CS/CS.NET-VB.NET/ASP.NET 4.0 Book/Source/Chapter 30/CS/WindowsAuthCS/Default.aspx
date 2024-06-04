<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
		<br /><br /><br /><br />
		<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
		  AllowSorting="True" AutoGenerateColumns="False" 
		  BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
		  CellPadding="2" DataKeyNames="ID" DataSourceID="SqlDataSource1" 
		  ForeColor="Black" GridLines="None">
		  <FooterStyle BackColor="Tan" />
		<Columns>
		<asp:BoundField DataField="ID" HeaderText="ID" 
		  SortExpression="ID" ReadOnly="True" />
		<asp:BoundField DataField="EventName" HeaderText="EventName" 
		  SortExpression="EventName" />
		<asp:BoundField DataField="Place" HeaderText="Place" 
		  SortExpression="Place" />
		<asp:BoundField DataField="Time" HeaderText="Time" SortExpression="SubmitTime" ControlStyle-Width="500px"/>
		<asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" 
		  SortExpression="CreatedBy" />
		</Columns>
		<PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
		  HorizontalAlign="Center" />
		<SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
		<HeaderStyle BackColor="Tan" Font-Bold="True" />
		<AlternatingRowStyle BackColor="PaleGoldenrod" />
		</asp:GridView>
		
               		
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
		  ConflictDetection="CompareAllValues" 
		   ConnectionString="<%$ ConnectionStrings:puneetConnectionString %>" 			
		SelectCommand="SELECT [EventName], [Place], [Time], [CreatedBy], [ID] FROM [Events]" >		
		</asp:SqlDataSource>
		<br /><br />
		<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddEvent.aspx">Add New Event</asp:HyperLink>

    </div>
    </form>
</body>
</html>
