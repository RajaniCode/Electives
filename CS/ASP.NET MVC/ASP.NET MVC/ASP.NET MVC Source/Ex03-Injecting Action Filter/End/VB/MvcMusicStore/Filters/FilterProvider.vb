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

Imports System.Web.Mvc
Imports Microsoft.Practices.Unity

Public Class FilterProvider
    Implements IFilterProvider

    Private container As IUnityContainer

    Public Sub New(ByVal container As IUnityContainer)
        Me.container = container
    End Sub

    Public Function GetFilters(ByVal controllerContext As ControllerContext, ByVal actionDescriptor As ActionDescriptor) _
        As IEnumerable(Of Filter) Implements System.Web.Mvc.IFilterProvider.GetFilters

        Dim result = New List(Of Filter)()
        For Each actionFilter As IActionFilter In container.ResolveAll(Of IActionFilter)()
            result.Add(New Filter(actionFilter, FilterScope.First, Nothing))
        Next actionFilter

        Return result
    End Function

End Class