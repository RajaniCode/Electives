<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BarChart.ascx.cs" Inherits="BarChart" %>


<table>
    <tr>
        <td align=center>
            <asp:Label id=lblChartTitle runat=server />            
        </td>
    </tr>
    <tr>
        <td>
            <table border=1 bordercolor='#777777' cellspacing=0 cellpadding=0>
                <tr>
                    <td>
                        <table>
                            <asp:Label id=lblItems runat=server />
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan=2 align=center>
            <asp:Label id=lblXAxisTitle runat=server />
        </td>
    </tr>
</table>
