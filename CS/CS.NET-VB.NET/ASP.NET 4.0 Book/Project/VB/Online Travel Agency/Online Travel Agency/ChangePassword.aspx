<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ChangePassword.aspx.vb" Inherits="Online_Travel_Agency.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#F7F6F3" 
        BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
        Font-Names="Verdana" Font-Size="0.8em" 
        CancelDestinationPageUrl="~/Home_User.aspx" 
        ContinueDestinationPageUrl="~/Home_User.aspx" Height="203px" Width="428px">
        <CancelButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <PasswordHintStyle Font-Italic="True" ForeColor="#888888" />
        <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <ChangePasswordButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        <TextBoxStyle Font-Size="0.8em" />
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
    </asp:ChangePassword>
</asp:Content>
