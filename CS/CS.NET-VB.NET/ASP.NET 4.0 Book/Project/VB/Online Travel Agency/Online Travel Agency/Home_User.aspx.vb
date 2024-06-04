Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ln As LoginName = CType(Master.FindControl("LoginName1"), LoginName)
        If ln.Page.User.Identity.Name = "administrator" Then
            Response.Redirect("~/Administrator.aspx")
        End If
    End Sub
    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetSlides(ByVal contextKey As String) As AjaxControlToolkit.Slide()
        Dim imgSlide As AjaxControlToolkit.Slide() = New AjaxControlToolkit.Slide(7) {}

        imgSlide(0) = New AjaxControlToolkit.Slide("Resources/cab1.jpg", "Cars", "Cars")
        imgSlide(1) = New AjaxControlToolkit.Slide("Resources/cab2.jpg", "Cars", "Cars")
        imgSlide(2) = New AjaxControlToolkit.Slide("Resources/bus.jpg", "Cars", "Cars")
        imgSlide(3) = New AjaxControlToolkit.Slide("Resources/Train.jpg", "Cars", "Cars")
        imgSlide(4) = New AjaxControlToolkit.Slide("Resources/Cars1.jpg", "Cars", "Cars")
        imgSlide(5) = New AjaxControlToolkit.Slide("Resources/Cars2.jpg", "Cars", "Cars")
        imgSlide(6) = New AjaxControlToolkit.Slide("Resources/Cars3.jpg", "Cars", "Cars")
        imgSlide(7) = New AjaxControlToolkit.Slide("Resources/Cars4.jpg", "Cars", "Cars")

        Return (imgSlide)
    End Function
End Class