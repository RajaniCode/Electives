<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

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
                    ASP.NET 4.0 Black Book
                </h1>
            </div>
            <div id="sidebar">
                <div id="nav">
                    &nbsp;
                </div>
            </div>
            <div id="content">
                <div class ="itemContent">
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="HTML Controls example" 
                        CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <select id="Select1" name="select1" runat="server">
                        <option selected="selected" value="Red">Red</option>
                        <option value="Green">Green</option>
                        <option value="Blue">Blue</option>
                        <option value="White">White</option>
                        <option value="Black">Black</option>
                        <option></option>
                    </select>
                    <input id="Checkbox1" type="checkbox" runat="server" />
                    CheckBox  
                    <input id="Radio1" type="radio" runat="server" />
                    Radio Button
                    <br />
                    <br />
                    <textarea id="TextArea1" cols="20" rows="2" runat="server" >
                    </textarea>
                    <select id="Select2" name="select1" size="3" style="width: 129px" runat="server" multiple="true">
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
                            <td>1
                            </td>
                            <td>2
                            </td>
                            <td>3
                            </td>
                        </tr>
                        <tr>
                            <td>4
                            </td>
                            <td>5
                            </td>
                            <td>6
                            </td>
                        </tr>
                    </table>
                    <br />
                    <input id="Button1" type="submit" value="Submit" runat="server" />
                    <input id="Button2" type="submit" value="Reset" runat="server"/><br />
                    <br />
                     <span id="span2" runat ="server"></span>
                    <br />
                    <br />
                    <span id="span1" runat ="server"></span>       
                    
                    <br />
                </div>
                <div id="footer">
                    <p class="left">
                        All content copyright &copy; Kogent Solputions Inc.</p>
                </div>
            </div>
        </div>
        
    </form>
</body>
</html>
