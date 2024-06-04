<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="BlogModel._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="EntityDataSource1">
        <AlternatingItemTemplate>
            <span style="">Title:
            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
            <br />
            CreatedDate:
            <asp:Label ID="CreatedDateLabel" runat="server" 
                Text='<%# Eval("CreatedDate") %>' />
            <br />
            PostContent:
            <asp:Label ID="PostContentLabel" runat="server" 
                Text='<%# Eval("PostContent") %>' />
            <br />
            <br />
            </span>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <span style="">Title:
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
            <br />
            CreatedDate:
            <asp:TextBox ID="CreatedDateTextBox" runat="server" 
                Text='<%# Bind("CreatedDate") %>' />
            <br />
            PostContent:
            <asp:TextBox ID="PostContentTextBox" runat="server" 
                Text='<%# Bind("PostContent") %>' />
            <br />
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                Text="Cancel" />
            <br /><br /></span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">Title:
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
            <br />CreatedDate:
            <asp:TextBox ID="CreatedDateTextBox" runat="server" 
                Text='<%# Bind("CreatedDate") %>' />
            <br />
            PostContent:
            <asp:TextBox ID="PostContentTextBox" runat="server" 
                Text='<%# Bind("PostContent") %>' />
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                Text="Insert" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                Text="Clear" />
            <br /><br /></span>
        </InsertItemTemplate>
        <ItemTemplate>
            <span style="">Title:
            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
            <br />
            CreatedDate:
            <asp:Label ID="CreatedDateLabel" runat="server" 
                Text='<%# Eval("CreatedDate") %>' />
            <br />
            PostContent:
            <asp:Label ID="PostContentLabel" runat="server" 
                Text='<%# Eval("PostContent") %>' />
            <br />
            <br />
            </span>
        </ItemTemplate>
        <LayoutTemplate>
            <div ID="itemPlaceholderContainer" runat="server" style="">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="">
                <asp:DataPager ID="DataPager1" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <span style="">Title:
            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
            <br />
            CreatedDate:
            <asp:Label ID="CreatedDateLabel" runat="server" 
                Text='<%# Eval("CreatedDate") %>' />
            <br />
            PostContent:
            <asp:Label ID="PostContentLabel" runat="server" 
                Text='<%# Eval("PostContent") %>' />
            <br />
            <br />
            </span>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
        ConnectionString="name=BlogContext" DefaultContainerName="BlogContext" 
        EnableFlattening="False" EntitySetName="Posts" OrderBy="it.CreatedDate" 
        Select="it.[Title], it.[CreatedDate], it.[PostContent]" 
        Where="it.Public == true">
    </asp:EntityDataSource>
    <p>
        &nbsp;</p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
