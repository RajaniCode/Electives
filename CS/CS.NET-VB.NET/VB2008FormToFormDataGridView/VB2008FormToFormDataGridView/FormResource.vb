Public Class FormResource

    Dim DataGridViewForm As FormDataGridView

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal f1p As Object)
        Me.new()
        DataGridViewForm = f1p
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim _dataSet As New DataSet()

            Dim DataTableAlphabets As New DataTable("Alphabets")

            Dim DataColumnUpperCase As New DataColumn("UpperCase", GetType(String))
            Dim DataColumnASCII As New DataColumn("ASCII", GetType(String))

            DataTableAlphabets.Columns.AddRange(New DataColumn() {DataColumnUpperCase, DataColumnASCII})

            For index As Integer = 0 To 25
                DataTableAlphabets.Rows.Add(New Object() {(65 + index).ToString(), index})
            Next

            DataGridViewForm.DataGridView1.DataSource = DataTableAlphabets.DefaultView

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

End Class