Partial Public Class MainPage


    Inherits UserControl
    Private checkTicket As Boolean
    Public Sub New()
        InitializeComponent()
        checkTicket = True
        text2.Text = "Today is " & DateTime.Now
        toIconButton.IsEnabled = False
        selectIconButton.IsEnabled = False
        fromCal.Visibility = Visibility.Collapsed
        toCal.Visibility = Visibility.Collapsed
        selectCal.Visibility = Visibility.Collapsed
    End Sub
    Private Sub fromIconClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
        fromCal.Visibility = Visibility.Visible
        fromCal.DisplayDateStart = New DateTime(2010, 1, 1)
        fromCal.DisplayDateEnd = New DateTime(2011, 12, 31)
    End Sub
    Private Sub fromCalDateSelected(ByVal sender As Object, ByVal e As RoutedEventArgs)
        fromDateBox.Text = fromCal.SelectedDate.ToString()
        fromCal.Visibility = Visibility.Collapsed
        toIconButton.IsEnabled = True
    End Sub
    Private Sub toIconClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
        toCal.Visibility = Visibility.Visible
        toCal.DisplayDateStart = fromCal.SelectedDate
        toCal.DisplayDateEnd = fromCal.DisplayDateEnd
    End Sub
    Private Sub toCalDateSelected(ByVal sender As Object, ByVal e As RoutedEventArgs)
        toDateBox.Text = toCal.SelectedDate.ToString()
        toCal.Visibility = Visibility.Collapsed
        checkAvailibility.IsEnabled = True
    End Sub
    Private Sub isTicketAvailable(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If checkTicket = True Then
            selectIconButton.IsEnabled = True
        End If
    End Sub
    Private Sub selectIconClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
        selectCal.Visibility = Visibility.Visible
        selectCal.DisplayDateStart = fromCal.SelectedDate
        selectCal.DisplayDateEnd = toCal.SelectedDate
    End Sub
    Private Sub selectCalDateSelected(ByVal sender As Object, ByVal e As RoutedEventArgs)
        selectDateBox.Text = selectCal.SelectedDate.ToString()
        selectCal.Visibility = Visibility.Collapsed
        confirmButton.IsEnabled = True
    End Sub
    Private Sub confirmBooking(ByVal sender As Object, ByVal e As RoutedEventArgs)
        text3.Opacity = 0
        text4.Opacity = 0
        text5.Opacity = 0
        text6.Opacity = 0
        fromDateBox.Opacity = 0
        fromIconButton.Opacity = 0
        toDateBox.Opacity = 0
        toIconButton.Opacity = 0
        selectDateBox.Opacity = 0
        selectIconButton.Opacity = 0
        checkAvailibility.Opacity = 0
        confirmButton.Opacity = 0
        text1.Text = "Thank You"
    End Sub
End Class
