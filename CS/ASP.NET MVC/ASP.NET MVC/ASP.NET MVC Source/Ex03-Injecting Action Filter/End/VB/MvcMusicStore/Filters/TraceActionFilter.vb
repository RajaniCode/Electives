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

Public Class TraceActionFilter
    Implements IActionFilter

    Public Sub OnActionExecuted(ByVal filterContext As ActionExecutedContext) Implements IActionFilter.OnActionExecuted

        filterContext.HttpContext.Trace.Write("OnActionExecuted")
        filterContext.HttpContext.Trace.Write("Action " & filterContext.ActionDescriptor.ActionName)
        filterContext.HttpContext.Trace.Write("Controller " & filterContext.ActionDescriptor.ControllerDescriptor.ControllerName)

    End Sub

    Public Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext) Implements IActionFilter.OnActionExecuting

        filterContext.HttpContext.Trace.Write("OnActionExecuting")
        filterContext.HttpContext.Trace.Write("Action " & filterContext.ActionDescriptor.ActionName)
        filterContext.HttpContext.Trace.Write("Controller " & filterContext.ActionDescriptor.ControllerDescriptor.ControllerName)

    End Sub

End Class