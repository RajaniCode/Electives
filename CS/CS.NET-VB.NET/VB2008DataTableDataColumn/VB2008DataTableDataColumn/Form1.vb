Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim _dataSet As New DataSet()

            Dim dataTableUpperCase As New DataTable("DataTableUpperCase")
            Dim dataTableLowerCase As New DataTable("DataTableLowerCase")

            Dim AlphabetsUpperCase As New DataColumn("Upper Case", GetType(String))
            Dim ASCIIUpperCase As New DataColumn("ASCII", GetType(String))
            Dim AlphabetsLowerCase As New DataColumn("Lower Case", GetType(String))
            Dim ASCIILowerCase As New DataColumn("ASCII", GetType(Byte))

            dataTableUpperCase.Columns.AddRange(New DataColumn() {AlphabetsUpperCase, ASCIIUpperCase})
            dataTableLowerCase.Columns.AddRange(New DataColumn() {AlphabetsLowerCase, ASCIILowerCase})

            _dataSet.Tables.AddRange(New DataTable() {dataTableUpperCase, dataTableLowerCase})

            For index As Integer = 0 To 25
                _dataSet.Tables(0).Rows.Add(New Object() {(65 + index).ToString(), index})
            Next

            For index As Integer = 0 To 25
                _dataSet.Tables(1).Rows.Add(New Object() {(97 + index).ToString(), index})
            Next

            DataGridView1.DataSource = dataTableUpperCase.DefaultView

            DataGridView2.DataSource = dataTableLowerCase.DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
End Class
