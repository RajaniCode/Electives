<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008LINQDuplicateRows._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
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
    
        <asp:GridView ID="GridView1" runat="server" >
         

        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Unique" onclick="Button1_Click" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="Non Unique" />
    
    </div>
    </form>
</body>
</html>
