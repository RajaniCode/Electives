<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008GridViewTableAdapter._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:GridView ID="grdContact" runat="server" AutoGenerateColumns="False" DataKeyNames="Id, Type" OnRowCancelingEdit="grdContact_RowCancelingEdit" OnRowDataBound="grdContact_RowDataBound" OnRowEditing="grdContact_RowEditing" OnRowUpdating="grdContact_RowUpdating" OnRowCommand="grdContact_RowCommand" ShowFooter="True" OnRowDeleting="grdContact_RowDeleting"> 
        <Columns> 
            <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNewName" runat="server" ></asp:TextBox> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Sex" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:DropDownList ID="ddlSex" runat="server" SelectedValue='<%# Eval("Sex") %>'> 
                        <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                        <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                    </asp:DropDownList> 
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblSex" runat="server" Text='<%# Eval("Sex") %>'></asp:Label> 
                </ItemTemplate> 
                <FooterTemplate> 
                    <asp:DropDownList ID="ddlNewSex" runat="server" >
                        <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem> 
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem> </asp:DropDownList> 
                </FooterTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Type" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:DropDownList ID="cmbType" runat="server" DataTextField="Typename" DataValueField="Id"> </asp:DropDownList> 
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type") %>'></asp:Label> 
                </ItemTemplate> 
                <FooterTemplate> 
                    <asp:DropDownList ID="cmbNewType" runat="server" DataTextField="Typename" DataValueField="Id"> </asp:DropDownList> 
                </FooterTemplate> 
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="Active"> 
                <EditItemTemplate> 
                    <asp:CheckBox ID="chkActive" runat="server" />
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblActive" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label> 
                </ItemTemplate> 
                <FooterTemplate> 
                    <asp:CheckBox ID="chkNewActive" runat="server" />
                </FooterTemplate> 
            </asp:TemplateField> 
            
            <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton> 
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Insert"></asp:LinkButton> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton> 
                </ItemTemplate> 
            </asp:TemplateField> 

            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" /> 
        </Columns> 
        </asp:GridView> 
        
    </div>
    </form>
</body>
</html>
