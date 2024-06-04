<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Dynamically Populating Accordion</title>
<style type="text/css">
    body
    {
        font: normal 11px auto "Trebuchet MS", Verdana;    
        background-color: #ffffff;
        color: #4f6b72;       
    }
    .header
    {
        color: #4f6b72;
        background: #D5EDEF;
        margin-bottom:10px;
    }
    .headerSelected
    {
       background: #F5FAFA;
        color: #797268;
    }
    .contentAcc
    {
        background: #fff;          
        color: #4f6b72;
    }
</style>
</head>
<body>
<form id="form1" runat="server">
<div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"             
    SelectCommand="SELECT [EmployeeID], [FirstName], [LastName], [Notes] FROM [Employees]" >
    </asp:SqlDataSource>
    <h2>About US</h2><br />
    <cc1:Accordion ID="Accordion1" runat="server"
        SelectedIndex="0"
        HeaderCssClass="header"
        HeaderSelectedCssClass="headerSelected"
        ContentCssClass="contentAcc"
        AutoSize="None"
        FadeTransitions="true"
        TransitionDuration="350"
        SuppressHeaderPostbacks = "true"
        DataSourceID="SqlDataSource1"         
        >
        <HeaderTemplate>
        <b>
        <a href="">
            <%#DataBinder.Eval(Container.DataItem, "FirstName")%> 
            <%#DataBinder.Eval(Container.DataItem, "LastName")%>
        </a>
        </b>

        </HeaderTemplate>

        <ContentTemplate> 
         <div style="float:left; margin:8px;">                      
            <asp:Image ID="Image1" runat="server" 
            ImageUrl='<%# "DisplayImage.ashx?id=" + Eval("EmployeeID") %>' />
         </div>
         <div style="margin-top:8px;">
            <%#DataBinder.Eval(Container.DataItem, "Notes")%>
        </div>
        </ContentTemplate>
    </cc1:Accordion>

</div>
</form>
</body>
</html>
