<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridViewEmailIDs" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceEmailIDs"
            OnRowCommand="GridViewEmailIDs_RowCommand" OnRowCancelingEdit="GridViewEmailIDs_RowCancelingEdit" OnRowDeleting="GridViewEmailIDs_RowDeleting" OnRowEditing="GridViewEmailIDs_RowEditing" ShowFooter="True" OnRowUpdating="GridViewEmailIDs_RowUpdating">
            <Columns>
                
                 <asp:TemplateField HeaderText="Id">
                    
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Identity") %>'></asp:Label>
                    </ItemTemplate>                    
                    <FooterTemplate>
                        <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Insert" />
                    </FooterTemplate>
                                        
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="EmailId">
                
                    <ItemTemplate>
                        <asp:Label ID="lblEmailId" Text='<%# Eval("EmailIdentity") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmailId" Text='<%# Eval("EmailIdentity") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="InserttxtEmailId" runat="server"></asp:TextBox>
                    </FooterTemplate>                   
                    </asp:TemplateField>
                                
                <asp:TemplateField HeaderText="UserId" Visible="False">
                
                    <ItemTemplate>
                        <asp:Label ID="lblUserId" Text='<%# Eval("UserIdentity") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUserId" Text='<%# Eval("UserIdentity") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="InserttxtUserId" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    
                </asp:TemplateField>
                
                    
                
                <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button" />
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ButtonType="Button" />
                
            </Columns>
        </asp:GridView>
         
            
    
    </div> <asp:ObjectDataSource ID="ObjectDataSourceEmailIDs" runat="server" SelectMethod="SelectTable" DeleteMethod="DeleteTable" InsertMethod="InsertTable" UpdateMethod="UpdateTable" TypeName="clsEmailIds">
        
            <UpdateParameters>
                <asp:Parameter Name="EMAILID" Type="String" />
            </UpdateParameters> 
            
        </asp:ObjectDataSource>
        
    </form>
</body>
</html>
