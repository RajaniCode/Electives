<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript" src="http://code.jquery.com/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(function() {
            $("#MoveRight,#MoveLeft").click(function(event) {                
                var id = $(event.target).attr("id");
                var selectFrom = id == "MoveRight" ? "#SelectLeft" : "#SelectRight";
                var moveTo = id == "MoveRight" ? "#SelectRight" : "#SelectLeft";

                var selectedItems = $(selectFrom + " :selected").toArray();
                $(moveTo).append(selectedItems);
                selectedItems.remove;
            });
        });
    </script>   
    
    <form method="get">              
        <select id="SelectLeft" multiple="multiple">
            <option value="1">Australia</option>
            <option value="2">New Zealand</option>
            <option value="3">Canada</option>
            <option value="4">USA</option>
            <option value="5">France</option>
        </select>
            
        <input id="MoveRight" type="button" value=" >> " />
        <input id="MoveLeft" type="button" value=" << " />
        
        <select id="SelectRight" multiple="multiple">           
        </select>
    </form>
</asp:Content>
