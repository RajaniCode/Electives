' delegate void CustomEventHandler(object sender, CustomEventArgs e);
Delegate Sub CustomEventHandler(ByVal sender As System.Object, ByVal e As CustomEventArgs)

Class CustomEventArgs
    Inherits EventArgs

    Private TextBoxText As String

    Public Sub New(ByVal TextBoxText As String)
        Me.TextBoxText = TextBoxText
    End Sub

    Friend ReadOnly Property TextBoxTextChanged() As String
        Get
            Return TextBoxText
        End Get
    End Property

End Class
