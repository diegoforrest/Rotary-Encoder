<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Guna2ToggleSwitch1 = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.LabelEncoderValue = New System.Windows.Forms.Label()
        Me.Button2 = New Guna.UI2.WinForms.Guna2Button()
        Me.LabelStartButton = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Guna2ToggleSwitch1
        '
        Me.Guna2ToggleSwitch1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ToggleSwitch1.CheckedState.BorderColor = System.Drawing.Color.Transparent
        Me.Guna2ToggleSwitch1.CheckedState.BorderRadius = 10
        Me.Guna2ToggleSwitch1.CheckedState.FillColor = System.Drawing.Color.Green
        Me.Guna2ToggleSwitch1.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.CheckedState.InnerColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.Location = New System.Drawing.Point(328, 480)
        Me.Guna2ToggleSwitch1.Name = "Guna2ToggleSwitch1"
        Me.Guna2ToggleSwitch1.Size = New System.Drawing.Size(72, 26)
        Me.Guna2ToggleSwitch1.TabIndex = 0
        Me.Guna2ToggleSwitch1.UncheckedState.BorderColor = System.Drawing.Color.Transparent
        Me.Guna2ToggleSwitch1.UncheckedState.BorderRadius = 10
        Me.Guna2ToggleSwitch1.UncheckedState.FillColor = System.Drawing.Color.Red
        Me.Guna2ToggleSwitch1.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.Guna2ToggleSwitch1.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'LabelEncoderValue
        '
        Me.LabelEncoderValue.AutoSize = True
        Me.LabelEncoderValue.BackColor = System.Drawing.Color.Transparent
        Me.LabelEncoderValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.2!)
        Me.LabelEncoderValue.Location = New System.Drawing.Point(43, 234)
        Me.LabelEncoderValue.Name = "LabelEncoderValue"
        Me.LabelEncoderValue.Size = New System.Drawing.Size(111, 35)
        Me.LabelEncoderValue.TabIndex = 1
        Me.LabelEncoderValue.Text = "Value: "
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BorderColor = System.Drawing.Color.Transparent
        Me.Button2.BorderRadius = 25
        Me.Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Button2.FillColor = System.Drawing.Color.Transparent
        Me.Button2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(96, 308)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(213, 38)
        Me.Button2.TabIndex = 3
        '
        'LabelStartButton
        '
        Me.LabelStartButton.AutoSize = True
        Me.LabelStartButton.BackColor = System.Drawing.Color.Transparent
        Me.LabelStartButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.2!)
        Me.LabelStartButton.Location = New System.Drawing.Point(196, 234)
        Me.LabelStartButton.Name = "LabelStartButton"
        Me.LabelStartButton.Size = New System.Drawing.Size(113, 35)
        Me.LabelStartButton.TabIndex = 4
        Me.LabelStartButton.Text = "Status:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(408, 512)
        Me.Controls.Add(Me.LabelStartButton)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.LabelEncoderValue)
        Me.Controls.Add(Me.Guna2ToggleSwitch1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "EXPERIMENT #4"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2ToggleSwitch1 As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents LabelEncoderValue As Label
    Friend WithEvents Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents LabelStartButton As Label
End Class
