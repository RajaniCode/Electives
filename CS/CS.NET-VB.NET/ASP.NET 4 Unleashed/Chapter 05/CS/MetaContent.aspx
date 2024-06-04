<%@ Page Language="C#" MasterPageFile="~/SimpleMaster.master" %>

<script runat="server">

    void Page_Load()
    {
        // Create Meta Description
        Page.MetaDescription = "A sample of using the ASP.NET 4.0 Meta Properties";
        
        // Create Meta Keywords
        Page.MetaKeywords = "MetaDescription,MetaKeywords,ASP.NET";
    }

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
