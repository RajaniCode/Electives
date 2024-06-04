Imports System.Data
Imports System.Data.SqlClient

Partial Class TreeViewDatabase
    Inherits System.Web.UI.Page
    Sub GetCategories(ByVal node As TreeNode)
        Dim sqlQuery As New SqlCommand( _
            "Select CategoryName, CategoryID From Categories")
        Dim ResultSet As DataSet
        ResultSet = PopulateDataFunction(sqlQuery)
        If ResultSet.Tables.Count > 0 Then
            Dim row As DataRow
            For Each row In ResultSet.Tables(0).Rows
                Dim NewNode As TreeNode = New  _
                    TreeNode(row("CategoryName").ToString(), _
                    row("CategoryID").ToString())
                NewNode.PopulateOnDemand = True
                NewNode.SelectAction = TreeNodeSelectAction.Expand
                node.ChildNodes.Add(NewNode)
            Next
        End If
    End Sub

    Sub GetProducts(ByVal node As TreeNode)
        Dim sqlQuery As New SqlCommand
        sqlQuery.CommandText = "Select ProductName From Products " & _
            " Where CategoryID = @categoryid"
        sqlQuery.Parameters.Add("@categoryid", SqlDbType.Int).Value = _
            node.Value
        Dim ResultSet As DataSet = PopulateDataFunction(sqlQuery)
        If ResultSet.Tables.Count > 0 Then
            Dim row As DataRow
            For Each row In ResultSet.Tables(0).Rows
                Dim NewNode As TreeNode = New  _
                    TreeNode(row("ProductName").ToString())
                NewNode.PopulateOnDemand = False
                NewNode.SelectAction = TreeNodeSelectAction.None
                node.ChildNodes.Add(NewNode)
            Next
        End If
    End Sub
    Function PopulateDataFunction(ByVal sqlQuery As SqlCommand) As DataSet
        Dim dbConnection As New SqlConnection("Data Source=AVANTIKA-PC\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True")
        Dim dbAdapter As New SqlDataAdapter
        dbAdapter.SelectCommand = sqlQuery
        sqlQuery.Connection = dbConnection
        Dim resultsDataSet As DataSet = New DataSet
        Try
            dbAdapter.Fill(resultsDataSet)
        Catch ex As Exception
        End Try
        Return resultsDataSet
    End Function
    Protected Sub TreeView2_TreeNodePopulate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles TreeView2.TreeNodePopulate
        If e.Node.ChildNodes.Count = 0 Then
            Select Case e.Node.Depth
                Case 0
                    GetCategories(e.Node)
                Case 1
                    GetProducts(e.Node)
            End Select
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TreeView2.ExpandDepth = 1
    End Sub

End Class
