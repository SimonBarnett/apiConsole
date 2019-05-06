<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Install
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Install))
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(12, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(105, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "MS URL Rewrite"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(12, 126)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(172, 17)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "Install .Net Endpoint Templates"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(12, 34)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(108, 17)
        Me.RadioButton5.TabIndex = 4
        Me.RadioButton5.Text = "Copy API website"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(56, 171)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 45)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Install"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(12, 80)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(86, 17)
        Me.RadioButton6.TabIndex = 0
        Me.RadioButton6.Text = "Configure IIS"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Location = New System.Drawing.Point(12, 103)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(139, 17)
        Me.RadioButton7.TabIndex = 7
        Me.RadioButton7.Text = "Install .Net Visual Studio"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(12, 57)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(94, 17)
        Me.RadioButton2.TabIndex = 8
        Me.RadioButton2.Text = "Set SQL Login"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Install
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(223, 228)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton7)
        Me.Controls.Add(Me.RadioButton6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Install"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Install"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents RadioButton7 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
End Class
