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

Namespace CalendarDemoVB
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
            myCal1.DisplayDate = New DateTime(2010, 5, 1)
            myCal1.DisplayDateStart = New DateTime(2010, 5, 1)
            myCal1.DisplayDateEnd = New DateTime(2010, 8, 31)
        End Sub

        Private Sub myCal1_SelectedDatesChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
            MessageBox.Show("You selected: " + myCal1.SelectedDate.ToString())
        End Sub
    End Class
End Namespace

