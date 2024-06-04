Imports CookComputing.XmlRpc

Public Structure blogInfo
    Public title As String
    Public description As String
End Structure

Public Interface IgetCatList
    <CookComputing.XmlRpc.XmlRpcMethod("metaWeblog.newPost")> _
Function NewPage(ByVal blogID As Integer, ByVal strUserName As String, ByVal strPassword As String, ByVal content As blogInfo, ByVal publish As Integer) As String
End Interface
Public Class Form1
    Public clientProtocol As XmlRpcClientProtocol
    Public categories As IgetCatList


    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim newBlogPost As blogInfo
        newBlogPost.title = txtTitle.Text
        newBlogPost.description = txtPost.Text

        categories = CType(XmlRpcProxyGen.Create(GetType(IgetCatList)), IgetCatList)
        clientProtocol = CType(categories, XmlRpcClientProtocol)

        clientProtocol.Url = "http://127.0.0.1/wpl/xmlrpc.php"

        Dim result As String
        result = ""

        Try
            result = categories.NewPage(1, "shoban", "shoban", newBlogPost, 1)
            MsgBox("Posted to Blog successfullly! Post ID : " & result)
            txtPost.Text = ""
            txtTitle.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
