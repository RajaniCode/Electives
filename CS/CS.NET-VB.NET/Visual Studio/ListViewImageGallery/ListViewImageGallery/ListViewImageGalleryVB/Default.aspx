<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Image
        <asp:Label ID="lblTags" runat="server" Text="Tags"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTags" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblImage" runat="server" Text="Upload Picture"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:FileUpload ID="imgUpload" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click"
            Text="Submit" />   
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<asp:Label ID="lblResult" runat="server" ForeColor="#0066FF"></asp:Label>
    <br />
    <hr />
    </div>
    <asp:ListView ID="ListView1" GroupItemCount="4" runat="server" DataKeyNames="pic_id"
    DataSourceID="SqlDataSource1">
        <LayoutTemplate>
            <asp:Placeholder
            id="groupPlaceholder"
            runat="server" />
        </LayoutTemplate>
        <GroupTemplate>
            <div>
            <asp:Placeholder
            id="itemPlaceholder"
            runat="server" />
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <asp:Image
            id="picAlbum" runat="server" AlternateText='<% #Eval("picture_tag") %>'
            ImageUrl='<%# "ShowImage.ashx?id=" & Eval("pic_id") %>' />
        </ItemTemplate>
        <EmptyItemTemplate>            
            
        </EmptyItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:albumConnString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT [pic_id],picture_tag, [pic] FROM [Album]"></asp:SqlDataSource>
    </form>
</body>
</html>
