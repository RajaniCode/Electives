<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style ="height:450px;">
<h2>Welcome To MyHomePage</h2>
<b>New User Register Here:</b>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
        OnContinueButtonClick="CreateUserWizard1_ContinueButtonClick" 
        OnCreatedUser="CreateUserWizard1_CreatedUser" BackColor="#EFF3FB" 
        BorderColor="#B5C7DE" BorderStyle="Solid" BorderWidth="1px" 
        Font-Names="Verdana" Font-Size="0.8em">
        <ContinueButtonStyle BackColor="White" BorderColor="#507CD1" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            ForeColor="#284E98" />
        <CreateUserButtonStyle BackColor="White" BorderColor="#507CD1" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            ForeColor="#284E98" />
        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
        <HeaderStyle BackColor="#284E98" BorderStyle="Solid" Font-Bold="True" 
            Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" 
            BorderColor="#EFF3FB" BorderWidth="2px" />
        <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            ForeColor="#284E98" />
        <SideBarButtonStyle Font-Names="Verdana" ForeColor="White" 
            BackColor="#507CD1" />
        <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" 
            VerticalAlign="Top" />
        <StepStyle Font-Size="0.8em" />
    </asp:CreateUserWizard>
</div>
</asp:Content>

