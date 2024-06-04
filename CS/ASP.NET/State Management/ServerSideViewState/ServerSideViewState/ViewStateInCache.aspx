<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewStateInCache.aspx.cs" Inherits="ViewStateInCache" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewState In Cache</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Make New Record" 
            onclick="Button1_Click" />
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Time">
                    <ItemTemplate>
                        <asp:Literal ID="Field1" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ticks">
                    <ItemTemplate>
                        <asp:Literal ID="Field2" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Random String">
                    <ItemTemplate>
                        <asp:Literal ID="Field3" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:HyperLink ID="hlnkDefault" runat="server" NavigateUrl="~/Default.aspx" Text="Back to Default"></asp:HyperLink>
    </form>
</body>
</html>
