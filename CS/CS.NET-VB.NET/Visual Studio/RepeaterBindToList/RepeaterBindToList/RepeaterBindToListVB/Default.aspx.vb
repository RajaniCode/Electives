
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        rptName.DataSource = EmployeeList.emp
        rptName.DataBind()
    End Sub
End Class
