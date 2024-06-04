<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">

    void employeesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // For each DataRow in the GridView, programmatically access the BulletedList, filter
        // the DataView based on the GridView row's EmployeeID value and bind the filtered DataView
        // to the BulletedList
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            BulletedList bl = (BulletedList)e.Row.FindControl("bltTerritories");
            territoryData.RowFilter = "EmployeeID = " + ((DataRowView) e.Row.DataItem)["EmployeeID"].ToString();
            bl.DataSource = territoryData;
            bl.DataBind();
        }
    }

    
    DataView territoryData;     // this DataView will hold all of the Territories, loaded at Page_Load
    
    void Page_Load(object sender, EventArgs e)
    {
        // Load all of the territories into a DataView from the SqlDataSource
        territoryData = (DataView)territoriesDataSource.Select(DataSourceSelectArguments.Empty);
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="employeesDataSource" Runat="server" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName] FROM [Employees] ORDER BY [LastName], [FirstName]"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="territoriesDataSource" Runat="server" SelectCommand="SELECT dbo.EmployeeTerritories.EmployeeID, dbo.Territories.TerritoryDescription FROM dbo.Territories INNER JOIN dbo.EmployeeTerritories ON dbo.Territories.TerritoryID = dbo.EmployeeTerritories.TerritoryID"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">
        </asp:SqlDataSource>
        <asp:GridView ID="employeesGridView" Runat="server" DataSourceID="employeesDataSource"
            AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" GridLines="Horizontal"
            CellPadding="3" BorderStyle="None" BorderColor="#E7E7FF" OnRowDataBound="employeesGridView_RowDataBound">
            <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
            <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF"></PagerStyle>
            <HeaderStyle ForeColor="#F7F7F7" Font-Bold="True" BackColor="#4A3C8C"></HeaderStyle>
            <AlternatingRowStyle BackColor="#F7F7F7"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField HeaderText="LastName" DataField="LastName" SortExpression="LastName"></asp:BoundField>
                <asp:BoundField HeaderText="FirstName" DataField="FirstName" SortExpression="FirstName"></asp:BoundField>
                <asp:TemplateField HeaderText="Territories"><ItemTemplate>
                    <asp:BulletedList ID="bltTerritories" Runat="server" DataTextField="TerritoryDescription"
                        DataValueField="TerritoryDescription">
                    </asp:BulletedList>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle ForeColor="#F7F7F7" Font-Bold="True" BackColor="#738A9C"></SelectedRowStyle>
            <RowStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></RowStyle>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
