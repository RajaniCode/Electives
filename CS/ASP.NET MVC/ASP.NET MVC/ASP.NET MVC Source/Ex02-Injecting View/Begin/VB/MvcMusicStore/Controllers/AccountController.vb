' ----------------------------------------------------------------------------------
' Microsoft Developer & Platform Evangelism
' 
' Copyright (c) Microsoft Corporation. All rights reserved.
' 
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
' OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ----------------------------------------------------------------------------------
' The example companies, organizations, products, domain names,
' e-mail addresses, logos, people, places, and events depicted
' herein are fictitious.  No association with any real company,
' organization, product, domain name, email address, logo, person,
' places, or events is intended or should be inferred.
' ----------------------------------------------------------------------------------

<HandleError()>
Public Class AccountController
    Inherits Controller

    Public Property FormsService As IFormsAuthenticationService
    Public Property MembershipService As IMembershipService

    Protected Overrides Sub Initialize(ByVal requestContext As RequestContext)
        If FormsService Is Nothing Then
            FormsService = New FormsAuthenticationService
        End If
        If MembershipService Is Nothing Then
            MembershipService = New AccountMembershipService
        End If

        MyBase.Initialize(requestContext)
    End Sub

    '**************************************
    'URL: /Account/LogOn
    '**************************************

    Public Function LogOn() As ActionResult
        Return View()
    End Function

    <HttpPost()>
    Public Function LogOn(ByVal model As LogOnModel, ByVal returnUrl As String) As ActionResult
        If ModelState.IsValid Then
            If MembershipService.ValidateUser(model.UserName, model.Password) Then
                FormsService.SignIn(model.UserName, model.RememberMe)
                If Not String.IsNullOrEmpty(returnUrl) Then
                    Return Redirect(returnUrl)
                Else
                    Return RedirectToAction("Index", "Home")
                End If
            Else
                ModelState.AddModelError("", "The user name or password provided is incorrect.")
            End If
        End If

        'If we got this far, something failed, redisplay form
        Return View(model)
    End Function

    '**************************************
    'URL: /Account/LogOff
    '**************************************

    Public Function LogOff() As ActionResult
        FormsService.SignOut()

        Return RedirectToAction("Index", "Home")
    End Function

    '**************************************
    'URL: /Account/Register
    '**************************************

    Public Function Register() As ActionResult
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View()
    End Function

    <HttpPost()>
    Public Function Register(ByVal model As RegisterModel) As ActionResult
        If ModelState.IsValid Then
            'Attempt to register the user
            Dim createStatus As MembershipCreateStatus =MembershipService.CreateUser(model.UserName, model.Password, model.Email)

            If createStatus = MembershipCreateStatus.Success Then
                'createPersistentCookie
                FormsService.SignIn(model.UserName, False)
                Return RedirectToAction("Index", "Home")
            Else
                ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus))
            End If
        End If

        'If we got this far, something failed, redisplay form
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View(model)
    End Function

    '**************************************
    'URL: /Account/ChangePassword
    '**************************************

    <Authorize()>
    Public Function ChangePassword() As ActionResult
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View()
    End Function

    <Authorize(), HttpPost()>
    Public Function ChangePassword(ByVal model As ChangePasswordModel) As ActionResult
        If ModelState.IsValid Then
            If MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword) Then
                Return RedirectToAction("ChangePasswordSuccess")
            Else
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.")
            End If
        End If

        'If we got this far, something failed, redisplay form
        ViewData("PasswordLength") = MembershipService.MinPasswordLength
        Return View(model)
    End Function

    '**************************************
    'URL: /Account/ChangePasswordSuccess
    '**************************************

    Public Function ChangePasswordSuccess() As ActionResult
        Return View()
    End Function

End Class

