Imports AjaxControlToolkit

Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub txtSlide_Changed(ByVal sender As Object, ByVal e As EventArgs)
        Dim txtCurrentPage As TextBox = TryCast(sender, TextBox)
        Dim rowPager As GridViewRow = GridView1.BottomPagerRow
        Dim txtSliderExt As TextBox = CType(rowPager.Cells(0).FindControl("txtSlide"), TextBox)
        GridView1.PageIndex = Int32.Parse(txtSliderExt.Text) - 1
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
        Dim rowPager As GridViewRow = GridView1.BottomPagerRow
        Dim slide As SliderExtender = CType(rowPager.Cells(0).FindControl("ajaxSlider"), SliderExtender)
        slide.Minimum = 1
        slide.Maximum = GridView1.PageCount
        slide.Steps = GridView1.PageCount
    End Sub

End Class
