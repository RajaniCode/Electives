<%@ Page language="c#" Codebehind="EmployeeList.aspx.cs" AutoEventWireup="false" Inherits="ConcurrencyADONet1.EmployeeList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Employee List</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmEmployees" method="post" runat="server">
			<DIV style="DISPLAY: inline; FONT-WEIGHT: bold; FONT-SIZE: large; Z-INDEX: 102; LEFT: 24px; WIDTH: 720px; COLOR: navy; FONT-FAMILY: Arial; POSITION: absolute; TOP: 8px; HEIGHT: 29px"
				ms_positioning="FlowLayout">Employee List</DIV>
			<HR style="Z-INDEX: 101; LEFT: 24px; WIDTH: 792px; POSITION: absolute; TOP: 40px; HEIGHT: 8px"
				width="100%" SIZE="1">
			<asp:DataGrid id="grdEmployees" runat="server" BorderColor="#3366CC" BorderWidth="1px" BackColor="White"
				CellPadding="4" Width="408px" BorderStyle="None" AutoGenerateColumns="False"
				Font-Names="Arial" Font-Size="X-Small"
				OnSelectedIndexChanged="grdEmployees_SelectedIndexChanged"
				DataSource="<%# oDsAllEmployees %>" DataMember="Employee" DataKeyField="EmployeeID" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 64px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:ButtonColumn Text="Select" CommandName="Select">
						<ItemStyle Wrap="False" ForeColor="Blue"></ItemStyle>
					</asp:ButtonColumn>
					<asp:BoundColumn DataField="EmployeeID" ReadOnly="True" HeaderText="Employee ID">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="FirstName" HeaderText="First Name">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="LastName" HeaderText="Last Name">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Title" HeaderText="Title">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="BirthDate" HeaderText="Birth Date" DataFormatString="{0:d}">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="HireDate" HeaderText="Hire Date" DataFormatString="{0:d}">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Extension" HeaderText="Extension">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="LastUpdateDateTime" ReadOnly="True" HeaderText="LastUpdateDateTime">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
