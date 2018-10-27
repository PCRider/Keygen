<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FKeygen
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
        Me.LHardCode = New System.Windows.Forms.Label()
        Me.THardCode = New System.Windows.Forms.TextBox()
        Me.TSerial = New System.Windows.Forms.TextBox()
        Me.LSerial = New System.Windows.Forms.Label()
        Me.TActCode = New System.Windows.Forms.TextBox()
        Me.BRegen = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BReg = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LHardCode
        '
        Me.LHardCode.AutoSize = True
        Me.LHardCode.Location = New System.Drawing.Point(11, 9)
        Me.LHardCode.Name = "LHardCode"
        Me.LHardCode.Size = New System.Drawing.Size(90, 13)
        Me.LHardCode.TabIndex = 0
        Me.LHardCode.Text = "HardWare Code :"
        '
        'THardCode
        '
        Me.THardCode.Location = New System.Drawing.Point(101, 6)
        Me.THardCode.Name = "THardCode"
        Me.THardCode.Size = New System.Drawing.Size(174, 20)
        Me.THardCode.TabIndex = 1
        '
        'TSerial
        '
        Me.TSerial.Location = New System.Drawing.Point(101, 32)
        Me.TSerial.Name = "TSerial"
        Me.TSerial.Size = New System.Drawing.Size(174, 20)
        Me.TSerial.TabIndex = 2
        Me.TSerial.Text = "00000-00000-00000-00000-00000"
        '
        'LSerial
        '
        Me.LSerial.AutoSize = True
        Me.LSerial.Location = New System.Drawing.Point(11, 35)
        Me.LSerial.Name = "LSerial"
        Me.LSerial.Size = New System.Drawing.Size(79, 13)
        Me.LSerial.TabIndex = 3
        Me.LSerial.Text = "Serial Number :"
        '
        'TActCode
        '
        Me.TActCode.Location = New System.Drawing.Point(101, 58)
        Me.TActCode.Name = "TActCode"
        Me.TActCode.Size = New System.Drawing.Size(174, 20)
        Me.TActCode.TabIndex = 4
        '
        'BRegen
        '
        Me.BRegen.Location = New System.Drawing.Point(14, 84)
        Me.BRegen.Name = "BRegen"
        Me.BRegen.Size = New System.Drawing.Size(75, 23)
        Me.BRegen.TabIndex = 5
        Me.BRegen.Text = "Generate"
        Me.BRegen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Activation Code :"
        '
        'BReg
        '
        Me.BReg.Location = New System.Drawing.Point(200, 84)
        Me.BReg.Name = "BReg"
        Me.BReg.Size = New System.Drawing.Size(75, 23)
        Me.BReg.TabIndex = 7
        Me.BReg.Text = "Register"
        Me.BReg.UseVisualStyleBackColor = True
        '
        'FKeygen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 115)
        Me.Controls.Add(Me.BReg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BRegen)
        Me.Controls.Add(Me.TActCode)
        Me.Controls.Add(Me.LSerial)
        Me.Controls.Add(Me.TSerial)
        Me.Controls.Add(Me.THardCode)
        Me.Controls.Add(Me.LHardCode)
        Me.Name = "FKeygen"
        Me.Text = "AryaTranslator V2 Keygen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LHardCode As System.Windows.Forms.Label
    Friend WithEvents THardCode As System.Windows.Forms.TextBox
    Friend WithEvents TSerial As System.Windows.Forms.TextBox
    Friend WithEvents LSerial As System.Windows.Forms.Label
    Friend WithEvents TActCode As System.Windows.Forms.TextBox
    Friend WithEvents BRegen As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BReg As System.Windows.Forms.Button

End Class
