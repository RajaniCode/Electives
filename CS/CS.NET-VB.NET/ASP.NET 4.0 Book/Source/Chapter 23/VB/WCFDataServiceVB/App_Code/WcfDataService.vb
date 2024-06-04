Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
Imports NorthwindModel

Public Class WcfDataService
    ' TODO: replace [[class name]] with your data class name
    Inherits DataService(Of [NorthwindEntities])

    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        ' TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
        ' Examples:
        config.SetEntitySetAccessRule("*", EntitySetRights.AllRead)
        config.SetServiceOperationAccessRule("*", ServiceOperationRights.All)
        config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2
    End Sub

End Class
