Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Try
            Dim driv As String = DropDownList1.SelectedValue
            Label1.Text = "You Have Selected Drive " & driv
            Dim retrieve_drive_info As New System.IO.DriveInfo(driv)
            Label2.Text = "Drive Type : " & retrieve_drive_info.DriveType.ToString()
            Label4.Text = "Free Space on Drive: " & retrieve_drive_info.AvailableFreeSpace.ToString()
            Label3.Text = "Total Size : " & retrieve_drive_info.TotalSize.ToString()
        Catch ex As Exception
            Label2.Text = ex.Message
            Label4.Text = ""
            Label3.Text = ""
        End Try

    End Sub

    Protected Sub BtnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Dim str() As String = Directory.GetLogicalDrives()
        For i As Integer = 0 To str.Length - 1
            DropDownList1.Items.Add(str(i))
        Next i
    End Sub
End Class
