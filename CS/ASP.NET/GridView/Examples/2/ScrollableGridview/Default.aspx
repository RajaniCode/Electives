<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script src="Scripts/ScrollableGridPlugin.js" type="text/javascript"></script>

    <title>Scrollable Gridview with Fixed Header</title>

    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            $('#<%=gvdetails.ClientID %>').Scrollable();
        }
)
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView runat="server" ID="gvdetails" DataSourceID="dsdetails" AutoGenerateColumns="false">
        <RowStyle BackColor="#EFF3FB" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="UserId" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" />
            <asp:BoundField DataField="Location" HeaderText="Location" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="dsdetails" runat="server" ConnectionString="<%$ConnectionStrings:dbconnection %>"
        SelectCommand="select * from UserInformation" />
    </form>
</body>
</html>
