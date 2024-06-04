<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Using accesskey and tabindex</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <strong><span style="text-decoration: underline"><em>Enter Student 
 			Information </em>
			</span></strong>
			<table style="width: 616px; height: 82px">
			<tr>
			<td style="width: 123px; text-align: left; background-color: #ffccff;">
				&nbsp; &nbsp;
				<label for="Text1" accesskey="S">
					<u style="text-decoration: underline">S</u>tudent Name
				</label>
			</td>
			<td style="width: 127px">
				<input id="Text1" type="text" tabindex="1" style="width: 179px"/>
				&nbsp;
			</td>
			</tr>
			<tr>
			<td style="width: 123px; text-align: left; background-color: #ffccff;">
				<label for="Text2" accesskey="A">
				&nbsp; &nbsp; <u style="text-decoration: underline">A</u>ge
				</label>
			</td>
			<td style="width: 127px">
			<input id="Text2" type="text" tabindex="2" style="width: 179px" />&nbsp;
			</td>
			</tr>
			<tr>
			<td style="width: 123px; text-align: left; background-color: #ffccff;">
				&nbsp; &nbsp;
				<label for="Text3" accesskey="C" >
				<u style="text-decoration:underline">C</u>ity 
				</label>                        
			</td>
			<td style="width: 127px">
			<input id="Text3" type="text" tabindex="3" style="width: 179px" />&nbsp;
			</td>
			</tr>
			</table>

    </div>
    </form>
</body>
</html>
