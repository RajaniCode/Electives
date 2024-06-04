<%@ Page Language="VB" MasterPageFile="~/SimpleMaster.master" %>
<script runat="server">

    Private Sub Page_Load()
        ' Create Meta Description
        Page.MetaDescription = "A sample of using HtmlMeta controls"
 
        ' Create Meta Keywords
        Page.MetaKeywords = "HtmlMeta,Page.Header,ASP.NET"

    End Sub
</script>
<asp:Content 
    ID="Content1" 
    ContentPlaceHolderID="ContentPlaceHolder1" 
    Runat="Server">
    Content in the first column
    <br />Content in the first column
    <br />Content in the first column
    <br />Content in the first column
    <br />Content in the first column
</asp:Content>

<asp:Content 
    ID="Content2" 
    ContentPlaceHolderID="ContentPlaceHolder2" 
    Runat="Server">
    Content in the second column
    <br />Content in the second column
    <br />Content in the second column
    <br />Content in the second column
    <br />Content in the second column
</asp:Content>


