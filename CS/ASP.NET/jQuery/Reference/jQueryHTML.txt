<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jQueryHTML.aspx.cs" Inherits="ASPCS2010JavaScriptVSjQuery.jQueryHTML" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>jQuery HTML</title>
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
                $("#button1").click
                (
                    function () 
                    {
                        $("#label1").text($("#text1").val());
                        //return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#button2").click
                (
                    function () 
                    {
                        $("#text1").val($("#label1").text());
                        //return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#select1").change
                (
                    function () 
                    {
                        alert("Number of items in select: " + $("#select1 option").length + "\n"
                            + "select selected value: " + $("#select1 option:selected").val() + "\n" //Note
                            + "select selected text: " + $("#select1 option:selected").text()); //Note
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#selectmultiple1").change
                (
                    function () 
                    {
                        for (var i = 0; i < $("#selectmultiple1 :selected").length; i++) 
                        {
                            alert("ListBox Number of Items: " + $("#selectmultiple1 option").length + "\n"
                            + "ListBox Number of Selected Items: " + $("#selectmultiple1 :selected").length + "\n"
                            + "ListBox Value: " + $("#selectmultiple1 :selected")[i].value + "\n"
                            + "ListBox Text: " + $("#selectmultiple1 :selected")[i].text);
                        }
                    }
                );
            }
       );

        $(document).ready
        (
            function () 
            {
                $("#checkboxlist1").change
                (
                    function () 
                    {
                        for (var i = 0; i < $("#checkboxlist1 :input").length; i++) 
                        {
                            if ($("#checkboxlist1 :input")[i].checked) 
                            {
                                alert("checkboxlist Number of Items: " + $("#checkboxlist1 :input").length + "\n"
                                    + "checkboxlist Number of Checked Items: " + $("#checkboxlist1 input:checked").length + "\n"
                                    + "checkboxlist Value: " + $("#checkboxlist1 :input")[i].value + "\n"
                                    + "checkboxlist Text: " + $("#checkboxlist1 label")[i].innerHTML);
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

                var Responsebutton3 = function () 
                {
                    var ReturnValue = $("input")[$("input").length - 1].value;
                    $("input")[$("input").length - 1].value = "";

                    if ($.trim(ReturnValue) != "") 
                    {
                        var selectNextValue = 0;
                        if ($("#select1 option").length > 0)
                        {
                            selectNextValue = parseInt($("#select1 option")[$("#select1 option").length - 1].value) + 1;
                        }

                        $("#select1").append("<option value=\"" + selectNextValue + "\" >" + ReturnValue + "</option>");
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
                        //return false; // to prevent the submit from going through
                    }
                    $("#CustomDialogInput").dialog("close");
                }

                var DialogOptionsbutton3 =
                {
                    modal: true,
                    buttons:
                    {
                        "OK": Responsebutton3,
                        "Cancel": cancel
                    },
                    autoOpen: false
                };

                $("#button3").click
                (

                    function () 
                    {
                        $("#CustomDialogInput").dialog(DialogOptionsbutton3);
                        $("#CustomDialogInput").dialog("open");
                        //return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#button4").click
                (
                    function () 
                    {
                        if ($("#select1 option").length > 0) 
                        {
                            //var selectOptionLastValue = $("#select1 option")[$("#select1 option").length - 1].value;
                            //var selectOptionLastText = $("#select1 option")[$("#select1 option").length - 1].text;
                            //$("#select1 option[value = " + selectOptionLastValue + "]").remove();
                            $("#select1 option:last").remove();
                        }
                        else 
                        {
                            alert("There are no options.");
                        }
                        //return false; // to prevent the submit from going through
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

                var Responsebutton5 = function () 
                {
                    var ReturnValue = $("input")[$("input").length - 1].value;
                    $("input")[$("input").length - 1].value = "";

                    if ($.trim(ReturnValue) != "") 
                    {
                        var ListBoxNextValue = 0;
                        if ($("#selectmultiple1 option").length > 0) 
                        {
                            ListBoxNextValue = parseInt($("#selectmultiple1 option")[$("#selectmultiple1 option").length - 1].value) + 1;
                        }

                        $("#selectmultiple1").append("<option value=\"" + ListBoxNextValue + "\" >" + ReturnValue + "</option>");
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
                        //return false; // to prevent the submit from going through
                    }
                    $("#CustomDialogInput").dialog("close");
                }

                var DialogOptionsbutton5 =
                {
                    modal: true,
                    buttons:
                    {
                        "OK": Responsebutton5,
                        "Cancel": cancel
                    },
                    autoOpen: false
                };

                $("#button5").click
                (
                    function () 
                    {
                        $("#CustomDialogInput").dialog(DialogOptionsbutton5);
                        $("#CustomDialogInput").dialog("open");
                        //return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#button6").click
                (
                    function () 
                    {
                        if ($("#selectmultiple1 option").length > 0) 
                        {
                            //var ListBoxOptionLastValue = $("#selectmultiple1 option")[$("#selectmultiple1 option").length - 1].value;
                            //$("#selectmultiple1 option[value = " + ListBoxOptionLastValue + "]").remove();
                            $("#selectmultiple1 option:last").remove();
                        }
                        else 
                        {
                            alert("There are no options.");
                        }
                        //return false; // to prevent the submit from going through
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

                var Responsebutton7 = function () 
                {
                    var ReturnValue = $("input")[$("input").length - 1].value;
                    $("input")[$("input").length - 1].value = "";

                    if ($.trim(ReturnValue) != "") 
                    {
                        var checkboxlistNextValue = 0;
                        if ($("#checkboxlist1 :input").length > 0) 
                        {
                            checkboxlistNextValue = parseInt($("#checkboxlist1 :input")[$("#checkboxlist1 :input").length - 1].value) + 1;
                        }

                        $("#checkboxlist1").append("<input type=\"checkbox\" value=\"" + checkboxlistNextValue + "\" ></input><label>" + ReturnValue + "</label></br>");
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
                        //return false; // to prevent the submit from going through
                    }
                    $("#CustomDialogInput").dialog("close");
                }

                var DialogOptionsbutton7 =
                {
                    modal: true,
                    buttons:
                    {
                        "OK": Responsebutton7,
                        "Cancel": cancel
                    },
                    autoOpen: false
                };

                $("#button7").click
                (
                    function () 
                    {
                        $("#CustomDialogInput").dialog(DialogOptionsbutton7);
                        $("#CustomDialogInput").dialog("open");
                        //return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#button8").click
                (
                    function () 
                    {
                        if ($("#checkboxlist1 :input").length > 0) 
                        {
                            //var checkboxlistInputLastValue = $("#checkboxlist1 :input")[$("#checkboxlist1 :input").length - 1].value;
                            //var checkboxlistInputLastInnerHTML = $("#checkboxlist1 label")[$("#checkboxlist1 label").length - 1].innerHTML;
                            //$("#checkboxlist1 label:contains(" + checkboxlistInputLastInnerHTML + ")").remove();
                            //$("#checkboxlist1 :input[value = " + checkboxlistInputLastValue + "]").remove();
                            ////$("#checkboxlist1 :input[value = " + checkboxlistInputLastValue + "]").next("label").remove(); //Note

                            $("#checkboxlist1 label:last").remove();
                            $("#checkboxlist1 :input:last").remove();
                        }
                        else 
                        {
                            alert("There are no CheckBoxes.");
                        }
                        //return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#checkbox1").click
                (
                    function () 
                    {
                        if ($(this).is(':checked')) 
                        {
                            $(this).next("label").text("Checked");
                            $(this).next("label").css({ backgroundColor: "#00FF00" });
                            $(this).css({ backgroundColor: "#FF1111" });
                            alert($(this).next('label').text());
                        }
                        else 
                        {
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
            function () 
            {
                var cancel = function () 
                {
                    $("#CustomDialogInput").dialog("close");
                }

                var Responsebutton9 = function () 
                {
                    var ReturnValue = $("input")[$("input").length - 1].value;
                    $("input")[$("input").length - 1].value = "";

                    if ($.trim(ReturnValue) != "") 
                    {
                        var radiobuttonlistNextValue = 0;
                        if ($("#radiobuttonlist1 :input").length > 0) 
                        {
                            radiobuttonlistNextValue = parseInt($("#radiobuttonlist1 :input")[$("#radiobuttonlist1 :input").length - 1].value) + 1;
                        }

                        $("#radiobuttonlist1").append("<input type=\"radio\" value=\"" + radiobuttonlistNextValue + "\" ></input><label>" + ReturnValue + "</label></br>");
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

                var DialogOptionsbutton9 =
                {
                    modal: true,
                    buttons:
                    {
                        "OK": Responsebutton9,
                        "Cancel": cancel
                    },
                    autoOpen: false
                };

                $("#button9").click
                (
                    function () {
                        $("#CustomDialogInput").dialog(DialogOptionsbutton9);
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
                $("#button10").click
                (
                    function () 
                    {
                        if ($("#radiobuttonlist1 :input").length > 0) 
                        {
                            //var radiobuttonlistInputLastValue = $("#radiobuttonlist1 :input")[$("#radiobuttonlist1 :input").length - 1].value;
                            //var radiobuttonlistInputLastInnerHTML = $("#radiobuttonlist1 label")[$("#radiobuttonlist1 label").length - 1].innerHTML;
                            //$("#radiobuttonlist1 label:contains(" + radiobuttonlistInputLastInnerHTML + ")").remove();
                            //$("#radiobuttonlist1 :input[value = " + radiobuttonlistInputLastValue + "]").remove();
                            //$("#radiobuttonlist1 :input[value = " + radiobuttonlistInputLastValue + "]").next("label").remove();

                            $("#radiobuttonlist1 label:last").remove();
                            $("#radiobuttonlist1 :input:last").remove();
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
                $("#radiobutton1").change
                (
                    function () 
                    {
                        if ($(this).is(':checked')) 
                        {
                            $(this).next("label").css({ backgroundColor: "#00FF00" });
                            $(this).css({ backgroundColor: "#11FF11" });

                            var radiobutton = $("#radiobutton2");
                            $(radiobutton).next('label').css({ backgroundColor: "#FF0000" });
                            $(radiobutton).css({ backgroundColor: "#FF1111" });
                        }
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#radiobutton2").change
                (
                    function () 
                    {
                        if ($(this).is(':checked'))
                        {
                            $(this).next("label").css({ backgroundColor: "#00FF00" });
                            $(this).css({ backgroundColor: "#11FF11" });

                            var radiobutton = $("#radiobutton1");
                            $(radiobutton).next('label').css({ backgroundColor: "#FF0000" });
                            $(radiobutton).css({ backgroundColor: "#FF1111" });
                        }
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#button11").click
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
                        //return false; // to prevent the submit from going through
                    }
                );
            }
        );

        $(document).ready
        (
            function () 
            {
                $("#button12").click
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
                        //return false; // to prevent the submit from going through
                    }
                );
            }
        );
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label id="label1">label</label>
        <input type="text" id="text1" />
        <input type="button" id="button1" value="Pass text to label"" />
        <input type="button" id="button2" value="Pass label to text"" />        
        <br />
        <br />
        <select id="select1" style="width: 10%">
            <option value="1" selected="selected">Red</option>
            <option value="2">Green</option>
            <option value="3">Blue</option>
            <option value="4">Black</option>
        </select>
        <input type="button" id="button3" value="Append item to select" />
        <input type="button" id="button4" value="Remove item from select" /> 
        <br />
        <br />
        <select id="selectmultiple1" style="width: 10%;" multiple="multiple">
            <option value="1" selected="selected">Red</option>
            <option value="2">Green</option>
            <option value="3">Blue</option>
            <option value="4">Black</option>
        </select>
        <input type="button" id="button5" value="Append item to multiple select" />
        <input type="button" id="button6" value="Remove item from multiple select" />
        <br />
        <br />        
        <div id="checkboxlist1">
            <input type="checkbox" value="1" checked="checked" />
                <label>Red</label><br />
            <input type="checkbox" value="2" />
                <label>Green</label><br />
            <input type="checkbox" value="3" />
                <label>Blue</label><br />
            <input type="checkbox" value="4" />
                <label>Black</label><br />
        </div>
        <input type="button" id="button7" value="Append item to checkbox options" />
        <input type="button" id="button8" value="Remove item from checkbox options"" />
        <br />
        <br />
        <input type="checkbox" id="checkbox1" /><label>Unchecked</label><br />
        <br />
        <br />
        <div id="radiobuttonlist1">
            <input type="radio" name="color" value="1" checked="checked" />
                <label>Red</label><br />
            <input type="radio" name="color" value="2" />
                <label>Green</label><br />
            <input type="radio" name="color" value="3" />
                <label>Blue</label><br />
            <input type="radio" name="color" value="4" />
                <label>Black</label><br />
        </div>
        <input type="button" id="button9" value="Add item to radio options" />
        <input type="button" id="button10" value="Remove item from radio options" />
        <br />
        <br />
        <input type="radio" id="radiobutton1" name="fruit" /><label>Apple</label>
        <input type="radio" id="radiobutton2" name="fruit" /><label>Mango</label>
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
            <input type="button" id="button11" value="Append Row" />
            <input type="button" id="button12" value="Delete Row" />
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
