<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 
        <asp:FormView ID="FormViewWell" DataSourceID="ObjectDataSourceWell" AllowPaging="true" Runat="server">
        
        <ItemTemplate>

        <table>
        <tr>
            <td>
            <asp:TextBox ID ="TextBoxWellheadID" runat="server" Text='<%# Eval("WellheadID")%>'></asp:TextBox>
            </td>
            <td>
            <asp:TextBox ID ="TextBoxGroupID" runat="server" Text='<%# Eval("GroupID")%>'></asp:TextBox>
            </td>
            <td>
          
            </td>
        </tr>
        </table>

        </ItemTemplate>


        <PagerTemplate>

        <asp:Button id="ButtonPrevious" Text="Previous Page" CommandName="Page" CommandArgument="Prev" Runat="server" Width="35%" />

        <asp:Button id="ButtonNext" Text="Next Page" CommandName="Page" CommandArgument="Next" Runat="server" Width="35%" />

        </PagerTemplate>

        </asp:FormView>
        
        <asp:ObjectDataSource ID="ObjectDataSourceWell" runat="server" SelectMethod="GetWell" TypeName="Well" >
         <SelectParameters>
         <asp:ControlParameter ControlID="FormViewWell" Name="idWellhead"  Type="String" />          
        </SelectParameters>
        </asp:ObjectDataSource>                    
                                                    
    </ContentTemplate>
    </asp:UpdatePanel> 
    </form>
</body>
</html>
