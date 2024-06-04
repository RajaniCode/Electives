Public Class ParentForm
    Inherits System.Windows.Forms.Form

    Private WithEvents childA As ChildAForm
    Private WithEvents childB As ChildBForm

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
    Friend WithEvents uxChildBValue As System.Windows.Forms.TextBox
    Friend WithEvents uxChildAValue As System.Windows.Forms.TextBox
    Friend WithEvents uxChildBValueLabel As System.Windows.Forms.Label
    Friend WithEvents uxChildAValueLabel As System.Windows.Forms.Label
    Friend WithEvents uxOpenChildB As System.Windows.Forms.Button
    Friend WithEvents uxOpenChildA As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.uxChildBValue = New System.Windows.Forms.TextBox
        Me.uxChildAValue = New System.Windows.Forms.TextBox
        Me.uxChildBValueLabel = New System.Windows.Forms.Label
        Me.uxChildAValueLabel = New System.Windows.Forms.Label
        Me.uxOpenChildB = New System.Windows.Forms.Button
        Me.uxOpenChildA = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'uxChildBValue
        '
        Me.uxChildBValue.Location = New System.Drawing.Point(120, 56)
        Me.uxChildBValue.Name = "uxChildBValue"
        Me.uxChildBValue.ReadOnly = True
        Me.uxChildBValue.TabIndex = 11
        Me.uxChildBValue.Text = ""
        '
        'uxChildAValue
        '
        Me.uxChildAValue.Location = New System.Drawing.Point(8, 56)
        Me.uxChildAValue.Name = "uxChildAValue"
        Me.uxChildAValue.ReadOnly = True
        Me.uxChildAValue.TabIndex = 10
        Me.uxChildAValue.Text = ""
        '
        'uxChildBValueLabel
        '
        Me.uxChildBValueLabel.Location = New System.Drawing.Point(120, 40)
        Me.uxChildBValueLabel.Name = "uxChildBValueLabel"
        Me.uxChildBValueLabel.Size = New System.Drawing.Size(100, 16)
        Me.uxChildBValueLabel.TabIndex = 9
        Me.uxChildBValueLabel.Text = "Child 'B' Value:"
        '
        'uxChildAValueLabel
        '
        Me.uxChildAValueLabel.Location = New System.Drawing.Point(8, 40)
        Me.uxChildAValueLabel.Name = "uxChildAValueLabel"
        Me.uxChildAValueLabel.Size = New System.Drawing.Size(100, 16)
        Me.uxChildAValueLabel.TabIndex = 8
        Me.uxChildAValueLabel.Text = "Child 'A' Value:"
        '
        'uxOpenChildB
        '
        Me.uxOpenChildB.Location = New System.Drawing.Point(120, 8)
        Me.uxOpenChildB.Name = "uxOpenChildB"
        Me.uxOpenChildB.Size = New System.Drawing.Size(104, 23)
        Me.uxOpenChildB.TabIndex = 7
        Me.uxOpenChildB.Text = "Open Child 'B'"
        '
        'uxOpenChildA
        '
        Me.uxOpenChildA.Location = New System.Drawing.Point(8, 8)
        Me.uxOpenChildA.Name = "uxOpenChildA"
        Me.uxOpenChildA.Size = New System.Drawing.Size(104, 23)
        Me.uxOpenChildA.TabIndex = 6
        Me.uxOpenChildA.Text = "Open Child 'A'"
        '
        'ParentForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(232, 86)
        Me.Controls.Add(Me.uxChildBValue)
        Me.Controls.Add(Me.uxChildAValue)
        Me.Controls.Add(Me.uxChildBValueLabel)
        Me.Controls.Add(Me.uxChildAValueLabel)
        Me.Controls.Add(Me.uxOpenChildB)
        Me.Controls.Add(Me.uxOpenChildA)
        Me.Name = "ParentForm"
        Me.Text = "Parent Form"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub uxOpenChildA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxOpenChildA.Click
        ' Create the child form
        Me.childA = New ChildAForm

        ' Add a handler to this class for when child A is updated
        AddHandler childA.ValueUpdated, AddressOf ChildAValueUpdated

        If Not Me.childB Is Nothing Then
            ' Make sure that the siblings are informed of each other.
            AddHandler childA.ValueUpdated, AddressOf childB.ChildAValueUpdated
            AddHandler childB.ValueUpdated, AddressOf childA.ChildBValueUpdated
        End If

        ' Show the form
        Me.childA.Show()
    End Sub

    Private Sub ChildAValueUpdated(ByVal sender As Object, ByVal e As ValueUpdatedEventArgs) Handles childA.ValueUpdated
        ' Update the value on this form (the parent) with the 
        ' value from the child.
        Me.uxChildAValue.Text = e.NewValue
    End Sub

    Private Sub uxOpenChildB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxOpenChildB.Click
        ' Create the child form
        Me.childB = New ChildBForm

        ' Add a handler to this class for when child A is updated
        AddHandler childB.ValueUpdated, AddressOf ChildBValueUpdated

        If Not Me.childA Is Nothing Then
            ' Make sure that the siblings are informed of each other.
            AddHandler childA.ValueUpdated, AddressOf childB.ChildAValueUpdated
            AddHandler childB.ValueUpdated, AddressOf childA.ChildBValueUpdated
        End If

        ' Show the form
        Me.childB.Show()
    End Sub

    Private Sub ChildBValueUpdated(ByVal sender As Object, ByVal e As ValueUpdatedEventArgs) Handles childB.ValueUpdated
        Me.uxChildBValue.Text = e.NewValue
    End Sub
End Class
