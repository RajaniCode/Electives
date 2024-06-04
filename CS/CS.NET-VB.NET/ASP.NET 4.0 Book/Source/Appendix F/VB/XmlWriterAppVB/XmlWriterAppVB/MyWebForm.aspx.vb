Imports System.Text
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Xml

Public Class MyWebForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim docSettings As New XmlWriterSettings()
        docSettings.Indent = True
        docSettings.Encoding = Encoding.UTF8

        Dim docPath As String = Server.MapPath("Employees.xml")
        Try
            Using xr As XmlWriter = XmlWriter.Create(docPath, docSettings)
                xr.WriteStartDocument()
                xr.WriteComment("This File Displays Employee Details")
                xr.WriteStartElement("Employees")
                xr.WriteStartElement("Employee")
                xr.WriteAttributeString("ID", "Emp1")
                xr.WriteStartElement("Name")
                xr.WriteElementString("FirstName", "Gerry")
                xr.WriteElementString("LastName", "Simpson")
                xr.WriteEndElement()
                xr.WriteElementString("Age", "25")
                xr.WriteElementString("Designation", "Manager")
                xr.WriteStartElement("Location")
                xr.WriteElementString("City", "New Delhi")
                xr.WriteElementString("Country", "India")
                xr.WriteEndElement()
                xr.WriteEndElement()
                xr.WriteEndElement()
                xr.WriteEndDocument()
            End Using
            Response.Redirect("Employees.xml")
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

End Class