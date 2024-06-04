Public Class BankController
	Inherits Controller
	'
	' GET: /Bank/Withdraw

	Public Function Withdraw() As ActionResult
		Return View()
	End Function

	'
	' POST: /Bank/Withdraw
	<AcceptVerbs(HttpVerbs.Post), ValidateAntiForgeryToken> _
	Public Function Withdraw(ByVal amount As Decimal) As ActionResult
		' Perform withdrawal
		Return View()
	End Function

End Class
