<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Url.ascx.cs" Inherits="DynamicData_FieldTemplates_Url" %>

<a href="<%# FieldValueString %>">
<asp:Literal ID="litURL" Text="<%# FieldValueString %>" runat="server" /></a>