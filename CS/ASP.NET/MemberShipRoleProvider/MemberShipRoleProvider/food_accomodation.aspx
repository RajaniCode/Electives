<%@ Page Language="C#" AutoEventWireup="true" CodeFile="food_accomodation.aspx.cs" Inherits="food_accomodation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kerala food and accomodation</title>
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
					<li><asp:LinkButton ID="foodaccomodation"  class="nav-current" runat="server">Food &amp; Accomodation</asp:LinkButton></li>
					<li><asp:LinkButton ID="travelAssistance" runat="server">Travel Assistance</asp:LinkButton></li>
					
				</ul>
				
			</div>
			
			
		</div>	
			
	</div>
			
    <div id="full-width-slider-small">		
		
				<img src="img-demo/kerala_food.jpg" alt="Kerala Food" />				
	</div>
	
	
	<div id="main-content">
		
		<div id="main-container-top"></div>
		
		
		<div id="main-container">
			
			<div id="main-container-top-gradient"></div>
			
			
			<div class="row">

				<div class="top_content"><img alt="Kerala Tourism" src="img-demo/food_thump.jpg" />
				<p><h2>Homestay</h2>

One of the many fascinating experiences for visitors to Kerala is without doubt the Home Stays. These are literally home away from home, allowing you to get close with the host family and the community that lives in an area.

Tucked away in misty plantation hills, amidst cool coconut groves, circled by backwaters, by the side of sun drenched beaches or in villages with distinct characteristics; home stays in Kerala offer you one of the most favoured means by visitors to enjoy and experience the culture, lifestyle and flavours of the land and its people. 
	<br /><h2>Food</h2>In Ayurveda food and drinks are classified according to their taste - sweet, salty, spicy, sour, hot, cold and bitter - and thus by their influence on the doshas. All tastes should be represented in each meal, but within the proportionally specific requirements for each individual guest.
				<br /><br />Coconuts grow in abundance in Kerala, and consequently, coconut kernel, (sliced or grated) coconut cream and coconut milk are widely used in dishes for thickening and flavoring. Kerala's long coastline, numerous rivers and backwater networks, and strong fishing industry have contributed to many sea and river food based dishes. Rice and cassava (Tapioca) form the staple food of Kerala. All main dishes are made with them and served along with Kootan; the side dishes which may be made from vegetables, meat, fish or a mix of all of them. The main dish for lunch and dinner is boiled rice. The Kerala breakfast shows a rich variety; the main dishes for which are made from rice flour, or fresh or dried cassava. Owing to the weather and the availability of spices, the Kerala cuisine is richly spicy especially the hot ones -chilly, black pepper, cardamom, cloves, ginger, and cinnamon.
				<br /><h2>Spices in Kerala Cuisine</h2>
				
				
				
				As with almost all Indian food, spices play an important part in Kerala cuisine. The main spices used are cinnamon, cardamom, ginger, green and red peppers, cloves, garlic, cumin seeds, coriander, turmeric, and so on. Few fresh herbs are used, unlike in European cuisine, and mainly consist of the commonly used curry leaf, and the occasional use of fresh coriander and mint. While Tamarind and lime are used to make sauces sour in North Malabar areas; the Travancore region uses only kodampuli (Garcinia cambogia), as sour sauces are very popular in Kerala. Sweet and sour dishes are however, rare, but exceptions like the ripe mango version of the pulissery and tamarind-jaggery-ginger chutney known as puliinji or injipuliwhich is also known as Sou Ginger are popular.
				<br />
				
				<h2>Lunch and dinner</h2>

The staple food of Kerala, like most South-Indian states, is rice. Unlike other states, however, many people in Kerala prefer parboiled rice (Choru) (rice made nutritious by boiling it with rice husk). Kanji (rice congee), a kind of rice porridge, is also popular. Tapioca, called kappa in Kerala, is popular in central Kerala and in the highlands, and is frequently eaten with fish curry.
Baked Tapioca dish<br /><br />

Rice is usually consumed with one or more curries. Accompaniments with rice may include upperis (dry braised or sauteed vegetables), rasam, chips, and/or buttermilk (called moru). Vegetarian dinners usually consist of multiple courses, each involving rice, one main dish (usually sambar, rasam, puli-sherry), and one or more side-dishes. Kerala cooking uses coconut oil almost exclusively, although health concerns and cost have led to coconut oil being replaced to some extent by palm oil and vegetable oil.
<br /><br />
Popular vegetarian dishes include sambar, aviyal, Kaalan, thoran, (Poduthol (dry curry), pulisherry (morozhichathu in Cochin and the Malabar region), olan, erisherry, puliinji, payaru (mung bean), kappa (tapioca), etc. Vegetarian dishes often consist of fresh spices that are liquefied and crushed to make a paste-like texture to dampen rice
				
				
				
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
