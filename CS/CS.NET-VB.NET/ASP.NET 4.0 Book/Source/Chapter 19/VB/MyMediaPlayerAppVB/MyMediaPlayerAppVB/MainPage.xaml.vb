Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub mediaOpen(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaFile.Text += mediaEle.Source.ToString()
        duration.Text += mediaEle.NaturalDuration.TimeSpan.Hours.ToString() & ":" &
         mediaEle.NaturalDuration.TimeSpan.Minutes.ToString() & ":" &
         mediaEle.NaturalDuration.TimeSpan.Seconds.ToString()
    End Sub
    Public Sub mediaError(ByVal sender As Object, ByVal e As RoutedEventArgs)
        errorText.Text = "Failed to open the media"
    End Sub
    Public Sub mediaPlay(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaEle.Play()
        play.Content = "Play"
    End Sub
    Public Sub mediaPause(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaEle.Pause()
        play.Content = "Resume"
    End Sub
    Public Sub mediaStop(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaEle.Stop()
        play.Content = "Play"
    End Sub
End Class