Public Module SubmitButtonHelper

	''' <summary>
	''' Renders an HTML form submit button
	''' </summary>
	<System.Runtime.CompilerServices.Extension> _
	Function SubmitButton(ByVal helper As HtmlHelper, ByVal buttonText As String) As String
		Return String.Format("<input type=""submit"" value=""{0}"" />", buttonText)
	End Function

End Module
