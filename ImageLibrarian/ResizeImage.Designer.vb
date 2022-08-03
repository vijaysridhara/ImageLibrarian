<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResizeImage
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
        Me.trkPct = New System.Windows.Forms.TrackBar()
        Me.nupdPercent = New System.Windows.Forms.NumericUpDown()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.butOK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.trkPct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupdPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'trkPct
        '
        Me.trkPct.Location = New System.Drawing.Point(12, 12)
        Me.trkPct.Maximum = 100
        Me.trkPct.Minimum = 1
        Me.trkPct.Name = "trkPct"
        Me.trkPct.Size = New System.Drawing.Size(477, 45)
        Me.trkPct.TabIndex = 0
        Me.trkPct.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.trkPct.Value = 100
        '
        'nupdPercent
        '
        Me.nupdPercent.Location = New System.Drawing.Point(23, 63)
        Me.nupdPercent.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupdPercent.Name = "nupdPercent"
        Me.nupdPercent.Size = New System.Drawing.Size(54, 23)
        Me.nupdPercent.TabIndex = 1
        Me.nupdPercent.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(126, 62)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.ReadOnly = True
        Me.txtWidth.Size = New System.Drawing.Size(50, 23)
        Me.txtWidth.TabIndex = 2
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(201, 62)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.ReadOnly = True
        Me.txtHeight.Size = New System.Drawing.Size(50, 23)
        Me.txtHeight.TabIndex = 2
        Me.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(182, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "x"
        '
        'butCancel
        '
        Me.butCancel.Location = New System.Drawing.Point(383, 63)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(94, 31)
        Me.butCancel.TabIndex = 15
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(283, 63)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(94, 31)
        Me.butOK.TabIndex = 14
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "%"
        '
        'ResizeImage
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(510, 102)
        Me.ControlBox = False
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHeight)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.nupdPercent)
        Me.Controls.Add(Me.trkPct)
        Me.Name = "ResizeImage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ResizeImage"
        CType(Me.trkPct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupdPercent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents trkPct As TrackBar
    Friend WithEvents nupdPercent As NumericUpDown
    Friend WithEvents txtWidth As TextBox
    Friend WithEvents txtHeight As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents butCancel As Button
    Friend WithEvents butOK As Button
    Friend WithEvents Label2 As Label
End Class
