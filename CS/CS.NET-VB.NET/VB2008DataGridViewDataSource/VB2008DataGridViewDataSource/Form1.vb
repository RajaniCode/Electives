Public Class Form1

    Dim dt As DataTable


    Private Sub DataGridView1_ColumnDisplayIndexChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)

        If (e.Column.Index = 0) AndAlso (e.Column.DisplayIndex <> 0) Then
            Dim mouseEventHandlerToRemove As MouseEventHandler = Nothing
            Dim mouseEventHandler As MouseEventHandler = _
            Function(sender1, mouseEventArgs) AnonymousMethod(sender1, mouseEventArgs, mouseEventHandlerToRemove)
            mouseEventHandlerToRemove = mouseEventHandler
            AddHandler Me.DataGridView1.MouseUp, mouseEventHandler
        End If

    End Sub

    Private Function AnonymousMethod(ByVal sender1 As Object, ByVal mouseEventArgs As MouseEventArgs, ByVal mouseEventHandlerToRemove As MouseEventHandler) As Object

        Me.DataGridView1.Columns(0).DisplayIndex = 0
        RemoveHandler Me.DataGridView1.MouseUp, mouseEventHandlerToRemove
        Return Nothing

    End Function

  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim uc As Char = Char.Parse(DataGridView1.Rows((DataGridView1.Rows.Count - 1)).Cells("UpperCase").Value.ToString())
        Dim lc As Char = Char.Parse(DataGridView1.Rows((DataGridView1.Rows.Count - 1)).Cells("LowerCase").Value.ToString())
        Dim i As Integer = Asc(uc)
        Dim j As Integer = Asc(lc)

        If i < 91 AndAlso j < 122 Then
            i = i + 1
            j = j + 1
        Else
            MessageBox.Show("Again!")
            i = 65
            j = 97
        End If

        If i <= 90 AndAlso i >= 65 AndAlso j <= 122 AndAlso j >= 97 Then
            dt.Rows.Add(New Object() {Chr(i), Chr(j)})
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
        dt.Rows.RemoveAt(DataGridView1.CurrentRow.Index)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        DataGridView2.DataSource = dt.DefaultView

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dt = New DataTable("Alphabets")
        Dim dcUpperCase As DataColumn = New DataColumn("UpperCase", GetType(String))
        Dim dcLowerCase As DataColumn = New DataColumn("LowerCase", GetType(String))
        dt.Columns.AddRange(New DataColumn() {dcUpperCase, dcLowerCase})

        Dim i As Integer = 0
        Do While (i < 5)
            dt.Rows.Add(New Object() {Chr(i + 65), Chr(i + 97)})
            i = (i + 1)
        Loop
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.DataSource = dt.DefaultView

    End Sub

End Class
