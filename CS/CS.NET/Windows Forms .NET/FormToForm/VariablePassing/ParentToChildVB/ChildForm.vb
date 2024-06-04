Public Class ChildForm
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal initialValue As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ValueFromParent = initialValue
    End Sub

#Region " Windows Form Designer generated code "


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
    Friend WithEvents uxParentValue As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.uxParentValue = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'uxParentValue
        '
        Me.uxParentValue.Location = New System.Drawing.Point(176, 8)
        Me.uxParentValue.Name = "uxParentValue"
        Me.uxParentValue.ReadOnly = True
        Me.uxParentValue.Size = New System.Drawing.Size(144, 20)
        Me.uxParentValue.TabIndex = 3
        Me.uxParentValue.Text = ""
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(8, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(168, 23)
        Me.label1.TabIndex = 2
        Me.label1.Text = "The value from the parent form:"
        '
        'ChildForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(330, 40)
        Me.Controls.Add(Me.uxParentValue)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChildForm"
        Me.Text = "Child Form"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public WriteOnly Property ValueFromParent() As String
        Set(ByVal Value As String)
            Me.uxParentValue.Text = Value
        End Set
    End Property
End Class
