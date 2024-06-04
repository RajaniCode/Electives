<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        ASP.NET 4.0 Black Book</h2>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" 
					Text="CNN.com RSS Feed"></asp:Label><br />
					<br />
					<asp:DataList ID="DataList1" runat="server" 
 					DataSourceID="XmlDataSource1" BackColor="White"
						BorderColor="#999999" BorderStyle="None" 
 						BorderWidth="1px" CellPadding="3" 
 						GridLines="Vertical"
						Font-Size="XX-Small" Width="308px">
						<ItemTemplate>
							<%#XPath("title")%>
							<%#XPath("description")%>
							<%#XPath("link")%>
						</ItemTemplate>
						<FooterStyle BackColor="#CCCCCC" 
 						ForeColor="Black" />
						<SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
						<AlternatingItemStyle BackColor="Tan" />
						<ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
						<HeaderStyle BackColor="#000084" Font-Bold="True" 
 						ForeColor="White" />
					</asp:DataList><br />
					<asp:XmlDataSource ID="XmlDataSource1" runat="server" 
 					DataFile="http://rss.cnn.com/rss/cnn_topstories.rss"
						XPath="rss/channel/item"></asp:XmlDataSource>
					&nbsp;

    </asp:Content>
