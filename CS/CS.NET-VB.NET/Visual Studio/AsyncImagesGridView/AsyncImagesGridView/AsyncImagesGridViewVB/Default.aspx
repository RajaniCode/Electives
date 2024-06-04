<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asynchronous Image</title>
    <script type="text/javascript" language="javascript">
        function RetrievePicture(imgCtrl, picid)
        {
            imgCtrl.onload = null;
            imgCtrl.src = 'ShowImage.ashx?id=' + picid;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="SqlDataSource1" AllowPaging="True">
    <Columns>
        <asp:BoundField DataField="pic_id" HeaderText="Picture ID" InsertVisible="False" 
            ReadOnly="True" SortExpression="pic_id" />
        <asp:BoundField DataField="picture_tag" HeaderText="Tags" 
            SortExpression="picture_tag" />
            <asp:TemplateField>
                <HeaderTemplate>Picture</HeaderTemplate>
                <ItemTemplate>
                    <img alt="pic" src="images/cursor.jpg" onError="this.src='images/error.jpg'" onload="RetrievePicture(this,'<%# Eval("pic_id")%>');"/>
                </ItemTemplate>
            </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:PictureAlbumConnectionString %>" 
    SelectCommand="SELECT [pic_id], [picture_tag] FROM [Album]">
</asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>

