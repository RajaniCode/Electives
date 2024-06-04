<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MultiView and View Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
			Font-Underline="True" Text="View and MultiView Controls 
 			  Example"></asp:Label>
			<br />
			<br />
			<asp:Button id="Button1" runat="server" Text="Click Me to See View1" 
			BackColor="Black" ForeColor="#00CCFF" onclick="Button1_Click" /> &nbsp;
			<asp:Button id="Button2" runat="server" Text="Click Me to See View2" 
			BackColor="Black" ForeColor="#00CCFF" onclick="Button2_Click" /> &nbsp; 
			<asp:Button id="Button3" runat="server" Text="Click Me to See View3" 
			BackColor="Black" ForeColor="#00CCFF" onclick="Button3_Click" />
			<br /><br />

			<asp:MultiView id="MultiView1" runat="server" ActiveViewIndex=0>
			<asp:View id="View1" runat="server">
			<a style="font-family: 'Times New Roman', Times, serif">I am Abraham</a> 
 			  <br />
			<br />
			<asp:Image ID="Image1" runat="server" Height="132px" 
 			  ImageUrl="Abraham.jpg" 
			Width="92px" />
			<br />
			</asp:View>
			<asp:View id="View2" runat="server">
			<a style="font-family: 'Times New Roman', Times, serif" >I am Lisa</a> 
			<br />
			<br />
			<asp:Image ID="Image2" runat="server" ImageUrl="Lisa.jpg" />
			</asp:View>
			<asp:View id="View3" runat="server">
			<a style="font-family: 'Times New Roman', Times, serif">I am Reginald</a> 
			<br />
			<br />
			<asp:Image ID="Image3" runat="server" ImageUrl="Reginald.jpg" />
			</asp:View>
			</asp:MultiView>

			<br />
			<br />
			<br />
			<asp:MultiView ID="MultiView2" runat="server">
			<asp:View ID="View4" runat="server">
			</asp:View>
			</asp:MultiView>
    </div>
    </form>
</body>
</html>
