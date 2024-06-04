<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Script/jquery-1.2.6.js" type="text/javascript"></script>
       
    <script type="text/javascript">

        $(document).ready(function() {
            $("tr").click(function(event) {
                var row = jQuery(this)
                var firstParam = row.children("td:eq(0)").text();
                var secondParam = row.children("td:eq(1)").text();                
                var navUrl = "http://localhost:7250/GridViewRowJQuery/CustomerDetails.aspx?cid=" + firstParam + "&cname=" + secondParam;
                top.location = navUrl;

            });
        });
    </script>
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                SelectCommand="SELECT [CustomerID], [CompanyName], [ContactName], [Address], [City] FROM [Customers]">
            </asp:SqlDataSource>    
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID"
            DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
            <Columns>                           
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            </Columns>
        </asp:GridView>

    </form>
</body>
</html>
