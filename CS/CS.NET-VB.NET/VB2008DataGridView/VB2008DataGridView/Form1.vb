Public Class Form1

    Private mTimeDouble As Double
    Private swatch As New Stopwatch()

    Private mSqlConnectionString As String = "Data Source=FB-DEV9\SQLEXPRESS;Initial Catalog=master;Integrated Security=true"
    Private mErrorMsgString As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        swatch.Reset()
        swatch.Start()

        Cursor = Cursors.WaitCursor
        Try
            Using BoundObject As New UnboundClass(mSqlConnectionString)
                Call BoundObject.BoundDataLoading(UnboundDataGridView, _
                                                  RecordCountTextBox, _
                                                  mErrorMsgString)
                If Not IsNothing(mErrorMsgString) Then
                    Cursor = Cursors.Default
                    MessageBox.Show(mErrorMsgString, _
                                    Me.Text, _
                                    MessageBoxButtons.OK, _
                                    MessageBoxIcon.Error)
                End If
            End Using
        Catch exError As Exception
            MessageBox.Show(exError.Message, _
                            Me.Text, _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
        swatch.Stop()
        mTimeDouble = swatch.ElapsedMilliseconds * 0.001
        BoundTimeTextBox.Text = mTimeDouble.ToString

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        UnboundDataGridView.DataSource = Nothing
        swatch.Reset()
        swatch.Start()
        Cursor = Cursors.WaitCursor


        Try
            Using UnboundObject As New UnboundClass(mSqlConnectionString)
                Call UnboundObject.UnboundDataLoading(UnboundDataGridView, _
                                                      RecordCountTextBox, _
                                                      mErrorMsgString)
                If Not IsNothing(mErrorMsgString) Then
                    Cursor = Cursors.Default
                    MessageBox.Show(mErrorMsgString, _
                                    Me.Text, _
                                    MessageBoxButtons.OK, _
                                    MessageBoxIcon.Error)
                End If
            End Using
        Catch exError As Exception
            MessageBox.Show(exError.Message, _
                            Me.Text, _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
        swatch.Stop()
        mTimeDouble = swatch.ElapsedMilliseconds * 0.001
        UnboundTimeTextBox.Text = mTimeDouble.ToString

    End Sub

End Class



