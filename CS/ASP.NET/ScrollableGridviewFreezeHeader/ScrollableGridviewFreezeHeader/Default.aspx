<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" 
Inherits="_Default"  %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    &nbsp;
    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">

        <contenttemplate>
<asp:Label id="Label1" runat="server" Text="GridView1 : This is inside of <b>UpdatePanel.</b> " ForeColor="#FF8000" Font-Underline="True" Font-Size="1.3em"></asp:Label><BR /><BR /><asp:Panel id="PanelContainer" runat="server" ScrollBars="Horizontal" Width="800px"><asp:Table id="_tb" runat="server" BorderWidth="0px" CellPadding="0" CellSpacing="0"></asp:Table> <asp:Panel id="PanelGridViewData" runat="server" ScrollBars="Vertical" Height="180px"><asp:GridView id="GridView1" runat="server" ForeColor="Black" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" DataKeyNames="ProductID" AllowSorting="True" PageSize="1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" OnRowCreated="GridView1_RowCreated" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound">
<FooterStyle BackColor="#CCCC99"></FooterStyle>

<RowStyle BackColor="#F7F7DE"></RowStyle>
<Columns>
<asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" InsertVisible="False" SortExpression="ProductID">
<HeaderStyle BorderWidth="1px" Width="70px"></HeaderStyle>

<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName">
<HeaderStyle BorderWidth="1px" Width="180px"></HeaderStyle>

<ItemStyle Width="180px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CategoryName" HeaderText="Category Name" SortExpression="CategoryName">
<HeaderStyle BorderWidth="1px" Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="QuantityPerUnit" HeaderText="Quantity Per Unit" SortExpression="QuantityPerUnit">
<HeaderStyle BorderWidth="1px" Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice">
<HeaderStyle BorderWidth="1px" Width="70px"></HeaderStyle>

<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" SortExpression="UnitsInStock">
<HeaderStyle BorderWidth="1px" Width="100px"></HeaderStyle>

<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued">
<HeaderStyle BorderWidth="1px" Width="100px"></HeaderStyle>

<ItemStyle Width="100px"></ItemStyle>
</asp:CheckBoxField>
</Columns>

<PagerStyle HorizontalAlign="Right" BackColor="#F7F7DE" ForeColor="Black"></PagerStyle>

<SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

<HeaderStyle HorizontalAlign="Left" BackColor="#6B696B" Font-Bold="True" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>

 </asp:Panel> <%--<div style="overflow-y: scroll; BORDER-RIGHT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; BORDER-BOTTOM: dimgray 1px solid; HEIGHT: 250px" id="contentDiv">
</div>
--%></asp:Panel> 
</contenttemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="1">
        <ProgressTemplate>
            Sorting...
        </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <asp:Label ID="Label2" runat="server" Font-Size="1.2em" Font-Underline="True" ForeColor="#FF8000"
        Text="GridView2 :  This is outside of  <b>UpdatePanel.</b> "></asp:Label><span style="font-size: 1.2em; color: #ff9900"></span><strong><br />
    </strong>
    <br />
    
<asp:Panel id="PanelContainer2" runat="server" ScrollBars="Horizontal" Width="800px"><asp:Table id="_tb2" runat="server" BorderWidth="0px" CellPadding="0" CellSpacing="0"></asp:Table> <asp:Panel id="Panel2" runat="server" ScrollBars="Vertical" Height="180px"><asp:GridView id="GridView2" runat="server" ForeColor="Black" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" DataKeyNames="ProductID" AllowSorting="True" PageSize="1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" OnRowCreated="GridView2_RowCreated" GridLines="Vertical" OnRowDataBound="GridView2_RowDataBound">
<FooterStyle BackColor="#CCCC99"></FooterStyle>

<RowStyle BackColor="#F7F7DE"></RowStyle>
<Columns>
<asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" InsertVisible="False" SortExpression="ProductID">
<HeaderStyle BorderWidth="1px" Width="70px"></HeaderStyle>

<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName">
<HeaderStyle BorderWidth="1px" Width="180px"></HeaderStyle>

<ItemStyle Width="180px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CategoryName" HeaderText="Category Name" SortExpression="CategoryName">
<HeaderStyle BorderWidth="1px" Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="QuantityPerUnit" HeaderText="Quantity Per Unit" SortExpression="QuantityPerUnit">
<HeaderStyle BorderWidth="1px" Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice">
<HeaderStyle BorderWidth="1px" Width="70px"></HeaderStyle>

<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" SortExpression="UnitsInStock">
<HeaderStyle BorderWidth="1px" Width="100px"></HeaderStyle>

<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued">
<HeaderStyle BorderWidth="1px" Width="100px"></HeaderStyle>

<ItemStyle Width="100px"></ItemStyle>
</asp:CheckBoxField>
</Columns>

<PagerStyle HorizontalAlign="Right" BackColor="#F7F7DE" ForeColor="Black"></PagerStyle>

<SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

<HeaderStyle HorizontalAlign="Left" BackColor="#6B696B" Font-Bold="True" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>

 </asp:Panel> <%--<div style="overflow-y: scroll; BORDER-RIGHT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; BORDER-BOTTOM: dimgray 1px solid; HEIGHT: 250px" id="contentDiv">
</div>
--%></asp:Panel>     
    
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
        SelectCommand="SELECT top 1 [ProductID], [ProductName], [CategoryName], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [Discontinued] FROM [Alphabetical list of products] ">
    </asp:SqlDataSource><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
        SelectCommand="SELECT [ProductID], [ProductName], [CategoryName], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [Discontinued] FROM [Alphabetical list of products]">
    </asp:SqlDataSource>
    &nbsp;<br />
    &nbsp;
</asp:Content>

