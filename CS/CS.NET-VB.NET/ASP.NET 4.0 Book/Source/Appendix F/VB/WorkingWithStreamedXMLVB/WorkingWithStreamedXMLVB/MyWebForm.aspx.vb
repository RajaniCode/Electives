Imports System
Imports System.Xml
Public Class MyWebForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        Dim xr As XmlReader = XmlReader.Create("D:\\Books\\Black Book\\ASP.NET 4.0_BB\\Source Code\\Appendix F\\VB\\WorkingWithStreamedXMLVB\\WorkingWithStreamedXMLVB\\Authors.xml")
        Do While xr.Read()
            If xr.NodeType = XmlNodeType.Text Then
                ListBox1.Items.Add(xr.Value)
            End If
        Loop
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        Dim xr As XmlReader = XmlReader.Create("D:\\Books\\Black Book\ASP.NET 4.0_BB\\Source Code\\Appendix F\\VB\\WorkingWithStreamedXMLVB\\WorkingWithStreamedXMLVB\\Authors.xml")
        Do While xr.Read()
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "au_lname" Then
                ListBox1.Items.Add(xr.ReadElementString())
            Else
                xr.Read()
            End If
        Loop
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        ListBox1.Items.Clear()
        Dim xr As XmlReader = XmlReader.Create("D:\\Books\\Black Book\\ASP.NET 4.0_BB\\Source Code\\Appendix F\\VB\\WorkingWithStreamedXMLVB\\WorkingWithStreamedXMLVB\\Authors.xml")
        Do While xr.Read()
            If xr.NodeType = XmlNodeType.Element Then
                For i As Integer = 0 To xr.AttributeCount - 1
                    ListBox1.Items.Add(xr.GetAttribute(i))
                Next i
            End If
        Loop
    End Sub
End Class