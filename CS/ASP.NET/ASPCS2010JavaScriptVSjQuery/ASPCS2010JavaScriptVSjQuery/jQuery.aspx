<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jQuery.aspx.cs" Inherits="ASPCS2010JavaScriptVSjQuery.jQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>jQuery</title>

    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script>
    <link type="text/css" href="jquery-ui-1.8.21.custom/css/ui-lightness/jquery-ui-1.8.21.custom.css" rel="Stylesheet" />
    <script type="text/javascript" src="jquery-ui-1.8.21.custom/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="jquery-ui-1.8.21.custom/js/jquery-ui-1.8.21.custom.min.js"></script>

    <script type="text/javascript">
        /*
        Note: $(document).ready = $ = jQuery
        */
        $(document).ready
        (
            function () 
            {
                $("#Button1").click
                (
                    function () 
                    {
                        $("#Label1").text($("#TextBox1").val());
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#Button2").click
                (
                    function () 
                    {
                        $("#TextBox1").val($("#Label1").text());
                        return false; // to prevent the submit from going through                   
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#DropDownList1").change
                (
                    function () 
                    {
                        alert("Number of items in DropDownList: " + $("#DropDownList1 option").length + "\n"
                            + "DropDownList selected value: " + $("#DropDownList1 option:selected").val() + "\n" //Note
                            + "DropDownList selected text: " + $("#DropDownList1 option:selected").text()); //Note
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#ListBox1").change
                (
                    function () 
                    {
                        for (var i = 0; i < $("#ListBox1 :selected").length; i++) 
                        {
                            alert("ListBox Number of Items: " + $("#ListBox1 option").length + "\n"
                            + "ListBox Number of Selected Items: " + $("#ListBox1 :selected").length + "\n"
                            + "ListBox Value: " + $("#ListBox1 :selected")[i].value + "\n"
                            + "ListBox Text: " + $("#ListBox1 :selected")[i].text);
                        }
                    }
                );
            }
       );
       
        $(document).ready
        (
            function () 
            {
                $("#CheckBoxList1").change
                (
                    function () 
                    {
                        for (var i = 0; i < $("#CheckBoxList1 :input").length; i++) 
                        {
                            if ($("#CheckBoxList1 :input")[i].checked) 
                            {
                                alert("CheckBoxList Number of Items: " + $("#CheckBoxList1 :input").length + "\n"
                                    + "CheckBoxList Number of Checked Items: " + $("#CheckBoxList1 input:checked").length + "\n"
                                    + "CheckBoxList Value: " + $("#CheckBoxList1 :input")[i].value + "\n"
                                    + "CheckBoxList Text: " + $("#CheckBoxList1 label")[i].innerHTML);
                            }
                        }
                    }
                );
            }
       );

        $(document).ready
        (
            function () 
            {
                $("#RadioButtonList1").change
                (
                    function () 
                    {
                        for (var i = 0; i < $("#RadioButtonList1 :input").length; i++) 
                        {
                            if ($("#RadioButtonList1 :input")[i].checked) 
                            {
                                alert("RadioButtonList Number of Items: " + $("#RadioButtonList1 :input").length + "\n"
                                    + "RadioButtonList Number of Checked Items: " + $("#RadioButtonList1 input:checked").length + "\n"
                                    + "RadioButtonList Value: " + $("#RadioButtonList1 :input")[i].value + "\n"
                                    + "RadioButtonList Text: " + $("#RadioButtonList1 label")[i].innerHTML);
                            }
                        }
                    }
                );
            }
       );

        $(document).ready
        (
            function () 
            {
                var cancel = function () 
                {
                    $("#CustomDialogInput").dialog("close");
                }

                var ResponseButton3 = function () 
                {
                    var ReturnValue = $("input")[$("input").length - 1].value;
                    $("input")[$("input").length - 1].value = "";

                    if ($.trim(ReturnValue) != "") 
                    {
                        var DropDownListNextValue = 0;
                        if ($("#DropDownList1 option").length > 0) 
                        {
                            DropDownListNextValue = parseInt($("#DropDownList1 option")[$("#DropDownList1 option").length - 1].value) + 1;
                        }

                        $("#DropDownList1").append("<option value=\"" + DropDownListNextValue + "\" >" + ReturnValue + "</option>");
                    }
                    else 
                    {
                        $("#CustomMessage").text("Enter item in the textbox or cancel.");

                        $("#CustomDialogMessage").dialog
                        (
                            {
                                bgiframe: true,
                                modal: true,
                                buttons: 
                                {
                                    Ok: function () 
                                    {
                                        $(this).dialog('close');
                                    }
                                }
                            }
                        );
                        return false; // to prevent the submit from going through
                    }
                    $("#CustomDialogInput").dialog("close");
                }

                var DialogOptionsButton3 =
                {
                    modal: true,
                    buttons:
                    {
                        "OK": ResponseButton3,
                        "Cancel": cancel
                    },
                    autoOpen: false
                };

                $("#Button3").click
                (

                    function () 
                    {
                        $("#CustomDialogInput").dialog(DialogOptionsButton3);
                        $("#CustomDialogInput").dialog("open");
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#Button4").click
                (
                    function () 
                    {
                        if ($("#DropDownList1 option").length > 0) 
                        {
                            //var DropDownListOptionLastValue = $("#DropDownList1 option")[$("#DropDownList1 option").length - 1].value;
                            //var DropDownListOptionLastText = $("#DropDownList1 option")[$("#DropDownList1 option").length - 1].text;
                            //$("#DropDownList1 option[value = " + DropDownListOptionLastValue + "]").remove();
                            $("#DropDownList1 option:last").remove();
                        }
                        else 
                        {
                            alert("There are no options.");
                        }
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                var cancel = function () 
                {
                    $("#CustomDialogInput").dialog("close");
                }

                var ResponseButton5 = function () 
                {
                    var ReturnValue = $("input")[$("input").length - 1].value;
                    $("input")[$("input").length - 1].value = "";

                    if ($.trim(ReturnValue) != "") 
                    {
                        var ListBoxNextValue = 0;
                        if ($("#ListBox1 option").length > 0) 
                        {
                            ListBoxNextValue = parseInt($("#ListBox1 option")[$("#ListBox1 option").length - 1].value) + 1;
                        }

                    $("#ListBox1").append("<option value=\"" + ListBoxNextValue + "\" >" + ReturnValue + "</option>");
                }
                else 
                {
                    $("#CustomMessage").text("Enter item in the textbox or cancel.");

                    $("#CustomDialogMessage").dialog
                    (
                        {
                            bgiframe: true,
                            modal: true,
                            buttons: 
                            {
                                Ok: function () 
                                {
                                    $(this).dialog('close');
                                }
                            }
                        }
                    );
                    return false; // to prevent the submit from going through
                }
                $("#CustomDialogInput").dialog("close");
            }

            var DialogOptionsButton5 =
            {
                modal: true,
                buttons:
                {
                    "OK": ResponseButton5,
                    "Cancel": cancel
                },
                autoOpen: false
            };

            $("#Button5").click
                (
                    function () 
                    {
                        $("#CustomDialogInput").dialog(DialogOptionsButton5);
                        $("#CustomDialogInput").dialog("open");
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#Button6").click
                (
                    function () 
                    {
                        if ($("#ListBox1 option").length > 0) 
                        {
                            //var ListBoxOptionLastValue = $("#ListBox1 option")[$("#ListBox1 option").length - 1].value;
                            //$("#ListBox1 option[value = " + ListBoxOptionLastValue + "]").remove();
                            $("#ListBox1 option:last").remove();
                        }
                        else 
                        {
                            alert("There are no options.");
                        }
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                var cancel = function () 
                {
                    $("#CustomDialogInput").dialog("close");
                }

                var ResponseButton7 = function () 
                {
                    var ReturnValue = $("input")[$("input").length - 1].value;
                    $("input")[$("input").length - 1].value = "";

                    if ($.trim(ReturnValue) != "") 
                    {
                        var CheckBoxListNextValue = 0;
                        if ($("#CheckBoxList1 :input").length > 0) 
                        {
                            CheckBoxListNextValue = parseInt($("#CheckBoxList1 :input")[$("#CheckBoxList1 :input").length - 1].value) + 1;
                        }

                        $("#CheckBoxList1").append("<input type=\"checkbox\" value=\"" + CheckBoxListNextValue + "\" ></input><label>" + ReturnValue + "</label></br>");
                    }
                    else 
                    {
                        $("#CustomMessage").text("Enter item in the textbox or cancel.");

                        $("#CustomDialogMessage").dialog
                        (
                            {
                                bgiframe: true,
                                modal: true,
                                buttons: 
                                {
                                    Ok: function () 
                                    {
                                        $(this).dialog('close');
                                    }
                                }
                            }
                        );
                    return false; // to prevent the submit from going through
                }
                $("#CustomDialogInput").dialog("close");
            }

            var DialogOptionsButton7 =
            {
                modal: true,
                buttons:
                {
                    "OK": ResponseButton7,
                    "Cancel": cancel
                },
                autoOpen: false
            };

            $("#Button7").click
                (
                    function () 
                    {
                        $("#CustomDialogInput").dialog(DialogOptionsButton7);
                        $("#CustomDialogInput").dialog("open");
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#Button8").click
                (
                    function () 
                    {
                        if ($("#CheckBoxList1 :input").length > 0) 
                        {
                            //var CheckBoxListInputLastValue = $("#CheckBoxList1 :input")[$("#CheckBoxList1 :input").length - 1].value;
                            //var CheckBoxListInputLastInnerHTML = $("#CheckBoxList1 label")[$("#CheckBoxList1 label").length - 1].innerHTML;
                            //$("#CheckBoxList1 label:contains(" + CheckBoxListInputLastInnerHTML + ")").remove();
                            //$("#CheckBoxList1 :input[value = " + CheckBoxListInputLastValue + "]").remove();
                            ////$("#CheckBoxList1 :input[value = " + CheckBoxListInputLastValue + "]").next("label").remove(); //Note
                            
                            $("#CheckBoxList1 label:last").remove();
                            $("#CheckBoxList1 :input:last").remove();                            
                        }
                        else 
                        {
                            alert("There are no CheckBoxes.");
                        }
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () {
                $("#CheckBox1").click
                (
                    function () {
                        if ($(this).is(':checked')) {
                            $(this).next("label").text("Checked");
                            $(this).next("label").css({ backgroundColor: "#00FF00" });
                            $(this).css({ backgroundColor: "#FF1111" });
                            alert($(this).next('label').text());
                        }
                        else {
                            $(this).next('label').text("Unchecked");
                            $(this).next('label').css({ backgroundColor: "#FF0000" });
                            $(this).css({ backgroundColor: "#11FF11" });
                            alert($(this).next('label').text());
                        }
                    }
                );
            }
        );

        $(document).ready
        (
            function () {
                var cancel = function () 
                {
                    $("#CustomDialogInput").dialog("close");
                }

                var ResponseButton9 = function () 
                {
                    var ReturnValue = $("input")[$("input").length - 1].value;
                    $("input")[$("input").length - 1].value = "";

                    if ($.trim(ReturnValue) != "") 
                    {
                        var RadioButtonListNextValue = 0;
                        if ($("#RadioButtonList1 :input").length > 0) 
                        {
                            RadioButtonListNextValue = parseInt($("#RadioButtonList1 :input")[$("#RadioButtonList1 :input").length - 1].value) + 1;
                        }

                        $("#RadioButtonList1").append("<input type=\"radio\" value=\"" + RadioButtonListNextValue + "\" ></input><label>" + ReturnValue + "</label></br>");
                    }
                    else 
                    {
                        $("#CustomMessage").text("Enter item in the textbox or cancel.");

                        $("#CustomDialogMessage").dialog
                        (
                            {
                                bgiframe: true,
                                modal: true,
                                buttons:
                                {
                                    Ok: function () {
                                        $(this).dialog('close');
                                    }
                                }
                            }
                        );
                        return false; // to prevent the submit from going through
                    }
                    $("#CustomDialogInput").dialog("close");
                }

                var DialogOptionsButton9 =
                {
                    modal: true,
                    buttons:
                    {
                        "OK": ResponseButton9,
                        "Cancel": cancel
                    },
                    autoOpen: false
                };

                $("#Button9").click
                (
                    function () {
                        $("#CustomDialogInput").dialog(DialogOptionsButton9);
                        $("#CustomDialogInput").dialog("open");
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#Button10").click
                (
                    function () 
                    {
                        if ($("#RadioButtonList1 :input").length > 0) 
                        {
                            //var RadioButtonListInputLastValue = $("#RadioButtonList1 :input")[$("#RadioButtonList1 :input").length - 1].value;
                            //var RadioButtonListInputLastInnerHTML = $("#RadioButtonList1 label")[$("#RadioButtonList1 label").length - 1].innerHTML;
                            //$("#RadioButtonList1 label:contains(" + RadioButtonListInputLastInnerHTML + ")").remove();
                            //$("#RadioButtonList1 :input[value = " + RadioButtonListInputLastValue + "]").remove();
                            //$("#RadioButtonList1 :input[value = " + RadioButtonListInputLastValue + "]").next("label").remove();

                            $("#RadioButtonList1 label:last").remove();
                            $("#RadioButtonList1 :input:last").remove();
                        }
                        else 
                        {
                            alert("There are no RadioButtons.");
                        }
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#RadioButton1").change
                (
                    function () 
                    {
                        if ($(this).is(':checked')) 
                        {
                            $(this).next("label").css({ backgroundColor: "#00FF00" });
                            $(this).css({ backgroundColor: "#11FF11" });

                            var RadioButton = $("#RadioButton2");
                            $(RadioButton).next('label').css({ backgroundColor: "#FF0000" });
                            $(RadioButton).css({ backgroundColor: "#FF1111" });
                        }
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#RadioButton2").change
                (
                    function () 
                    {
                        if ($(this).is(':checked')) 
                        {
                            $(this).next("label").css({ backgroundColor: "#00FF00" });
                            $(this).css({ backgroundColor: "#11FF11" });

                            var RadioButton = $("#RadioButton1");
                            $(RadioButton).next('label').css({ backgroundColor: "#FF0000" });
                            $(RadioButton).css({ backgroundColor: "#FF1111" });
                        }
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#Button11").click
                (
                    function () 
                    {
                        var rowCount = $('#Table1 tr').length;
                        if (rowCount > 4) 
                        {
                            alert("Add up to 4 rows only.");
                        }
                        else 
                        {
                            $("#Table1 tr:last").after("<tr><td height=\"25px\" width=\"35%\"></td><td height=\"25px\" width=\"35%\"></td></tr>");
                        }
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#Button12").click
                (
                    function () 
                    {
                        var rowCount = $('#Table1 tr').length;
                        if (rowCount > 1) 
                        {
                            $("#Table1 tr:last").remove();
                        }
                        else 
                        {
                            alert("There are no rows.");
                        }
                        return false; // to prevent the submit from going through
                    }
                );
            }
        );
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Pass TextBox to Label" />
        <asp:Button ID="Button2" runat="server" Text="Pass Label to TextBox" />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" Width="10%">
            <asp:ListItem Selected="True" Value="1">Red</asp:ListItem>
            <asp:ListItem Value="2">Green</asp:ListItem>
            <asp:ListItem Value="3">Blue</asp:ListItem>
            <asp:ListItem Value="4">Black</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button3" runat="server" Text="Append item to DropDownList" />
        <asp:Button ID="Button4" runat="server" Text="Remove item from DropDownList" />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Width="10%" SelectionMode="Multiple">
            <asp:ListItem Selected="True" Value="1">Red</asp:ListItem>
            <asp:ListItem Selected="False" Value="2">Green</asp:ListItem>
            <asp:ListItem Value="3">Blue</asp:ListItem>
            <asp:ListItem Value="4">Black</asp:ListItem>
        </asp:ListBox>
        <asp:Button ID="Button5" runat="server" Text="Append item to ListBox" />
        <asp:Button ID="Button6" runat="server" Text="Remove item from ListBox" />
        <br />
        <br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="10%">
            <asp:ListItem Selected="True" Value="1">Red</asp:ListItem>
            <asp:ListItem Selected="False" Value="2">Green</asp:ListItem>
            <asp:ListItem Value="3">Blue</asp:ListItem>
            <asp:ListItem Value="4">Black</asp:ListItem>
        </asp:CheckBoxList>
        <asp:Button ID="Button7" runat="server" Text="Add item to CheckBoxList"/>
        <asp:Button ID="Button8" runat="server" Text="Remove item from CheckBoxList" />
        <br />
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Unchecked" />
        <br />
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Selected="True" Value="1">Red</asp:ListItem>
            <asp:ListItem Value="2">Green</asp:ListItem>
            <asp:ListItem Value="3">Blue</asp:ListItem>
            <asp:ListItem Value="4">Black</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="Button9" runat="server" Text="Add item to RadioButtonList "/>
        <asp:Button ID="Button10" runat="server" Text="Remove item from RadioButtonList" />
        <br />
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Apple" GroupName="RadioButtonGroup1" />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="Mango" GroupName="RadioButtonGroup1" />
        <br />
        <br />
        <div>            
            <table border="1" id="Table1">
                <tr>
                    <th height="25px" width="35%">
                        Header 1
                    </th>
                    <th height="25px" width="35%">
                        Header 2
                    </th>
                </tr>
                <tr>
                    <td height="25px" width="35%">
                    </td>
                    <td height="25px" width="35%">
                    </td>
                </tr>
                <tr>
                    <td height="25px" width="35%">
                    </td>
                    <td height="25px" width="35%">
                    </td>
                </tr>
            </table>
            <asp:Button ID="Button11" runat="server" Text="Append Row" />
            <asp:Button ID="Button12" runat="server" Text="Delete Row" />
        </div>
    </div>
    <div id="CustomDialogInput" class="flora" title="Add item" style="display: none;">
        <p>Please enter your input:</p>
        <label>Text:</label>
        <input id="textbox2" type="text" />
    </div>
    <div id="CustomDialogMessage" class="ui-dialog" title="Message" style="display: none;">
        <p id="CustomMessage"></p>
    </div>
    </form>
</body>
</html>
