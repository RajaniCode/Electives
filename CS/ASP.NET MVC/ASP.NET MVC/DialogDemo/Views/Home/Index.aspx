<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DialogDemo.Models.HomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3>jQuery Dialog Demos:</h3>
    <ul>
    <li><%: Html.ActionLink("jQuery UI-Dialog", "SalesInfo", "jqUI", new { customerid = 93 }, new { @class = "dialog-link" })%>
    <li><%: Html.ActionLink("ColorBox Dialog", "SalesInfo", "Colorbox", new { customerid = 93 }, new { @class = "dialog-link" }) %>
    <li><%: Html.ActionLink("Simple Dialog", "SalesInfo", "SimpleDialog", new { customerid = 93 }, new { @class = "dialog-link" }) %>
    </ul>

    <div style="font-family: Tahoma; font-size: 10pt; margin: 40px 0 0 0; color: blue; line-height: 1.5">
    <b>Notes:</b> 
    <ul style="margin-top: -2px">
    <li>Except in the jQuery UI-Dialog sample, the <u>Delete</u> links are not wired up and will produce errors.</li>
    <li>Similarly, none of the links to add new records have code attached except in the jQuery UI-Dialog sample.</li>
    <li>All other links should be functional on all the samples.</li>
    <li>See the Code Project article for notes about validation and/or lack thereof.</li>
    </ul>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
