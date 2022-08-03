<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Export
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.butBrowse = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nupdOuterBorder = New System.Windows.Forms.NumericUpDown()
        Me.butOuterBorderColor = New System.Windows.Forms.Button()
        Me.chkOutBorder = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.nupdInnerBorder = New System.Windows.Forms.NumericUpDown()
        Me.butInBorderColor = New System.Windows.Forms.Button()
        Me.chkInBorder = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.butOK = New System.Windows.Forms.Button()
        Me.lblStatusmessage = New System.Windows.Forms.Label()
        Me.chkResize = New System.Windows.Forms.CheckBox()
        Me.nupdMaxWidth = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nupdOuterBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nupdInnerBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupdMaxWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(2, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "&Max long side"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(147, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "px"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(80, 12)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(218, 23)
        Me.txtLocation.TabIndex = 1
        '
        'butBrowse
        '
        Me.butBrowse.Location = New System.Drawing.Point(304, 12)
        Me.butBrowse.Name = "butBrowse"
        Me.butBrowse.Size = New System.Drawing.Size(38, 25)
        Me.butBrowse.TabIndex = 2
        Me.butBrowse.Text = "..."
        Me.butBrowse.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "To &location"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nupdOuterBorder)
        Me.GroupBox1.Controls.Add(Me.butOuterBorderColor)
        Me.GroupBox1.Controls.Add(Me.chkOutBorder)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(143, 71)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Outer border"
        '
        'nupdOuterBorder
        '
        Me.nupdOuterBorder.Location = New System.Drawing.Point(12, 40)
        Me.nupdOuterBorder.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupdOuterBorder.Name = "nupdOuterBorder"
        Me.nupdOuterBorder.Size = New System.Drawing.Size(39, 23)
        Me.nupdOuterBorder.TabIndex = 1
        Me.nupdOuterBorder.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'butOuterBorderColor
        '
        Me.butOuterBorderColor.BackColor = System.Drawing.Color.Black
        Me.butOuterBorderColor.Location = New System.Drawing.Point(83, 39)
        Me.butOuterBorderColor.Name = "butOuterBorderColor"
        Me.butOuterBorderColor.Size = New System.Drawing.Size(52, 24)
        Me.butOuterBorderColor.TabIndex = 3
        Me.butOuterBorderColor.UseVisualStyleBackColor = False
        '
        'chkOutBorder
        '
        Me.chkOutBorder.AutoSize = True
        Me.chkOutBorder.Location = New System.Drawing.Point(12, 19)
        Me.chkOutBorder.Name = "chkOutBorder"
        Me.chkOutBorder.Size = New System.Drawing.Size(91, 19)
        Me.chkOutBorder.TabIndex = 0
        Me.chkOutBorder.Text = "Draw border"
        Me.chkOutBorder.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(57, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "px"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nupdInnerBorder)
        Me.GroupBox2.Controls.Add(Me.butInBorderColor)
        Me.GroupBox2.Controls.Add(Me.chkInBorder)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(198, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(143, 71)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Outer border"
        '
        'nupdInnerBorder
        '
        Me.nupdInnerBorder.Location = New System.Drawing.Point(7, 40)
        Me.nupdInnerBorder.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupdInnerBorder.Name = "nupdInnerBorder"
        Me.nupdInnerBorder.Size = New System.Drawing.Size(39, 23)
        Me.nupdInnerBorder.TabIndex = 1
        Me.nupdInnerBorder.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'butInBorderColor
        '
        Me.butInBorderColor.BackColor = System.Drawing.Color.White
        Me.butInBorderColor.Location = New System.Drawing.Point(78, 39)
        Me.butInBorderColor.Name = "butInBorderColor"
        Me.butInBorderColor.Size = New System.Drawing.Size(52, 24)
        Me.butInBorderColor.TabIndex = 3
        Me.butInBorderColor.UseVisualStyleBackColor = False
        '
        'chkInBorder
        '
        Me.chkInBorder.AutoSize = True
        Me.chkInBorder.Location = New System.Drawing.Point(12, 19)
        Me.chkInBorder.Name = "chkInBorder"
        Me.chkInBorder.Size = New System.Drawing.Size(91, 19)
        Me.chkInBorder.TabIndex = 0
        Me.chkInBorder.Text = "Draw border"
        Me.chkInBorder.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(52, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "px"
        '
        'butCancel
        '
        Me.butCancel.Location = New System.Drawing.Point(240, 200)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(94, 31)
        Me.butCancel.TabIndex = 11
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(140, 200)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(94, 31)
        Me.butOK.TabIndex = 10
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'lblStatusmessage
        '
        Me.lblStatusmessage.AutoSize = True
        Me.lblStatusmessage.Location = New System.Drawing.Point(4, 179)
        Me.lblStatusmessage.Name = "lblStatusmessage"
        Me.lblStatusmessage.Size = New System.Drawing.Size(0, 15)
        Me.lblStatusmessage.TabIndex = 9
        '
        'chkResize
        '
        Me.chkResize.AutoSize = True
        Me.chkResize.Location = New System.Drawing.Point(5, 41)
        Me.chkResize.Name = "chkResize"
        Me.chkResize.Size = New System.Drawing.Size(58, 19)
        Me.chkResize.TabIndex = 3
        Me.chkResize.Text = "Resize"
        Me.chkResize.UseVisualStyleBackColor = True
        '
        'nupdMaxWidth
        '
        Me.nupdMaxWidth.Enabled = False
        Me.nupdMaxWidth.Location = New System.Drawing.Point(83, 63)
        Me.nupdMaxWidth.Maximum = New Decimal(New Integer() {7680, 0, 0, 0})
        Me.nupdMaxWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupdMaxWidth.Name = "nupdMaxWidth"
        Me.nupdMaxWidth.Size = New System.Drawing.Size(58, 23)
        Me.nupdMaxWidth.TabIndex = 5
        Me.nupdMaxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nupdMaxWidth.Value = New Decimal(New Integer() {1024, 0, 0, 0})
        '
        'Export
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(356, 238)
        Me.ControlBox = False
        Me.Controls.Add(Me.nupdMaxWidth)
        Me.Controls.Add(Me.lblStatusmessage)
        Me.Controls.Add(Me.chkResize)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.butBrowse)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Export"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nupdOuterBorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nupdInnerBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupdMaxWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents butBrowse As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents butOuterBorderColor As Button
    Friend WithEvents chkOutBorder As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents butInBorderColor As Button
    Friend WithEvents chkInBorder As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents butCancel As Button
    Friend WithEvents butOK As Button
    Friend WithEvents lblStatusmessage As Label
    Friend WithEvents chkResize As CheckBox
    Friend WithEvents nupdOuterBorder As NumericUpDown
    Friend WithEvents nupdInnerBorder As NumericUpDown
    Friend WithEvents nupdMaxWidth As NumericUpDown
End Class
