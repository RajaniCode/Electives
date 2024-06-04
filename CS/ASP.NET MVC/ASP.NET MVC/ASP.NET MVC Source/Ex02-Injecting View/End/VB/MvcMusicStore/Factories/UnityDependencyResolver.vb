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

Public Class UnityDependencyResolver
    Implements IDependencyResolver

    Private container As IUnityContainer
    Private resolver As IDependencyResolver

    Public Sub New(ByVal container As IUnityContainer,ByVal resolver As IDependencyResolver)

        Me.container = container
        Me.resolver = resolver

    End Sub

    Public Function GetService(ByVal serviceType As Type) As Object Implements IDependencyResolver.GetService

        Try
            Return Me.container.Resolve(serviceType)
        Catch
            Return Me.resolver.GetService(serviceType)
        End Try

    End Function

    Public Function GetServices(ByVal serviceType As Type) As IEnumerable(Of Object) Implements IDependencyResolver.GetServices

        Try
            Return Me.container.ResolveAll(serviceType)
        Catch
            Return Me.resolver.GetServices(serviceType)
        End Try

    End Function
End Class
