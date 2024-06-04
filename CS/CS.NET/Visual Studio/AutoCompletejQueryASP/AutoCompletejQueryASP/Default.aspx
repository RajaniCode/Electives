<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AutoComplete Box with jQuery</title>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>  
	<script type="text/javascript">
	    $(function() {
	        $(".tb").autocomplete({
	            source: function(request, response) {
	                $.ajax({
	                    url: "EmployeeList.asmx/FetchEmailList",
	                    data: "{ 'mail': '" + request.term + "' }",
	                    dataType: "json",
	                    type: "POST",
	                    contentType: "application/json; charset=utf-8",
	                    dataFilter: function(data) { return data; },
	                    success: function(data) {
	                        response($.map(data.d, function(item) {
	                            return {
	                                value: item.Email
	                            }
	                        }))
	                    },
	                    error: function(XMLHttpRequest, textStatus, errorThrown) {
	                        alert(textStatus);
	                    }
	                });
	            },
	            minLength: 2
	        });
	    });
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="demo">
        <div class="ui-widget">
            <label for="tbAuto">Enter Email: </label>
             <asp:TextBox ID="tbAuto" class="tb" runat="server">
             </asp:TextBox>
        </div>
    </div>
    </form>
</body>
</html>
