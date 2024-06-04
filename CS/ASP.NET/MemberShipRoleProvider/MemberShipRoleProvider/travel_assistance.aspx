<%@ Page Language="C#" AutoEventWireup="true" CodeFile="travel_assistance.aspx.cs" Inherits="travel_assistance" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Kerala Travel Assistance</title>
	<link rel="stylesheet" type="text/css" href="style.css" />
	</head>
<body>
    <form id="form1" runat="server">
    <div id="full-width-header-small">
		
		
		<div id="header">
		
			
			<div id="logo_menu">
					<h1>
            <asp:ImageButton ID="logo" runat="server" ImageUrl="img-demo/logo.png"/>
	</h1>
				<div id="logo-bottom">&nbsp;
					<div id="logo-bottom-left"></div>
					<div id="logo-bottom-right"></div>
				</div>
			</div>
			
			<div id="nav">
				
				<div id="nav-left"></div>
				<div id="nav-right"></div>
				
				<ul>
					<li>
                    <asp:LinkButton ID="home" runat="server">Home</asp:LinkButton></li>
					<li><asp:LinkButton ID="kerala_overview" runat="server">Kerala Overview</asp:LinkButton></li>
					<li><asp:LinkButton ID="destination" runat="server">Destination</asp:LinkButton>
						<ul>
							<li><asp:LinkButton ID="district" runat="server">Districts</asp:LinkButton></li>
							<li><asp:LinkButton ID="attraction" runat="server">Attractions</asp:LinkButton></li>
							<li><asp:LinkButton ID="popularDestination" runat="server">Popular destinations</asp:LinkButton></li>
						</ul>
					</li>
					<li><asp:LinkButton ID="foodaccomodation" runat="server">Food &amp; Accomodation</asp:LinkButton></li>
					<li><asp:LinkButton ID="travelAssistance" class="nav-current" runat="server">Travel Assistance</asp:LinkButton></li>
					
				</ul>
				
			</div>
			
			
		</div>
		
		</div>
			
    <div id="full-width-slider-small">			
				<img src="img-demo/travel_assistance.jpg" alt="Travel Assistance" />					
	</div>
	
	
	<div id="main-content">
		
		<div id="main-container-top"></div>
		
		
		<div id="main-container">
			
			<div id="main-container-top-gradient"></div>
			
			
			<div class="row">

				<div class="top_content"><img alt="Kerala Tourism" src="img-demo/travel_assistance_thump.jpg" />
				<p>
				<h2>Money</h2>
There is no limit to the amount of foreign currency that visitors can bring.<br/>
<h2>Banks</h2>
Banks are open for transaction from 10:00 - 15:30 hrs on weekdays and from 10:00 - 12:00 hrs on Saturdays.<br/>
<h2>Credit Cards</h2>
Main hotels, restaurants and shopping centres honour major credit cards. )<br/>
<h2>Time</h2>
(Hours fast (+), slow (-) on IST)<br/>
USA: -10.30, Germany: - 4.30, Canada: - 10.30, France: - 4.30, Australia: + 4.30, Spain: - 4.30, UAE: - 1.30, UK: - 5:30. )<br/>
<h2>Travel Kit</h2>
Cotton outfits; hats, sunglasses, sunscreen lotion etc.<br/>
<h2>Drugs</h2>
Heavy penalties including imprisonment for possession of narcotic drugs.<br/>
<h2>Ayurveda</h2>
Go only to those Ayurveda centres that are classified/approved by the Department of Tourism. <br/>
<h2>Food</h2>
All standard restaurants offer a variety of cuisines including Continental, Chinese, Indian and typical Kerala fare.<br/>
<h2>Water</h2>
Tap water is purified and quite safe to drink. It is not advisable to drink water from slow moving streams, lakes or dams. Bottled water is also available.<br/>
<h2>Emergency Numbers</h2>
Police control room: 100<br/>
Fire station: 101<br/>
Ambulance: 102, 108<br/>
<h2>Police Helpline</h2>
While traveling on Highways (Highway Alert Number): 9846 100 100<br/>
While traveling in Trains (Railway Alert Number): 9846 200 100<br/>
<h2>Temple Codes</h2>
Some temples do not permit entry to non-Hindus. Strict dress codes are followed in most of the temples. Footwear is banned inside the temple premises.<br/>
<h2>Nudity</h2>
Nudity is not allowed in any Kerala beach.<br/>
<h2>Smoking</h2>
Smoking is banned in public places. .<br/>
<h2>Footwear in Houses</h2>
Visitors to most Kerala houses leave their footwear outside before entering the house. .<br/>
<h2>Demonstrativeness in Public</h2>
Behaviour, demonstrating affection in public like hugging or kissing is not an accepted practice in Kerala. .<br/>
<h2>Wildlife Sanctuaries</h2>
To visit a wildlife sanctuary, prior permission has to be taken from the authority concerned of the sanctuary.<br/><br/>
For further enquiries, contact: The Chief Conservator of Forests, Thiruvananthapuram 695 014, Tel: + 91 471 2322217


				
				
				</p>
				
				</div>
			
			</div>
			
			
			
			
			
		</div>
				
		<div id="main-container-bottom"></div>
	<div id="footer-copyright">
				&copy; Copyright 2011 All rights are Reserved by <a href="#">The Kerala Tours</a>
				</div>
	</div>

    </form>
</body>
</html>
