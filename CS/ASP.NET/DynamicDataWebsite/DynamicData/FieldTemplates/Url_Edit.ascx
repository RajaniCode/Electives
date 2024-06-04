<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Url_Edit.ascx.cs" Inherits="DynamicData_FieldTemplates_Url_Edit" %>

<asp:TextBox 
    ID="txtUrl" 
    Text='<%# FieldValueEditString %>' 
    CssClass="droplist"
    runat="server"  />
    
<a href="javascript:void(0);" 
    id="ancTest"
    onclick="window.open($get('<%= txtUrl.ClientID %>').value)" 
    runat="server">Test</a>

<asp:RequiredFieldValidator 
    ID="rfvUrl" 
    ControlToValidate="txtUrl" 
    Enabled="false"
    CssClass="droplist" 
    Display="Dynamic" 
    runat="server" />

<asp:RegularExpressionValidator  
    ID="regUrl" 
    ControlToValidate="txtUrl"
    Enabled="false"
    CssClass="droplist" 
    Display="Dynamic" 
    runat="server" />
    
<asp:DynamicValidator 
    ID="dyvUrl" 
    ControlToValidate="txtUrl" 
    CssClass="droplist" 
    Display="Dynamic"
    runat="server" />