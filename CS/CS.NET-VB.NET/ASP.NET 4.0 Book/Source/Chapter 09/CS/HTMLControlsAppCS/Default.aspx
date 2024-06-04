<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>HTML Controls Example</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="mainForm" runat="server">
    <div>
        <div id="header">
            <h1>
          ASP.NET 4.0 Black Book</h1>
        </div>
        <div id="sidebar">
            <div id="nav">
                &nbsp;
            </div>
        </div>
        <div id="content">
            <div class="itemContent">
                <br />
                <asp:Label ID="Label1" runat="server" Text="HTML Controls example" 
                    CssClass="Heading1"></asp:Label>
                <br />
                <br />
                <select id="Select1" name="select1" runat="server" 
                    onserverchange="Select1_ServerChange" class="Cb1">
                    <option selected="selected" value="Red">Red</option>
                    <option value="Green">Green</option>
                    <option value="Blue">Blue</option>
                    <option value="White">White</option>
                    <option value="Black">Black</option>
                    <option></option>
                </select>
                <input id="Checkbox1" type="checkbox" runat="server" 
                    onserverchange="Checkbox1_ServerChange" class="Cb1" />
                CheckBox
                <input id="Radio1" type="radio" runat="server" onserverchange="Radio1_ServerChange" />
                Radio Button<br />
                <br />
                <textarea id="TextArea1" cols="20" rows="2" runat="server" onserverchange="TextArea1_ServerChange"></textarea>
                <select id="Select2" name="select1" multiple="True" size="3"
                    runat="server" onserverchange="Select2_ServerChange">
                    <option selected="selected" value="Red">Red</option>
                    <option value="Green">Green</option>
                    <option value="Blue">Blue</option>
                    <option value="White">White</option>
                    <option value="Black">Black</option>
                    <option></option>
                </select>
                <br />
                <br />
                <table id="Table1" style="width: 249px" runat="server">
                    <tr>
                        <td>
                            1
                        </td>
                        <td>
                            2
                        </td>
                        <td>
                            3
                        </td>
                    </tr>
                    <tr>
                        <td>
                            4
                        </td>
                        <td>
                            5
                        </td>
                        <td>
                            6
                        </td>
                    </tr>
                </table>
                <br />
                <input id="Button1" type="submit" value="Submit" runat="server" onserverclick="Button1_ServerClick" />
                <input id="Reset1" type="reset" value="Reset" runat="server" />
                <br />
                <br />
                <span id="span2" runat="server"></span>
                <br />
                <br />
                <span id="span1" runat="server"></span>
                <br />
            </div>
                    </div>
    </div>
    </form>
</body>
</html>
