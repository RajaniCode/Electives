<%@ Page Language="C#" %>
<%@ Register Assembly="System.Web.DataVisualization, 
    Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN"
   "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Show Chart</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Chart ID="chtMovies" runat="server" DataSourceID="srcMovies" BackColor="AliceBlue" BackGradientStyle="LeftRight" BackSecondaryColor="SkyBlue" Palette="Pastel" BorderSkin-SkinStyle="Emboss" >
            <Series>
                <asp:Series Name="MovieCategorySeries"
                                  XValueMember="Category" YValueMembers="Count" >
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="MovieChartArea" BackColor="AntiqueWhite">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    
    <asp:SqlDataSource
        id="srcMovies"
        ConnectionString="<%$ ConnectionStrings:Movies %>"
        SelectCommand="CountMoviesInCategory"
        SelectCommandType="StoredProcedure"
        Runat="server" />    
    </div>
    </form>
</body>
</html>
