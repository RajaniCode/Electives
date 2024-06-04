
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        MultiView1.Visible = True
        MultiView1.SetActiveView(View1)

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        MultiView1.Visible = True
        MultiView1.SetActiveView(View2)

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        MultiView1.Visible = True
        MultiView1.SetActiveView(View3)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MultiView1.Visible = False
    End Sub
End Class
