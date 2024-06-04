Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnFetchRss_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFetchRss.Click
        Dim xFeed As XElement = XElement.Load("http://feeds.feedburner.com/netCurryRecentArticles")

        Dim items As IEnumerable(Of ArticlesList) = _
        From item In xFeed.Elements("channel").Elements("item") _
        Select New ArticlesList With {.Title = item.Element("title").Value, _
                         .Link = item.Element("link").Value, _
                         .Description = item.Element("description").Value, _
                         .Author = item.Element("author").Value}

        GridView1.DataSource = items
        GridView1.DataBind()
    End Sub

End Class