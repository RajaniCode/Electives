<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ListView with HoverMenuExtender</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1"
DataKeyNames="ProductID" InsertItemPosition="LastItem">
<LayoutTemplate>
    <table>
        <tr>
            <td>
                <table border="1" style="border-width:1; border-color:Black">
                    <tr>
                        <th></th>
                        <!-- Width 100 px to accomodate the HoverMenu Popup -->
                        <th style="width:100px">ProductID</th>
                        <th>ProductName</th>
                        <th>Discontinued</th>
                    </tr>
                        <tr runat="server" ID="itemPlaceholder">
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataPager runat="server" ID="listViewPager" PageSize="5">
                 <Fields>
                      <asp:NumericPagerField ButtonCount="10" 
                       PreviousPageText="<--" NextPageText="-->" />
                 </Fields>
                </asp:DataPager>
            </td>
        </tr>
    </table>
</LayoutTemplate>

<ItemTemplate>
    <tr>
        <td>     
            <cc1:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                TargetControlID="lblProdName"  PopupControlID="panelPopUp"
                PopDelay="20" OffsetX="-100" OffsetY="-5">
            </cc1:HoverMenuExtender>
            <asp:Panel ID="panelPopUp" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnEdit" runat="server"
                            CommandName="Edit" Text="Edit" />
                        </td>
                        <td>
                             <asp:Button ID="btnDelete" runat="server" 
                             CommandName="Delete" Text="Delete" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
         </td>
         <td>
             <asp:Label ID="lblProdID" runat="server" 
              Text='<%# Eval("ProductID") %>' />
          </td>
          <td>
             <asp:Label ID="lblProdName" runat="server" 
              Text='<%# Eval("ProductName") %>' />
          </td>
          <td>
             <asp:Label ID="cbDiscontinued" runat="server" 
              Text='<%# Eval("Discontinued") %>' />
          </td>
    </tr>
</ItemTemplate>

<EditItemTemplate>
   <tr>
      <td>
         <asp:Button ID="btnUpdate" runat="server" 
          CommandName="Update" Text="Update" />
         <asp:Button ID="btnCancel" runat="server" 
          CommandName="Cancel" Text="Cancel" />
      </td>
      <td>
         <asp:Label ID="lblProdIDReadOnly" runat="server" 
          Text='<%# Bind("ProductID") %>' /></td>
       <td>
         <asp:TextBox ID="txtEditProdName" runat="server" 
          Text='<%# Bind("ProductName") %>' />
      </td>
   </tr>
</EditItemTemplate>

<InsertItemTemplate>
   <tr>
      <td>
      </td>
      <td>
         <asp:Button ID="btnInsert" runat="server" CommandName="Insert" 
          Text="Insert" />
         <asp:Button ID="btnInsertCancel" runat="server" CommandName="Cancel" 
          Text="Cancel" />
      </td>
      <td>
         <asp:TextBox ID="txtInsertProdName" runat="server" 
          Text='<%# Bind("ProductName") %>' />
      </td>
      <td>
         <asp:CheckBox ID="cbInsertDiscontinued" runat="server" 
          Checked='<%# Bind("Discontinued") %>' />
      </td>
   </tr>
</InsertItemTemplate>

</asp:ListView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server"  
    ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
    SelectCommand="SELECT [ProductID], [ProductName], [Discontinued] FROM [Alphabetical list of products]"
    InsertCommand = "INSERT INTO [Products] (ProductName, Discontinued)VALUES(@ProductName,@Discontinued)"
    UpdateCommand = "UPDATE [Products] SET [ProductName] = @ProductName WHERE [ProductID] = @ProductID"
    DeleteCommand = "DELETE FROM [Products] WHERE [ProductID]=@ProductID">
     <InsertParameters>
        <asp:Parameter Name="ProductName" Type="String" />
        <asp:Parameter Name="Discontinued" Type="Byte" />
     </InsertParameters>            
    <UpdateParameters>
        <asp:Parameter Name="ProductName" Type="String" />              
        <asp:Parameter Name="ProductID" Type="Int32" />
    </UpdateParameters>
    <DeleteParameters>
        <asp:Parameter Name="ProductID" Type="Int32" />
    </DeleteParameters>
</asp:SqlDataSource>

    </div>
    </form>
</body>
</html>

