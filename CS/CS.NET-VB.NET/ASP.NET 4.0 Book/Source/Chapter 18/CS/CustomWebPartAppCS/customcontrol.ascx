<%@ Control Language="C#"%>
<%@ Implements Interface="System.Web.UI.WebControls.WebParts.IWebPart" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>

<script runat="server">
	private String image = string.Empty;
	private String desc= string.Empty;
	private String mySubtitle = "[0]";
	private String mytitle = "Custom Control ";
	
	public String CatalogIconImageUrl
	{
		get { return image; }
		set { image = value; }
	}
	public String Description
	{
		get { return desc; }
		set { desc = value; }
	}
	public String Subtitle
	{
		get {return string.Empty; }
		set { ; }
	}
	public String Title
	{
		get { return mytitle; }
		set { mytitle = value; }
	}
	public String TitleIconImageUrl
	{
		get { return string.Empty; }
		set { ; }
	}
	public String TitleUrl
	{
		get { return string.Empty; }
		set { ; }
	}
</script>
<asp:Label ID="Label1" Text="Enter Text: " Runat="server"/>
<asp:TextBox ID="TextBox1" Runat="server"/>
<br />
<asp:Button ID="Button1" Text="OK" Runat="server" />