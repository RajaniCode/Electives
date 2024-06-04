<%@ Control Language="VB"%>
<%@ Implements Interface="System.Web.UI.WebControls.WebParts.IWebPart" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>

<script runat="server">

	Private image As String = String.Empty
	Private desc As String = String.Empty
	Private mySubtitle As String = "[0]"
	Private mytitle As String = "Custom Control "
    Public Property CatalogIconImageUrl() As String Implements IWebPart.CatalogIconImageUrl
        Get
            Return image
        End Get
        Set(ByVal value As String)
            image = value
        End Set
    End Property

	Public Property Description() As String Implements IWebPart.Description
		Get
			Return desc
		End Get
		Set(ByVal value As String)
			desc = value
		End Set
	End Property
	Public ReadOnly Property Subtitle() As String Implements IWebPart.Subtitle
		Get
			Return String.Empty
		End Get
	End Property
	Public Property Title() As String Implements IWebPart.Title
		Get
			Return mytitle
		End Get
		Set(ByVal title As String)
		End Set
	End Property
    Public Property TitleIconImageUrl() As String Implements IWebPart.TitleIconImageUrl
        Get
            Return String.Empty
        End Get
        Set(ByVal mytitle As String)
        End Set
    End Property
	Public Property TitleUrl() As String Implements IWebPart.TitleUrl
		Get
			Return String.Empty
		End Get
		Set(ByVal mytitle As String)
		End Set
	End Property
</script>
<asp:Label ID="Label1" Text="User Text Here: " Runat="server" />
<asp:TextBox ID="TextBox1" Runat="server" />
<br />
<asp:Button ID="Button1" Text="OK" Runat="server" />
