Imports NewPublisherModel

Partial Class _Default
    Inherits System.Web.UI.Page
    Private PublisherContext As NewPublisherEntities
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim AuthorID As Int32 = Convert.ToInt32(DropDownList1.SelectedValue)
        Dim BookDetails = From bookD In PublisherContext.Books
        Where bookD.Author.AuthorID = AuthorID _
        Select New With _
        { _
         .BookName = bookD.Title, _
         .Pages = bookD.Pages, _
         .ISBN = bookD.BookISBN _
        }
        GridView1.DataSource = BookDetails
        GridView1.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PublisherContext = New NewPublisherEntities()
    End Sub
End Class
