<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NameCaptureForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSubmitName = New System.Windows.Forms.Button()
        Me.tbxNameBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnSubmitName
        '
        Me.btnSubmitName.Location = New System.Drawing.Point(211, 12)
        Me.btnSubmitName.Name = "btnSubmitName"
        Me.btnSubmitName.Size = New System.Drawing.Size(65, 20)
        Me.btnSubmitName.TabIndex = 0
        Me.btnSubmitName.Text = "Submit"
        Me.btnSubmitName.UseVisualStyleBackColor = True
        '
        'tbxNameBox
        '
        Me.tbxNameBox.Location = New System.Drawing.Point(12, 12)
        Me.tbxNameBox.Name = "tbxNameBox"
        Me.tbxNameBox.Size = New System.Drawing.Size(193, 20)
        Me.tbxNameBox.TabIndex = 1
        '
        'NameCaptureForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 43)
        Me.Controls.Add(Me.tbxNameBox)
        Me.Controls.Add(Me.btnSubmitName)
        Me.Name = "NameCaptureForm"
        Me.Text = "NameCaptureForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSubmitName As System.Windows.Forms.Button
    Friend WithEvents tbxNameBox As System.Windows.Forms.TextBox
End Class
