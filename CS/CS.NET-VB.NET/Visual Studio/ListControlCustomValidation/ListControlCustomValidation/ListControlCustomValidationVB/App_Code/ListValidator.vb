Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text


Namespace CustomListValidator
    ''' <summary>
    ''' Summary description for ListValidator
    ''' </summary>
    Public Class ListValidator
        Inherits BaseValidator
        Public Sub New()

        End Sub

        Protected Overrides Function ControlPropertiesValid() As Boolean
            Dim ctrl As Control = TryCast(FindControl(ControlToValidate), ListControl)
            Return (Not ctrl Is Nothing)
        End Function

        Protected Overrides Function EvaluateIsValid() As Boolean
            Return Me.CheckIfItemIsChecked()
        End Function

        Protected Function CheckIfItemIsChecked() As Boolean
            Dim listItemValidate As ListControl = (CType(Me.FindControl(Me.ControlToValidate), ListControl))
            For Each listItem As ListItem In listItemValidate.Items
                If listItem.Selected = True Then
                    Return True
                End If
            Next listItem
            Return False
        End Function

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            ' Determines whether the validation control can be rendered
            ' for a newer ("uplevel") browser.
            ' check if client-side validation is enabled.
            If Me.DetermineRenderUplevel() AndAlso Me.EnableClientScript Then
                Page.ClientScript.RegisterExpandoAttribute(Me.ClientID, "evaluationfunction", "CheckIfListChecked")
                Me.CreateJavaScript()
            End If
            MyBase.OnPreRender(e)
        End Sub

        Protected Sub CreateJavaScript()
            Dim sb As StringBuilder = New StringBuilder()
            sb.Append("<script type=""text/javascript"">function CheckIfListChecked(ctrl){")
            sb.Append("var chkBoxList = document.getElementById(document.getElementById(ctrl.id).controltovalidate);")
            sb.Append("var chkBoxCount= chkBoxList.getElementsByTagName(""input"");")
            sb.Append("for(var i=0;i<chkBoxCount.length;i++){")
            sb.Append("if(chkBoxCount.item(i).checked){")
            sb.Append("return true; }")
            sb.Append("}return false; ")
            sb.Append("}</script>")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "JSScript", sb.ToString())
        End Sub
    End Class
End Namespace