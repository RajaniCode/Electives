Imports ServiceReference1
Imports System.Data.Services
Imports System.Data.Services.Client

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim svc As New NorthwindEntities(New Uri("http://localhost:4236/WCFDataServiceVB/WcfDataService.svc"))
        GridView1.DataSource = svc.Customers
        GridView1.DataBind()
    End Sub
End Class
