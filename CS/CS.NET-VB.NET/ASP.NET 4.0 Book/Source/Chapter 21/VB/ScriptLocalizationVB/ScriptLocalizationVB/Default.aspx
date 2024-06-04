<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="ScriptLocalizationVB._Default" Culture="auto" UICulture="auto"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       ASP.NET 4.0 black book
    </h2>
     <br />
    <asp:ScriptManager ID= "SM1" runat="server" EnableScriptLocalization="true">
    <Scripts>
    <asp:ScriptReference Assembly="LocalizingResources" Name="LocalizingResources.CreateScript.js" />
    </Scripts>
    </asp:ScriptManager>
    <br />
    <br />
    <asp:Button ID="button" runat="server" 
        OnClientClick="CreateScript('Hello World.txt');" Text="Create" Width="92px"/>
</asp:Content>
