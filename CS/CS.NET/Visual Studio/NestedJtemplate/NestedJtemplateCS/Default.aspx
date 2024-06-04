<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
<script src="Scripts/jtemplates.js" type="text/javascript"></script>
<script src="Scripts/jquery.blockUI.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $.blockUI({ message: '<h1> Processing...</h1>' });
        $.ajax({
            type: "POST",
            url: "Default.aspx/getAllPatientList",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $.unblockUI();
                $('#placeholder').setTemplateURL('JTemplates/ForEachTemplate.htm');
                $('#placeholder').processTemplate(data.d);
            },
            error: function (textStatus) {
                $.unblockUI();
                alert(textStatus);
            }
        });


    });
</script>
    <%--Author: Aamir Hasan 
    Date:August 19, 2010
    www.aspxtutorial.com
    article written for DotNetCurry.com
    --%>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       Nested jTemplate, jQuery and JSON in ASP.NET </h2>
    <p><div id="placeholder" style="clear: both;">&nbsp;</div></p>
</asp:Content>
