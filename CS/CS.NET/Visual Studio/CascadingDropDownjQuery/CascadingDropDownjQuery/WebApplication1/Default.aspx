<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        #ddlEmployeeCars 
        {
        	display:none;
        	position:absolute;
        	top:50px;
        	left:9px;
        }
    </style>
    <script language="javascript" type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>       
    <script language="javascript" type="text/javascript">
        $(function() {
            var $ddl = $("select[name$=ddlEmployee]");
            var $ddlCars = $("select[name$=ddlEmployeeCars]");
            $ddl.focus();
            $ddl.bind("change keyup", function() {
                if ($(this).val() != "0") {
                    loadEmployeeCars($("select option:selected").val());                    
                    $ddlCars.fadeIn("slow");
                } else {
                    $ddlCars.fadeOut("slow");
                }
            });
        });

        function loadEmployeeCars(selectedItem) {
            $.ajax({
                type: "POST",
                url: "Default.aspx/FetchEmployeeCars",
                data: "{id: " + selectedItem + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    printEmployeeCars(data.d);
                }
            });
        }        

        function printEmployeeCars(data) {
            $("select[name$=ddlEmployeeCars] > option").remove();
            for (var i = 0; i < data.length; i++) {
                $("select[name$=ddlEmployeeCars]").append(
                    $("<option></option>").val(data[i].Id).html(data[i].Car)
                );
            }
        }       
    </script>
</head>
<body>
    <form id="form1" runat="server">        
        <asp:DropDownList ID="ddlEmployee" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Text="(Please Select)" Value="0" Selected="True" />
        </asp:DropDownList>
        <asp:DropDownList ID="ddlEmployeeCars" runat="server">
        </asp:DropDownList>
    </form>
</body>
</html>
