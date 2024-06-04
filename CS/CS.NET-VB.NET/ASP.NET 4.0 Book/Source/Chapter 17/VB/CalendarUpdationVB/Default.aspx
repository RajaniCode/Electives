<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
Enter date(MM/DD/YY)in Textbox for updating Calendar control<br />
	<br />
	<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text="Label" 
 	Visible="False"></asp:Label><br />
	&nbsp;<br />
	<asp:Button ID="Button1" runat="server" BackColor="Black" Font-Bold="True" 
            Font-Size="Small" ForeColor="White" Text="Update Calendar" OnClick="Button1_Click" />
</asp:Content>

