Imports System.Data

Partial Class Default2
    Inherits System.Web.UI.Page

    Private cntView As Int64
    Private cntClick As Int64

    Public Sub ChildRepeater_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        Dim lt As ListItemType = e.Item.ItemType
        If lt = ListItemType.Item OrElse lt = ListItemType.AlternatingItem Then
            Dim dv As DataRowView = TryCast(e.Item.DataItem, DataRowView)
            If Not dv Is Nothing Then
                cntView += Convert.ToInt64(dv("AdImpression"))
                cntClick += Convert.ToInt64(dv("AdClicks"))
            End If

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            Dim lblCount As Label = TryCast(e.Item.FindControl("lblImpressionCount"), Label)
            lblCount.Text = cntView.ToString()

            Dim lblSum As Label = TryCast(e.Item.FindControl("lblClickCount"), Label)
            lblSum.Text = cntClick.ToString()
            cntView = 0
            cntClick = 0
        End If
    End Sub


End Class
