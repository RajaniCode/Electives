<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" Title="Recover your password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" BackColor="#FFFBD6" 
    BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
    Font-Names="Verdana" Font-Size="X-Small" SuccessPageUrl="~/Login.aspx" 
        Width="340px" Height="127px">
       
    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
    <SuccessTextStyle Font-Bold="True" ForeColor="#5D7B9D" />
    
    <TextBoxStyle Font-Size="X-Small" />
    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        
    <SubmitButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="X-Small"  ForeColor="#284775" />
       
</asp:PasswordRecovery>
</asp:Content>

