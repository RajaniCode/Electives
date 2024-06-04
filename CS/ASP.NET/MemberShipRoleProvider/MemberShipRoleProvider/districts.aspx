<%@ Page Language="C#" AutoEventWireup="true" CodeFile="districts.aspx.cs" Inherits="districts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="en" />
    <title>Kerala Districts</title>
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
		
		
		
				<img src="img-demo/distric.jpg" alt="Kerala Distric" />
			
					
	</div>
	
	
	<div id="main-content">
		
		<div id="main-container-top"></div>
		
		
		<div id="main-container">
			
			<div id="main-container-top-gradient"></div>
			
			
			<div class="row">

				<div class="top_content"><img alt="Kerala Tourism" src="img-demo/kerala_map.jpg" />
				<p><h2>Kerala Districts</h2>The Indian state of Kerala borders with the states of Tamil Nadu on the south and east, Karnataka on the north and the Arabian Sea coastline on the west. The Western Ghats, bordering the eastern boundary of the State, form an almost continuous mountain wall, except near Palakkad where there is a natural mountain pass known as the Palakkad Gap.When the independent India amalgamated small states together Travancore and Cochin states were integrated to form Travancore-Cochin state on 1 July 1949. However, Malabar remained under the Madras province. The States Reorganisation Act of 1 November 1956 elevated Kerala to statehood.
				<br />The state of Kerala is divided into 14 revenue districts. On the basis of geographical, historical and cultural similarities, the districts are generally grouped into Malabar (Northern Kerala) (Kasaragod, Kannur, Wayanad, Kozhikkode, Malappuram); Kochi Region (Central Kerala) (Palakkad, Thrissur, Eranakulam); and Travancore (South Kerala) (Thiruvananthapuram, Kollam, Alappuzha, Pathanamthitta, Kottayam, Idukki).<br /><br /> Such a regional division occurred being part of historical Kingdoms of Kochi, Travancore and British Province of Malabar. The Travancore region is again divided into 3 zones as Northern Travancore (Hill Range) (Pathanamthitta and Idukki), Central Travancore (Central Range) (Alappuzha and Kottayam) and Southern Travancore (South Range) (Thiruvananthapuram and Kollam). Almost all of the districts in Kerala have the same name as the important town or city in the district, the exception being Wayanad district& Ernakulam district.<br /><br /> The 14 districts are further divided into 62 taluks, 999 revenue villages and 1007 Gram panchayats. Some of the districts and their towns were renamed in 1990 like Thiruvananthapuram (formerly known as Trivandrum), Kollam (Quilon), Alappuzha (Alleppey),Thrissur (Trichur or Thirushivaperur), Palakkad (Palghat), Kozhikode (Calicut) and Kannur (Cannanore).
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
