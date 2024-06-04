<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="index.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to our Kerala tourism</title>    
    <link rel="stylesheet" type="text/css" href="style.css" />
	</head>
<body>
    <form id="form1" runat="server">
    
	
	<div id="full-width-header">
		
		
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
                    <asp:LinkButton ID="home" class="nav-current" runat="server">Home</asp:LinkButton></li>
					<li><asp:LinkButton ID="kerala_overview" runat="server">Kerala Overview</asp:LinkButton></li>
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
			
			<div id="slider-control">
				<a id="slider-button-left" href="#"></a>
				<a id="slider-button-right" href="#"></a>
			</div>
			
			
		</div>
		
		<div id="top-area">
				
			
			
			<div id="top-area-bottom"></div>
			
		</div>
		
			
	</div>
	
	<div id="full-width-slider">	
	</div>
	
	<div id="main-content">
		
		<div id="main-container-top"></div>
		
		
		<div id="main-container">
			
			<div id="main-container-top-gradient"></div>
			
			
			<div class="row">

				<div class="top_content"><img alt="Kerala Tourism" src="img-demo/kerala_tours.jpg" /><p><h2>
                        <asp:Label ID="description" runat="server" Text="Label"></asp:Label>
                    </p></div>
			
			</div>
			
			<div class="row row-grid-pattern">
				<h2>Gallareis</h2>
				
							
				
				<div id="testimonials-first-container">
				
					<a id="testimonials-button-left" class="button-left-blue" href="#"></a>
					<a id="testimonials-button-right" class="button-right-blue" href="#"></a>
					<div id="testimonials-button-left-disabled" class="button-left-disabled"></div>
					<div id="testimonials-button-right-disabled" class="button-right-disabled"></div>
					
					
					
					<div id="testimonials-second-container">
				
						
						<div id="testimonials-slide">
						
							
							<div class="testimonial">
							
								<div class="testimonial-top"></div>
							
								
								<div>
									
								<img alt="" src="img-demo/gallery_1.jpg" />
									
									
									
								</div>
								
								
								<div class="testimonial-bottom"></div>
								
							</div>
													
							
							<div class="testimonial">
							
								<div class="testimonial-top"></div>
							
								
								<div>
									<img src="img-demo/gallery_2.jpg" />
								</div>
								
								
								<div class="testimonial-bottom"></div>
								
							</div>
							
							<div class="testimonial">
							
								<div class="testimonial-top"></div>
							
								
								<div>
									<img alt="" src="img-demo/gallery_3.jpg" />
								</div>
								
								
								<div class="testimonial-bottom"></div>
								
							</div>
							
							<div class="testimonial">
							
								<div class="testimonial-top"></div>
							
								
								<div>
									<img alt="" src="img-demo/gallery_4.jpg" />
								</div>
								
								
								<div class="testimonial-bottom"></div>
								
							</div>
							
							<div class="testimonial">
							
								<div class="testimonial-top"></div>
							
								
								<div>
									<img alt="" src="img-demo/gallery_5.jpg" />
								</div>
								
								
								<div class="testimonial-bottom"></div>
								
							</div>
							

						</div>
						
					
					</div>
					
					
				</div>	
				
				
			</div>
			
			<div class="row row-last">
			
				
				<div class="column-fourth-width">
					<h2>Location</h2>
					
					<p>
						<a href="#"><img src="img-demo/mountain.jpg" alt="" /></a>
					</p>
					<p>
						Kerala is a travel destination that one would not want to miss in his / her lifetime. The reasons can be many.
Those who have visited Kerala, they eagerly look forward to their next.<br/>
						<asp:LinkButton class="button" ID="learn_more_destination" runat="server">Learn More</asp:LinkButton>
					</p>
				</div>
				
				<div class="column-fourth-width">
					<h2>History</h2>
					
					<p>
						<a href="#"><img src="img-demo/book.jpg" alt="" /></a>
					</p>
					<p>
						Kerala is a top tourist destination. National Geographic's Traveller magazine names Kerala as one of the "ten paradises of the world" and "50 must see destinations of a lifetime". <br/>
						<asp:LinkButton class="button" ID="learn_more_history" runat="server">Learn More</asp:LinkButton>
					</p>
				</div>
				
				<div class="column-fourth-width">
					<h2>Destinations</h2>
					
					<p>
						<a href="#"><img src="img-demo/massage.jpg" alt="" /></a>
					</p>
					<p>
						Referred to as the Venice of the East, Alappuzha has always enjoyed an important place in the maritime history of Kerala. <br/>
						<asp:LinkButton class="button" ID="travel_more" runat="server">Learn More</asp:LinkButton>
					</p>
				</div>
				
				<div class="column-fourth-width column-last">
					<h2>Kerala Special</h2>
					
					<p>
						<a href="#"><img src="img-demo/destination.jpg" alt="" /></a>
					</p>
					<p>
						Coconuts grow in abundance in Kerala, and consequently, coconut kernel, (sliced or grated) coconut cream and coconut milk are widely used in dishes for thickening and flavoring. <br/>
						<asp:LinkButton class="button" ID="kerala_special" runat="server">Learn More</asp:LinkButton>
					</p>
				</div>
				
				
				<div class="clear"></div>
				
			</div>
			
		</div>
				
		<div id="main-container-bottom"></div>
	
	</div>
	<div id="full-width-footer">
	
		<div id="footer-image"></div>
		
		<div id="footer-mask"></div>
		
		<div id="footer-content-container">
			
			
			<div id="footer-content">
			
				
				<div class="column-fifth-width">
					<h3>Travel Desk</h3>
					<ul>
						<li><a href="#">Plan Your Trip</a></li>
						<li><a href="#">Message Board</a></li>
						<li><a href="#">Contact</a></li>
						<li><a href="#">Travel Tips</a></li>
						<li><a href="#">Maps</a></li>
						<li><a href="#">Information Centres</a></li>
						
					</ul>
				</div>
				<div class="column-fifth-width">
					<h3>Service Providers</h3>
					<ul>
						<li><a href="#">Ayurveda Centres</a></li>
						<li><a href="#">Homestays</a></li>
						<li><a href="#">Serviced Villas</a></li>
						<li><a href="#">Houseboats</a></li>
						<li><a href="#">Tour Operators</a></li>
						<li><a href="#">Tourist Guides</a></li>
						<li><a href="#">Tourist Guides</a></li>
						
					</ul>
				</div>
				<div class="column-fifth-width">
					<h3>About The Palace</h3>
					<ul>
						<li><a href="#">Overview</a></li>
						<li><a href="#">Lorem ipsum</a></li>
						<li><a href="#">Team</a></li>
					</ul>	
					
				</div>
				<div class="column-fifth-width">
					<h3>Packages</h3>
					<ul>
						<li><a href="#">Massage &amp; Spa week</a></li>
						<li><a href="#">Bed &amp; Breakfast</a></li>
						<li><a href="#">Friday to Monday</a></li>
					</ul>	
					
				</div>
				<div class="column-fifth-width column-last">
					<h3>Footer easy to use</h3>
					<ul>
						<li><a href="#">Massage &amp; Spa week</a></li>
						<li><a href="#">Bed &amp; Breakfast</a></li>
						<li><a href="#">Friday to Monday</a></li>
					</ul>	
				</div>
				<div class="clear"></div>																																																																																								
				
				<div id="footer-copyright">
				&copy; Copyright 2011 All rights are Reserved by <a href="#">The Kerala Tours</a>
				</div>
				</div>
					
		</div>
		
	</div>
		
	  </form>
</body>
</html>
