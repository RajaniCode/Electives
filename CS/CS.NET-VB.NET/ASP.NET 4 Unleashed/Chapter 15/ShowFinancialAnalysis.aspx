<%@ Page Language="C#" %>
<%@ Register Assembly="System.Web.DataVisualization, 
    Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN"
   "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">
    void PopulateData()
    {
        chtPrices.Series["PriceSeries"].Points.AddXY("2/1/2010", 50);
        chtPrices.Series["PriceSeries"].Points.AddXY("2/2/2010", 75);
        chtPrices.Series["PriceSeries"].Points.AddXY("2/3/2010", 35);
        chtPrices.Series["PriceSeries"].Points.AddXY("2/4/2010", 85);
        chtPrices.Series["PriceSeries"].Points.AddXY("2/5/2010", 45);
        chtPrices.Series["PriceSeries"].Points.AddXY("2/6/2010", 87);
        chtPrices.Series["PriceSeries"].Points.AddXY("2/7/2010", 72);
    }

    void Page_Load()
    {
        PopulateData();

        chtPrices.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Exponential,3,false,false", "PriceSeries", "ForecastSeries");
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Show Chart</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Chart ID="chtPrices" runat="server" >
            <Series>
                <asp:Series Name="PriceSeries" ChartType="Line" Color="Red" BorderWidth="2"></asp:Series>
                <asp:Series Name="ForecastSeries" ChartType="Line" Color="Blue"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="PriceChartArea">
                    <AxisY>
                        <LabelStyle Format="C0" />
                    </AxisY>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart> 
    </div>
    </form>
</body>
</html>

