<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Accordion Tips and Tricks</title>
    <style type="text/css">
        .accordionHeader
        {
            color: white;
            background-color: #719DDB;
            font: bold 11px auto "Trebuchet MS", Verdana;
            font-size: 12px;
            cursor: pointer;
            padding: 4px;
            margin-top: 3px;
        }
        .accordionContent
        {
            background-color: #DCE4F9;
            font: normal 10px auto Verdana, Arial;
            border: 1px gray;                
            padding: 4px;
            padding-top: 7px;
        }
</style>
    
<script type="text/javascript">
    function pageLoad()
    {
        //hideAccordionPane(1);
        //changeSelected(2);
        //var accCtrl = $find('<%= AccordionCtrl.ClientID %>'+'_AccordionExtender');
        //accCtrl.add_selectedIndexChanged(onAccordionPaneChanged);   
        //AddPaneAtRuntime();
        // Prevent Pane 3 from expanding
        // RemoveHandlerAtRuntime(2);           
        //AddMouseOverToAccordion();
    }
    
    
    function AddMouseOverToAccordion()
    {
        var acc = $find('AccordionCtrl_AccordionExtender');
        for(paneIdx = 0; paneIdx < acc.get_Count(); paneIdx++)
        {                
            $addHandler(acc.get_Pane(paneIdx).header,"mouseover",acc._headerClickHandler);
        }  
    }
            
    function RemoveHandlerAtRuntime(pane)
    {
         $removeHandler($find('AccordionCtrl_AccordionExtender').get_Pane(pane).header,"click",$find('AccordionCtrl_AccordionExtender')._headerClickHandler);
    }
    
    function AddPaneAtRuntime()
    {
        var newAccordion = $find("AccordionCtrl_AccordionExtender");
        var header = document.createElement("div");
        header.innerText = "Pane 5";
        header.className = "accordionHeader"; //set header css                        
        var content = document.createElement("div");
        content.innerText = "This pane was added using JavaScript";
        content.className = "accordionContent"; // set content css
        newAccordion.get_element().appendChild(header);
        newAccordion.get_element().appendChild(content);
        newAccordion.addPane(header,content);        
    }

    // hides pane 1
    function hideAccordionPane(paneno)
    {
        $find('AccordionCtrl_AccordionExtender').get_Pane(paneno).header.style.display="none";
        $find('AccordionCtrl_AccordionExtender').get_Pane(paneno).content.style.display="none";
    }
    
    // expand given accordion pane
    function changeSelected(idx)
    {
        $find('AccordionCtrl_AccordionExtender').set_SelectedIndex(idx);
    }
    
    function onAccordionPaneChanged(sender, eventArgs)
    {
        var selPane = sender.get_SelectedIndex() + 1;
        alert('You selected Pane ' + selPane);
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <cc1:Accordion ID="AccordionCtrl" runat="server" 
        SelectedIndex="0" HeaderCssClass="accordionHeader"
        ContentCssClass="accordionContent" AutoSize="None" 
        FadeTransitions="true">
            <Panes>
                <cc1:AccordionPane ID="AccordionPane0" runat="server">
                    <Header>Pane 1</Header>
                    <Content>
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit, 
                        sed do eiusmod tempor incididunt ut labore et dolore magna 
                        aliqua. 
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>Pane 2</Header>
                    <Content>
                        Ut enim ad minim veniam, quis nostrud exercitation ullamco 
                        laboris nisi ut aliquip ex ea commodo consequat. 
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>Pane 3</Header>
                    <Content>
                        Duis aute irure dolor in reprehenderit in voluptate velit 
                        esse cillum dolore eu fugiat nulla pariatur.
                    </Content>               
                </cc1:AccordionPane>
                <cc1:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>Pane 4</Header>
                    <Content>
                        Excepteur sint occaecat cupidatat non proident, sunt in 
                        culpa qui officia deserunt mollit anim id est laborum.
                    </Content>
                </cc1:AccordionPane>
            </Panes>
        </cc1:Accordion>        
    </div>
    </form>
</body>
</html>
