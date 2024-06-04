<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameBrowser.aspx.cs" Inherits="QueryExtenderApplication.GameBrowser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>        
        Genre: <asp:DropDownList runat="server" ID="GenreDropDownList" 
                DataSourceID="GenreSource" DataTextField="Name" DataValueField="ID" AutoPostBack="true" /><br />
        Game Search: <asp:TextBox ID="GameSearchTextBox" runat="server" /><br />

        <asp:GridView runat="server" ID="GamesGrid" DataSourceID="GamesSource" 
            AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
            GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                    SortExpression="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" 
                    SortExpression="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    ReadOnly="True" SortExpression="Description" />
                <asp:BoundField DataField="GenreID" HeaderText="GenreID" ReadOnly="True" 
                    SortExpression="GenreID" />
                <asp:BoundField DataField="GenreName" HeaderText="Genre Name" ReadOnly="true" />                    
                <asp:BoundField DataField="ESRB" HeaderText="ESRB" ReadOnly="True" 
                    SortExpression="ESRB" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>

        <asp:LinqDataSource ID="GamesSource" runat="server" 
            ContextTypeName="QueryExtenderApplication.VideoGamesModelDataContext" 
            TableName="VideoGames" EntityTypeName="" 
            Select="new (Genre.Name as GenreName, ID, Title, Description, GenreID, ESRB)" />
        <asp:LinqDataSource ID="GenreSource" runat="server" 
            ContextTypeName="QueryExtenderApplication.VideoGamesModelDataContext" 
            TableName="Genres" EntityTypeName="" />

        <asp:QueryExtender runat="server" TargetControlID="GamesSource">
            <asp:PropertyExpression>
                <asp:ControlParameter ControlID="GenreDropDownList" Name="GenreID" />
            </asp:PropertyExpression>
            <asp:SearchExpression ComparisonType="InvariantCultureIgnoreCase" DataFields="Title,Description" SearchType="Contains">                
                <asp:ControlParameter ControlID="GameSearchTextBox" />
            </asp:SearchExpression>
        </asp:QueryExtender>

    </div>
    </form>
</body>
</html>
