Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D

Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub DrawShape()
        Dim BitMapObject As System.Drawing.Bitmap
        Dim g As System.Drawing.Graphics
        BitMapObject = New Bitmap(300, 300)
        g = System.Drawing.Graphics.FromImage(BitMapObject)
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.TextRenderingHint = TextRenderingHint.AntiAlias
        g.Clear(Color.Silver)

        If DropDownList1.SelectedItem.Text = "Line" Then
            CallDrawLine(g)
        ElseIf DropDownList1.SelectedItem.Text = "Ellipse" Then
            CallDrawEllipse(g)
        ElseIf DropDownList1.SelectedItem.Text = "Rectangle" Then
            CallDrawRectangle(g)
        End If
        Response.ContentType = "image/jpeg"
        BitMapObject.Save(Response.OutputStream, ImageFormat.Jpeg)
        BitMapObject.Dispose()
        g.Dispose()
        Response.End()
    End Sub
    Private Sub CallDrawLine(ByVal g As System.Drawing.Graphics)
        Dim cl As Color
        cl = ColorTranslator.FromHtml(DropDownList2.SelectedItem.Text)
        Dim RPen As New Pen(cl, 8)
        Dim p1 As New Point(95, 55)
        Dim p2 As New Point(196, 55)
        Dim joinPoints As Point() = {p1, p2}
        g.DrawLines(RPen, joinPoints)
    End Sub
    Private Sub CallDrawRectangle(ByVal g As System.Drawing.Graphics)
        Dim RPen As New Pen(Color.Yellow, 15)
        Dim rect As New Rectangle(95, 109, 100, 90)
        g.DrawRectangle(RPen, rect)
        Dim cl As Color
        cl = ColorTranslator.FromHtml(DropDownList2.SelectedItem.Text)
        g.FillRectangle(New SolidBrush(cl), rect)
    End Sub
    Private Sub CallDrawEllipse(ByVal g As System.Drawing.Graphics)
        Dim RPen As New Pen(Color.Yellow, 15)
        Dim rectF As New RectangleF(100, 109, 100, 90)
        g.DrawEllipse(RPen, rectF)
        Dim cl As Color
        cl = ColorTranslator.FromHtml(DropDownList2.SelectedItem.Text)
        g.FillEllipse(New SolidBrush(cl), rectF)
    End Sub

    Protected Sub Wizard1_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick
        DrawShape()
    End Sub
End Class
