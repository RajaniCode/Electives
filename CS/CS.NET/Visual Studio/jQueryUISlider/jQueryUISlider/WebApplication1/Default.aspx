<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
    <link type="text/css" href="jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="jquery-1.3.2.js"></script>
    <script language="javascript" type="text/javascript" src="jquery-ui-1.7.2.custom.min.js"></script>
    <script language="javascript" type="text/javascript" src="http://jtemplates.tpython.com/jTemplates/jquery-jtemplates.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            var $slide = $("#slider");
            $slide.slider({
                orientation: "horizontal",
                range: "min",
                min: 0,
                max: 20,
                value: 10,
                step: 1,
                slide: function(event, ui) {
                    printRecordsPerPage(ui.value);
                },
                change: function(event, ui) {
                    fetchCustomer(1);
                }
            });
            printRecordsPerPage($slide.slider("option", "value"));
            fetchCustomer(1);
        });

        function fetchCustomer(skip) {              
            var $slide = $("#slider");
            var take =  $slide.slider("option", "value");            
            var skippy = skip == 1 ? 0 : (skip * take) - take;
            $.ajax({
                type: "POST",
                url: "Default.aspx/FetchCustomers",
                data: "{skip:" + skippy + ",take:" + take + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                cache: false,
                success: function(msg) {                    
                    var total = msg.d.TotalRecords;
                    if (total > 0) {
                        printCustomer(msg.d.Customers);
                        $("#paging").text("");
                        $("#paging").die("click");
                        // Get the page count by dividing the total records
                        // by the page size. This has to be rounded up
                        // otherwise you might not get the last page
                        var pageTotal = Math.ceil(total / take);
                        for (var i = 0; i < pageTotal; i++) {                            
                            var newId = "anchor" + i;
                            var pageNo = parseInt(i + 1);
                            $("#paging").append("<a href=\"#pagedData\" id=" + newId + ">" + pageNo + "</a>&nbsp;");
                            $("#paging a[id$=" + newId + "]").live("click", function() {
                                fetchCustomer($(this).text());
                            });
                        }
                    }
                },
                error: function(XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }

        // Display the number of rows per page
        function printRecordsPerPage(count) {
            $("#recordsPerPage").text(count + " records per page");
        } 
        
        // This function accepts a customer object
        // and prints the results to the div element.
        function printCustomer(msg) {            
            $("#result").setTemplateURL("Template.htm");
            $("#result").processTemplate(msg);
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="slider" style="width:200px;"></div>
        <span id="recordsPerPage"></span><br />
        <div id="result"></div>
        <div id="paging"></div>
    </form>
</body>
</html>
