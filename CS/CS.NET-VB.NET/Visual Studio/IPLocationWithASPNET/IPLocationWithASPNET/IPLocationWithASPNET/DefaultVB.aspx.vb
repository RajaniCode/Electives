Imports System.Xml.Linq

Partial Class DefaultVB
    Inherits System.Web.UI.Page

    Protected Sub btnGetLoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetLoc.Click
        Dim url As String = String.Empty

        If txtIP.Text.Trim() <> String.Empty Then
            url = String.Format("http://iplocationtools.com/ip_query2.php?ip={0}", txtIP.Text.Trim())
            Dim xDoc As XDocument = XDocument.Load(url)
            If xDoc Is Nothing Or xDoc.Root Is Nothing Then
                Throw New ApplicationException("Data is not Valid")
            End If

            Xml1.TransformSource = "IP.xslt"
            Xml1.DocumentContent = xDoc.ToString()
        End If
    End Sub
End Class
