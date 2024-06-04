Public Delegate Sub ValueUpdatedEventHandler(ByVal sender As Object, ByVal e As ValueUpdatedEventArgs)

Public Class ValueUpdatedEventArgs
    Inherits System.EventArgs

    ' Stores the new value
    Dim _newValue As String

    ' Create a new instance of the 
    ' ValueUpdatedEventArgs class.
    ' newValue represents the change to the value.
    Public Sub New(ByVal newValue As String)
        MyBase.New()

        Me._newValue = newValue

    End Sub

    ' Gets the updated value
    ReadOnly Property NewValue() As String
        Get
            Return Me._newValue
        End Get
    End Property

End Class
