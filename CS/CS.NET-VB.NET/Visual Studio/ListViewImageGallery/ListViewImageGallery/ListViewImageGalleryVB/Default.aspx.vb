Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Dim connection As SqlConnection = Nothing
        Try
            Dim img As FileUpload = CType(imgUpload, FileUpload)
            Dim imgByte As Byte() = Nothing
            If img.HasFile AndAlso Not img.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = imgUpload.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            ' Insert the picture tags and image into db
            Dim conn As String = ConfigurationManager.ConnectionStrings("albumConnString").ConnectionString
            connection = New SqlConnection(conn)

            connection.Open()
            Dim sql As String = "INSERT INTO Album(picture_tag,pic) VALUES(@tag,@pic) SELECT @@IDENTITY"
            Dim cmd As SqlCommand = New SqlCommand(sql, connection)
            cmd.Parameters.AddWithValue("@tag", txtTags.Text)
            cmd.Parameters.AddWithValue("@pic", imgByte)
            Dim id As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            lblResult.Text = String.Format("Picture ID is {0}", id)
            ListView1.DataBind()
        Catch
            lblResult.Text = "There was an error"
        Finally
            connection.Close()
        End Try
    End Sub


End Class
