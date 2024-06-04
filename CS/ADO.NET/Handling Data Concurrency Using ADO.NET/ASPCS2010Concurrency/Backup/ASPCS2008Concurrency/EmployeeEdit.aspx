<%@ Page language="c#" Codebehind="EmployeeEdit.aspx.cs" AutoEventWireup="false" Inherits="ConcurrencyADONet1.EmployeeEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EmployeeEdit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:button id="btnGoBack" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 336px"
				runat="server" Width="184px" Text="Go Back to Employee List"></asp:button>
			<asp:button id="btnReloadFromDB" style="Z-INDEX: 108; LEFT: 24px; POSITION: absolute; TOP: 400px"
				runat="server" Width="184px" Text="Cancel &amp; Reload from DB"></asp:button>
			<asp:button id="btnCancelChanges" style="Z-INDEX: 107; LEFT: 24px; POSITION: absolute; TOP: 368px"
				runat="server" Width="184px" Text="Cancel Changes"></asp:button>
			<asp:button id="btnSaveAnyway" style="Z-INDEX: 106; LEFT: 24px; POSITION: absolute; TOP: 464px"
				runat="server" Width="184px" Text="Save Anyway"></asp:button><asp:button id="btnSave" style="Z-INDEX: 100; LEFT: 24px; POSITION: absolute; TOP: 432px" runat="server"
				Width="184px" Text="Save Changes"></asp:button>
			<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 24px; WIDTH: 792px; POSITION: absolute; TOP: 72px; HEIGHT: 251px"
				cellSpacing="1" cellPadding="1" width="792" border="0">
				<TR>
					<TD style="WIDTH: 95px; HEIGHT: 21px"></TD>
					<TD style="WIDTH: 178px; HEIGHT: 21px" width="178"></TD>
					<TD style="WIDTH: 215px; HEIGHT: 21px" noWrap><asp:label id="lblOriginalHeader" runat="server" Width="104px" Font-Bold="True" Visible="False"
							Font-Size="X-Small" Font-Names="Arial">Original Values From DataSet</asp:label></TD>
					<TD style="HEIGHT: 21px" noWrap><asp:label id="lblInDBHeader" runat="server" Width="104px" Font-Bold="True" Visible="False"
							Font-Size="X-Small" Font-Names="Arial">Values in Database</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 95px; HEIGHT: 25px"><asp:label id="Label1" runat="server" Width="104px" Font-Bold="True" Font-Size="X-Small" Font-Names="Arial">Employee ID</asp:label></TD>
					<TD style="WIDTH: 178px; HEIGHT: 25px" width="178"><asp:label id=lblEmployeeID runat="server" Width="156px" Text='<%# DataBinder.Eval(oDsEmployee, "Tables[Employee].DefaultView.[0].EmployeeID") %>' Font-Size="X-Small" Font-Names="Arial">
						</asp:label></TD>
					<TD style="WIDTH: 215px; HEIGHT: 25px" noWrap></TD>
					<TD style="HEIGHT: 25px" noWrap></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 95px"><asp:label id="Label2" runat="server" Width="104px" Font-Bold="True" Font-Size="X-Small" Font-Names="Arial">First Name</asp:label></TD>
					<TD style="WIDTH: 178px" width="178"><asp:textbox id=txtFirstName runat="server" Width="140px" Text='<%# DataBinder.Eval(oDsEmployee, "Tables[Employee].DefaultView.[0].FirstName") %>' Font-Size="X-Small" Font-Names="Arial">
						</asp:textbox></TD>
					<TD style="WIDTH: 215px" noWrap><asp:label id="lblFirstName_Original" runat="server" Width="200px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
					<TD noWrap><asp:label id="lblFirstName_InDB" runat="server" Width="104px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 95px"><asp:label id="Label3" runat="server" Width="104px" Font-Bold="True" Font-Size="X-Small" Font-Names="Arial">Last Name</asp:label></TD>
					<TD style="WIDTH: 178px" width="178"><asp:textbox id=txtLastName runat="server" Width="140px" Text='<%# DataBinder.Eval(oDsEmployee, "Tables[Employee].DefaultView.[0].LastName") %>' Font-Size="X-Small" Font-Names="Arial">
						</asp:textbox></TD>
					<TD style="WIDTH: 215px" noWrap><asp:label id="lblLastName_Original" runat="server" Width="200px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
					<TD noWrap><asp:label id="lblLastName_InDB" runat="server" Width="104px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 95px"><asp:label id="Label4" runat="server" Width="104px" Font-Bold="True" Font-Size="X-Small" Font-Names="Arial">Title</asp:label></TD>
					<TD style="WIDTH: 178px" width="178"><asp:textbox id=txtTitle runat="server" Width="140px" Text='<%# DataBinder.Eval(oDsEmployee, "Tables[Employee].DefaultView.[0].Title") %>' Font-Size="X-Small" Font-Names="Arial">
						</asp:textbox></TD>
					<TD style="WIDTH: 215px" noWrap><asp:label id="lblTitle_Original" runat="server" Width="192px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
					<TD noWrap><asp:label id="lblTitle_InDB" runat="server" Width="104px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 95px; HEIGHT: 28px"><asp:label id="Label5" runat="server" Width="104px" Font-Bold="True" Font-Size="X-Small" Font-Names="Arial">Birth Date</asp:label></TD>
					<TD style="WIDTH: 178px; HEIGHT: 28px" width="178"><asp:textbox id=txtBirthDate runat="server" Width="140px" Text='<%# DataBinder.Eval(oDsEmployee, "Tables[Employee].DefaultView.[0].BirthDate", "{0:d}") %>' Font-Size="X-Small" Font-Names="Arial">
						</asp:textbox></TD>
					<TD style="WIDTH: 215px; HEIGHT: 28px" noWrap><asp:label id="lblBirthDate_Original" runat="server" Width="200px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
					<TD style="HEIGHT: 28px" noWrap><asp:label id="lblBirthDate_InDB" runat="server" Width="104px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 95px"><asp:label id="Label6" runat="server" Width="104px" Font-Bold="True" Font-Size="X-Small" Font-Names="Arial">Hire Date</asp:label></TD>
					<TD style="WIDTH: 178px" width="178"><asp:textbox id=txtHireDate runat="server" Width="140px" Text='<%# DataBinder.Eval(oDsEmployee, "Tables[Employee].DefaultView.[0].HireDate", "{0:d}") %>' Font-Size="X-Small" Font-Names="Arial"></asp:textbox></TD>
					<TD style="WIDTH: 215px" noWrap><asp:label id="lblHireDate_Original" runat="server" Width="200px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
					<TD noWrap><asp:label id="lblHireDate_InDB" runat="server" Width="104px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 95px"><asp:label id="Label7" runat="server" Width="104px" Font-Bold="True" Font-Size="X-Small" Font-Names="Arial">Extension</asp:label></TD>
					<TD style="WIDTH: 178px" width="178"><asp:textbox id=txtExtension runat="server" Width="140px" Text='<%# DataBinder.Eval(oDsEmployee, "Tables[Employee].DefaultView.[0].Extension") %>' Font-Size="X-Small" Font-Names="Arial">
						</asp:textbox></TD>
					<TD style="WIDTH: 215px" noWrap><asp:label id="lblExtension_Original" runat="server" Width="200px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
					<TD noWrap><asp:label id="lblExtension_InDB" runat="server" Width="104px" Font-Size="X-Small" Font-Names="Arial"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 95px"><asp:label id="Label8" runat="server" Width="104px" Font-Bold="True" Font-Size="X-Small" Font-Names="Arial">Last Update</asp:label></TD>
					<TD style="WIDTH: 178px" width="178"><asp:label id=lblLastUpdateDateTime runat="server" Width="200px" Text='<%# DataBinder.Eval(oDsEmployee, "Tables[Employee].DefaultView.[0].LastUpdateDateTime") %>' Font-Size="X-Small" Font-Names="Arial">
						</asp:label></TD>
					<TD style="WIDTH: 215px" noWrap><asp:label id="lblLastUpdateDateTime_Original" runat="server" Width="232px" Font-Size="X-Small"
							Font-Names="Arial"></asp:label></TD>
					<TD noWrap><asp:label id="lblLastUpdateDateTime_InDB" runat="server" Width="128px" Font-Size="X-Small"
							Font-Names="Arial"></asp:label></TD>
				</TR>
			</TABLE>
			<asp:label id="lblMessage" style="Z-INDEX: 103; LEFT: 224px; POSITION: absolute; TOP: 344px"
				runat="server" Width="416px" Font-Size="X-Small" Font-Names="Arial" ForeColor="Blue" Height="56px"></asp:label>
			<DIV style="DISPLAY: inline; FONT-WEIGHT: bold; FONT-SIZE: large; Z-INDEX: 104; LEFT: 24px; WIDTH: 720px; COLOR: navy; FONT-FAMILY: Arial; POSITION: absolute; TOP: 8px; HEIGHT: 29px"
				ms_positioning="FlowLayout">Edit an Employee</DIV>
			<HR style="Z-INDEX: 105; LEFT: 24px; WIDTH: 792px; POSITION: absolute; TOP: 40px; HEIGHT: 8px"
				width="100%" SIZE="1">
		</form>
	</body>
</HTML>
