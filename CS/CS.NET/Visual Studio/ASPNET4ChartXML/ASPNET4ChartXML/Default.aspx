<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="btnBind" runat="server" Text="Bind Chart to XML" 
        onclick="btnBind_Click" />
    <asp:Chart ID="chartBooks" runat="server"  Width="700" Height="450"
         BackColor="LightBlue" BackSecondaryColor="AliceBlue" 
         BackGradientStyle="TopBottom" BorderColor="DarkBlue">
        <Series>
            <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Column" 
                Color="Wheat">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"  
            BackColor="#0066cc" BorderColor="DarkBlue">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart> 
</asp:Content>
