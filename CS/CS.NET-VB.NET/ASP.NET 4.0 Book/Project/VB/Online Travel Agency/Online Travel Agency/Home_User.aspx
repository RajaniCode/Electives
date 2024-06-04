<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="Home_User.aspx.vb" Inherits="Online_Travel_Agency.WebForm3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script type="text/javascript">
     function pageLoad()
      {
         var slide = $find('fadeSlide');
         slide.add_slideChanging(animateSlides);
         var ae = $find("fadeAnim");
         var be = ae.get_OnLoadBehavior();
         var an = be.get_animation();
         fadein = an.get_animations()[1];
         fadeout = an.get_animations()[0];
         fadein.set_duration(1.0);
         fadeout.set_duration(1.0);
     }
     function animateSlides() 
     {
         fadein.play();
         window.setTimeout("fadeout.play()", 1000);
     }     
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         <br />
            <asp:Image ID="imgSlideShow" runat="server" Height="272px" Width="540px" 
                BorderWidth="5px" BorderColor="#7C0104" />
            <cc1:AnimationExtender ID="imgSlideShow_AnimationExtender" runat="server" Enabled="True"
                TargetControlID="imgSlideShow" BehaviorID="fadeAnim">
                <Animations>
            <OnLoad>
            <Sequence>
              <FadeOut Duration="0" Fps="20" />
              <FadeIn Duration="0" Fps="20" />
            </Sequence>
            </OnLoad>
                </Animations>
            </cc1:AnimationExtender>
            <cc1:SlideShowExtender ID="imgSlideShow_SlideShowExtender" runat="server" AutoPlay="True"
                Loop="True" SlideShowServiceMethod="GetSlides" TargetControlID="imgSlideShow"
                UseContextKey="True" BehaviorID="fadeSlide">
            </cc1:SlideShowExtender>
            <br />
            <br />
            Bon Voyage allows you to book cars, bus tickets, and train tickets according to your requirements.
            <br />
            <br />
            <table style="width: 100%;">
                <tr>
                    <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Resources/CarButton.jpg" PostBackUrl="~/Car.aspx" /></td>
                    <td><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Resources/BusButton.jpg" PostBackUrl="~/Bus.aspx" /></td>
                    <td><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Resources/TrainButton.jpg" PostBackUrl="~/Train.aspx" /></td>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
