<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Surname <asp:TextBox ID="txtSurname" runat="server" ValidationGroup="Surname"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Surname is required" ControlToValidate="txtSurname" 
        Display="None" ValidationGroup="Surname"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Save Data" 
        ValidationGroup="Surname" />
</asp:Content>
