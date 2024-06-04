<%@ Control Language="C#" AutoEventWireup="true" Codebehind="RSSFeed.ascx.cs" Inherits="ContentLoading.RSSFeed" %>
<%@ Register Assembly="RssToolkit" Namespace="RssToolkit" TagPrefix="cc1" %>

<cc1:RssDataSource ID="rssData" runat="server" Url="http://tempuri.com" MaxItems="5" />

<asp:Panel runat="server" ID="pnlRSS" CssClass="RSSBlock" Width="275">

    <asp:Label runat="Server" ID="lblHeader" Text="Headlines" Visible="False" />
    
    <asp:UpdatePanel runat="Server" ID="updateRSS" UpdateMode="Conditional">
        <contenttemplate>
      <asp:MultiView runat="server" ID="mvRSS" ActiveViewIndex="0" >

        <%-- This is the default view that will load with the page --%>
        
        <asp:View runat="Server" ID="view1">
          <asp:image runat="server" ID="image1" 
            ImageAlign="middle" ImageUrl="spinner.gif" />
          <asp:Label runat="Server" ID="label1" 
            Text="Loading..." Font-Size="smaller" ForeColor="orange" />
        </asp:View>

        <%-- 
          This is the where you will display the content that you want to
          load AFTER the page loads.  In this example, the RSS headlines
          will be retrieved and displayed here. 
        --%>
        <asp:View runat="server" ID="view2">
          <asp:Repeater runat="Server" ID="rptRSS">
            <HeaderTemplate>
                <asp:Label runat="Server" id="lblRSSHeader" 
                    Text='<%# lblHeader.Text %>'
                    Class="RSSHeader" />
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
              <li>
                <asp:hyperlink runat="server" ID="linkRSS"
                  Text='<%# Eval("Title") %>' 
                  NavigateUrl='<%# Eval("Link") %>' />
              </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
          </asp:Repeater> 
        </asp:View>

        <%-- This is displayed if the content fails to load --%>
        <asp:View runat="Server" ID="view3">
          <asp:Label runat="Server" ID="lblNoData" 
            Text="Unable to load headlines at this time." 
            Font-Size="smaller" ForeColor="orange" />
        </asp:View>
      </asp:MultiView> 


      <%-- 
        The timer works in millisecond intervals.  A setting of "1" 
        will begin loading the block almost instantly after the page loads. 
      --%>
      <asp:Timer ID="timerRSS" Interval="1" OnTick="DisplayRSS" runat="server" /> 


    </contenttemplate>
    </asp:UpdatePanel>
</asp:Panel>
