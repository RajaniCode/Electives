<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Need of Label Tag</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <strong><span style="text-decoration: underline"><em>
			Enter Student Information </em>
			</span></strong>
			<table style="width: 616px; height: 82px">
			<tr>
			<td bgcolor="#ffccff" style="width: 127px; text-align: center">
			Student Name
			</td>
			<td bgcolor="#ffccff" style="width: 185px; text-align: center">
			Age</td>
			<td bgcolor="#ffccff" style="width: 180px; text-align: center">
			City</td>
			</tr>
			<tr>
			<td style="width: 127px">
			    <br />
			<input id="Text1" type="text" style="width: 179px" />&nbsp;
			</td>
			<td style="width: 185px">
			<input id="Text3" style="width: 183px" type="text" /></td>
			<td style="width: 180px">
			<input id="Text4" style="width: 240px" type="text" /></td>
			</tr>
			</table>

    </div>
    </form>
</body>
</html>
