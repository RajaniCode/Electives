<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Createuser.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#F7F6F3" 
		BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" 
		Font-Names="Verdana" Font-Size="0.8em" Height="55px" Width="349px" 
		oncreateduser="CreateUserWizard1_CreatedUser">
		<SideBarStyle BackColor="#5D7B9D" Font-Size="0.9em" VerticalAlign="Top" 
		BorderWidth="0px" />
		<SideBarButtonStyle Font-Names="Verdana" 
		ForeColor="White" BorderWidth="0px" />
		<ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
		BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
		ForeColor="#284775" />
		<NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
		BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
		ForeColor="#284775" />
		<HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" 
		Font-Size="0.9em" ForeColor="White" 
		HorizontalAlign="Center" />
		<CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
		BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
		ForeColor="#284775" />
		<TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
		<StepStyle BorderWidth="0px" />
		<WizardSteps>
		<asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server"   
		Title="CreateUser">
		<ContentTemplate>
		<table border="0" class="style2" style="font-family:Verdana;font-size:100%;">
		<tr>
		<td align="center" colspan="2" 
		style="color:White;background-color:#507CD1;font-weight:bold;">
		CreateUser</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
		Name:</asp:Label>
		</td>
		<td>
		<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
		<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
		ControlToValidate="UserName" ErrorMessage="User Name is required." 
		ToolTip="User Name is required." 
		ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
		</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID ="lblName" runat="server" Text="Name">
		</asp:Label>
		</td>
		<td align="left">
		<asp:TextBox ID ="Name" runat ="server">
		</asp:TextBox>
		</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID="PasswordLabel" runat="server" 
		AssociatedControlID="Password">Password:</asp:Label>
		</td>
		<td>
		<asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
		<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
		ControlToValidate="Password" ErrorMessage="Password is required." 
		ToolTip="Password is required." 
		ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
		</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID="ConfirmPasswordLabel" runat="server" 
		AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
		</td>
		<td>
		<asp:TextBox ID="ConfirmPassword" runat="server" 
		TextMode="Password"></asp:TextBox>
		<asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
		ControlToValidate="ConfirmPassword" 
		ErrorMessage="Confirm Password is required." 
		ToolTip="Confirm Password is required." 
		ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
		</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">
		E-mail:</asp:Label>
		</td>
		<td>
		<asp:TextBox ID="Email" runat="server"></asp:TextBox>
		<asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
		ControlToValidate="Email" ErrorMessage="E-mail is required." 
		ToolTip="E-mail is required." 
		ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
		</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID="QuestionLabel" runat="server" 
		AssociatedControlID="Question">Security 
		Question:</asp:Label>
		</td>
		<td>
		<asp:TextBox ID="Question" runat="server"></asp:TextBox>
		<asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
		ControlToValidate="Question" ErrorMessage="Security question is required." 
		ToolTip="Security question is required." 
		ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
		</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security 
		Answer:</asp:Label>
		</td>
		<td>
		<asp:TextBox ID="Answer" runat="server"></asp:TextBox>
		<asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
		ControlToValidate="Answer" ErrorMessage="Security answer is required." 
		ToolTip="Security answer is required." 
		ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
		</td>
		</tr>
		<tr>
		<td align="center" colspan="2">
		<asp:CompareValidator ID="PasswordCompare" runat="server" 
		ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
		Display="Dynamic" 
		ErrorMessage="The Password and Confirmation Password must match." 
		ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
		</td>
		</tr>
		<tr>
		<td align="center" colspan="2" style="color:Red;">
		<asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
		</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID="lblcountry" runat="server" Text="Country"></asp:Label>
		</td>
		<td align ="left" colspan="2"> 
		<asp:DropDownList ID="Country" runat="server" style="margin-left: 11px" >
		<asp:ListItem>Others</asp:ListItem>
		<asp:ListItem>India</asp:ListItem>
		<asp:ListItem>China</asp:ListItem>
		<asp:ListItem>Nepal
		</asp:ListItem>
		<asp:ListItem></asp:ListItem>
		</asp:DropDownList>
		</td>
		</tr>
		<tr>
		<td align="right">
		<asp:Label ID="Lblgender" runat="server" Text="Gender"></asp:Label>
		</td>
		<td align ="left" colspan="2"> 
		<asp:DropDownList ID="Gender" runat="server" style="margin-left: 9px" >
		<asp:ListItem>Male</asp:ListItem>
		<asp:ListItem>Female</asp:ListItem>
		</asp:DropDownList>
		</td>
		</tr>
		</table>
		</ContentTemplate>
		</asp:CreateUserWizardStep>
		<asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" >
		<ContentTemplate>
		<table border="0" 
		style="font-family:Verdana;font-size:100%;height:212px;width:362px;">
		<tr>
		<td align="center" colspan="2" 
		style="color:White;background-color:#5D7B9D;font-weight:bold;">
		Complete</td>
		</tr>
		<tr>
		<td>
		Your account has been successfully created.</td>
		</tr>
		<tr>
		<td align="right" colspan="2">
		<asp:Button ID="ContinueButton" runat="server" BackColor="#FFFBFF" 
		BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" 
		CausesValidation="False" CommandName="Continue" Font-Names="Verdana" 
		ForeColor="#284775" Text="Continue" ValidationGroup="CreateUserWizard1" />
		<a href="Login.aspx">Login</a>
		</td>
	</tr>
		</table>
		</ContentTemplate>
		</asp:CompleteWizardStep>
		<asp:WizardStep ID="WizardStep1" runat="server" Title="Registerd">
		<asp:Label ID="Label1" runat="server" 
		Text="You Are a Registered User now,You can login Into the website"></asp:Label>
		<a href="Login.aspx">Login</a>
		</asp:WizardStep>
		</WizardSteps>
		</asp:CreateUserWizard>

    </div>
    </form>
</body>
</html>
