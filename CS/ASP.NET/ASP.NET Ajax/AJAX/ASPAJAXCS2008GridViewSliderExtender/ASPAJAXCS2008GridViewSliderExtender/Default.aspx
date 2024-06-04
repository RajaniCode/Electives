<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">    
    <title></title>
    <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div align="center">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class ="Caption" align="center" >
                        Paging in Grid View using Slide Extender
                    </td>
                </tr>
                <tr>
                    <td class="Caption">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" >
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" PageSize="5" runat="server" AllowPaging="True" DataKeyNames="ProductID"
                                    HeaderStyle-HorizontalAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                    GridLines="Horizontal" BorderStyle="Solid" HeaderStyle-CssClass="GVHeader" OnRowCommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name">
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Category" HeaderText="Category">
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MRP" HeaderText="MRP">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Discount" HeaderText="Discount">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Qty" HeaderText="Qty">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerTemplate>
                                        <div class="PagerStyle">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left" style="width: 25px;">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" style="width: 34px;">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="First" ImageUrl="~/Images/button-first.jpg" /></td>
                                                    <td align="left" style="width: 34px;">
                                                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Prev" ImageUrl="~/Images/button-prev.jpg" /></td>
                                                    <td align="center" style="width: 200px;">
                                                        <asp:TextBox ID="txtSlider" runat="server" AutoPostBack="True" Text='<%# GridView1.PageIndex + 1 %>'
                                                            OnTextChanged="txtSlider_TextChanged" Width="200px"></asp:TextBox>
                                                        <ajaxToolkit:SliderExtender ID="SliderExtender1" runat="server" Orientation="Horizontal"
                                                            TargetControlID="txtSlider" Minimum="1" Steps='<%# GridView1.PageCount %>' Maximum='<%# ((GridView)Container.NamingContainer).PageCount %>'>
                                                        </ajaxToolkit:SliderExtender>
                                                    </td>
                                                    <td align="left" style="width: 34px;">
                                                        <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Next" ImageUrl="~/Images/button-next.jpg" /></td>
                                                    <td align="left" style="padding-left: 5px; width: 34px;">
                                                        <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Last" ImageUrl="~/Images/button-last.jpg" /></td>
                                                    <td align="right" style="padding-right: 25px" class="PageNumber">
                                                        <asp:Label ID="lblPaging" Text='<%# "Page " + (GridView1.PageIndex + 1) + " of " + GridView1.PageCount %>'
                                                            runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </PagerTemplate>
                                    <AlternatingRowStyle CssClass="GVItemStyle" />
                                    <RowStyle CssClass="GVAltItemStyle" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
