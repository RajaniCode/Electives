 Partial Public Class App
    Inherits Application

    Dim mainUI As Grid = New Grid()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Application_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
        Me.RootVisual = mainUI
        mainUI.Children.Add(New Page1())
    End Sub

    Private userName_Renamed As String

    Public Property UserName() As String
        Get
            Return userName_Renamed
        End Get
        Set(ByVal value As String)
            userName_Renamed = value
        End Set
    End Property

 

    Public Sub GoToPage(ByVal nextPg As UserControl)
        Dim app As App = CType(Application.Current, App)
        ' Remove the displayed page
        app.mainUI.Children.Clear()
        ' Show the next page
        app.mainUI.Children.Add(nextPg)
    End Sub
    
    Private Sub Application_Exit(ByVal o As Object, ByVal e As EventArgs) Handles Me.Exit

    End Sub
    
    Private Sub Application_UnhandledException(ByVal sender As object, ByVal e As ApplicationUnhandledExceptionEventArgs) Handles Me.UnhandledException

        ' If the app is running outside of the debugger then report the exception using
        ' the browser's exception mechanism. On IE this will display it a yellow alert 
        ' icon in the status bar and Firefox will display a script error.
        If Not System.Diagnostics.Debugger.IsAttached Then

            ' NOTE: This will allow the application to continue running after an exception has been thrown
            ' but not handled. 
            ' For production applications this error handling should be replaced with something that will 
            ' report the error to the website and stop the application.
            e.Handled = True

            Try
                Dim errorMsg As String = e.ExceptionObject.Message + e.ExceptionObject.StackTrace
                errorMsg = errorMsg.Replace(""""c, "\"c).Replace("\r\n", "\n")

                System.Windows.Browser.HtmlPage.Window.Eval("throw New Error(""Unhandled Error in Silverlight 2 Application " + errorMsg + """);")
            Catch

            End Try
        End If
    End Sub
    
End Class
