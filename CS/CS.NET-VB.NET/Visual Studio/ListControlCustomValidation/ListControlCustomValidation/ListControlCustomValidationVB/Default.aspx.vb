Imports System.Collections.Generic

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            Dim lstStr As List(Of String) = New List(Of String)()
            lstStr.Add("Item 1")
            lstStr.Add("Item 2")
            lstStr.Add("Item 3")
            lstStr.Add("Item 4")
            CheckBoxList1.DataSource = lstStr
            CheckBoxList1.DataBind()
            RadioButtonList1.DataSource = lstStr
            RadioButtonList1.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class
