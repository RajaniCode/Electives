<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>GridView With ModalPopUpExtender</title>
<style type="text/css">
    body
    {
        font: normal 12px auto "Trebuchet MS", Verdana;    
        background-color: #ffffff;
        color: #4f6b72;       
    }

    .popUpStyle
    {
        font: normal 11px auto "Trebuchet MS", Verdana;    
        background-color: #ffffff;
        color: #4f6b72;  
        padding:6px;      
        filter: alpha(opacity=80);
        opacity: 0.8;
    }
    
    .drag
    {
         background-color: #dddddd;
         cursor: move;
         border:solid 1px gray ;
    }
</style>

</head>

<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
AutoGenerateColumns="false" AllowPaging="true" >        
<Columns>       
    <asp:BoundField HeaderText="OrderID" DataField="OrderID" />
     <asp:TemplateField HeaderText="CustomerID">
        <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkCustDetails" Text='<%# Eval("CustomerID") %>'  OnClick="lnkCustDetails_Click" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField HeaderText="OrderDate" DataField="OrderDate" />
    <asp:BoundField HeaderText="ShippedDate" DataField="ShippedDate" />
</Columns>
</asp:GridView>
        
<asp:Button runat="server" ID="btnShowModalPopup" style="display:none"/>
<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
    TargetControlID="btnShowModalPopup"
    PopupControlID="divPopUp" 
    BackgroundCssClass="popUpStyle" 
    PopupDragHandleControlID="panelDragHandle"
    DropShadow="true"
    />
<br />

<div class="popUpStyle" id="divPopUp" style="display:none;">
    <asp:Panel runat="Server" ID="panelDragHandle" CssClass="drag">
        Hold here to Drag this Box
    </asp:Panel>
    <asp:Label runat="server" ID="lblText" Text="CustomerID: "></asp:Label>
    <asp:Label ID="lblCustValue" runat="server"></asp:Label>
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>                          
    <asp:Button ID="btnClose" runat="server" Text="Close" />
   <br />
</div>        
    </ContentTemplate>
    </asp:UpdatePanel>   
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
        SelectCommand="SELECT [OrderID],[CustomerID],[OrderDate],[ShippedDate] FROM [Orders]"></asp:SqlDataSource>        
    
    </form>
</body> 
</html>
