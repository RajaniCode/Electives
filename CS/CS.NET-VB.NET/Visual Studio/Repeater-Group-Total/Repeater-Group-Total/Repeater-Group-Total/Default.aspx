<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>My Ad Reports</title>
<style type="text/css">
body {font: normal 11px auto "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;	   background-color: #ffffff;color: #4f6b72;	    }#mytable {width: 700px;padding: 10px;margin: 10px;}th {font: bold 11px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;color: #4f6b72;border-right: 1px solid #C1DAD7;border-bottom: 1px solid #C1DAD7;border-top: 1px solid #C1DAD7;letter-spacing: 2px;text-transform: uppercase;text-align: left;padding: 6px 6px 6px 12px;background: #D5EDEF;}td {border-right: 1px solid #C1DAD7;border-bottom: 1px solid #C1DAD7;background: #fff;padding: 6px 6px 6px 12px;color: #4f6b72;}td.alt {background: #F5FAFA;color: #797268;}

td.boldtd
{
font: bold 13px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
background: #D5EDEF;color: #797268;
}
</style>

</head>
<body style="background-color:White">
<form id="form1" runat="server">
<div>

<h3>Daily Activity Reports</h3><br />
<asp:Repeater ID="ParentRepeater" runat="server" DataSourceID="SqlDataSource1">                
<ItemTemplate>             
   <p style="margin-left:10px"><b><asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AdDate", "{0: dd MMM}")%>'></asp:Label></b></p>
     <asp:Repeater ID="ChildRepeater" runat="server" DataSourceID="SqlDataSource2" OnItemDataBound="ChildRepeater_ItemDataBound">
     <HeaderTemplate>
         <table id="mytable">  
         <tr>
                <th>Banner Type</th>
                <th>Impressions</th> 
                <th>Clicks</th> 
        </tr>                            
    </HeaderTemplate>
    <ItemTemplate>
     <tr>
       <td>
        <%# Eval("AdComments")%></td>
        <td>  <%# Eval("AdImpression")%> </td>
        <td> <%# Eval("AdClicks")%></td> 
     </tr>                
    </ItemTemplate>
    
    <AlternatingItemTemplate>
         <tr>
            <td class="alt">
            <%# Eval("AdComments")%></td>
            <td class="alt">  <%# Eval("AdImpression")%> </td>
            <td class="alt"> <%# Eval("AdClicks")%></td> 
        </tr>                
    </AlternatingItemTemplate>
    
<FooterTemplate>
    <tr class="boldtr" >
        <td class="boldtd">Totals</td>
        <td class="boldtd">
        <asp:Label ID="lblImpressionCount" runat="server" Text=""></asp:Label></td>
        <td class="boldtd"><asp:Label ID="lblClickCount" runat="server" Text=""></asp:Label></td>
    </tr>
    </table><br />
</FooterTemplate>
</asp:Repeater>
    
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:AdConnString %>"
    SelectCommand="SELECT DATEADD(dd,DATEDIFF(dd,0,ast.AdDate),0) as AdDate,al.Comments as AdComments, SUM(CASE WHEN AdType=0 THEN 1 ELSE 0 END) AS AdImpression, SUM(CASE WHEN AdType=1 THEN 1 ELSE 0 END) AS AdClicks FROM Ads al INNER JOIN AdsStats ast ON ast.AdId =al.AdId WHERE AdDate >= DATEADD(dd, DATEDIFF(dd, 0, @AdDate), 0) and AdDate <DATEADD(dd, DATEDIFF(dd, 0, @AdDate), 1) GROUP BY DATEADD(dd,DATEDIFF(dd,0,AdDate),0), al.Comments">
    <SelectParameters>
  <asp:ControlParameter ControlID="lblDate" Name="AdDate"  />
</SelectParameters></asp:SqlDataSource>            
   
</ItemTemplate>
</asp:Repeater>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AdConnString %>"
    SelectCommand="SELECT DISTINCT CONVERT(VARCHAR(12), AdDate, 106) as AdDate FROM AdsStats ORDER BY AdDate"></asp:SqlDataSource>
</div>
<br />        

</form>
</body>
</html>
