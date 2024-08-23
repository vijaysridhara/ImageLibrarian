<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        PictureBox1 = New PictureBox()
        lblProductname = New Label()
        lblVersion = New Label()
        lblCopyright = New Label()
        lblDescription = New Label()
        butCancel = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.piclib_128
        PictureBox1.Location = New Point(12, 23)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(127, 126)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' lblProductname
        ' 
        lblProductname.AutoSize = True
        lblProductname.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        lblProductname.Location = New Point(143, 32)
        lblProductname.Name = "lblProductname"
        lblProductname.Size = New Size(70, 25)
        lblProductname.TabIndex = 1
        lblProductname.Text = "Label1"
        ' 
        ' lblVersion
        ' 
        lblVersion.AutoSize = True
        lblVersion.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        lblVersion.Location = New Point(143, 57)
        lblVersion.Name = "lblVersion"
        lblVersion.Size = New Size(67, 25)
        lblVersion.TabIndex = 1
        lblVersion.Text = "Label1"
        ' 
        ' lblCopyright
        ' 
        lblCopyright.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        lblCopyright.Location = New Point(145, 93)
        lblCopyright.Name = "lblCopyright"
        lblCopyright.Size = New Size(263, 56)
        lblCopyright.TabIndex = 1
        lblCopyright.Text = "Label1"
        ' 
        ' lblDescription
        ' 
        lblDescription.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        lblDescription.Location = New Point(12, 164)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(395, 189)
        lblDescription.TabIndex = 1
        lblDescription.Text = "Label1"
        ' 
        ' butCancel
        ' 
        butCancel.Location = New Point(330, 365)
        butCancel.Name = "butCancel"
        butCancel.Size = New Size(77, 35)
        butCancel.TabIndex = 20
        butCancel.Text = "E&xit"
        butCancel.UseVisualStyleBackColor = True
        ' 
        ' About
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = butCancel
        ClientSize = New Size(420, 404)
        Controls.Add(butCancel)
        Controls.Add(lblDescription)
        Controls.Add(lblCopyright)
        Controls.Add(lblVersion)
        Controls.Add(lblProductname)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        KeyPreview = True
        Name = "About"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "About"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblProductname As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblCopyright As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents butCancel As Button
End Class
