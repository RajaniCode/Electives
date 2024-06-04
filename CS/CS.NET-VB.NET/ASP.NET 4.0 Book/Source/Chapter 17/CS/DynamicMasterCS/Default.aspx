<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<script runat="server" language="cs">
	void Page_PreInit(Object sender, EventArgs e)
	{
		if (Session["masterpage"] != null)
		{
			this.MasterPageFile = (String)Session["masterpage"];
		}
	}
	protected void Button1_Click(object sender, System.EventArgs e)
	{
		label1.Text = "<b>Hello " + TextBox1.Text + "! Welcome to the Web Site. </b>";
	}
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<b>Enter Your Name: </b>
	<br />
	<asp:TextBox ID="TextBox1" runat="server" />
	<br />
	<br />
	<asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Button1_Click" />
	<br />
	<asp:Label ID="label1" runat="server" />
</asp:Content>

