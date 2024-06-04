Imports System
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports System.Data.SqlClient
Imports System.Text
Imports System.Xml

Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Try

            Response.Clear()
            Response.ContentType = "text/xml"
            Dim XMLTextObject As New XmlTextWriter(Response.OutputStream, Encoding.UTF8)
            XMLTextObject.WriteStartDocument()
            XMLTextObject.WriteStartElement("rss")
            XMLTextObject.WriteAttributeString("version", "2.0")
            XMLTextObject.WriteStartElement("channel")
            XMLTextObject.WriteElementString("title", "Creating RSS Feed On a Website")
            XMLTextObject.WriteElementString("link", "http://www.somedomain.com/news.aspx")
            XMLTextObject.WriteElementString("description", "This is a sample RSS 2.0 Feed")
            XMLTextObject.WriteElementString("copyright", "(c) 2006,  All rights reserved.")
            XMLTextObject.WriteElementString("ttl", "5")
            Dim connectionstring As String = "Data Source=.\\sqlexpress;Initial Catalog=rsssample;Integrated Security=True"
            Dim objConnection As New SqlConnection(connectionstring)
            objConnection.Open()
            Dim sql As String = "SELECT TOP 3 newstitle, newsdescription, newsdate FROM newsdata ORDER BY newsdate DESC"
            Dim objCommand As New SqlCommand(sql, objConnection)
            Dim objReader As SqlDataReader = objCommand.ExecuteReader()
            Do While objReader.Read()
                XMLTextObject.WriteStartElement("item")
                XMLTextObject.WriteElementString("title", objReader.GetString(0))
                XMLTextObject.WriteElementString("description", objReader.GetString(1))
                XMLTextObject.WriteElementString("link",
                "http://www.somedomain.com/GetArticle.aspx?id=0")
                XMLTextObject.WriteElementString("pubDate",
                objReader.GetDateTime(2).ToString("R"))
                XMLTextObject.WriteEndElement()
            Loop
            objReader.Close()
            objConnection.Close()

            XMLTextObject.WriteEndElement()
            XMLTextObject.WriteEndElement()
            XMLTextObject.WriteEndDocument()
            XMLTextObject.Flush()
            XMLTextObject.Close()
            Response.End()
        Catch ex As Exception
            Label1.Text = ex.Message
        End Try
    End Sub

End Class
