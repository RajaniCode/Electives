Public Class LookupController
    Inherits Controller

    Public Function Index(ByVal search As String) As ActionResult
        Dim users As New MembershipUserCollection()
        If Not String.IsNullOrEmpty(search) Then
            users = Membership.FindUsersByName("%" & search & "%")
        End If

        Return View(users)
    End Function

End Class
