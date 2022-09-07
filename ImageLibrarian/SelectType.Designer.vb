<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SelectType
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
        Me.chkJPEG = New System.Windows.Forms.CheckBox()
        Me.chkPNG = New System.Windows.Forms.CheckBox()
        Me.chkBMP = New System.Windows.Forms.CheckBox()
        Me.chkGIF = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.butOK = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCat = New System.Windows.Forms.ComboBox()
        Me.cboSubCat = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkSubfolders = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkJPEG
        '
        Me.chkJPEG.AutoSize = True
        Me.chkJPEG.Checked = True
        Me.chkJPEG.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkJPEG.Location = New System.Drawing.Point(6, 18)
        Me.chkJPEG.Name = "chkJPEG"
        Me.chkJPEG.Size = New System.Drawing.Size(51, 19)
        Me.chkJPEG.TabIndex = 0
        Me.chkJPEG.Text = "JPEG"
        Me.chkJPEG.UseVisualStyleBackColor = True
        '
        'chkPNG
        '
        Me.chkPNG.AutoSize = True
        Me.chkPNG.Location = New System.Drawing.Point(97, 18)
        Me.chkPNG.Name = "chkPNG"
        Me.chkPNG.Size = New System.Drawing.Size(50, 19)
        Me.chkPNG.TabIndex = 0
        Me.chkPNG.Text = "PNG"
        Me.chkPNG.UseVisualStyleBackColor = True
        '
        'chkBMP
        '
        Me.chkBMP.AutoSize = True
        Me.chkBMP.Location = New System.Drawing.Point(188, 18)
        Me.chkBMP.Name = "chkBMP"
        Me.chkBMP.Size = New System.Drawing.Size(51, 19)
        Me.chkBMP.TabIndex = 1
        Me.chkBMP.Text = "BMP"
        Me.chkBMP.UseVisualStyleBackColor = True
        '
        'chkGIF
        '
        Me.chkGIF.AutoSize = True
        Me.chkGIF.Location = New System.Drawing.Point(270, 18)
        Me.chkGIF.Name = "chkGIF"
        Me.chkGIF.Size = New System.Drawing.Size(43, 19)
        Me.chkGIF.TabIndex = 2
        Me.chkGIF.Text = "GIF"
        Me.chkGIF.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkGIF)
        Me.GroupBox1.Controls.Add(Me.chkBMP)
        Me.GroupBox1.Controls.Add(Me.chkPNG)
        Me.GroupBox1.Controls.Add(Me.chkJPEG)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 44)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select file types"
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(144, 129)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(94, 31)
        Me.butOK.TabIndex = 7
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Location = New System.Drawing.Point(244, 129)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(94, 31)
        Me.butCancel.TabIndex = 0
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Category"
        '
        'cboCat
        '
        Me.cboCat.FormattingEnabled = True
        Me.cboCat.Location = New System.Drawing.Point(93, 71)
        Me.cboCat.Name = "cboCat"
        Me.cboCat.Size = New System.Drawing.Size(245, 23)
        Me.cboCat.TabIndex = 3
        '
        'cboSubCat
        '
        Me.cboSubCat.FormattingEnabled = True
        Me.cboSubCat.Location = New System.Drawing.Point(93, 100)
        Me.cboSubCat.Name = "cboSubCat"
        Me.cboSubCat.Size = New System.Drawing.Size(245, 23)
        Me.cboSubCat.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sub category"
        '
        'chkSubfolders
        '
        Me.chkSubfolders.AutoSize = True
        Me.chkSubfolders.Location = New System.Drawing.Point(13, 136)
        Me.chkSubfolders.Name = "chkSubfolders"
        Me.chkSubfolders.Size = New System.Drawing.Size(85, 19)
        Me.chkSubfolders.TabIndex = 6
        Me.chkSubfolders.Text = "Sub folders"
        Me.chkSubfolders.UseVisualStyleBackColor = True
        '
        'SelectType
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(350, 167)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkSubfolders)
        Me.Controls.Add(Me.cboSubCat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "SelectType"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelectType"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkJPEG As CheckBox
    Friend WithEvents chkPNG As CheckBox
    Friend WithEvents chkBMP As CheckBox
    Friend WithEvents chkGIF As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents butOK As Button
    Friend WithEvents butCancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboCat As ComboBox
    Friend WithEvents cboSubCat As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkSubfolders As CheckBox
End Class
