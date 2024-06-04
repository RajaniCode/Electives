<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title>Entity Framework Application</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
			Demo showing the use of Entity Framework in database application<br />
			<br />
			-------------------------------------------------------------------------
			<br />
			<i>Select the Author Name from the Drop - Down list to view the books 
			asscociated with author<br />
        <br />
        </i><br />
			<i>Author Name</i>
			<asp:DropDownList ID="DropDownList1" runat="server" 
 			DataSourceID="AuthorName"
			DataTextField="FirstName" DataValueField="AuthorID" AutoPostBack="True" 
            Height="20px" Width="80px" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
			</asp:DropDownList>
			<br />
			<br />
			<span class="style1">Book Details of Author</span><asp:GridView 
 			ID="GridView1" 
			runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
			BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
			<RowStyle BackColor="#F7F7DE" />
			<FooterStyle BackColor="#CCCC99" />
			<PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
			<SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
			<HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
			<AlternatingRowStyle BackColor="White" />
			</asp:GridView>
			<asp:LinqDataSource ID="AuthorName" runat="server" 
			ContextTypeName="NewPublisherModel.NewPublisherEntities2" TableName="Authors" 
			EntityTypeName="">			
			</asp:LinqDataSource>

    </div>
    </form>
</body>
</html>
