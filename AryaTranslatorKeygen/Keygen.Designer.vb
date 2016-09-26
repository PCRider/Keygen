<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Keygen
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
        Me.txtCpuId = New System.Windows.Forms.TextBox()
        Me.SerialBox = New System.Windows.Forms.TextBox()
        Me.ActivationBox = New System.Windows.Forms.TextBox()
        Me.HWLable = New System.Windows.Forms.Label()
        Me.SNLable = New System.Windows.Forms.Label()
        Me.ACLable = New System.Windows.Forms.Label()
        Me.Regen = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtCpuId
        '
        Me.txtCpuId.Location = New System.Drawing.Point(112, 12)
        Me.txtCpuId.Name = "txtCpuId"
        Me.txtCpuId.Size = New System.Drawing.Size(170, 20)
        Me.txtCpuId.TabIndex = 0
        '
        'SerialBox
        '
        Me.SerialBox.Location = New System.Drawing.Point(112, 38)
        Me.SerialBox.Name = "SerialBox"
        Me.SerialBox.Size = New System.Drawing.Size(170, 20)
        Me.SerialBox.TabIndex = 1
        Me.SerialBox.Text = "00000-00000-00000-00000-00000"
        '
        'ActivationBox
        '
        Me.ActivationBox.Location = New System.Drawing.Point(112, 64)
        Me.ActivationBox.Name = "ActivationBox"
        Me.ActivationBox.Size = New System.Drawing.Size(170, 20)
        Me.ActivationBox.TabIndex = 2
        '
        'HWLable
        '
        Me.HWLable.AutoSize = True
        Me.HWLable.Location = New System.Drawing.Point(12, 15)
        Me.HWLable.Name = "HWLable"
        Me.HWLable.Size = New System.Drawing.Size(81, 13)
        Me.HWLable.TabIndex = 3
        Me.HWLable.Text = "Hardware Code"
        '
        'SNLable
        '
        Me.SNLable.AutoSize = True
        Me.SNLable.Location = New System.Drawing.Point(12, 41)
        Me.SNLable.Name = "SNLable"
        Me.SNLable.Size = New System.Drawing.Size(73, 13)
        Me.SNLable.TabIndex = 4
        Me.SNLable.Text = "Serial Number"
        '
        'ACLable
        '
        Me.ACLable.AutoSize = True
        Me.ACLable.Location = New System.Drawing.Point(12, 67)
        Me.ACLable.Name = "ACLable"
        Me.ACLable.Size = New System.Drawing.Size(82, 13)
        Me.ACLable.TabIndex = 5
        Me.ACLable.Text = "Activation Code"
        '
        'Regen
        '
        Me.Regen.Location = New System.Drawing.Point(15, 90)
        Me.Regen.Name = "Regen"
        Me.Regen.Size = New System.Drawing.Size(110, 23)
        Me.Regen.TabIndex = 6
        Me.Regen.Text = "Generate Key"
        Me.Regen.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(157, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Keygen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 132)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Regen)
        Me.Controls.Add(Me.ACLable)
        Me.Controls.Add(Me.SNLable)
        Me.Controls.Add(Me.HWLable)
        Me.Controls.Add(Me.ActivationBox)
        Me.Controls.Add(Me.SerialBox)
        Me.Controls.Add(Me.txtCpuId)
        Me.Name = "Keygen"
        Me.Text = "AryaTranslator V2 Keygen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCpuId As System.Windows.Forms.TextBox
    Friend WithEvents SerialBox As System.Windows.Forms.TextBox
    Friend WithEvents ActivationBox As System.Windows.Forms.TextBox
    Friend WithEvents HWLable As System.Windows.Forms.Label
    Friend WithEvents SNLable As System.Windows.Forms.Label
    Friend WithEvents ACLable As System.Windows.Forms.Label
    Friend WithEvents Regen As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
