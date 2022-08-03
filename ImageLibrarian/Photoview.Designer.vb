<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Photoview
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tlstpOpen = New System.Windows.Forms.ToolStripButton()
        Me.tlstpClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpUndo = New System.Windows.Forms.ToolStripButton()
        Me.tlstpRedo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpCrop = New System.Windows.Forms.ToolStripButton()
        Me.tlstpConfirmCrop = New System.Windows.Forms.ToolStripButton()
        Me.tlstpFlipHorizontal = New System.Windows.Forms.ToolStripButton()
        Me.tlstpFlipVertical = New System.Windows.Forms.ToolStripButton()
        Me.tlstpRotateimage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tlstpZoom = New System.Windows.Forms.ToolStripComboBox()
        Me.tlstpResetImage = New System.Windows.Forms.ToolStripButton()
        Me.tlstpFitToscreen = New System.Windows.Forms.ToolStripButton()
        Me.pnlPhotoContainerr = New System.Windows.Forms.Panel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpSaveas = New System.Windows.Forms.ToolStripButton()
        Me.tlstpSave = New System.Windows.Forms.ToolStripButton()
        Me.tlstpCopyImage = New System.Windows.Forms.ToolStripButton()
        Me.tlstpResizeimage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlstpOpen, Me.tlstpSave, Me.tlstpSaveas, Me.tlstpCopyImage, Me.tlstpClose, Me.ToolStripSeparator1, Me.tlstpUndo, Me.tlstpRedo, Me.ToolStripSeparator2, Me.tlstpResizeimage, Me.tlstpCrop, Me.tlstpConfirmCrop, Me.tlstpFlipHorizontal, Me.tlstpFlipVertical, Me.tlstpRotateimage, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.tlstpZoom, Me.tlstpFitToscreen, Me.ToolStripSeparator4, Me.tlstpResetImage})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1006, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tlstpOpen
        '
        Me.tlstpOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpOpen.Image = Global.VijaySridhara.Applications.My.Resources.Resources.open
        Me.tlstpOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpOpen.Name = "tlstpOpen"
        Me.tlstpOpen.Size = New System.Drawing.Size(28, 28)
        Me.tlstpOpen.Text = "Open image"
        '
        'tlstpClose
        '
        Me.tlstpClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpClose.Enabled = False
        Me.tlstpClose.Image = Global.VijaySridhara.Applications.My.Resources.Resources.close
        Me.tlstpClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpClose.Name = "tlstpClose"
        Me.tlstpClose.Size = New System.Drawing.Size(28, 28)
        Me.tlstpClose.Text = "Close image"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'tlstpUndo
        '
        Me.tlstpUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpUndo.Enabled = False
        Me.tlstpUndo.Image = Global.VijaySridhara.Applications.My.Resources.Resources.undo
        Me.tlstpUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpUndo.Name = "tlstpUndo"
        Me.tlstpUndo.Size = New System.Drawing.Size(28, 28)
        Me.tlstpUndo.Text = "ToolStripButton3"
        '
        'tlstpRedo
        '
        Me.tlstpRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpRedo.Enabled = False
        Me.tlstpRedo.Image = Global.VijaySridhara.Applications.My.Resources.Resources.redo
        Me.tlstpRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpRedo.Name = "tlstpRedo"
        Me.tlstpRedo.Size = New System.Drawing.Size(28, 28)
        Me.tlstpRedo.Text = "Redo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'tlstpCrop
        '
        Me.tlstpCrop.CheckOnClick = True
        Me.tlstpCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpCrop.Enabled = False
        Me.tlstpCrop.Image = Global.VijaySridhara.Applications.My.Resources.Resources.crop
        Me.tlstpCrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpCrop.Name = "tlstpCrop"
        Me.tlstpCrop.Size = New System.Drawing.Size(28, 28)
        Me.tlstpCrop.Text = "Crop image"
        '
        'tlstpConfirmCrop
        '
        Me.tlstpConfirmCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpConfirmCrop.Enabled = False
        Me.tlstpConfirmCrop.Image = Global.VijaySridhara.Applications.My.Resources.Resources.tick1
        Me.tlstpConfirmCrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpConfirmCrop.Name = "tlstpConfirmCrop"
        Me.tlstpConfirmCrop.Size = New System.Drawing.Size(28, 28)
        Me.tlstpConfirmCrop.Text = "Confirm crop"
        '
        'tlstpFlipHorizontal
        '
        Me.tlstpFlipHorizontal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpFlipHorizontal.Enabled = False
        Me.tlstpFlipHorizontal.Image = Global.VijaySridhara.Applications.My.Resources.Resources.fliphorizontal
        Me.tlstpFlipHorizontal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpFlipHorizontal.Name = "tlstpFlipHorizontal"
        Me.tlstpFlipHorizontal.Size = New System.Drawing.Size(28, 28)
        Me.tlstpFlipHorizontal.Text = "Flip horizontal"
        '
        'tlstpFlipVertical
        '
        Me.tlstpFlipVertical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpFlipVertical.Enabled = False
        Me.tlstpFlipVertical.Image = Global.VijaySridhara.Applications.My.Resources.Resources.flipvertical
        Me.tlstpFlipVertical.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpFlipVertical.Name = "tlstpFlipVertical"
        Me.tlstpFlipVertical.Size = New System.Drawing.Size(28, 28)
        Me.tlstpFlipVertical.Text = "Flip vertical"
        '
        'tlstpRotateimage
        '
        Me.tlstpRotateimage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpRotateimage.Enabled = False
        Me.tlstpRotateimage.Image = Global.VijaySridhara.Applications.My.Resources.Resources.rotate_clock
        Me.tlstpRotateimage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpRotateimage.Name = "tlstpRotateimage"
        Me.tlstpRotateimage.Size = New System.Drawing.Size(28, 28)
        Me.tlstpRotateimage.Text = "Rotate image by 90 degrees"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(66, 28)
        Me.ToolStripLabel1.Text = "Zoom level"
        '
        'tlstpZoom
        '
        Me.tlstpZoom.Enabled = False
        Me.tlstpZoom.Name = "tlstpZoom"
        Me.tlstpZoom.Size = New System.Drawing.Size(75, 31)
        Me.tlstpZoom.Text = "100"
        '
        'tlstpResetImage
        '
        Me.tlstpResetImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpResetImage.Enabled = False
        Me.tlstpResetImage.Image = Global.VijaySridhara.Applications.My.Resources.Resources.refresh
        Me.tlstpResetImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpResetImage.Name = "tlstpResetImage"
        Me.tlstpResetImage.Size = New System.Drawing.Size(28, 28)
        Me.tlstpResetImage.Text = "Reset image to original"
        '
        'tlstpFitToscreen
        '
        Me.tlstpFitToscreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpFitToscreen.Enabled = False
        Me.tlstpFitToscreen.Image = Global.VijaySridhara.Applications.My.Resources.Resources.fittoscreen
        Me.tlstpFitToscreen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpFitToscreen.Name = "tlstpFitToscreen"
        Me.tlstpFitToscreen.Size = New System.Drawing.Size(28, 28)
        Me.tlstpFitToscreen.Text = "Fit to screen"
        '
        'pnlPhotoContainerr
        '
        Me.pnlPhotoContainerr.AutoScroll = True
        Me.pnlPhotoContainerr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPhotoContainerr.Location = New System.Drawing.Point(0, 31)
        Me.pnlPhotoContainerr.Name = "pnlPhotoContainerr"
        Me.pnlPhotoContainerr.Size = New System.Drawing.Size(1006, 585)
        Me.pnlPhotoContainerr.TabIndex = 1
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'tlstpSaveas
        '
        Me.tlstpSaveas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpSaveas.Enabled = False
        Me.tlstpSaveas.Image = Global.VijaySridhara.Applications.My.Resources.Resources.saveas
        Me.tlstpSaveas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpSaveas.Name = "tlstpSaveas"
        Me.tlstpSaveas.Size = New System.Drawing.Size(28, 28)
        Me.tlstpSaveas.Text = "Save image as"
        '
        'tlstpSave
        '
        Me.tlstpSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpSave.Enabled = False
        Me.tlstpSave.Image = Global.VijaySridhara.Applications.My.Resources.Resources.save
        Me.tlstpSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpSave.Name = "tlstpSave"
        Me.tlstpSave.Size = New System.Drawing.Size(28, 28)
        Me.tlstpSave.Text = "Save to original location"
        '
        'tlstpCopyImage
        '
        Me.tlstpCopyImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpCopyImage.Enabled = False
        Me.tlstpCopyImage.Image = Global.VijaySridhara.Applications.My.Resources.Resources.copyimage
        Me.tlstpCopyImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpCopyImage.Name = "tlstpCopyImage"
        Me.tlstpCopyImage.Size = New System.Drawing.Size(28, 28)
        Me.tlstpCopyImage.Text = "Copy image to clipboard"
        '
        'tlstpResizeimage
        '
        Me.tlstpResizeimage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpResizeimage.Enabled = False
        Me.tlstpResizeimage.Image = Global.VijaySridhara.Applications.My.Resources.Resources.resize
        Me.tlstpResizeimage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpResizeimage.Name = "tlstpResizeimage"
        Me.tlstpResizeimage.Size = New System.Drawing.Size(28, 28)
        Me.tlstpResizeimage.Text = "Resize image"
        '
        'Photoview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1006, 616)
        Me.Controls.Add(Me.pnlPhotoContainerr)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "Photoview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Photoview"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlPhotoContainerr As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tlstpOpen As ToolStripButton
    Friend WithEvents tlstpClose As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tlstpUndo As ToolStripButton
    Friend WithEvents tlstpRedo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tlstpCrop As ToolStripButton
    Friend WithEvents tlstpConfirmCrop As ToolStripButton
    Friend WithEvents tlstpRotateimage As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tlstpZoom As ToolStripComboBox
    Friend WithEvents tlstpResetImage As ToolStripButton
    Friend WithEvents tlstpFlipHorizontal As ToolStripButton
    Friend WithEvents tlstpFlipVertical As ToolStripButton
    Friend WithEvents tlstpFitToscreen As ToolStripButton
    Friend WithEvents tlstpSave As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tlstpSaveas As ToolStripButton
    Friend WithEvents tlstpCopyImage As ToolStripButton
    Friend WithEvents tlstpResizeimage As ToolStripButton
End Class
