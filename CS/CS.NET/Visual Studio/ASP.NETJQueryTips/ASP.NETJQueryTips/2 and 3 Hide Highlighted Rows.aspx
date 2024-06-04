<%@ Page Language="C#" AutoEventWireup="true" CodeFile="2 and 3 Hide Highlighted Rows.aspx.cs" Inherits="_2_Hide_Highlighted_Rows" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Hide Highlighted Rows></title>

    <script src="Scripts/jquery-1.3.min.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(document).ready(function() {
            $("tr").filter(function() {
                return $('td', this).length && !$('table', this).length
            }).click(function() {
                $(this).toggleClass('currRow');
            });


            $("#Button1").click(function() {                
                var hideRows = $("tr").hasClass("currRow");
                if (hideRows == true) {                    
                    $("tr.currRow").remove();
                }
            });
        });
        
    </script>
    
 <%--   <script type="text/javascript">
            $(document).ready(function() {
                $("tr").filter(function() {
                    return $('td', this).length && !$('table', this).length
                }).click(function() {
                    $(this).remove();
                });
            });        
    </script>--%>

    
    <style type="text/css">
        .currRow
        {
            background-color:Gray;
            cursor:pointer;
        }    
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <input id="Button1" type="button" value="Remove Rows" />

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                SelectCommand="SELECT [CustomerID], [CompanyName], [ContactName], [Address], [City] FROM [Customers]">
            </asp:SqlDataSource>    
            <br />           
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID"
                DataSourceID="SqlDataSource1" AllowPaging="False" AllowSorting="True" >
                <Columns>                           
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                    <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                </Columns>
            </asp:GridView><br />
            
        </div>
    </form>
</body>
</html>

