Public Class UserController
    Inherits Controller

    Public Function Index() As ActionResult
        ' Show ManagerView view to members of Manager role
        If User.IsInRole("Manager") Then
            Return View("ManagerView")
        End If

        ' Show JackView to Jack (and no one else)
        If String.Equals(User.Identity.Name, "Jack", StringComparison.CurrentCultureIgnoreCase) Then
            Return View("JackView")
        End If

        ' Show AuthenticatedView to non-anonymous visitors
        If User.Identity.IsAuthenticated Then
            Return View("AuthenticatedView")
        End If

        ' Otherwise, redirect to LogOn action
        Return RedirectToAction("LogOn", "Account")
    End Function

End Class
