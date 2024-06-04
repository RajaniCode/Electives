<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <style type="text/css">


</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True"
            >
            <Columns>                           
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:RadioButtonList AutoPostBack="true" ID="rbl" runat="server"
                    Enabled="true" SelectedIndex='<%#Convert.ToInt32(DataBinder.Eval(Container.DataItem , "Discontinued"))%>' 
                    OnSelectedIndexChanged="rbl_SelectedIndexChanged">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>                        
                </asp:RadioButtonList>
            </ItemTemplate>
        </asp:TemplateField>                
    </Columns>
</asp:GridView>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [Discontinued] FROM [Products]"
            UpdateCommand="UPDATE [Products] SET [Discontinued] = @Discontinued WHERE [ProductID] = @ProductID">
            <UpdateParameters>
                <asp:Parameter Name="Discontinued" Type="Boolean" />
                <asp:Parameter Name="ProductID" Type="Int32" />
            </UpdateParameters>

        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
