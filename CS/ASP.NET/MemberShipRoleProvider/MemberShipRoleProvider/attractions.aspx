<%@ Page Language="C#" AutoEventWireup="true" CodeFile="attractions.aspx.cs" Inherits="attractions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Kerala Attractions</title>
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
					<li><asp:LinkButton ID="destination" class="nav-current" runat="server">Destination</asp:LinkButton>
						<ul>
							<li><asp:LinkButton ID="district" runat="server">Districts</asp:LinkButton></li>
							<li><asp:LinkButton ID="attraction" runat="server">Attractions</asp:LinkButton></li>
							<li><asp:LinkButton ID="popularDestination" runat="server">Popular destinations</asp:LinkButton></li>
						</ul>
					</li>
					<li><asp:LinkButton ID="foodaccomodation" runat="server">Food &amp; Accomodation</asp:LinkButton></li>
					<li><asp:LinkButton ID="travelAssistance" runat="server">Travel Assistance</asp:LinkButton></li>
					
				</ul>
				
			</div>
			
			
		</div>
		
		
		
		
		
			
	</div>
			
    <div id="full-width-slider-small">		
		
				<img src="img-demo/attraction.jpg" alt="Kerala Attractiions" />	
					
	</div>
	
	
	<div id="main-content">
		
		<div id="main-container-top"></div>
		
		
		<div id="main-container">
			
			<div id="main-container-top-gradient"></div>
			
			
			<div class="row">

				<div class="top_content"><img alt="Kerala Tourism" src="img-demo/kerala_attractions_thump.jpg" />
				<p><h2>Kerala Attractions</h2>Kerala is one of the most popular tourist destinations in India. It's well known for its Backwaters, Beaches, National Parks, Wild life sanctuaries, Hill stations and Ayurvedic treatments. Kerala Beaches are spread along the 900 km Arabian Sea coastline. The Kerala Backwaters are a network of interconnected brackish lagoons and lakes lying parallel to the Arabian Sea coast.<br />
				<h2>Thiruvananthapuram </h2>
				Thiruvananthapuram is the capital of Kerala state. This ancient city was the spiritual centre of Travancore kings since 11th century and became their capital in 1750 AD. Thiruvananthapuram is ranked top in the number of foreign tourists visiting Kerala and is a beautiful destination for holidaymakers.<br /><h2>Alappuzha</h2>Alappuzha (Alleppy) 'The Venice of the East' is endowed with exceptional natural beauty and emerged as a major tourist destination. The entire district teams with an array of rivers, canals and lakes ideal for boat cruise.</p>
				<br /><h2>Periyar Wild life Sanctuary, Thekkady</h2>One of the most popular wildlife sanctuaries of the country and is also India's southern most tiger reserve. The sanctuary sprawls over an area of 777 sq. kms. near a vast and attractive lake. The artificial lake was built by the British in 1895 AD.<br />
				Munnar or the 'three rivers' nestles amidst Western Ghats at the confluence of three mountain streams (Mudrapuzha, Nallathani, and Kundala). It is one of the most popular tourist destinations of Kerala. Kerala tourist attractions gives more details about Munnar <br />
				Kochi
<h2>Kochi</h2>
Kochi, also known as the "Queen of Arabian Sea" is the most important commercial place of this beautiful State of Kerala.. The Chinese fishing nets, Dutch buildings, Portuguese artistics, British monuments, etc. add the beauty of Kochi(Cochin).
<br /><h2>Thrissur</h2>

Thrissur, the 'Cultural Capital' of Kerala has been of great religious and cultural significance for many centuries. The district is endowed with rich history and culture and has played an important role in the political history of South India. Thrissur is an important place in Kerala tourist attractions.				
				
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
