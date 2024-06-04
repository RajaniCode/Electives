<%@ Page Language="C#" AutoEventWireup="true" CodeFile="overview.aspx.cs" Inherits="overview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kerala Overview</title>
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
					<li><asp:LinkButton ID="kerala_overview" class="nav-current" runat="server">Kerala Overview</asp:LinkButton></li>
					<li><asp:LinkButton ID="destination" runat="server">Destination</asp:LinkButton>
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
			
    <div id="full-width-overviewmall">		
		<img src="img-demo/overview_top_bg.jpg" alt="Kerala Overview" />					
	</div>
	
	
	<div id="main-content">
		
		<div id="main-container-top"></div>
		
		
		<div id="main-container">
			
			<div id="main-container-top-gradient"></div>
			
			
			<div class="row">

				<div class="top_content"><img alt="Kerala Tourism" src="img-demo/kerala_overview.jpg" />
				<p><h2>Kerala Overview</h2>Kerala is a top tourist destination. National Geographic's Traveller magazine names Kerala as one of the "ten paradises of the world" and "50 must see destinations of a lifetime".Travel and Leisure names Kerala as "One of the 100 great trips for the 21st century". The Kerala Government Tourism Department, a government department in charge of promoting tourism has adopted the slogan God's Own Country for its campaigns.
				<h2>Tourism</h2>
				Kerala is an established tourist destination for both Indians and non-Indians alike. Tourists mostly visit such attractions as the beaches at Kovalam, Cherai and Varkala, the hill stations of Munnar, Nelliampathi, and Ponmudi, and national parks and wildlife sanctuaries such as Periyar and Eravikulam National Park. The "backwaters" region — an extensive network of interlocking rivers, lakes, and canals that center on Alleppey, Kumarakom, and Punnamada — also see heavy tourist traffic. Examples of Keralite architecture, such as the Padmanabhapuram Palace, Padmanabhapuram, are also visited. The capital city Thiruvananthapuram, Kochi(called as the "Queen of the Arabian Sea"), and Alappuzha(called the "Venice of the East"), are popular destinations. Tourism plays an important role in the state's economy.
				<h2>Culture</h2>
				Kerala's culture is derived from both a Tamil-heritage region known as Tamilakam and southern coastal Karnataka. Later, Kerala's culture was elaborated upon through centuries of contact with neighboring and overseas cultures.Native performing arts include koodiyattom (a 2000-year-old Sanskrit theatre tradition,officially recognised by UNESCO as a Masterpiece of the Oral and Intangible Heritage of Humanity[168]), kathakali—from katha ("story") and kali ("performance")—and its offshoot Kerala natanam, Kaliyattam -(North Malabar special), koothu (akin to stand-up comedy), mohiniaattam ("dance of the enchantress"), Theyyam, thullal NS padayani. Kathakali and Mohiniattam are widely recognized Indian Classical Dance traditions from Kerala.
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
