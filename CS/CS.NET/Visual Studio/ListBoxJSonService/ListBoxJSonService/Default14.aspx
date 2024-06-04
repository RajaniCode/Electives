<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default14.aspx.cs" Inherits="Default14" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Populate a ListBox from JSON Results</title>
    <script language="javascript" type="text/javascript" 
    src="http://code.jquery.com/jquery-latest.js"></script>
    
    <script type="text/javascript">
        $(function() {
            var firstParam = 'F';
            var radBtn = $("table.tbl input:radio");
            var lBox = $('select[id$=lb]');
            $(radBtn).click(function() {
                lBox.empty();
                var firstParam = $(':radio:checked').val();
                $.ajax({
                    type: "POST",
                    url: "Services/EmployeeList.asmx/FetchEmpOnGender",
                    data: "{empSex:\"" + firstParam + "\"}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        var gender = msg.d;
                        if (gender.length > 0) {
                            var listItems = [];
                            for (var key in gender) {
                                listItems.push('<option value="' + 
                                key + '">' + gender[key].FName 
                                + '</option>');
                            }
                            $(lBox).append(listItems.join(''));
                        }
                        else {
                            alert("No records found");
                        }
                    },
                   error: function(XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            });
        });
    </script>

      
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Click on a Radio Button to retrieve 'Gender' based data</h2>
        <br /><br />
        <asp:RadioButtonList ID="rbl" runat="server" class="tbl"
        ToolTip="Click on this RadioButton to retrieve data">    
            <asp:ListItem Text="Male" Value="M"></asp:ListItem>    
            <asp:ListItem Text="Female" Value="F"></asp:ListItem>             
        </asp:RadioButtonList><br />
        <asp:ListBox ID="lb" runat="server"></asp:ListBox>
    </div>
    </form>
</body>
</html>

