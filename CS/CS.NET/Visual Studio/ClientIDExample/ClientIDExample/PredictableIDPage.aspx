<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PredictableIDPage.aspx.cs" Inherits="PredictableIDPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:GridView ID="lstView" runat="server" ClientIDMode="Predictable" 
        ClientIDRowSuffix="EmployeeID" AutoGenerateColumns="false" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:TemplateField HeaderText="Employee Details">
                <ItemTemplate>
                    <asp:Label ID="lblFName" Text='<%# Bind("FirstName") %>' runat="server" Font-Bold="true" />
                    <asp:Label ID="lblLName" Text='<%# Bind("LastName") %>' runat="server" Font-Bold="true" />
                    <asp:Label ID="lblCity" Text='<%# Bind("City") %>' runat="server" Font-Bold="true" />
                    <asp:Label ID="lblCountry" Text='<%# Bind("Country") %>' runat="server" Font-Bold="true" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
        SelectCommand="SELECT [EmployeeID],[FirstName], [LastName], [City], [Country] FROM [Employees]">
    </asp:SqlDataSource>

    
</asp:Content>

