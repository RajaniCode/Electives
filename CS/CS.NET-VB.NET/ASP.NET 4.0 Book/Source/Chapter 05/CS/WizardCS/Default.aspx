<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wizard Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
			Font-Underline="True" Text="Wizard Control Example"></asp:Label>
            <br />
			<br />
			<br />
            <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" 
			Height="163px" Width="356px" HeaderText ="Choose your favourite 
			shape" BorderColor ="#FFDFAD" BackColor="#FFFBD6" 
			BorderWidth="1px" Font-Names="Verdana" Font-Size="Small" 
            onfinishbuttonclick="Wizard1_FinishButtonClick" >
			<WizardSteps>
				<asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1" >
					<asp:Label ID="Label2" runat="server" Text="Select a 
 					  shape:" Font-Size="Small"></asp:Label><br />
					<br />
					<asp:DropDownList ID="DropDownList1" runat="server">
						<asp:ListItem>Line</asp:ListItem>
						<asp:ListItem>Ellipse</asp:ListItem>
						<asp:ListItem>Rectangle</asp:ListItem>
					</asp:DropDownList><br />
					<br />
					<asp:Label ID="Label3" runat="server" 
					Text="Select a color:"></asp:Label><br />
					<br />
					<asp:DropDownList ID="DropDownList2" 
					runat="server">
						<asp:ListItem>Maroon</asp:ListItem>
						<asp:ListItem>Purple</asp:ListItem>
						<asp:ListItem>Blue</asp:ListItem>
						<asp:ListItem>Pink</asp:ListItem>
					</asp:DropDownList>
				</asp:WizardStep>
			</WizardSteps>
			<SideBarStyle BackColor="#990000" Font-Size="0.9em" 
			VerticalAlign="Top" />
			<NavigationButtonStyle BackColor="White" 
			BorderColor="#CC9966" BorderStyle="Solid" 
			BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
			ForeColor="#990000" />
			<SideBarButtonStyle ForeColor="White" />
			<HeaderStyle BackColor="#FFCC66" BorderColor="#FFFBD6" 
			BorderStyle="Solid" BorderWidth="2px" 
			Font-Bold="True" Font-Size="0.9em" ForeColor="#333333" 
			HorizontalAlign="Center" />
			</asp:Wizard>
    </div>
    </form>
</body>
</html>
