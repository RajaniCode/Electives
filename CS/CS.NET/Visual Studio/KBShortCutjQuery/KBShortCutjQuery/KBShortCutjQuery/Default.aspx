<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:LinkButton ID="lbPage1" runat="server" PostBackUrl="Page1.aspx">
    Page 1</asp:LinkButton><br />
    <asp:LinkButton ID="lbPage2" runat="server" PostBackUrl="Page2.aspx">
    Page 2</asp:LinkButton><br />
    <asp:LinkButton ID="lbPage3" runat="server" PostBackUrl="Page3.aspx">
    Page 3</asp:LinkButton><br />
    <asp:Button ID="btnAlert" runat="server" Text="Click Me" />   
</div>
</asp:Content>

