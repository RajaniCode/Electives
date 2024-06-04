<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Using ModalPopup Extender</title>
    <link href="style.css" rel="stylesheet" type="text/css" />    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <%--Countries Display--%>
            <asp:Label ID="lblCountries" runat="server" Text="Countries" SkinID="Heading"></asp:Label><br />
            <asp:UpdatePanel ID="upCountries" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        DataSourceID="ObjectDataSource1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">   
                                <ItemStyle HorizontalAlign="Left" Width="80%" />
                                <HeaderStyle HorizontalAlign="Left" Width="80%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                <HeaderStyle HorizontalAlign="Center" Width="20%" />                    
                                <ItemTemplate>
                                    <asp:ImageButton ID="showCities" CommandName="Select" runat="server" ImageUrl="~/images/add_details.gif" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>                
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetCountries" TypeName="ModalPopupTableAdapters.CountriesTableAdapter">
            </asp:ObjectDataSource>
            
            <%--Cities Popup Display--%>
            <asp:Button id="btnShowPopup" runat="server" style="display:none" />
            <cc1:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlCities"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Panel ID="pnlCities" runat="server" style="display:none;" SkinID="PopUpPanel">
                <asp:UpdatePanel ID="upCities" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblCities" runat="server" Text="Cities" SkinID="Heading"></asp:Label><br />
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Width="50%">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="odsCities" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetCitiesByCountryId" TypeName="ModalPopupTableAdapters.CitiesTableAdapter">
                            <SelectParameters>
                                <asp:Parameter Name="countryId" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>            
                <div style="text-align: right; width: 100%; margin-top: 5px;">
                    <asp:Button ID="btnClose" runat="server" Text="Close" Width="50px" />
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
