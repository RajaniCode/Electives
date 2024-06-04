Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

Public Class Form1

    Dim pd As PrintDocument = New PrintDocument()
    Dim strPrint As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtFileNm.Text = openFileDialog1.FileName
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        ' Displays the document name in the print status or queue
        pd.DocumentName = txtFileNm.Text
        ' Associate PrintPage method with its event handler
        AddHandler pd.PrintPage, AddressOf pd_PrintPage
        ' Open the document
        Using fs As FileStream = New FileStream(pd.DocumentName, FileMode.Open)
            ' Read the contents of the document in a stream reader object
            Using sr As StreamReader = New StreamReader(fs)
                strPrint = sr.ReadToEnd()
            End Using
        End Using
        ' Calling this method invokes the PrintPage event
        pd.Print()
    End Sub

    Private Sub pd_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Dim charCount As Integer = 0
        Dim lineCount As Integer = 0

        ' Measure the specified string 'strPrint'
        ' Calculate characters per line 'charCount'
        ' Calcuate lines per page that will fit within 
        ' the bounds of the page 'lineCount'
        e.Graphics.MeasureString(strPrint, Me.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, charCount, lineCount)

        ' Determine the page bound and draw the string accordingly
        e.Graphics.DrawString(strPrint, Me.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic)

        ' Now remove that part of the string that has been printed.
        strPrint = strPrint.Substring(charCount)

        ' Check if any more pages left for printing
        If strPrint.Length > 0 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

End Class
