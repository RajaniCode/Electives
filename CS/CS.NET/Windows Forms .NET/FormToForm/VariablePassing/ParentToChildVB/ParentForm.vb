Public Class ParentForm
    Inherits System.Windows.Forms.Form

    Private uxChildForm As ChildForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents uxOpenDialog As System.Windows.Forms.Button
    Friend WithEvents uxOpenForm As System.Windows.Forms.Button
    Friend WithEvents uxUserResponse As System.Windows.Forms.TextBox
    Friend WithEvents uxPrompt As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.uxOpenDialog = New System.Windows.Forms.Button
        Me.uxOpenForm = New System.Windows.Forms.Button
        Me.uxUserResponse = New System.Windows.Forms.TextBox
        Me.uxPrompt = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'uxOpenDialog
        '
        Me.uxOpenDialog.Location = New System.Drawing.Point(144, 40)
        Me.uxOpenDialog.Name = "uxOpenDialog"
        Me.uxOpenDialog.Size = New System.Drawing.Size(152, 23)
        Me.uxOpenDialog.TabIndex = 7
        Me.uxOpenDialog.Text = "Open Child Form as Dialog"
        '
        'uxOpenForm
        '
        Me.uxOpenForm.Location = New System.Drawing.Point(16, 40)
        Me.uxOpenForm.Name = "uxOpenForm"
        Me.uxOpenForm.Size = New System.Drawing.Size(120, 23)
        Me.uxOpenForm.TabIndex = 6
        Me.uxOpenForm.Text = "Open Child Form"
        '
        'uxUserResponse
        '
        Me.uxUserResponse.Location = New System.Drawing.Point(176, 8)
        Me.uxUserResponse.Name = "uxUserResponse"
        Me.uxUserResponse.Size = New System.Drawing.Size(120, 20)
        Me.uxUserResponse.TabIndex = 5
        Me.uxUserResponse.Text = ""
        '
        'uxPrompt
        '
        Me.uxPrompt.Location = New System.Drawing.Point(8, 8)
        Me.uxPrompt.Name = "uxPrompt"
        Me.uxPrompt.Size = New System.Drawing.Size(168, 23)
        Me.uxPrompt.TabIndex = 4
        Me.uxPrompt.Text = "Type the value for your variable:"
        '
        'ParentForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 78)
        Me.Controls.Add(Me.uxOpenDialog)
        Me.Controls.Add(Me.uxOpenForm)
        Me.Controls.Add(Me.uxUserResponse)
        Me.Controls.Add(Me.uxPrompt)
        Me.Name = "ParentForm"
        Me.Text = "Parent Form"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub uxOpenForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxOpenForm.Click
        ' Get the value that the child will be initialised with
        Dim initialValue As String
        initialValue = Me.uxUserResponse.Text

        ' Create the child form.
        Me.uxChildForm = New ChildForm(initialValue)

        ' Show the child form.
        Me.uxChildForm.Show()
    End Sub

    Private Sub uxOpenDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxOpenDialog.Click
        ' Get the value that the child will be initialised with
        Dim initialValue As String
        initialValue = Me.uxUserResponse.Text

        Dim childForm As ChildForm

        ' Create the child form.
        childForm = New ChildForm(initialValue)

        ' Show the child dialog.
        childForm.ShowDialog()
    End Sub

    Private Sub uxUserResponse_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxUserResponse.TextChanged
        ' Pass the variable from the parent to the child form while the child
        ' is already open.
        If Not Me.uxChildForm Is Nothing Then
            Me.uxChildForm.ValueFromParent = Me.uxUserResponse.Text
        End If
    End Sub
End Class
