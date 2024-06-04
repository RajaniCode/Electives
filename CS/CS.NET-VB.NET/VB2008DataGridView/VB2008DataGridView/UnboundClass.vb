Imports System.Data.SqlClient

Public Class UnboundClass

    Inherits ObjectDisposeClass

    Private mDataView As DataView

    Private mSqlConnectionString As String

    Public Sub New(ByVal pSqlConnectionString As String)

        mSqlConnectionString = pSqlConnectionString

    End Sub

    Public Sub BoundDataLoading(ByRef pDataGridViewControl As DataGridView, _
                           ByRef pTextBoxRecordCount As TextBox, _
                           ByRef pErrorMessageString As String)
        Dim RecordCountInt32 As Int32
        Try
            Using mSqlConnection As New SqlConnection(mSqlConnectionString)
                mSqlConnection.Open()
                Using mSqlCommand As New SqlCommand
                    With mSqlCommand
                        .Connection = mSqlConnection
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_test_select_all"
                    End With
                    Using mSqlDataAdapter As New SqlDataAdapter(mSqlCommand)
                        Using mDataSet As New DataSet
                            mDataSet.Clear()
                            mSqlDataAdapter.Fill(mDataSet, "test")
                            mDataView = New DataView
                            mDataView.Table = mDataSet.Tables("test")
                        End Using
                    End Using
                End Using
            End Using
            RecordCountInt32 = mDataView.Count
            pTextBoxRecordCount.Text = FormatNumber(RecordCountInt32.ToString, 0)
            Call DataGridViewBound(pDataGridViewControl)
            pDataGridViewControl.DataSource = mDataView
        Catch exError As Exception
            pErrorMessageString = exError.Message
        End Try
    End Sub

    Public Sub UnboundDataLoading(ByRef pDataGridViewControl As DataGridView, _
                              ByRef pTextBoxRecordCount As TextBox, _
                              ByRef pErrorMessageString As String)
        Dim CellsArrayObject() As Object
        Dim RecordCountInt32 As Int32
        Try
            Using SqlConnection As New SqlConnection(mSqlConnectionString)
                SqlConnection.Open()
                Using mSqlCommand As New SqlCommand
                    With mSqlCommand
                        .Connection = SqlConnection
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_test_select_all"
                    End With
                    Using mSqlDataReader As SqlDataReader = _
                       mSqlCommand.ExecuteReader(CommandBehavior.SingleResult)
                        With mSqlDataReader
                            If .HasRows Then
                                Call DataGridViewUnbound(pDataGridViewControl)
                                ReDim CellsArrayObject(.FieldCount - 1)
                                While .Read
                                    .GetValues(CellsArrayObject)
                                    pDataGridViewControl.Rows.Add(CellsArrayObject)
                                    RecordCountInt32 += 1
                                End While
                                pTextBoxRecordCount.Text = FormatNumber(RecordCountInt32.ToString, 0)
                            End If
                        End With
                    End Using
                End Using
            End Using
        Catch exError As Exception
            pErrorMessageString = exError.Message
        End Try
    End Sub

    Private Sub DataGridViewBound(ByRef pDataGridViewControl As DataGridView)
        With pDataGridViewControl
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowTemplate.Height = 17
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .ReadOnly = True
            .MultiSelect = False
            .Columns.Clear()
            Dim ColumnID As New DataGridViewTextBoxColumn
            With ColumnID
                .DataPropertyName = "id"
                .Name = "id"
                .HeaderText = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(ColumnID)
            Dim Column2 As New DataGridViewTextBoxColumn
            With Column2
                .DataPropertyName = "Column2"
                .Name = "Column2"
                .HeaderText = "Column2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column2)
            Dim Column3 As New DataGridViewTextBoxColumn
            With Column3
                .DataPropertyName = "Column3"
                .Name = "Column3"
                .HeaderText = "Column3"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column3)
            Dim Column4 As New DataGridViewTextBoxColumn
            With Column4
                .DataPropertyName = "Column4"
                .Name = "Column4"
                .HeaderText = "Column4"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column4)
            Dim Column5 As New DataGridViewTextBoxColumn
            With Column5
                .DataPropertyName = "Column5"
                .Name = "Column5"
                .HeaderText = "Column5"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column5)
            Dim Column6 As New DataGridViewTextBoxColumn
            With Column6
                .DataPropertyName = "Column6"
                .Name = "Column6"
                .HeaderText = "Column6"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column6)
            Dim Column7 As New DataGridViewTextBoxColumn
            With Column7
                .DataPropertyName = "Column7"
                .Name = "Column7"
                .HeaderText = "Column7"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column7)
            Dim Column8 As New DataGridViewTextBoxColumn
            With Column8
                .DataPropertyName = "Column8"
                .Name = "Column8"
                .HeaderText = "Column8"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column8)
            Dim Column9 As New DataGridViewTextBoxColumn
            With Column9
                .DataPropertyName = "Column9"
                .Name = "Column9"
                .HeaderText = "Column9"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column9)
            Dim Column10 As New DataGridViewTextBoxColumn
            With Column10
                .DataPropertyName = "Column10"
                .Name = "Column10"
                .HeaderText = "Column10"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column10)
        End With
    End Sub

    Private Sub DataGridViewUnbound(ByRef pDataGridViewControl As DataGridView)
        With pDataGridViewControl
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowTemplate.Height = 17
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .ReadOnly = True
            .MultiSelect = False
            .Columns.Clear()
            Dim ColumnID As New DataGridViewTextBoxColumn
            With ColumnID
                .Name = "ID"
                .HeaderText = "ID"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(ColumnID)
            Dim Column2 As New DataGridViewTextBoxColumn
            With Column2
                .Name = "Column2"
                .HeaderText = "Column2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column2)
            Dim Column3 As New DataGridViewTextBoxColumn
            With Column3
                .Name = "Column3"
                .HeaderText = "Column3"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column3)
            Dim Column4 As New DataGridViewTextBoxColumn
            With Column4
                .Name = "Column4"
                .HeaderText = "Column4"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column4)
            Dim Column5 As New DataGridViewTextBoxColumn
            With Column5
                .Name = "Column5"
                .HeaderText = "Column5"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column5)
            Dim Column6 As New DataGridViewTextBoxColumn
            With Column6
                .Name = "Column6"
                .HeaderText = "Column6"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column6)
            Dim Column7 As New DataGridViewTextBoxColumn
            With Column7
                .Name = "Column7"
                .HeaderText = "Column7"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column7)
            Dim Column8 As New DataGridViewTextBoxColumn
            With Column8
                .Name = "Column8"
                .HeaderText = "Column8"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column8)
            Dim Column9 As New DataGridViewTextBoxColumn
            With Column9
                .Name = "Column9"
                .HeaderText = "Column9"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column9)
            Dim Column10 As New DataGridViewTextBoxColumn
            With Column10
                .Name = "Column10"
                .HeaderText = "Column10"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.Add(Column10)
        End With
    End Sub

End Class



