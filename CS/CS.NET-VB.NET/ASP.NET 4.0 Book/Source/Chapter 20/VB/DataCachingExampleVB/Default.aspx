<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Data Caching Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
		<br />
		<asp:DataGrid ID="DataGrid1" Style="z-index: 101; left: 216px; position: 
 		  absolute;
		top: 123px" runat="server" BorderColor="Tan" BorderWidth="1px" 
 		  BackColor="LightGoldenrodYellow"
		CellPadding="2" Width="664px" ForeColor="Black" GridLines="None">
		<FooterStyle BackColor="Tan"></FooterStyle>
		<SelectedItemStyle ForeColor="GhostWhite" 
 		  BackColor="DarkSlateBlue"></SelectedItemStyle>
		<HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
		<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" 
 		  BackColor="PaleGoldenrod">
		</PagerStyle>
		<AlternatingItemStyle BackColor="PaleGoldenrod" />
		</asp:DataGrid>
		<asp:Label ID="Label1" Style="z-index: 102; left: 477px; position: absolute; top: 
 		  83px"
		runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large">Data 
 		  Caching Example</asp:Label>
		<asp:Label ID="Label2" Style="z-index: 104; left: 225px; position: absolute; top: 
 		 81px"
		runat="server">Label</asp:Label>

    </div>
    </form>
</body>
</html>
