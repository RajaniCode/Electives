<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:50%;float:left;padding-right:10px;">
        <h2>Select a Customer from the Left...</h2>
        <asp:SqlDataSource ID="customerDataSource" Runat="server" SelectCommand="SELECT [CustomerID], [CompanyName], [ContactName] FROM [Customers] ORDER BY [CompanyName]"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">
        </asp:SqlDataSource>
        <asp:GridView ID="customerGridView" Runat="server" DataSourceID="customerDataSource" DataKeyNames="CustomerID"
            AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" CellPadding="4"
            BorderStyle="None" BorderColor="#CC9966">
            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
            <PagerStyle ForeColor="#330099" HorizontalAlign="Center" BackColor="#FFFFCC"></PagerStyle>
            <HeaderStyle ForeColor="#FFFFCC" Font-Bold="True" BackColor="#990000"></HeaderStyle>
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="View Customer Details"></asp:CommandField>
                <asp:BoundField HeaderText="CompanyName" DataField="CompanyName" SortExpression="CompanyName"></asp:BoundField>
                <asp:BoundField HeaderText="ContactName" DataField="ContactName" SortExpression="ContactName"></asp:BoundField>
            </Columns>
            <SelectedRowStyle ForeColor="#663399" Font-Bold="True" BackColor="#FFCC66"></SelectedRowStyle>
            <RowStyle ForeColor="#330099" BackColor="White"></RowStyle>
        </asp:GridView>
    </div>
    <div>
        <h2>... and See Their Detailed Information on the Right</h2>
        <asp:SqlDataSource ID="customerDetailsDataSource" Runat="server" SelectCommand="SELECT [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [CustomerID] FROM [Customers]"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>" FilterExpression="CustomerID='{0}'">
            <FilterParameters>
                <asp:ControlParameter Name="CustomerID" DefaultValue="-1" Type="String" ControlID="customerGridView"
                    PropertyName="SelectedValue"></asp:ControlParameter>
            </FilterParameters>
        </asp:SqlDataSource>
        <asp:DetailsView ID="customerDetailsView" Runat="server" DataSourceID="customerDetailsDataSource"
            BorderWidth="1px" BackColor="White" CellPadding="4" BorderStyle="None" BorderColor="#CC9966"
            AutoGenerateRows="False">
            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
            <RowStyle ForeColor="#330099" BackColor="White"></RowStyle>
            <PagerStyle ForeColor="#330099" HorizontalAlign="Center" BackColor="#FFFFCC"></PagerStyle>
            <Fields>
                <asp:BoundField HeaderText="CompanyName" DataField="CompanyName" SortExpression="CompanyName"></asp:BoundField>
                <asp:BoundField HeaderText="ContactName" DataField="ContactName" SortExpression="ContactName"></asp:BoundField>
                <asp:BoundField HeaderText="ContactTitle" DataField="ContactTitle" SortExpression="ContactTitle"></asp:BoundField>
                <asp:BoundField HeaderText="Address" DataField="Address" SortExpression="Address"></asp:BoundField>
                <asp:BoundField HeaderText="City" DataField="City" SortExpression="City"></asp:BoundField>
                <asp:BoundField HeaderText="Region" DataField="Region" SortExpression="Region"></asp:BoundField>
                <asp:BoundField HeaderText="PostalCode" DataField="PostalCode" SortExpression="PostalCode"></asp:BoundField>
                <asp:BoundField HeaderText="Country" DataField="Country" SortExpression="Country"></asp:BoundField>
                <asp:BoundField HeaderText="Phone" DataField="Phone" SortExpression="Phone"></asp:BoundField>
                <asp:BoundField HeaderText="Fax" DataField="Fax" SortExpression="Fax"></asp:BoundField>
            </Fields>
            <FieldHeaderStyle ForeColor="#FFFFCC" Font-Bold="True" BackColor="#990000"></FieldHeaderStyle>
            <HeaderStyle ForeColor="#FFFFCC" Font-Bold="True" BackColor="#990000"></HeaderStyle>
            <EditRowStyle ForeColor="#663399" Font-Bold="True" BackColor="#FFCC66"></EditRowStyle>
        </asp:DetailsView>
        </div>    
    </form>
</body>
</html>
