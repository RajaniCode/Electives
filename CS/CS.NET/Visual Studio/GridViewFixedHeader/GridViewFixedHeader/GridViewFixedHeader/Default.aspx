<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fixed Header</title>
    <script src="Scripts/jquery-1.2.6.js" type="text/javascript"></script>
    <script src="Scripts/webtoolkit.jscrollable.js" type="text/javascript"></script>
    <script src="Scripts/webtoolkit.scrollabletable.js" type="text/javascript"></script>    
    
    <script type="text/javascript">
        $(document).ready(function() {
            jQuery('table').Scrollable(400, 800);
        });
    </script>
    
    <style type="text/css">
			table {				
				font: normal 11px "Trebuchet MS", Verdana, Arial;								
			    background:#fff;            				
			    border:solid 1px #C2EAD6;
			}			
			
			td{			    
	            padding: 3px 3px 3px 6px;
	            color: #5D829B;
			}
			th {
				font-weight:bold;
				font-size:smaller;
	            color: #5D728A;	                        	            
	            padding: 0px 3px 3px 6px;
	            background: #CAE8EA 				
			}
		</style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
          <asp:GridView ID="ScrollT" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="SqlDataSource1" AllowPaging="False" AllowSorting="True" OnPreRender="GridView1_PreRender">
            <Columns>                           
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
            </Columns>
        </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [Discontinued] FROM [Products]">
            </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
