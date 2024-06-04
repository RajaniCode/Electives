<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JavaScript.aspx.cs" Inherits="ASPCS2010JavaScriptVSjQuery.JavaScript" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JavaScript</title>
    <style type="text/css">
        .divTable
        {
            display: table;
            width: auto;
            background-color: #eee;
            border: 1px solid #666666;
            border-spacing: 5px;
        }
        
        .divRow
        {
            display: table-row;
            width: auto;
            border: 1px Solid #FFFFFF;
        }
        
        .divCell
        {
            float: left; /*fix for  buggy browsers*/
            display: table-column;
            width: 200px;
            background-color: #ccc;
        }
    </style>
    <script type="text/javascript">
        function PassTextToLabel() {
            var TextBox = document.getElementById("TextBox1");
            var Label = document.getElementById("Label1");
            Label.innerHTML = TextBox.value;
        }

        function PassLabelToText() {
            var TextBox = document.getElementById("TextBox1");
            var Label = document.getElementById("Label1");
            TextBox.value = Label.innerHTML;
        }

        function DropDownListOnChange() {
            var DropDownList = document.getElementById("DropDownList1");
            var DropDownListValue = DropDownList.options[DropDownList.selectedIndex].value;
            var DropDownListText = DropDownList.options[DropDownList.selectedIndex].text;
            alert("DropDownList Value: " + DropDownListValue + "\n"
                + "DropDownList Text: " + DropDownListText);
        }

        function AppendItemToDropDownList() {
            var ReturnText = prompt("Please enter the text to add to DropDownList.");
            if (ReturnText != null) {
                var DropDownList = document.getElementById("DropDownList1");
                var DropDownListOptionsLength = DropDownList.options.length;

                var DropDownListNextValue = 0;
                if (DropDownListOptionsLength > 0) {
                    DropDownListNextValue = parseInt(DropDownList.options[DropDownListOptionsLength - 1].value) + 1;
                }
                else {
                    DropDownListNextValue = 1;
                }
                AddItemToDropDownList(ReturnText, DropDownListNextValue);
            }
        }

        function AddItemToDropDownList(Text, Value) {
            // Create an Option object                 
            var opt = document.createElement("option");
            // Add an Option object to Drop Down/List Box
            document.getElementById("DropDownList1").options.add(opt);
            // Assign text and value to Option object
            opt.text = Text;
            opt.value = Value;

        }

        function RemoveItemFromDropDownList() {
            var DropDownList = document.getElementById("DropDownList1");
            var DropDownListLength = DropDownList.options.length;

            if (DropDownListLength > 0) {
                DropDownList.remove(DropDownListLength - 1);
            }
            else {
                alert("There are no items.");
            }
        }

        function ListBoxOnChange() {
            var ListBox = document.getElementById("ListBox1");
            var ListBoxNumberOfSelectedItems = ListBoxNumberOfItemsSelected();
            var ListBoxOptionsLength = ListBox.options.length;
            for (var i = 0; i < ListBoxOptionsLength; i++) {
                if (ListBox.options[i].selected) {
                    var ListBoxValue = ListBox.options[i].value;
                    var ListBoxText = ListBox.options[i].text;
                    alert("ListBox Number Of Selected Items: " + ListBoxNumberOfSelectedItems + "\n"
                        + "ListBox Value: " + ListBoxValue + "\n"
                        + "ListBox Text: " + ListBoxText);
                }
            }
        }

        function AppendItemToListBox() {
            var ReturnText = prompt("Please enter the text to add to ListBox.");
            if (ReturnText != null) {
                var ListBox = document.getElementById("ListBox1");
                var ListBoxOptionsLength = ListBox.options.length;

                var ListBoxNextValue = 0;
                if (ListBoxOptionsLength > 0) {
                    ListBoxNextValue = parseInt(ListBox.options[ListBoxOptionsLength - 1].value) + 1;
                }
                else {
                    ListBoxNextValue = 1;
                }
                AddItemToListBox(ReturnText, ListBoxNextValue);
            }
        }

        function AddItemToListBox(Text, Value) {
            // Create an Option object                 
            var opt = document.createElement("option");
            // Add an Option object to Drop Down/List Box
            document.getElementById("ListBox1").options.add(opt);
            // Assign text and value to Option object
            opt.text = Text;
            opt.value = Value;

        }

        function RemoveItemFromListBox() {
            var ListBox = document.getElementById("ListBox1");
            var ListBoxLength = ListBox.options.length;

            if (ListBoxLength > 0) {
                ListBox.remove(ListBoxLength - 1);
            }
            else {
                alert("There are no items.");
            }
        }

        function ListBoxNumberOfItemsSelected() {
            var ListBox = document.getElementById("ListBox1");
            var ListBoxOptions = ListBox.options
            var ListBoxOptionsLength = ListBox.options.length;
            var Counter = 0;
            for (var i = 0; i < ListBoxOptionsLength; i++) {
                if (ListBox.options[i].selected) {
                    Counter++;
                }
            }
            return Counter;
        }

        function CheckBoxListOnChange() {
            var CheckBoxList = document.getElementById("CheckBoxList1");
            var CheckBoxListInput = CheckBoxList.getElementsByTagName("input");
            var CheckBoxListInputLength = CheckBoxList.getElementsByTagName("input").length;
            var CheckBoxListLabel = CheckBoxList.getElementsByTagName("label");

            var CheckBoxListNumberOfSelectedItems = CheckBoxListNumberOfItemsSelected();

            for (var i = 0; i < CheckBoxListInputLength; i++) {
                if (CheckBoxListInput[i].checked) {
                    var CheckBoxListValue = CheckBoxListInput[i].value;
                    var CheckBoxListText = CheckBoxListLabel[i].innerHTML;
                    alert("CheckBoxList Number Of Selected Items: " + CheckBoxListNumberOfSelectedItems + "\n"
                        + "CheckBoxList Value: " + CheckBoxListValue + "\n"
                        + "CheckBoxList Text: " + CheckBoxListText);
                }
            }
        }

        function CheckBoxListNumberOfItemsSelected() {
            var CheckBoxList = document.getElementById("CheckBoxList1");
            //var CheckBoxListRows = CheckBoxList.rows
            //var CheckBoxListRowsLength = CheckBoxList.rows.length;
            var CheckBoxListInput = CheckBoxList.getElementsByTagName("input");
            var CheckBoxListInputLength = CheckBoxList.getElementsByTagName("input").length;
            var Counter = 0;
            for (var i = 0; i < CheckBoxListInputLength; i++) {
                if (CheckBoxListInput[i].checked) {
                    Counter++;
                }
            }
            return Counter;
        }

        function CheckBoxOnChange() {
            var CheckBox = document.getElementById("CheckBox1");

            if (CheckBox.checked) {
                CheckBox.style.backgroundColor = "#3399FF";
                CheckBox.nextSibling.innerHTML = "Checked";
                CheckBox.nextSibling.style.backgroundColor = "#00FF00";
                alert(CheckBox.nextSibling.innerHTML);
            }
            else {
                CheckBox.style.backgroundColor = "#FF3399";
                CheckBox.nextSibling.innerHTML = "Unchecked";
                CheckBox.nextSibling.style.backgroundColor = "#FF0000";
                alert(CheckBox.nextSibling.innerHTML);
            }
        }

        function AppendTableRow() {
            try {
                var table = document.getElementById("Table1");
                var rowCount = table.rows.length;
                if (rowCount > 5) {
                    alert("Add up to 5 rows only.");
                }
                else {
                    var row = document.createElement("tr")
                    var cell1 = document.createElement("td")
                    cell1.height = "25px";
                    cell1.width = "90px";
                    //cell1.appendChild(document.createTextNode("Column1"))
                    var cell2 = document.createElement("td")
                    //cell2.appendChild(document.createTextNode("Column2"))
                    cell2.height = "25px";
                    cell2.width = "90px";
                    row.appendChild(cell1);
                    row.appendChild(cell2);
                    table.appendChild(row);
                }
            }
            catch (e) { alert(e); }
        }

        function DeleteTableRow() {
            try {
                var table = document.getElementById("Table1");
                var rowCount = table.rows.length;
                if (rowCount > 1) {
                    table.deleteRow(1);
                }
                else {
                    alert("There are no rows.");
                }
            }
            catch (e) { alert(e); }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Pass text to label" OnClientClick="PassTextToLabel(); return false;" />
        <asp:Button ID="Button2" runat="server" Text="Pass label to text" OnClientClick="PassLabelToText(); return false;" />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" onchange="jQueryDropDownListOnChange();">
            <asp:ListItem Selected="True" Value="1">White</asp:ListItem>
            <asp:ListItem Value="2">Black</asp:ListItem>
            <asp:ListItem Value="3">Red</asp:ListItem>
            <asp:ListItem Value="4">Green</asp:ListItem>
            <asp:ListItem Value="5">Blue</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button3" runat="server" Text="Append item to DropDownList" OnClientClick="AppendItemToDropDownList(); return false;" />
        <asp:Button ID="Button4" runat="server" Text="Remove item from DropDownList" OnClientClick="RemoveItemFromDropDownList(); return false;" />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Width="100px" onchange="ListBoxOnChange();"
            SelectionMode="Multiple">
             <asp:ListItem Selected="True" Value="1">White</asp:ListItem>
            <asp:ListItem Value="2" Selected="False">Black</asp:ListItem>
            <asp:ListItem Value="3">Red</asp:ListItem>
            <asp:ListItem Value="4">Green</asp:ListItem>
            <asp:ListItem Value="5">Blue</asp:ListItem>
        </asp:ListBox>
        <asp:Button ID="Button5" runat="server" Text="Append item to ListBox" OnClientClick="AppendItemToListBox(); return false;" />
        <asp:Button ID="Button6" runat="server" Text="Remove item to ListBox" OnClientClick="RemoveItemFromListBox(); return false;" />
        <br />
        <br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" onchange="CheckBoxListOnChange();">
             <asp:ListItem Selected="True" Value="1">White</asp:ListItem>
            <asp:ListItem Value="2" Selected="False">Black</asp:ListItem>
            <asp:ListItem Value="3">Red</asp:ListItem>
            <asp:ListItem Value="4">Green</asp:ListItem>
            <asp:ListItem Value="5">Blue</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Unchecked" onchange="CheckBoxOnChange();" />
        <br />
        <br />
        <div>
            <asp:Button ID="Button7" runat="server" Text="Append Row" OnClientClick="AppendTableRow(); return false;" />
            <asp:Button ID="Button8" runat="server" Text="Delete Row" OnClientClick="DeleteTableRow(); return false;" />
            <table border="1" id="Table1">
                <tr>
                    <th height="25px" width="90px">
                        Header 1
                    </th>
                    <th height="25px" width="90px">
                        Header 2
                    </th>
                </tr>
                <tr>
                    <td height="25px" width="90px">
                    </td>
                    <td height="25px" width="90px">
                    </td>
                </tr>
                <tr>
                    <td height="25px" width="90px">
                    </td>
                    <td height="25px" width="90px">
                    </td>
                </tr>
            </table>
            <input id="Button9" type="button" runat="server" value="Append Row" onclick="AppendTableRow();" />
            <input id="Button10" type="button" runat="server" value="Delete Row" onclick="DeleteTableRow();" />
        </div>
        <br />
        <br />
    </div>
    </form>
</body>
</html>

