<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="BackToTop.aspx.cs" Inherits="BackToTop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".backtotoplink").attr("innerHTML", "Back to Top");
            $(".backtotoplink").attr("title", "Back to Top");
            $(".backtotoplink").attr("href", "#Top");
        });
    </script>
    <style type="text/css">
        .backtotoplink
        {
            color: Blue;
            cursor: hand;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:HyperLink ID="Top" runat="server"></asp:HyperLink>
        <div style="width: 300px; border: solid;">
            Content 1
            <br />
            JQuery is the most widely used JavaScript library in web applications today, supported
            by an active community of developers. It is a complex JavaScript object, could be
            think of as a wrapper over selected DOM elements with extended functionality. JQuery
            is designed to be lightweight, cross browser, and CSS3 compliant. It simplifies
            the way DOM elements are selected, and make your operations on that elements. jQuery
            can be implemented with various web platforms such as .NET, PHP and Java. Now having
            the official support of Microsoft, it is now distributed with Visual Studio (Version
            2010 onwards). The library has gained popularity with ASP.NET developers. jQuery
            can be very easily implemented with ASP.NET controls as well as custom user controls.
            It can be used to validate controls using client side scripts, incorporate cool
            animation effects. jQuery Selectors allow you to select DOM elements so that you
            can apply functionality to them with jQuery’s functional methods, and helps to encorporate
            CSS very easily. Using CSS means that you use selector syntax you’re probably already
            familiar with from HTML styling. You can select elements by id, CSS class, attribute
            filters, by relationship to other element and also filter conditions that can be
            combined together.
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="backtotoplink"></asp:HyperLink>
        <div style="width: 300px; border: solid;">
            Content 2
            <br />
            JQuery is the most widely used JavaScript library in web applications today, supported
            by an active community of developers. It is a complex JavaScript object, could be
            think of as a wrapper over selected DOM elements with extended functionality. JQuery
            is designed to be lightweight, cross browser, and CSS3 compliant. It simplifies
            the way DOM elements are selected, and make your operations on that elements. jQuery
            can be implemented with various web platforms such as .NET, PHP and Java. Now having
            the official support of Microsoft, it is now distributed with Visual Studio (Version
            2010 onwards). The library has gained popularity with ASP.NET developers. jQuery
            can be very easily implemented with ASP.NET controls as well as custom user controls.
            It can be used to validate controls using client side scripts, incorporate cool
            animation effects. jQuery Selectors allow you to select DOM elements so that you
            can apply functionality to them with jQuery’s functional methods, and helps to encorporate
            CSS very easily. Using CSS means that you use selector syntax you’re probably already
            familiar with from HTML styling. You can select elements by id, CSS class, attribute
            filters, by relationship to other element and also filter conditions that can be
            combined together.
        </div>
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="backtotoplink"></asp:HyperLink>
        <div style="width: 300px; border: solid;">
            Content 3
            <br />
            JQuery is the most widely used JavaScript library in web applications today, supported
            by an active community of developers. It is a complex JavaScript object, could be
            think of as a wrapper over selected DOM elements with extended functionality. JQuery
            is designed to be lightweight, cross browser, and CSS3 compliant. It simplifies
            the way DOM elements are selected, and make your operations on that elements. jQuery
            can be implemented with various web platforms such as .NET, PHP and Java. Now having
            the official support of Microsoft, it is now distributed with Visual Studio (Version
            2010 onwards). The library has gained popularity with ASP.NET developers. jQuery
            can be very easily implemented with ASP.NET controls as well as custom user controls.
            It can be used to validate controls using client side scripts, incorporate cool
            animation effects. jQuery Selectors allow you to select DOM elements so that you
            can apply functionality to them with jQuery’s functional methods, and helps to encorporate
            CSS very easily. Using CSS means that you use selector syntax you’re probably already
            familiar with from HTML styling. You can select elements by id, CSS class, attribute
            filters, by relationship to other element and also filter conditions that can be
            combined together.
        </div>
        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="backtotoplink"></asp:HyperLink>
    </div>
</asp:Content>
