Imports System.Globalization
Imports System.IO

Imports System.Collections


Public Class Form1

    Dim _tzi As TimeZoneInfo

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim timeZoneInfos() As TimeZoneInfo = TimeZoneInfo.GetTimeZones
        Using swTzSysName As StreamWriter = New StreamWriter("Time Zone System Name.txt")
            Using swTzSysNameStdName As StreamWriter = New StreamWriter("Time Zone System Name Standard Name.txt")
                Using swTzSysNameStdNameDlName As StreamWriter = New StreamWriter("Time Zone System Name Standard Name Daylight Name.txt")

                    Using swTzStdNameDlName As StreamWriter = New StreamWriter("Time Zone Standard Name Daylight Name.txt")
                        Using swTzStdName As StreamWriter = New StreamWriter("Time Zone Standard Name.txt")
                            Using swTzStdNameWithDlName As StreamWriter = New StreamWriter("Time Zone Standard Name With Daylight Name.txt")
                                Using swTzStdNameHavingDlName As StreamWriter = New StreamWriter("Time Zone Standard Name Having Daylight Name.txt")

                                    For Each tzi As TimeZoneInfo In timeZoneInfos
                                        Me.CTZComboBox.Items.Add(tzi)
                                        Me.TZComboBox.Items.Add(tzi)

                                        swTzSysName.WriteLine(tzi)

                                        swTzSysNameStdName.Write(tzi)
                                        swTzSysNameStdName.Write("====")
                                        swTzSysNameStdName.WriteLine(tzi.StandardName)

                                        swTzSysNameStdNameDlName.Write(tzi)
                                        swTzSysNameStdNameDlName.Write("====")
                                        swTzSysNameStdNameDlName.Write(tzi.StandardName)
                                        swTzSysNameStdNameDlName.Write("====")
                                        swTzSysNameStdNameDlName.WriteLine(tzi.DaylightName)


                                        swTzStdNameDlName.Write(tzi.StandardName)
                                        swTzStdNameDlName.Write("====")
                                        swTzStdNameDlName.WriteLine(tzi.DaylightName)

                                        swTzStdName.WriteLine(tzi.StandardName)

                                        If tzi.StandardName <> tzi.DaylightName Then
                                            swTzStdNameWithDlName.Write(tzi.StandardName)
                                            swTzStdNameWithDlName.Write("====")
                                            swTzStdNameWithDlName.Write(tzi.DaylightName)

                                            swTzStdNameHavingDlName.WriteLine(tzi.StandardName)
                                        End If

                                    Next
                                    swTzSysName.Close()
                                    swTzSysNameStdName.Close()
                                    swTzStdNameDlName.Close()
                                    swTzStdName.Close()
                                    swTzStdNameWithDlName.Close()
                                    swTzStdNameHavingDlName.Close()
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using

        Dim tz As TimeZoneInfo = TimeZoneInfo.CurrentTimeZone
        For i As Integer = 0 To Me.CTZComboBox.Items.Count - 1
            If CType(Me.CTZComboBox.Items(i), TimeZoneInfo).Id = tz.Id Then
                Me.CTZComboBox.SelectedIndex = i
                Me.Tzi = CType(Me.CTZComboBox.Items(i), TimeZoneInfo)
                Me.YearNumericUpDown.Value = Me.Tzi.CurrentTime.Year
                Exit For
            End If
        Next

    End Sub

    Property Tzi() As TimeZoneInfo
        Get
            Return Me._tzi
        End Get
        Set(ByVal value As TimeZoneInfo)
            If Not (Me.Tzi IsNot Nothing AndAlso Me.Tzi.Id = value.Id) Then
                Me._tzi = value
            End If
        End Set
    End Property

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YearNumericUpDown.ValueChanged
        If Me.Visible AndAlso Me.Tzi IsNot Nothing Then
            Dim year As Integer = CInt(Me.YearNumericUpDown.Value)
            Me.PrintFiled("", "")
            Me.PrintFiled("DaylightChanges in " & year & ":", "")
            Dim dt As DaylightTime = Me.Tzi.GetDaylightChanges(year)
            Me.PrintFiled("Daylight Start Date: ", dt.Start.ToString("dddd, MMMM dd, yyyy   hh:mm:ss tt"))
            Me.PrintFiled("Daylight End Date: ", dt.End.ToString("dddd, MMMM dd, yyyy   hh:mm:ss tt"))
            Me.PrintFiled("Delta: ", dt.Delta.ToString)
            Me.DisplayRichTextBox.ScrollToCaret()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Print()
    End Sub

    Private Sub TZComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TZComboBox.SelectedIndexChanged
        If Me.Visible Then
            Me.Tzi = CType(Me.TZComboBox.SelectedItem, TimeZoneInfo)
            Me.YearNumericUpDown.Value = Me.Tzi.CurrentTime.Year
            Me.Print()
        End If
    End Sub

    Private Sub Print()
        Me.DisplayRichTextBox.Clear()

        Me.PrintFiled("Time Zone ID: ", Me.Tzi.Id)
        Me.PrintFiled("Display Name: ", Me.Tzi.DisplayName)
        Me.PrintFiled("Daylight Name: ", Me.Tzi.DaylightName)
        Me.PrintFiled("Standard Name: ", Me.Tzi.StandardName)
        Dim dt As DaylightTime = Me.Tzi.GetDaylightChanges(Me.Tzi.CurrentTime.Year)
        Me.PrintFiled("Daylight Starts: ", dt.Start.ToString("dddd, MMMM dd, yyyy   hh:mm:ss tt"))
        Me.PrintFiled("Daylight Ends: ", dt.End.ToString("dddd, MMMM dd, yyyy   hh:mm:ss tt"))
        Me.PrintFiled("Delta: ", dt.Delta.ToString)
        Me.PrintFiled("Daylight SavingTime: ", CStr(Me.Tzi.IsDaylightSavingTime))
        Me.PrintFiled("Standard Utc Offset: ", Me.Tzi.StandardUtcOffset.ToString)
        Me.PrintFiled("Current Utc Offset: ", Me.Tzi.CurrentUtcOffset.ToString)
        Me.PrintFiled("CurrentTime: ", Me.Tzi.CurrentTime.ToString("dddd, MMMM dd, yyyy   hh:mm:ss tt"))
        Me.PrintFiled("", "")
        Me.DisplayRichTextBox.ScrollToCaret()
    End Sub

    Private Sub PrintFiled(ByVal titel As String, ByVal text As String)
        Me.DisplayRichTextBox.SelectionFont = New Font(Me.Font.FontFamily, Me.Font.Size, fontstyle.Bold)
        Me.DisplayRichTextBox.SelectedText = titel
        Me.DisplayRichTextBox.SelectionFont = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
        Me.DisplayRichTextBox.SelectedText = text
        Me.DisplayRichTextBox.SelectedText = Environment.NewLine
    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplyButton.Click
        TimeZoneInfo.CurrentTimeZone = CType(Me.CTZComboBox.SelectedItem, TimeZoneInfo)
        Me.Tzi = CType(Me.CTZComboBox.SelectedItem, TimeZoneInfo)
        Me.YearNumericUpDown.Value = Me.Tzi.CurrentTime.Year
        Me.Print()
        Me.TableLayoutPanel1.Enabled = False
    End Sub

    Private Sub CTZComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CTZComboBox.SelectedIndexChanged
        If Me.Visible Then
            Me.TableLayoutPanel1.Enabled = True
        End If
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton1.Click
        Dim tz As TimeZoneInfo = TimeZoneInfo.CurrentTimeZone
        For i As Integer = 0 To Me.CTZComboBox.Items.Count - 1
            If CType(Me.CTZComboBox.Items(i), TimeZoneInfo).Id = tz.Id Then
                Me.CTZComboBox.SelectedIndex = i
                Exit For
            End If
        Next
        Me.TableLayoutPanel1.Enabled = False
    End Sub
End Class

