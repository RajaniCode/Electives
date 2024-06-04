
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim DataSet1 As New Data.DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Cache("MyCacheDataset") Is Nothing Then
            DataSet1.ReadXml(Server.MapPath("Authors.xml"))
			Cache.Insert("MyCacheDataset", DataSet1, New CacheDependency(Server.MapPath("Authors.xml")))
            Label2.Text = "Cache Generated"
        Else
            Label2.Text = "Using pre-generated Cache"
        End If
        DataGrid1.DataSource = Cache("MyCacheDataset")
        DataGrid1.DataBind()

    End Sub
End Class
