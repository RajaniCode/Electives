<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Table Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" 
 					  Font-Size="Medium" 
					Font-Underline="True" Text="Table Control 
 					  Example"></asp:Label>
					<br />
					<br />
					<asp:Button ID="Button1" runat="server" Font-Bold="True" 
 					  Height="60px" 
					Text="Click Me to See the Students Detail!!" 
					Width="316px" onclick="Button1_Click" />
					<br />
					<br />
					<asp:Table ID="Table1" runat="server" BorderColor="Black" 
 					  BorderStyle="Solid" 
					BorderWidth="2px" Caption="Students Detail" Font-
 					  Size="Small" ForeColor="Red" 
					GridLines="Both" Height="163px" HorizontalAlign="Center" 
 					  Visible="False" 
					Width="341px">
					<asp:TableRow ID="TableRow1" runat="server" 
 					  BorderColor="Black" ForeColor="#000099">
					<asp:TableCell ID="TableCell1" runat="server" 
 					  BorderColor="Black" BorderStyle="Solid">Student 
 					  ID</asp:TableCell>
					<asp:TableCell ID="TableCell2" runat="server" 
 					  BorderColor="Black" BorderStyle="Solid">Student 
					Name</asp:TableCell>
					<asp:TableCell ID="TableCell3" runat="server" 
 					  BorderColor="Black" BorderStyle="Solid">Roll 
 					  No.</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow ID="TableRow2" runat="server" 
 					  BorderColor="Black">
					<asp:TableCell ID="TableCell4" runat="server" 
 					  BorderColor="Black" 
 					  BorderStyle="Solid">A001</asp:TableCell>
					<asp:TableCell ID="TableCell5" runat="server" 
 					  BorderColor="Black" 
 					  BorderStyle="Solid">James</asp:TableCell>
					<asp:TableCell ID="TableCell6" runat="server" 
 					  BorderColor="Black" 
 					  BorderStyle="Solid">16</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow ID="TableRow3" runat="server" 
 					  BorderColor="Black" BorderStyle="Solid">
					<asp:TableCell ID="TableCell7" runat="server" 
 					  BorderColor="Black" 
 					  BorderStyle="Solid">A002</asp:TableCell>
					<asp:TableCell ID="TableCell8" runat="server" 
 					  BorderColor="Black" 
 					  BorderStyle="Solid">John</asp:TableCell>
					<asp:TableCell ID="TableCell9" runat="server" 
 					  BorderColor="Black" 
 					  BorderStyle="Solid">17</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow ID="TableRow4" runat="server" 
 					  BorderColor="Black" BorderStyle="Solid">
					<asp:TableCell ID="TableCell10" runat="server" 
 					  BorderColor="Black" 
 					  BorderStyle="Solid">A003</asp:TableCell>
					<asp:TableCell ID="TableCell11" runat="server" 
 					  BorderColor="Black" 
 					  BorderStyle="Solid">Lisa</asp:TableCell>
					<asp:TableCell ID="TableCell12" runat="server" 
 					  BorderColor="Black" 
 					  BorderStyle="Solid">20</asp:TableCell>
					</asp:TableRow>
					</asp:Table>

    </div>
    </form>
</body>
</html>
