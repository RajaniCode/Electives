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

Public Class UnityControllerFactory
    Implements IControllerFactory

    Private _container As IUnityContainer
    Private _innerFactory As IControllerFactory

    Public Sub New(ByVal container As IUnityContainer)
        Me.New(container, New DefaultControllerFactory)
    End Sub

    Protected Sub New(ByVal container As IUnityContainer, ByVal innerFactory As IControllerFactory)

        _container = container
        _innerFactory = innerFactory
    End Sub

    Public Function CreateController(ByVal requestContext As RequestContext, ByVal controllerName As String) _
        As IController Implements IControllerFactory.CreateController

        Try
            Return _container.Resolve(Of IController)(controllerName)
        Catch e1 As Exception
            Return _innerFactory.CreateController(requestContext, controllerName)
        End Try
    End Function

    Public Sub ReleaseController(ByVal controller As IController) Implements IControllerFactory.ReleaseController
        _container.Teardown(controller)
    End Sub

    Public Function GetControllerSessionBehavior(ByVal requestContext As RequestContext, ByVal controllerName As String) _
        As System.Web.SessionState.SessionStateBehavior Implements IControllerFactory.GetControllerSessionBehavior

        Return System.Web.SessionState.SessionStateBehavior.Default
    End Function

End Class
