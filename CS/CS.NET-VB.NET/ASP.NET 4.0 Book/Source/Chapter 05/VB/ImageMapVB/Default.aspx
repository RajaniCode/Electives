<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Image Map Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:label id="Label1" runat="server" font-bold="True" 
 					  font-underline="True" text="ImageMap Control Example"> </asp:label>
					<br />
					<br />
					<br />
					<asp:imagemap id="ImageMap1" runat="server" 
 					  imageurl="~/SampleImageMap.jpg">
					<asp:RectangleHotSpot AlternateText="HOTSPOT 1" Bottom="10" HotSpotMode="Navigate" Left="20" 
 					  NavigateUrl="~/Default2.aspx" Right="50" 
					Target="_self" Top="100" />
					    <asp:RectangleHotSpot />
                        <asp:RectangleHotSpot />
					</asp:imagemap>
					<br />
					<br />
					<br />

    </div>
    </form>
</body>
</html>
