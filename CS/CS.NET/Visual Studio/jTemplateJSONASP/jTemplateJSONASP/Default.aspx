<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jtemplates.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(document).ready(function () {
         $.ajax({
             type: "POST",
             url: "Default.aspx/getAllPatientList",
             data: "{}",
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             success: function (data) {
     
                 $('#placeholder').setTemplateURL('JTemplates/ForEachTemplate.htm');
                 $('#placeholder').processTemplate(data.d);
             }
         });


     });
    </script>
</asp:Content>



<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>jTemplate,jQuery and JSON in ASP.NET for DotNetCurry.com</h2>
    <p>
        <div id="placeholder" style="clear: both;"></div>
    </p>   
</asp:Content>
