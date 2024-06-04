<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">
    string ComputeSeniorityLevel(TimeSpan ts)
    {
        int numberOfDaysOnTheJob = ts.Days;
        if (numberOfDaysOnTheJob >= 0 && numberOfDaysOnTheJob <= 1000)
            return "Newbie";
        else if (numberOfDaysOnTheJob > 1000 && numberOfDaysOnTheJob <= 4000)
            return "Associate";
        else if (numberOfDaysOnTheJob >= 4000 && numberOfDaysOnTheJob <= 8000)
            return "One of the Regulars";
        else
            return "An Ol' Fogey";
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="employeeDataSource" Runat="server" SelectCommand="SELECT [LastName], [FirstName], [HireDate] FROM [Employees] ORDER BY [LastName], [FirstName]"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" Runat="server" DataSourceID="employeeDataSource" AutoGenerateColumns="False"
            BorderWidth="1px" BackColor="White" GridLines="Vertical" CellPadding="4" BorderStyle="None"
            BorderColor="#DEDFDE" ForeColor="Black">
            <FooterStyle BackColor="#CCCC99"></FooterStyle>
            <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE"></PagerStyle>
            <HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#6B696B"></HeaderStyle>
            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField HeaderText="Last" DataField="LastName" SortExpression="LastName"></asp:BoundField>
                <asp:BoundField HeaderText="First" DataField="FirstName" SortExpression="FirstName"></asp:BoundField>
                <asp:BoundField HeaderText="Hire Date" DataField="HireDate" SortExpression="HireDate"
                    DataFormatString="{0:d}"></asp:BoundField>
                <asp:TemplateField HeaderText="Seniority">
                    <ItemTemplate>
                        <%# ComputeSeniorityLevel(DateTime.Now - (DateTime)Eval("HireDate")) %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle ForeColor="White" Font-Bold="True" BackColor="#CE5D5A"></SelectedRowStyle>
            <RowStyle BackColor="#F7F7DE"></RowStyle>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
