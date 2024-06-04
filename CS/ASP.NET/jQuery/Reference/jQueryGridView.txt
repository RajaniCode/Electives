<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jQueryGridView.aspx.cs" Inherits="ASPCS2010JavaScriptVSjQuery.jQueryGridView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="jquery-ui-1.8.21.custom/css/ui-lightness/jquery-ui-1.8.21.custom.css" rel="Stylesheet" />
    <style type="text/css">
        th
        {
            text-align:left;
        }
          body
         {
             font-family:Arial;
             font-size:10pt;
         }
         #divEditBox
         {
             display:none;
             position:absolute;
             left:30%;
             top:30%;
         }
         .highlightRow
         {
            background-color:Yellow;   
         }
         .select
         {
             background-color:#c0c0c0;
         }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <p><a href="javascript:void(0)" onclick="LoadGridViewForm(0, 1)">Load</a> | <a id="addLink" href="javascript:void(0)" title="Add">Add</a></p>
    <div id="divGridViewForm"></div>
    <div id="divEditBox">
        <table cellpadding="4" width="600" cellspacing="0" border="0" style="background-color:#efefef;border:1px solid #c0c0c0;">
            <tr style="background-color:#b0b0b0;" valign="top">
                <td style="width: 91%" colspan="3">&nbsp;<label id="lblPopTitle">Modify Record</label></td>
                <td align="right" style="width: 9%;padding-right:10px;">
                    <a id="closeLink"  href="javascript:void(0)" onclick="HideEditBox()" title="Close">Close</a>
                </td>
            </tr>
            <tr>
                <td>Name: </td><td><input type="text" id="txtEditName" />
                </td>                
                <td>Country: </td><td><input type="text" id="txtEditCountry" /></td>
            </tr>

            <tr><td colspan="4" align="center">&nbsp;
            <input type="button" value="Submit" onclick="UpdateInsertData()" />
            <input type="hidden" id="editId" value="0" />
            </td></tr>
        </table>
    </div>
    <div id="CustomDialogMessage" class="ui-dialog" title="Message" style="display: none;">
        <p id="CustomMessage"></p>
    </div>
    </form>
        
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script>
    <script type="text/javascript" src="jquery-ui-1.8.21.custom/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="jquery-ui-1.8.21.custom/js/jquery-ui-1.8.21.custom.min.js"></script>

        <script type="text/javascript">
            // Load the gridview page data
            function LoadGridViewForm(start, pageNo) {
                $(document).ready(function () {
                    $.post("GridViewForm.aspx", {
                        startRowIndex: start,
                        thisPage: pageNo
                    },
                    function (data) {
                        $("div#divGridViewForm").html(data);
                    });
                });
            }

            //Fixed to Trim the Text
            // insert / update the data
            function UpdateInsertData() {
                $(document).ready(function () {
                    $.post("GridViewForm.aspx",
                    {
                        pName: $.trim($("#txtEditName").val()),
                        pCountry: $.trim($("#txtEditCountry").val()),

                        editId: $.trim($("#editId").val())
                    },
                    function (data) {
                        $("div#divGridViewForm").html(data);
                        var Text = $.trim($("#HiddenFieldMessage").val())

                        if (Text != "") {
                            ShowMessage(Text);
                        }
                    });
                });
                // hide the edit box
                HideEditBox();
            }

            // delete the record
            function DeleteRecord(id) {
                $(document).ready(function () {
                    $.post("GridViewForm.aspx",
                    {
                        deleteId: id
                    },
                    function (data) {
                        $("div#divGridViewForm").html(data);                        
                        var Text = $.trim($("#HiddenFieldMessage").val())
                        if (Text != "") {
                            ShowMessage(Text);
                        }
                    });
                });
            }

            //Fixed to Trim the Text      
            // show edit box when edit link is clicked   
            function ShowEditBox(id) {
                $("#divEditBox").slideDown("medium");
                var pid = 'PName' + id;
                var colIndex = 0;

                var $tr = $("#" + pid).parent().parent();
                $tr.find('td').each(function () {

                    if (colIndex == 2) {
                        $("#txtEditName").val($.trim($(this).text()));
                    }
                    else if (colIndex == 3) {
                        $("#txtEditCountry").val($.trim($(this).text()));
                    }
                    colIndex++;
                })
                $("#editId").val(id);
                $("#lblPopTitle").text("Modify Record");
            }

            // Hide the edit/insert box
            function HideEditBox() {
                $("#divEditBox").slideUp("medium");
                $("#lblPopTitle").text("");
            }

            // show the box when add link is clicked
            $(document).ready(function () {

                // when add link will be clicked
                $("#addLink").click(function () {
                    $("#divEditBox").slideDown("medium");
                    $("#txtEditName").val("");
                    $("#txtEditCountry").val("");

                    $("#editId").val("0");
                    $("#lblPopTitle").text("Add Record");
                })
            });

            function ShowMessage(Text) 
            {
                $("#CustomMessage").text(Text);

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
                return false;
            }    
    </script>

</body>
</html>
