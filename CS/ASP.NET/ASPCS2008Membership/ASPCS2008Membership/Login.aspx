<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASPCS2008Membership.Login" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style ="height:450px;">
<h2>Login:</h2>
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" 
        BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" 
        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333">
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" 
            ForeColor="White" />
    </asp:Login>
</div>
</asp:Content>

