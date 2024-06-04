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

'Note: For instructions on enabling IIS6 or IIS7 classic mode, 
'visit http://go.microsoft.com/?LinkId=9394801

Public Class MvcApplication
    Inherits HttpApplication

    Public Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute)
    End Sub

    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        'Parameter defaults -  URL with parameters -  Route name
        routes.MapRoute("Default", "{controller}/{action}/{id}", New With{Key .controller = "Home", Key .action = "Index", Key .id = UrlParameter.Optional})

    End Sub

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)

        Dim container = New UnityContainer
        container.RegisterType(Of IStoreService, StoreService)()
        container.RegisterType(Of IController, StoreController)("Store")

        Dim factory = New UnityControllerFactory(container)
        ControllerBuilder.Current.SetControllerFactory(factory)

        'You could implement another IMessageService, maybe a dynamic one
        container.RegisterInstance(Of IMessageService)(New MessageService With {.Message = "You are welcome to our Web Camps Training Kit!", _
                                                                               .ImageUrl = "/Content/Images/logo-webcamps.png"})

        container.RegisterType(Of IViewPageActivator, CustomViewPageActivator)(New InjectionConstructor(container))

        Dim resolver As IDependencyResolver = DependencyResolver.Current

        Dim newResolver As IDependencyResolver = New UnityDependencyResolver(container, resolver)

        DependencyResolver.SetResolver(newResolver)
    End Sub
End Class
