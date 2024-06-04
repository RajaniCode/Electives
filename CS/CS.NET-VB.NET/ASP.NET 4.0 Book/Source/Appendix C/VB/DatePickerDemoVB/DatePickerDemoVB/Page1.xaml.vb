Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace DatePickerDemoVB
    ''' <summary>
    ''' Interaction logic for Page1.xaml
    ''' </summary>
    Partial Public Class Page1
        Inherits Page
        Public Sub New()
            InitializeComponent()
            SetDisplayDates()
        End Sub
        Private Sub SetDisplayDates()
            myDP.DisplayDate = New DateTime(2010, 6, 1)
            myDP.DisplayDateStart = New DateTime(2010, 6, 1)
            myDP.DisplayDateEnd = New DateTime(2010, 6, 30)
            myDP.FirstDayOfWeek = DayOfWeek.Tuesday
        End Sub
    End Class
End Namespace

