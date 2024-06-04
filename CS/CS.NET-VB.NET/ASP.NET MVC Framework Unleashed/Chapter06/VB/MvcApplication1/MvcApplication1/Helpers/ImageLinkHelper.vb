Public Module ImageLinkHelper

	<System.Runtime.CompilerServices.Extension> _
	Function ImageLink(ByVal helper As HtmlHelper, ByVal actionName As String, ByVal imageUrl As String, ByVal alternateText As String) As String
		Return ImageLink(helper, actionName, imageUrl, alternateText, Nothing, Nothing, Nothing)
	End Function

	<System.Runtime.CompilerServices.Extension> _
	Function ImageLink(ByVal helper As HtmlHelper, ByVal actionName As String, ByVal imageUrl As String, ByVal alternateText As String, ByVal routeValues As Object) As String
		Return ImageLink(helper, actionName, imageUrl, alternateText, routeValues, Nothing, Nothing)
	End Function

	<System.Runtime.CompilerServices.Extension> _
	Function ImageLink(ByVal helper As HtmlHelper, ByVal actionName As String, ByVal imageUrl As String, ByVal alternateText As String, ByVal routeValues As Object, ByVal linkHtmlAttributes As Object, ByVal imageHtmlAttributes As Object) As String
		Dim urlHelper = New UrlHelper(helper.ViewContext.RequestContext)
		Dim url = urlHelper.Action(actionName, routeValues)

		' Create link
		Dim linkTagBuilder = New TagBuilder("a")
		linkTagBuilder.MergeAttribute("href", url)
		linkTagBuilder.MergeAttributes(New RouteValueDictionary(linkHtmlAttributes))

		' Create image
		Dim imageTagBuilder = New TagBuilder("img")
		imageTagBuilder.MergeAttribute("src", urlHelper.Content(imageUrl))
		imageTagBuilder.MergeAttribute("alt", helper.AttributeEncode(alternateText))
		imageTagBuilder.MergeAttributes(New RouteValueDictionary(imageHtmlAttributes))

		' Add image to link
		linkTagBuilder.InnerHtml = imageTagBuilder.ToString(TagRenderMode.SelfClosing)

		Return linkTagBuilder.ToString()
	End Function
End Module
