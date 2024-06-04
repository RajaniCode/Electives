<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010DataTableDataViewSortFilter.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="Styles/StyleSheet.css" />
    <link type="text/css" rel="stylesheet" href="Styles/divStyleSheet.css" />
    <style type="text/css">
        .WrapperDiv
        {
            /*width: 560px;*/
            width: 75%;
            height: 250px;
            border: 1px solid black;
        }
        .WrapperDiv TH
        {
            /* Needed for IE */
            position: relative;
        }
        .WrapperDiv TR
        {
            /* Needed for IE */
            height: 0px;
        }
        .ScrollContent
        {
            /* Needed for Opera */
            display: block;
            overflow: auto;
            width: 100%;
            height: 250px;
        }
        .FixedHeader
        {
            /* Needed for opera */
            display: block;
        }
    </style>
    <script type="text/ecmascript">

        var headerHeight = 8;

        /// <summary>
        ///  Responsible for call appropriate function according to browser
        ///  for Browser Compatibility
        /// </summary>
        function onLoad() {
            if (navigator.appName == "Opera") {
                freezeGridViewHeaderForOpera('GridView1');
            }
            else {
                freezeGridViewHeaderForIEAndFF('GridView1', 'WrapperDiv');
            }
        }

        /// <summary>
        ///  Used to create a fixed GridView header and allow scrolling
        ///  for IE and FF (Tested in IE-7 and FF-3.0.3)
        /// </summary>
        /// <param name="gridViewId" type="String">
        ///   Client-side ID of the GridView control
        /// </param>
        /// <param name="wrapperDivCssClass" type="String">
        ///   CSS class to be applied to the GridView's wrapper div element.  
        /// </param>
        function freezeGridViewHeaderForIEAndFF(gridViewId, wrapperDivCssClass) {
            var grid = document.getElementById(gridViewId);
            if (grid != 'undefined') {
                grid.style.visibility = 'hidden';

                var div = null;
                if (grid.parentNode != 'undefined') {
                    //Find wrapper div output by GridView
                    div = grid.parentNode;
                    if (div.tagName == "DIV") {
                        div.className = wrapperDivCssClass;
                        div.style.overflow = "auto";
                    }
                }

                var grid = prepareFixedHeader(grid);
                var tbody = grid.getElementsByTagName('TBODY')[0];

                //Needed for Firefox
                tbody.style.height = (div.offsetHeight - headerHeight) + 'px';

                tbody.style.overflowX = "hidden";
                tbody.overflow = 'auto';
                tbody.overflowX = 'hidden';

                grid.style.visibility = 'visible';
            }
        }

        /// <summary>
        ///  Used to create a fixed GridView header and allow scrolling
        ///  for Opera (Tested in Opera-9.2)
        /// </summary>
        /// <param name="gridViewId" type="String">
        ///   Client-side ID of the GridView control
        /// </param>
        function freezeGridViewHeaderForOpera(gridViewId) {
            var grid = document.getElementById(gridViewId);
            if (grid != 'undefined') {
                grid = prepareFixedHeader(grid);

                var headers = grid.getElementsByTagName('THEAD')[0];
                headers.className = "FixedHeader";

                var tbody = grid.getElementsByTagName('TBODY')[0];
                tbody.className = "ScrollContent";
                var cells = tbody.childNodes[0];

                for (var i = 0; i < cells.childNodes.length; i++) {
                    var tableCell = cells.childNodes[i];
                    var tableCellWidth = getStyle(tableCell, 'width')
                    var headerCell = headers.childNodes[0].childNodes[i];

                    var headerCellWidth = getStyle(headerCell, 'width');

                    if (widthPxToInt(tableCellWidth) > widthPxToInt(headerCellWidth)) {
                        headerCell.style.width = (widthPxToInt(tableCellWidth) - 10) + "px";
                    }
                    else {
                        tableCell.style.width = (widthPxToInt(headerCellWidth) - 10) + "px";
                    }
                }
            }
        }

        /// <summary>
        ///  Used to prepare a fixed GridView header
        /// </summary>
        /// <param name="grid" type="GridView">
        ///   The Reference Of GridView control
        /// </param>
        function prepareFixedHeader(grid) {
            //Find DOM TBODY element and  and 
            var tags = grid.getElementsByTagName('TBODY');
            if (tags != 'undefined') {
                var tbody = tags[0];

                var trs = tbody.getElementsByTagName('TR');

                if (trs != 'undefined') {
                    headerHeight += trs[0].offsetHeight;

                    //Remove first TR tag from it        
                    var headTR = tbody.removeChild(trs[0]);

                    //create a new element called THEAD
                    var head = document.createElement('THEAD');
                    head.appendChild(headTR);

                    //add to a THEAD element instead of TR so CSS styles
                    //can be applied properly in both IE and FireFox
                    grid.insertBefore(head, grid.firstChild);
                }
            }

            return grid;
        }

        function getStyle(oElm, strCssRule) {
            var strValue = "";
            if (document.defaultView && document.defaultView.getComputedStyle) {
                strValue = document.defaultView.getComputedStyle(oElm, "").getPropertyValue(strCssRule);
            }
            else if (oElm.currentStyle) {
                strCssRule = strCssRule.replace(/\-(\w)/g, function (strMatch, p1) {
                    return p1.toUpperCase();
                });
                strValue = oElm.currentStyle[strCssRule];
            }
            return strValue;
        }

        /// <summary>
        ///  Used to convert from Pxel to Integer
        /// </summary>
        /// <param name="width" type="String">
        ///  Width of any thing like GridHeader,GridCell
        /// </param>	
        function widthPxToInt(width) {
            width = width.substr(0, width.length - 2);
            return new Number(width);
        }    
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" Font-Size="12px" BackColor="#FFFFFF"
                    GridLines="Both" CellPadding="4" RowStyle-Wrap="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt">
                    <HeaderStyle BackColor="#EDEDED" BorderStyle="Solid" BorderColor="#000000" BorderWidth="2px" />
                </asp:GridView>
                <br />
                <div id="outer-container">
                    <div id="left-sidebar">
                        <asp:Button ID="Button1" runat="server" Text="DataTable Filter and Sort" OnClick="Button1_Click" />
                    </div>
                    <div id="content-container">
                        <asp:Button ID="Button2" runat="server" Text="Reload" OnClick="Button2_Click" />
                    </div>
                    <div id="right-sidebar">
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="DataView  Filter and Sort" />
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
<script type="text/ecmascript">
    // PageLoad only for sync
    // window.onload = onLoad();
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded
    (
        function (sender, args) 
        {
            // PageLoad for sync and async 
            onLoad();
        }
    ); 
</script>
